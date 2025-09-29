using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.ViewModels;
using Project.Models;
using Project.Utilities.Enums;
using Project.Utilities;
using System.Data;
using Project.Helpers;
using System.Security.Claims;

namespace Project.Controllers
{
    namespace Project.Controllers
    {
        [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
        public class FridgesController : Controller
        {
            private readonly ApplicationDbContext _db;
            private readonly ILogger<FridgesController> _logger;

            public FridgesController(ApplicationDbContext db, ILogger<FridgesController> logger)
            {
                _db = db;
                _logger = logger;
            }

            // GET: Fridges
            public async Task<IActionResult> Index(string searchString, string statusFilter, string conditionFilter, string locationFilter, int page = 1, int pageSize = 10)
            {
                try
                {
                    var query = _db.Fridges
                        .Include(f => f.FridgeModel)
                        .Include(f => f.CurrentLocation)
                        .Where(f => f.IsActive);

                    // Apply search filter
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        searchString = searchString.ToLower();
                        query = query.Where(f =>
                            f.SerialNumber.ToLower().Contains(searchString) ||
                            f.FridgeModel.Manufacturer.ToLower().Contains(searchString) ||
                            f.FridgeModel.ModelName.ToLower().Contains(searchString) ||
                            f.FridgeModel.ModelCode.ToLower().Contains(searchString) ||
                            f.Supplier.ToLower().Contains(searchString)
                        );
                    }

                    // Apply status filter
                    if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                    {
                        if (Enum.TryParse<FridgeStatus>(statusFilter, out var status))
                        {
                            query = query.Where(f => f.Status == status);
                        }
                    }

                    // Apply condition filter
                    if (!string.IsNullOrEmpty(conditionFilter) && conditionFilter != "All")
                    {
                        if (Enum.TryParse<FridgeCondition>(conditionFilter, out var condition))
                        {
                            query = query.Where(f => f.Condition == condition);
                        }
                    }

                    // Apply location filter
                    if (!string.IsNullOrEmpty(locationFilter) && locationFilter != "All")
                    {
                        query = query.Where(f =>
                            f.CurrentLocation.City.Contains(locationFilter) ||
                            f.CurrentLocation.Province.Contains(locationFilter) ||
                            f.CurrentLocation.Suburb.Contains(locationFilter)
                        );
                    }

                    // Pagination
                    var totalCount = await query.CountAsync();
                    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                    page = Math.Max(1, Math.Min(page, totalPages));

                    var fridges = await query
                        .OrderBy(f => f.FridgeModel.Manufacturer)
                        .ThenBy(f => f.FridgeModel.ModelName)
                        .ThenBy(f => f.SerialNumber)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

                    var fridgeVMs = new List<FridgeVM>();
                    foreach (var fridge in fridges)
                    {
                        var fridgeVM = await MapToViewModelAsync(fridge);
                        fridgeVM.CalculateComputedProperties();
                        fridgeVMs.Add(fridgeVM);
                    }

                    await PopulateFilterDropdowns();

                    // ViewBag for filters and pagination
                    ViewBag.SearchString = searchString;
                    ViewBag.StatusFilter = statusFilter;
                    ViewBag.ConditionFilter = conditionFilter;
                    ViewBag.LocationFilter = locationFilter;
                    ViewBag.CurrentPage = page;
                    ViewBag.TotalPages = totalPages;
                    ViewBag.PageSize = pageSize;
                    ViewBag.TotalCount = totalCount;

                    return View(fridgeVMs);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error loading fridge index page with filters: Search={Search}, Status={Status}, Condition={Condition}, Location={Location}",
                        searchString, statusFilter, conditionFilter, locationFilter);
                    TempData["error"] = "An error occurred while loading fridges.";
                    return RedirectToAction("Index", "Home");
                }
            }

