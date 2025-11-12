using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ClosedXML.Excel;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Project.Controllers
{
    [Authorize]
    public class ReplacementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ReplacementController> _logger;

        public ReplacementController(ApplicationDbContext db, ILogger<ReplacementController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // ===================================================================
        // TECHNICIAN: REQUEST REPLACEMENT
        // ===================================================================
        [Authorize(Roles = SD.FaultTechnician)]
        public async Task<IActionResult> RequestReplacement(int visitId)
        {
            try
            {
                var visit = await _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                        .ThenInclude(rh => rh.Customer!.ApplicationUser)
                    .Include(v => v.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges!)
                        .ThenInclude(rf => rf.CustomerFridges!)
                        .ThenInclude(cf => cf.FridgeInStock)
                    .Include(v => v.FaultTechnicians)
                    .FirstOrDefaultAsync(v => v.VisitId == visitId);

                if (visit == null)
                {
                    TempData[SD.Error] = "Visit record not found";
                    return RedirectToAction("Index", "FaultTechnician");
                }

                var customerFridge = visit.RequestHeader?.RequestFridges?
                    .FirstOrDefault()?.CustomerFridges?.FirstOrDefault();

                if (customerFridge?.FridgeInStock == null)
                {
                    TempData[SD.Error] = "Customer fridge information not found";
                    return RedirectToAction("Index", "FaultTechnician");
                }

                // Check if fridge is already marked as scrapped
                var existingFault = visit.FaultTechnicians.FirstOrDefault();
                if (existingFault?.IsScrapped == true)
                {
                    TempData[SD.Error] = "This fridge has already been scrapped and replacement processed";
                    return RedirectToAction("Index", "FaultTechnician");
                }

                var viewModel = new FridgeReplacementViewModel
                {
                    VisitId = visitId,
                    CustomerID = visit.RequestHeader?.CustomerID ?? 0,
                    CustomerName = $"{visit.RequestHeader?.Customer?.ApplicationUser?.FirstName} {visit.RequestHeader?.Customer?.ApplicationUser?.LastName}",
                    OldFridgeNo = customerFridge.FridgeInStock.FridgeNo ?? "Unknown",
                    FridgeModel = visit.RequestHeader?.RequestFridges?.FirstOrDefault()?.Fridge?.Model ?? "Unknown Model",
                    ReplacementDate = DateTime.Now,
                    CustomerPhone = visit.RequestHeader?.Customer?.ApplicationUser?.PhoneNumber ?? "N/A",
                    CustomerEmail = visit.RequestHeader?.Customer?.ApplicationUser?.Email ?? "N/A"
                };

                ViewBag.ReplacementReasons = await GetReplacementReasonsAsync();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement request form for visit {VisitId}", visitId);
                TempData[SD.Error] = "An error occurred while loading the replacement request form";
                return RedirectToAction("Index", "FaultTechnician");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.FaultTechnician)]
        public async Task<IActionResult> RequestReplacement(FridgeReplacementViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReplacementReasons = await GetReplacementReasonsAsync();
                return View(viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _db.AppUser.FindAsync(userId);

            try
            {
                var visit = await _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .Include(v => v.FaultTechnicians)
                    .FirstOrDefaultAsync(v => v.VisitId == viewModel.VisitId);

                if (visit == null)
                {
                    TempData[SD.Error] = "Visit record not found";
                    return RedirectToAction("Index", "FaultTechnician");
                }

                // Check for existing pending replacement
                var existingReplacement = await _db.tblFridgeReplacements
                    .FirstOrDefaultAsync(fr => fr.VisitId == viewModel.VisitId &&
                        (fr.ReplacementStatus == SD.Pending || fr.ReplacementStatus == SD.Approved));

                if (existingReplacement != null)
                {
                    TempData[SD.Error] = "A replacement request already exists for this visit";
                    return RedirectToAction("ReplacementHistory");
                }

                await using var transaction = await _db.Database.BeginTransactionAsync();

                try
                {
                    // Create replacement request
                    var replacementRequest = new FridgeReplacement
                    {
                        VisitId = viewModel.VisitId,
                        CustomerID = viewModel.CustomerID,
                        OldFridgeNo = viewModel.OldFridgeNo,
                        ReasonForReplacement = viewModel.ReasonForReplacement,
                        AdditionalNotes = viewModel.AdditionalNotes,
                        ReplacementDate = viewModel.ReplacementDate,
                        RequestDate = DateTime.Now,
                        ReplacementStatus = SD.Pending,
                        ApplicationUserId = userId,
                        TechnicianNotes = viewModel.TechnicianNotes
                    };

                    _db.tblFridgeReplacements.Add(replacementRequest);
                    await _db.SaveChangesAsync();

                    // Update fault status to scrapped
                    var fault = visit.FaultTechnicians.FirstOrDefault();
                    if (fault != null)
                    {
                        fault.RepairStatus = "Scrapped";
                        fault.IsScrapped = true;
                        fault.ScrappedDate = DateTime.Now;
                        fault.ReplacementRequestId = replacementRequest.FridgeReplacementId;
                        _db.tblFaultTechnicians.Update(fault);
                    }

                    // Mark old fridge as unavailable and pending scrapping
                    var oldFridge = await _db.tblFridgeInStocks
                        .FirstOrDefaultAsync(f => f.FridgeNo == viewModel.OldFridgeNo);

                    if (oldFridge != null)
                    {
                        oldFridge.IsAvailable = false;
                        oldFridge.Status = "Pending Scrapping";
                        _db.tblFridgeInStocks.Update(oldFridge);
                    }

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();

                    // Log the action
                    _logger.LogInformation("Replacement request created by technician {Technician} for fridge {FridgeNo}",
                        currentUser?.UserName, viewModel.OldFridgeNo);

                    TempData[SD.Success] = "Fridge replacement request submitted successfully! The old fridge has been marked for scrapping.";
                    return RedirectToAction("ReplacementHistory");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Transaction error while creating replacement request");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting replacement request by user {UserId}", userId);
                TempData[SD.Error] = $"Error submitting replacement request: {ex.Message}";
                ViewBag.ReplacementReasons = await GetReplacementReasonsAsync();
                return View(viewModel);
            }
        }

        // ===================================================================
        // CUSTOMER: VIEW REPLACEMENT REQUESTS
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> MyReplacements()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to view replacement requests";
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var replacements = await _db.tblFridgeReplacements
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges!)
                        .ThenInclude(rf => rf.Fridge)
                    .Include(fr => fr.NewFridgeInStock)
                        .ThenInclude(nf => nf.Fridge)
                    .Include(fr => fr.ApplicationUser)
                    .Where(fr => fr.CustomerID == customerId)
                    .OrderByDescending(fr => fr.RequestDate)
                    .ToListAsync();

                return View(replacements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement requests for customer {CustomerId}", customerId);
                TempData[SD.Error] = "An error occurred while loading your replacement requests";
                return View(new List<FridgeReplacement>());
            }
        }

        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> ReplacementDetails(int id)
        {
            var customerId = GetCurrentCustomerId();

            try
            {
                var replacement = await _db.tblFridgeReplacements
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges!)
                        .ThenInclude(rf => rf.Fridge)
                    .Include(fr => fr.NewFridgeInStock)
                        .ThenInclude(nf => nf.Fridge)
                    .Include(fr => fr.ApplicationUser)
                    .FirstOrDefaultAsync(fr => fr.FridgeReplacementId == id && fr.CustomerID == customerId);

                if (replacement == null)
                {
                    TempData[SD.Error] = "Replacement request not found";
                    return RedirectToAction("MyReplacements");
                }

                return View(replacement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement details {ReplacementId} for customer {CustomerId}", id, customerId);
                TempData[SD.Error] = "An error occurred while loading replacement details";
                return RedirectToAction("MyReplacements");
            }
        }

        // ===================================================================
        // TECHNICIAN: VIEW REPLACEMENT HISTORY
        // ===================================================================
        [Authorize(Roles = SD.FaultTechnician)]
        public async Task<IActionResult> ReplacementHistory()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var replacements = await _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                    .Include(fr => fr.NewFridgeInStock)
                        .ThenInclude(nf => nf.Fridge)
                    .Where(fr => fr.ApplicationUserId == userId)
                    .OrderByDescending(fr => fr.RequestDate)
                    .ToListAsync();

                return View(replacements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement history for technician {UserId}", userId);
                TempData[SD.Error] = "An error occurred while loading replacement history";
                return View(new List<FridgeReplacement>());
            }
        }

        // ===================================================================
        // CUSTOMER SUPPORT: MANAGE REPLACEMENTS
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> ManageReplacements(string statusFilter = "all", string searchString = "")
        {
            try
            {
                var query = _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.ApplicationUser)
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                    .Include(fr => fr.NewFridgeInStock)
                        .ThenInclude(nf => nf.Fridge)
                    .AsQueryable();

                // Apply status filter
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
                {
                    query = query.Where(fr => fr.ReplacementStatus == statusFilter);
                }

                // Apply search filter
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(fr =>
                        fr.OldFridgeNo.Contains(searchString) ||
                        (fr.Customer != null && fr.Customer.ApplicationUser != null &&
                         (fr.Customer.ApplicationUser.FirstName.Contains(searchString) ||
                          fr.Customer.ApplicationUser.LastName.Contains(searchString))) ||
                        fr.ReasonForReplacement.Contains(searchString));
                }

                var replacements = await query
                    .OrderByDescending(fr => fr.RequestDate)
                    .ToListAsync();

                ViewBag.StatusFilter = statusFilter;
                ViewBag.SearchString = searchString;
                ViewBag.PendingCount = await _db.tblFridgeReplacements.CountAsync(fr => fr.ReplacementStatus == SD.Pending);
                ViewBag.ApprovedCount = await _db.tblFridgeReplacements.CountAsync(fr => fr.ReplacementStatus == SD.Approved);
                ViewBag.RejectedCount = await _db.tblFridgeReplacements.CountAsync(fr => fr.ReplacementStatus == SD.Rejected);

                return View(replacements);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement management view");
                TempData[SD.Error] = "An error occurred while loading replacement requests";
                return View(new List<FridgeReplacement>());
            }
        }

        // GET replacement details for modal (AJAX)
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> GetReplacementDetails(int id)
        {
            try
            {
                var replacement = await _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.ApplicationUser)
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                    .Include(fr => fr.NewFridgeInStock)
                        .ThenInclude(nf => nf.Fridge)
                    .FirstOrDefaultAsync(fr => fr.FridgeReplacementId == id);

                if (replacement == null)
                {
                    return NotFound();
                }

                return PartialView("_ReplacementDetailsPartial", replacement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading replacement details for modal {ReplacementId}", id);
                return StatusCode(500, "Error loading replacement details");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> ApproveReplacement(int id, string? technicianNotes = null)
        {
            try
            {
                var replacement = await _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                    .Include(fr => fr.ApplicationUser)
                    .Include(fr => fr.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                    .FirstOrDefaultAsync(fr => fr.FridgeReplacementId == id);

                if (replacement == null)
                {
                    TempData[SD.Error] = "Replacement request not found";
                    return RedirectToAction("ManageReplacements");
                }

                if (replacement.ReplacementStatus != SD.Pending)
                {
                    TempData[SD.Error] = "This replacement request has already been processed";
                    return RedirectToAction("ManageReplacements");
                }

                await using var transaction = await _db.Database.BeginTransactionAsync();

                try
                {
                    // Find an available fridge of the same model
                    var availableFridge = await _db.tblFridgeInStocks
                        .Include(fis => fis.Fridge)
                        .FirstOrDefaultAsync(fis => fis.IsAvailable && fis.Status == "Available");

                    if (availableFridge == null)
                    {
                        TempData[SD.Error] = "No available fridges in stock";
                        return RedirectToAction("ManageReplacements");
                    }

                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
                    var approvedByName = currentUser != null ?
                        $"{currentUser.FirstName} {currentUser.LastName}" :
                        User.Identity?.Name ?? "System";

                    var technicianName = replacement.ApplicationUser != null ?
                        $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                        "Technician";

                    // Update replacement status
                    replacement.ReplacementStatus = SD.Approved;
                    replacement.NewFridgeInStockId = availableFridge.FridgeInStockId;
                    replacement.ActionDate = DateTime.Now;
                    replacement.ActionBy = technicianName;
                    replacement.ApprovedBy = approvedByName;
                    replacement.TechnicianNotes = technicianNotes;

                    // Mark the available fridge as allocated
                    availableFridge.IsAvailable = false;
                    availableFridge.Status = "Allocated";

                    // Process old fridge scrapping
                    var oldFridge = await _db.tblFridgeInStocks
                        .FirstOrDefaultAsync(f => f.FridgeNo == replacement.OldFridgeNo);

                    if (oldFridge != null)
                    {
                        oldFridge.Status = "Scrapped";
                        oldFridge.IsAvailable = false;
                        replacement.IsScrapped = true;
                        replacement.ScrappedDate = DateTime.Now;
                        replacement.ScrappedBy = approvedByName;
                        replacement.ScrappingReason = $"Replaced due to: {replacement.ReasonForReplacement}";
                    }

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation("Replacement request {ReplacementId} approved by {ApprovedBy}", id, approvedByName);

                    TempData[SD.Success] = $"Replacement approved successfully! New fridge allocated: {availableFridge.FridgeNo}";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Transaction error while approving replacement {ReplacementId}", id);
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving replacement request {ReplacementId}", id);
                TempData[SD.Error] = $"Error approving replacement: {ex.Message}";
            }

            return RedirectToAction("ManageReplacements");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> RejectReplacement(int id, string declineReason)
        {
            if (string.IsNullOrWhiteSpace(declineReason))
            {
                TempData[SD.Error] = "Please provide a reason for declining the replacement request";
                return RedirectToAction("ManageReplacements");
            }

            try
            {
                var replacement = await _db.tblFridgeReplacements
                    .Include(fr => fr.ApplicationUser)
                    .FirstOrDefaultAsync(fr => fr.FridgeReplacementId == id);

                if (replacement == null)
                {
                    TempData[SD.Error] = "Replacement request not found";
                    return RedirectToAction("ManageReplacements");
                }

                if (replacement.ReplacementStatus != SD.Pending)
                {
                    TempData[SD.Error] = "This replacement request has already been processed";
                    return RedirectToAction("ManageReplacements");
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var currentUser = await _db.AppUser.FirstOrDefaultAsync(u => u.Id == userId);
                var rejectedByName = currentUser != null ?
                    $"{currentUser.FirstName} {currentUser.LastName}" :
                    User.Identity?.Name ?? "System";

                var technicianName = replacement.ApplicationUser != null ?
                    $"{replacement.ApplicationUser.FirstName} {replacement.ApplicationUser.LastName}" :
                    "Technician";

                replacement.ReplacementStatus = SD.Rejected;
                replacement.DeclineReason = declineReason;
                replacement.ActionDate = DateTime.Now;
                replacement.ActionBy = technicianName;
                replacement.ApprovedBy = rejectedByName;

                // Reactivate old fridge if it was marked for scrapping
                var oldFridge = await _db.tblFridgeInStocks
                    .FirstOrDefaultAsync(f => f.FridgeNo == replacement.OldFridgeNo);

                if (oldFridge?.Status == "Pending Scrapping")
                {
                    oldFridge.Status = "Available";
                    oldFridge.IsAvailable = true;
                }

                await _db.SaveChangesAsync();

                _logger.LogInformation("Replacement request {ReplacementId} rejected by {RejectedBy}", id, rejectedByName);

                TempData[SD.Success] = "Replacement request rejected successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting replacement request {ReplacementId}", id);
                TempData[SD.Error] = $"Error rejecting replacement: {ex.Message}";
            }

            return RedirectToAction("ManageReplacements");
        }

        // ===================================================================
        // STOCK CONTROLLER: VIEW SCRAPPED FRIDGES
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole},{SD.StockController}")]
        public async Task<IActionResult> ScrappedFridges(string searchString = "", string scrappedByFilter = "")
        {
            try
            {
                var query = _db.tblFridgeReplacements
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.ApplicationUser)
                    .Include(fr => fr.NewFridgeInStock)
                    .Where(fr => fr.IsScrapped)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(fr =>
                        fr.OldFridgeNo.Contains(searchString) ||
                        (fr.Customer != null && fr.Customer.ApplicationUser != null &&
                         (fr.Customer.ApplicationUser.FirstName.Contains(searchString) ||
                          fr.Customer.ApplicationUser.LastName.Contains(searchString))));
                }

                if (!string.IsNullOrEmpty(scrappedByFilter))
                {
                    query = query.Where(fr => fr.ScrappedBy != null && fr.ScrappedBy.Contains(scrappedByFilter));
                }

                var scrappedFridges = await query
                    .OrderByDescending(fr => fr.ScrappedDate)
                    .ToListAsync();

                ViewBag.SearchString = searchString;
                ViewBag.ScrappedByFilter = scrappedByFilter;

                return View(scrappedFridges);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading scrapped fridges");
                TempData[SD.Error] = "An error occurred while loading scrapped fridges";
                return View(new List<FridgeReplacement>());
            }
        }

        // ===================================================================
        // PRIVATE HELPER METHODS
        // ===================================================================
        private async Task<List<SelectListItem>> GetReplacementReasonsAsync()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
                new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
                new SelectListItem { Text = "Old Age", Value = "Old Age" },
                new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
                new SelectListItem { Text = "Safety Concerns", Value = "Safety Concerns" },
                new SelectListItem { Text = "Other", Value = "Other" }
            };
        }

        private int GetCurrentCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return 0;

            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
            return customer?.CustomerID ?? 0;
        }
    }
}