            // GET: Fridges/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                try
                {
                    if (id == null || id == 0)
                    {
                        TempData["error"] = "Fridge ID is required.";
                        return RedirectToAction(nameof(Index));
                    }

                    var fridge = await _db.Fridges
                        .Include(f => f.FridgeModel)
                        .Include(f => f.CurrentLocation)
                        .Include(f => f.MaintenanceRecords.OrderByDescending(mr => mr.ServiceDate).Take(5))
                        .Include(f => f.AllocationHistory.Where(a => a.IsActive).OrderByDescending(a => a.AllocationDate).Take(5))
                        .Include(f => f.FaultReports.OrderByDescending(fr => fr.ReportedDate).Take(5))
                        .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                    if (fridge == null)
                    {
                        TempData["error"] = "Fridge not found or has been deleted.";
                        return RedirectToAction(nameof(Index));
                    }

                    var fridgeVM = await MapToViewModelAsync(fridge);
                    fridgeVM.CalculateComputedProperties();

                    // Load additional statistics
                    await LoadFridgeStatistics(fridgeVM, fridge.Id);

                    return View(fridgeVM);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error loading fridge details for ID: {FridgeId}", id);
                    TempData["error"] = "An error occurred while loading fridge details.";
                    return RedirectToAction(nameof(Index));
                }
            }

            // GET: Fridges/Upsert
            public async Task<IActionResult> Upsert(int? id)
            {
                try
                {
                    FridgeVM fridgeVM = new();

                    if (id == null || id == 0)
                    {
                        // Create mode
                        ViewBag.Action = "Create New Fridge";
                        fridgeVM.Status = FridgeStatus.Available;
                        fridgeVM.Condition = FridgeCondition.New;
                        fridgeVM.PurchaseDate = DateTime.Today;
                    }
                    else
                    {
                        // Edit mode
                        ViewBag.Action = "Edit Fridge";
                        var fridge = await _db.Fridges
                            .Include(f => f.FridgeModel)
                            .Include(f => f.CurrentLocation)
                            .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                        if (fridge == null)
                        {
                            TempData["error"] = "Fridge not found or has been deleted.";
                            return RedirectToAction(nameof(Index));
                        }

                        fridgeVM = await MapToViewModelAsync(fridge);
                    }

                    await PopulateDropdowns(fridgeVM);
                    return View(fridgeVM);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error loading fridge upsert page for ID: {FridgeId}", id);
                    TempData["error"] = "An error occurred while loading the fridge form.";
                    return RedirectToAction(nameof(Index));
                }
            }

            // POST: Fridges/Upsert
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Upsert(FridgeVM fridgeVM)
            {
                try
                {
                    // Clean input data
                    fridgeVM.SerialNumber = fridgeVM.SerialNumber?.Trim().ToUpper();
                    fridgeVM.Supplier = fridgeVM.Supplier?.Trim();

                    if (!ModelState.IsValid)
                    {
                        await PopulateDropdowns(fridgeVM);
                        ViewBag.Action = fridgeVM.Id == 0 ? "Create New Fridge" : "Edit Fridge";
                        return View(fridgeVM);
                    }

                    if (fridgeVM.Id == 0)
                    {
                        // Create operation
                        var validationResult = await ValidateFridgeForCreation(fridgeVM);
                        if (!validationResult.IsValid)
                        {
                            ModelState.AddModelError("", validationResult.ErrorMessage);
                            await PopulateDropdowns(fridgeVM);
                            ViewBag.Action = "Create New Fridge";
                            return View(fridgeVM);
                        }

                        var fridge = new Fridge
                        {
                            SerialNumber = fridgeVM.SerialNumber,
                            FridgeModelId = fridgeVM.FridgeModelId,
                            LocationId = fridgeVM.LocationId,
                            Condition = fridgeVM.Condition,
                            Status = fridgeVM.Status,
                            PurchaseDate = fridgeVM.PurchaseDate,
                            PurchasePrice = fridgeVM.PurchasePrice,
                            Supplier = fridgeVM.Supplier,
                            WarrantyExpiryDate = fridgeVM.WarrantyExpiryDate,
                            LastServiceDate = fridgeVM.LastServiceDate,
                            NextServiceDue = await CalculateNextServiceDue(fridgeVM.LastServiceDate, fridgeVM.FridgeModelId),
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            ModifiedAt = DateTime.UtcNow,
                            CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System"
                        };

                        _db.Fridges.Add(fridge);
                        await _db.SaveChangesAsync();

                        _logger.LogInformation("Fridge created: {SerialNumber} by {User}", fridge.SerialNumber, User.Identity?.Name);
                        TempData["success"] = $"Fridge {fridge.SerialNumber} created successfully.";

                        return RedirectToAction(nameof(Details), new { id = fridge.Id });
                    }
                    else
                    {
                        // Update operation
                        var fridge = await _db.Fridges
                            .FirstOrDefaultAsync(f => f.Id == fridgeVM.Id && f.IsActive);

                        if (fridge == null)
                        {
                            TempData["error"] = "Fridge not found or has been deleted.";
                            return RedirectToAction(nameof(Index));
                        }

                        var validationResult = await ValidateFridgeForUpdate(fridgeVM, fridge);
                        if (!validationResult.IsValid)
                        {
                            ModelState.AddModelError("", validationResult.ErrorMessage);
                            await PopulateDropdowns(fridgeVM);
                            ViewBag.Action = "Edit Fridge";
                            return View(fridgeVM);
                        }

                        // Update fridge properties
                        fridge.SerialNumber = fridgeVM.SerialNumber;
                        fridge.FridgeModelId = fridgeVM.FridgeModelId;
                        fridge.LocationId = fridgeVM.LocationId;
                        fridge.Condition = fridgeVM.Condition;
                        fridge.Status = fridgeVM.Status;
                        fridge.PurchaseDate = fridgeVM.PurchaseDate;
                        fridge.PurchasePrice = fridgeVM.PurchasePrice;
                        fridge.Supplier = fridgeVM.Supplier;
                        fridge.WarrantyExpiryDate = fridgeVM.WarrantyExpiryDate;
                        fridge.LastServiceDate = fridgeVM.LastServiceDate;
                        fridge.NextServiceDue = await CalculateNextServiceDue(fridgeVM.LastServiceDate, fridgeVM.FridgeModelId);
                        fridge.ModifiedAt = DateTime.UtcNow;
                        fridge.ModifiedBy = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

                        _db.Fridges.Update(fridge);
                        await _db.SaveChangesAsync();

                        _logger.LogInformation("Fridge updated: {SerialNumber} by {User}", fridge.SerialNumber, User.Identity?.Name);
                        TempData["success"] = $"Fridge {fridge.SerialNumber} updated successfully.";

                        return RedirectToAction(nameof(Details), new { id = fridge.Id });
                    }
                }
                catch (DbUpdateException dbEx)
                {
                    _logger.LogError(dbEx, "Database error while saving fridge");
                    ModelState.AddModelError("", "A database error occurred while saving the fridge. Please try again.");
                    await PopulateDropdowns(fridgeVM);
                    ViewBag.Action = fridgeVM.Id == 0 ? "Create New Fridge" : "Edit Fridge";
                    return View(fridgeVM);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving fridge");
                    TempData["error"] = "An error occurred while saving the fridge.";
                    return RedirectToAction(nameof(Index));
                }
            }

            // POST: Fridges/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = SD.AdminRole)]
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    var fridge = await _db.Fridges
                        .Include(f => f.FridgeModel)
                        .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                    if (fridge == null)
                    {
                        TempData["error"] = "Fridge not found or already deleted.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Check if fridge is currently allocated
                    var activeAllocation = await _db.FridgeAllocations
                        .AnyAsync(a => a.FridgeId == id && a.IsActive && a.Status == AllocationStatus.Active);

                    if (activeAllocation)
                    {
                        TempData["error"] = "Cannot delete fridge that is currently allocated to a customer.";
                        return RedirectToAction(nameof(Details), new { id });
                    }

                    // Soft delete
                    fridge.IsActive = false;
                    fridge.Status = FridgeStatus.Scrapped;
                    fridge.ModifiedAt = DateTime.UtcNow;
                    fridge.ModifiedBy = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

                    _db.Fridges.Update(fridge);
                    await _db.SaveChangesAsync();

                    _logger.LogInformation("Fridge deleted: {SerialNumber} by {User}", fridge.SerialNumber, User.Identity?.Name);
                    TempData["success"] = $"Fridge {fridge.SerialNumber} deleted successfully.";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting fridge with ID: {FridgeId}", id);
                    TempData["error"] = "An error occurred while deleting the fridge.";
                    return RedirectToAction(nameof(Details), new { id });
                }
            }

            // POST: Fridges/Scrap/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Scrap(int id, string scrapReason)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(scrapReason))
                    {
                        TempData["error"] = "Scrap reason is required.";
                        return RedirectToAction(nameof(Details), new { id });
                    }

                    var fridge = await _db.Fridges
                        .Include(f => f.FridgeModel)
                        .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                    if (fridge == null)
                    {
                        TempData["error"] = "Fridge not found or already deleted.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Check if fridge is currently allocated
                    var activeAllocation = await _db.FridgeAllocations
                        .AnyAsync(a => a.FridgeId == id && a.IsActive && a.Status == AllocationStatus.Active);

                    if (activeAllocation)
                    {
                        TempData["error"] = "Cannot scrap fridge that is currently allocated to a customer.";
                        return RedirectToAction(nameof(Details), new { id });
                    }

                    // Mark as scrapped (soft delete)
                    fridge.Condition = FridgeCondition.Poor;
                    fridge.Status = FridgeStatus.Scrapped;
                    fridge.IsActive = false;
                    fridge.ModifiedAt = DateTime.UtcNow;
                    fridge.ModifiedBy = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

                    // TODO: Consider creating a ScrapRecord table to store scrap reasons
                    _logger.LogInformation("Fridge scrapped: {SerialNumber} by {User}. Reason: {ScrapReason}",
                        fridge.SerialNumber, User.Identity?.Name, scrapReason);

                    _db.Fridges.Update(fridge);
                    await _db.SaveChangesAsync();

                    TempData["success"] = $"Fridge {fridge.SerialNumber} has been scrapped successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error scrapping fridge with ID: {FridgeId}", id);
                    TempData["error"] = "An error occurred while scrapping the fridge.";
                    return RedirectToAction(nameof(Details), new { id });
                }
            }

            // AJAX: Check if serial number exists
            [AcceptVerbs("GET", "POST")]
            public async Task<JsonResult> VerifySerialNumber(string serialNumber, int id = 0)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(serialNumber))
                    {
                        return Json(new { isValid = false, message = "Serial number is required." });
                    }

                    serialNumber = serialNumber.Trim().ToUpper();
                    var exists = await _db.Fridges
                        .AnyAsync(f => f.SerialNumber == serialNumber && f.Id != id && f.IsActive);

                    return Json(new
                    {
                        isValid = !exists,
                        message = exists ? "A fridge with this serial number already exists." : "Serial number is available."
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error verifying serial number: {SerialNumber}", serialNumber);
                    return Json(new { isValid = false, message = "Error verifying serial number." });
                }
            }

            // AJAX: Get fridge model details
            [HttpGet]
            public async Task<JsonResult> GetFridgeModelDetails(int modelId)
            {
                try
                {
                    var model = await _db.FridgeModels
                        .Where(fm => fm.Id == modelId && fm.IsActive)
                        .Select(fm => new
                        {
                            fm.Manufacturer,
                            fm.ModelName,
                            fm.ModelCode,
                            fm.ServiceIntervalMonths,
                            fm.MonthlyRentalPrice,
                            fm.WarrantyPeriodMonths
                        })
                        .FirstOrDefaultAsync();

                    if (model == null)
                    {
                        return Json(new { error = "Fridge model not found." });
                    }

                    return Json(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error getting fridge model details for ID: {ModelId}", modelId);
                    return Json(new { error = "Error retrieving fridge model details." });
                }
            }

            #region Private Methods

            private async Task<FridgeVM> MapToViewModelAsync(Fridge fridge)
            {
                return new FridgeVM
                {
                    Id = fridge.Id,
                    SerialNumber = fridge.SerialNumber,
                    FridgeModelId = fridge.FridgeModelId,
                    LocationId = fridge.LocationId,
                    Condition = fridge.Condition,
                    Status = fridge.Status,
                    PurchaseDate = fridge.PurchaseDate,
                    PurchasePrice = fridge.PurchasePrice,
                    Supplier = fridge.Supplier,
                    WarrantyExpiryDate = fridge.WarrantyExpiryDate,
                    LastServiceDate = fridge.LastServiceDate,
                    NextServiceDue = fridge.NextServiceDue,
                    TotalServiceCount = fridge.TotalServiceCount,
                    IsActive = fridge.IsActive,
                    FridgeModelDetails = fridge.FridgeModel != null ? new FridgeModelVM
                    {
                        Manufacturer = fridge.FridgeModel.Manufacturer,
                        ModelName = fridge.FridgeModel.ModelName,
                        ModelCode = fridge.FridgeModel.ModelCode,
                        ServiceIntervalMonths = fridge.FridgeModel.ServiceIntervalMonths,
                        WarrantyPeriodMonths = fridge.FridgeModel.WarrantyPeriodMonths
                    } : null,
                    LocationDetails = fridge.CurrentLocation != null ? new LocationVM
                    {
                        Suburb = fridge.CurrentLocation.Suburb,
                        City = fridge.CurrentLocation.City,
                        Province = fridge.CurrentLocation.Province,
                        AddressLine1 = fridge.CurrentLocation.AddressLine1
                    } : null
                };
            }

            private async Task PopulateDropdowns(FridgeVM fridgeVM)
            {
                fridgeVM.FridgeModelList = await _db.FridgeModels
                    .Where(fm => fm.IsActive && !fm.IsScrapped)
                    .OrderBy(fm => fm.Manufacturer)
                    .ThenBy(fm => fm.ModelName)
                    .Select(fm => new SelectListItem
                    {
                        Value = fm.Id.ToString(),
                        Text = $"{fm.Manufacturer} {fm.ModelName} ({fm.ModelCode})"
                    })
                    .ToListAsync();

                fridgeVM.LocationList = await _db.Locations
                    .Where(l => l.IsActive)
                    .OrderBy(l => l.Province)
                    .ThenBy(l => l.City)
                    .ThenBy(l => l.Suburb)
                    .Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = $"{l.Suburb}, {l.City}, {l.Province}"
                    })
                    .ToListAsync();

                fridgeVM.ConditionList = Enum.GetValues<FridgeCondition>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.GetDisplayName()
                    })
                    .ToList();

                fridgeVM.StatusList = Enum.GetValues<FridgeStatus>()
                    .Where(s => s != FridgeStatus.Scrapped) // Exclude scrapped status from dropdown
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.GetDisplayName()
                    })
                    .ToList();

                // Get distinct suppliers for dropdown
                fridgeVM.SupplierList = await _db.Fridges
                    .Where(f => f.Supplier != null && f.IsActive)
                    .Select(f => f.Supplier)
                    .Distinct()
                    .OrderBy(s => s)
                    .Select(s => new SelectListItem
                    {
                        Value = s,
                        Text = s
                    })
                    .ToListAsync();
            }

            private async Task PopulateFilterDropdowns()
            {
                ViewBag.StatusList = await GetStatusSelectListAsync();
                ViewBag.ConditionList = await GetConditionSelectListAsync();
                ViewBag.LocationList = await GetLocationSelectListAsync();
            }

            private async Task<IEnumerable<SelectListItem>> GetStatusSelectListAsync()
            {
                var items = Enum.GetValues<FridgeStatus>()
                    .Select(s => new SelectListItem
                    {
                        Value = s.ToString(),
                        Text = s.GetDisplayName()
                    })
                    .ToList();

                items.Insert(0, new SelectListItem { Value = "All", Text = "All Statuses" });
                return items;
            }

            private async Task<IEnumerable<SelectListItem>> GetConditionSelectListAsync()
            {
                var items = Enum.GetValues<FridgeCondition>()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ToString(),
                        Text = c.GetDisplayName()
                    })
                    .ToList();

                items.Insert(0, new SelectListItem { Value = "All", Text = "All Conditions" });
                return items;
            }

            private async Task<IEnumerable<SelectListItem>> GetLocationSelectListAsync()
            {
                var locations = await _db.Locations
                    .Where(l => l.IsActive)
                    .OrderBy(l => l.Province)
                    .ThenBy(l => l.City)
                    .Select(l => new SelectListItem
                    {
                        Value = l.City,
                        Text = $"{l.City}, {l.Province}"
                    })
                    .Distinct()
                    .ToListAsync();

                locations.Insert(0, new SelectListItem { Value = "All", Text = "All Locations" });
                return locations;
            }

            private async Task<ValidationResult> ValidateFridgeForCreation(FridgeVM fridgeVM)
            {
                // Check serial number uniqueness
                if (await _db.Fridges.AnyAsync(f => f.SerialNumber == fridgeVM.SerialNumber && f.IsActive))
                {
                    return ValidationResult.Error("A fridge with this serial number already exists.");
                }

                // Validate fridge model exists and is active
                var fridgeModel = await _db.FridgeModels
                    .FirstOrDefaultAsync(fm => fm.Id == fridgeVM.FridgeModelId && fm.IsActive && !fm.IsScrapped);

                if (fridgeModel == null)
                {
                    return ValidationResult.Error("Selected fridge model is not available.");
                }

                // Validate location exists
                var location = await _db.Locations
                    .FirstOrDefaultAsync(l => l.Id == fridgeVM.LocationId && l.IsActive);

                if (location == null)
                {
                    return ValidationResult.Error("Selected location is not available.");
                }

                return ValidationResult.Success;
            }

            private async Task<ValidationResult> ValidateFridgeForUpdate(FridgeVM fridgeVM, Fridge existingFridge)
            {
                // Check serial number uniqueness (excluding current fridge)
                if (await _db.Fridges.AnyAsync(f => f.SerialNumber == fridgeVM.SerialNumber && f.Id != existingFridge.Id && f.IsActive))
                {
                    return  ValidationResult.Error("A fridge with this serial number already exists.");
                }

                return ValidationResult.Success;
            }

            private async Task<DateTime?> CalculateNextServiceDue(DateTime? lastServiceDate, int fridgeModelId)
            {
                if (!lastServiceDate.HasValue) return null;

                var fridgeModel = await _db.FridgeModels.FindAsync(fridgeModelId);
                return lastServiceDate.Value.AddMonths(fridgeModel?.ServiceIntervalMonths ?? 6);
            }

            private async Task LoadFridgeStatistics(FridgeVM fridgeVM, int fridgeId)
            {
                fridgeVM.AllocationHistoryCount = await _db.FridgeAllocations
                    .CountAsync(a => a.FridgeId == fridgeId);

                fridgeVM.MaintenanceHistoryCount = await _db.MaintenanceRecords
                    .CountAsync(mr => mr.FridgeId == fridgeId);

                fridgeVM.FaultReportCount = await _db.FaultRecords
                    .CountAsync(fr => fr.FridgeId == fridgeId);
            }

            #endregion
        }

        // Helper class for validation results
        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; }

            public ValidationResult(bool isValid, string errorMessage = "")
            {
                IsValid = isValid;
                ErrorMessage = errorMessage;
            }

            public static ValidationResult Success => new ValidationResult(true);
            public static ValidationResult Error(string message) => new ValidationResult(false, message);
        }
    }
}