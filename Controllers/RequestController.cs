using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Project.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RequestController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // ====================== SHARED ACTIONS ======================

        // LIST REQUESTS (Customer sees own, Support sees all)
        public async Task<IActionResult> Index(string statusFilter = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isSupport = User.IsInRole(SD.CustomerSupport) || User.IsInRole(SD.AdminRole);

            IQueryable<RequestHeader> query = _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .Include(r => r.Employee);

            if (!isSupport)
            {
                query = query.Where(r => r.Customer.ApplicationUserId == userId);
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(r => r.Status == statusFilter);
            }

            var requests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            ViewBag.IsSupport = isSupport;
            ViewBag.SelectedStatus = statusFilter;

            // For support dashboard summary
            if (isSupport)
            {
                ViewBag.TotalPending = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Pending);
                ViewBag.TotalApproved = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Approved);
                ViewBag.TotalRejected = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Rejected);
                ViewBag.TotalRelaunched = await _db.tblRequestHeaders.CountAsync(r => r.IsRelaunched);
            }

            return View(requests);
        }

        // VIEW REQUEST DETAILS (With decline reason if applicable)
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isSupport = User.IsInRole(SD.CustomerSupport) || User.IsInRole(SD.AdminRole);

            var request = await _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .Include(r => r.RelaunchedRequests)
                .Include(r => r.OriginalRequest)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

            if (request == null)
            {
                return NotFound();
            }

            // Security check for customers
            if (!isSupport && request.Customer.ApplicationUserId != userId)
            {
                TempData[SD.Error] = "You are not authorized to view this request.";
                return RedirectToAction(nameof(Index));
            }

            // Load decline reason if rejected
            var declineNote = await _db.tblRequestNotes
                .FirstOrDefaultAsync(n => n.RequestHeaderId == id && n.NoteType == "DeclineReason");

            // Check if customer has allocated fridges for replacement requests
            var hasAllocatedFridges = await _db.tblCustomerFridge
                .AnyAsync(cf => cf.CustomerID == request.CustomerID);

            ViewBag.DeclineReason = declineNote?.NoteContent;
            ViewBag.IsSupport = isSupport;
            ViewBag.CanRelaunch = !isSupport && request.Status == SD.Rejected;
            ViewBag.HasAllocatedFridges = hasAllocatedFridges;

            var vm = new RequestVM
            {
                RequstHeader = request,
                RequstDetail = request.RequestFridges
            };

            return View(vm);
        }

        // ====================== CUSTOMER ACTIONS ======================

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Relaunch(int id, string additionalInfo = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var originalRequest = await _db.tblRequestHeaders
                .Include(r => r.Customer)
                .Include(r => r.RequestFridges)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == id && r.Customer.ApplicationUserId == userId);

            if (originalRequest == null)
            {
                TempData[SD.Error] = "Request not found.";
                return RedirectToAction(nameof(Index));
            }

            if (originalRequest.Status != SD.Rejected)
            {
                TempData[SD.Error] = "Only declined requests can be relaunched.";
                return RedirectToAction(nameof(Index));
            }

            // Create a new request based on the original
            var newRequest = new RequestHeader
            {
                CustomerID = originalRequest.CustomerID,
                RequestDate = DateTime.Now,
                RequestTotal = originalRequest.RequestTotal,
                FirstName = originalRequest.FirstName,
                LastName = originalRequest.LastName,
                StreetAddress = originalRequest.StreetAddress,
                City = originalRequest.City,
                State = originalRequest.State,
                PostalCode = originalRequest.PostalCode,
                CellNumber = originalRequest.CellNumber,
                Status = SD.Pending,
                PaymentDueDate = DateTime.Now.AddDays(7),
                IsRelaunched = true,
                OriginalRequestHeaderId = id
            };

            _db.tblRequestHeaders.Add(newRequest);
            await _db.SaveChangesAsync();

            // Copy request details
            foreach (var detail in originalRequest.RequestFridges)
            {
                var newDetail = new RequestDetails
                {
                    RequestHeaderId = newRequest.RequestHeaderId,
                    FridgeId = detail.FridgeId,
                    Count = detail.Count,
                    Price = detail.Price
                };
                _db.tblRequestDetais.Add(newDetail);
            }

            // Add additional info as a note if provided
            if (!string.IsNullOrEmpty(additionalInfo))
            {
                var note = new RequestNote
                {
                    RequestHeaderId = newRequest.RequestHeaderId,
                    NoteType = "RelaunchInfo",
                    NoteContent = additionalInfo,
                    CreatedDate = DateTime.Now
                };
                _db.tblRequestNotes.Add(note);
            }

            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request relaunched successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ====================== FAULT REPORTING ACTIONS ======================

        // FRIDGE SELECTION PAGE
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CreateFaultSelection()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customer.CustomerID)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            if (!customerFridges.Any())
            {
                TempData[SD.Error] = "You don't have any allocated fridges to report faults for.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new FaultReportVM
            {
                CustomerID = customer.CustomerID,
                AvailableFridges = customerFridges,
                CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}"
            };

            return View(viewModel);
        }

        // CREATE FAULT REPORT - GET (for specific fridge)
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CreateFault(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customer.CustomerID)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            if (!customerFridges.Any())
            {
                TempData[SD.Error] = "You don't have any allocated fridges to report faults for.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new FaultReportVM
            {
                CustomerID = customer.CustomerID,
                AvailableFridges = customerFridges,
                CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}"
            };

            // Pre-select fridge if id is passed
            if (id.HasValue)
            {
                viewModel.FridgeInStockId = id.Value;
            }

            return View(viewModel);
        }

        // CREATE FAULT REPORT - POST
        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFault(FaultReportVM faultReportVM)
        {
            Console.WriteLine(">>> Entered POST CreateFault action <<<");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            // Reload dropdown data if validation fails
            faultReportVM.AvailableFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customer.CustomerID)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();
            faultReportVM.CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}";

            if (!ModelState.IsValid)
            {
                TempData[SD.Error] = "Please fill in all required fields.";
                return View(faultReportVM);
            }

            // Check fridge allocation
            bool isAllocated = await _db.tblCustomerFridge
                .AnyAsync(cf => cf.CustomerID == customer.CustomerID &&
                                cf.FridgeInStockId == faultReportVM.FridgeInStockId);

            if (!isAllocated)
            {
                TempData[SD.Error] = "You can only report faults for your allocated fridges.";
                return View(faultReportVM);
            }

            // Handle image upload
            string? imageUrls = null;
            if (faultReportVM.FaultImages != null && faultReportVM.FaultImages.Count > 0)
            {
                imageUrls = await SaveFaultImages(faultReportVM.FaultImages);
            }

            // Save Fault Report
            var fault = new FaultReport
            {
                CustomerId = customer.CustomerID,
                FridgeInStockId = faultReportVM.FridgeInStockId,
                FaultType = faultReportVM.FaultType,
                Description = faultReportVM.Description,
                Priority = faultReportVM.Priority,
                Status = "Reported",
                ReportedDate = DateTime.Now,
                ImageUrl = imageUrls,
                RequestReplacement = faultReportVM.RequestReplacement
            };

            _db.tblFaultReports.Add(fault);
            await _db.SaveChangesAsync();

            // Create fault technician record
            var technicianRecord = new FaultTechnician
            {
                FaultReportId = fault.FaultReportId,
                FaultDescription = $"{fault.FaultType}: {fault.Description}",
                Priority = fault.Priority,
                CustomerBookingStatus = "Pending",
                CreatedDate = DateTime.Now
            };

            _db.tblFaultTechnicians.Add(technicianRecord);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Fault reported successfully!";
            return RedirectToAction(nameof(ViewFaultStatus));
        }

        // VIEW FAULT STATUS - FIXED WITH EXPLICIT VIEW PATH
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> ViewFaultStatus(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(Index));
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["FaultTypeSortParm"] = sortOrder == "faulttype" ? "faulttype_desc" : "faulttype";
            ViewData["PrioritySortParm"] = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";

            var faults = _db.tblFaultReports
                .Where(fr => fr.CustomerId == customer.CustomerID)
                .Include(fr => fr.FaultTechnicians)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                faults = faults.Where(fr => fr.FaultType.Contains(searchString) || fr.Status.Contains(searchString));
            }

            faults = sortOrder switch
            {
                "date_desc" => faults.OrderByDescending(fr => fr.ReportedDate),
                "faulttype" => faults.OrderBy(fr => fr.FaultType),
                "faulttype_desc" => faults.OrderByDescending(fr => fr.FaultType),
                "priority" => faults.OrderBy(fr => fr.Priority),
                "priority_desc" => faults.OrderByDescending(fr => fr.Priority),
                "status" => faults.OrderBy(fr => fr.Status),
                "status_desc" => faults.OrderByDescending(fr => fr.Status),
                _ => faults.OrderByDescending(fr => fr.ReportedDate)
            };

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var paginatedFaults = await PaginatedList<FaultReport>.CreateAsync(faults.AsNoTracking(), pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = paginatedFaults.TotalPages;

            // EXPLICITLY SPECIFY THE VIEW PATH
            return View("~/Views/Request/ViewFaultStatus.cshtml", paginatedFaults);
        }

        // VIEW FAULT DETAILS
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> FaultDetails(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }

            var fault = await _db.tblFaultReports
                .Include(fr => fr.FaultTechnicians)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .FirstOrDefaultAsync(fr => fr.FaultReportId == id && fr.CustomerId == customer.CustomerID);

            if (fault == null)
            {
                TempData[SD.Error] = "Fault report not found.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }

            return View(fault);
        }

        // RELAUNCH DECLINED FAULT REQUEST
        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RelaunchFault(int faultReportId, string additionalInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }

            try
            {
                var originalFault = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == faultReportId && fr.CustomerId == customer.CustomerID);

                if (originalFault == null)
                {
                    TempData[SD.Error] = "Fault report not found.";
                    return RedirectToAction(nameof(ViewFaultStatus));
                }

                if (originalFault.Status != "Declined")
                {
                    TempData[SD.Error] = "Only declined requests can be relaunched.";
                    return RedirectToAction(nameof(ViewFaultStatus));
                }

                var newFaultReport = new FaultReport
                {
                    CustomerId = customer.CustomerID,
                    FridgeInStockId = originalFault.FridgeInStockId,
                    FaultType = originalFault.FaultType,
                    Description = originalFault.Description +
                                 (string.IsNullOrEmpty(additionalInfo) ? "" : $"\n\nAdditional Info: {additionalInfo}"),
                    ReportedDate = DateTime.Now,
                    Status = "Reported",
                    Priority = originalFault.Priority,
                    ImageUrl = originalFault.ImageUrl,
                    RequestReplacement = originalFault.RequestReplacement,
                    DeclineReason = null,
                    IsRelaunched = true,
                    OriginalFaultReportId = faultReportId
                };

                _db.tblFaultReports.Add(newFaultReport);
                await _db.SaveChangesAsync();

                var newFaultTechnician = new FaultTechnician
                {
                    FaultDescription = $"{newFaultReport.FaultType}: {newFaultReport.Description}",
                    FaultReportId = newFaultReport.FaultReportId,
                    CustomerBookingStatus = "Pending",
                    Priority = newFaultReport.Priority,
                    CreatedDate = DateTime.Now
                };
                _db.tblFaultTechnicians.Add(newFaultTechnician);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault request relaunched successfully!";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error relaunching fault report: {ex.Message}");
                TempData[SD.Error] = "Error relaunching fault request. Please try again.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
        }

        // ====================== SUPPORT ACTIONS ======================

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var request = await _db.tblRequestHeaders
                    .Include(r => r.RequestFridges)
                    .Include(r => r.Customer)
                    .FirstOrDefaultAsync(r => r.RequestHeaderId == id);

                if (request == null)
                {
                    return NotFound();
                }

                // Check stock availability before approving
                var stockCheckResult = await CheckStockAvailability(request.RequestFridges);
                if (!stockCheckResult.IsAvailable)
                {
                    TempData[SD.Error] = $"Cannot approve request: {stockCheckResult.Message}";
                    return RedirectToAction(nameof(Details), new { id });
                }

                request.Status = SD.Approved;
                request.RequestDate = DateTime.Now;

                _db.tblRequestHeaders.Update(request);

                // Allocate fridges
                await ReserveApprovedFridges(request);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData[SD.Success] = "Request approved and fridges allocated successfully.";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData[SD.Error] = $"Error approving request: {ex.Message}";
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string rejectReason)
        {
            if (string.IsNullOrWhiteSpace(rejectReason))
            {
                TempData[SD.Error] = "Reject reason is required.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var request = await _db.tblRequestHeaders.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = SD.Rejected;
            request.RequestDate = DateTime.Now;

            var note = new RequestNote
            {
                RequestHeaderId = id,
                NoteType = "DeclineReason",
                NoteContent = rejectReason,
                CreatedDate = DateTime.Now
            };

            _db.tblRequestNotes.Add(note);
            await _db.SaveChangesAsync();

            TempData[SD.Success] = "Request rejected successfully.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> Dashboard(string statusFilter)
        {
            var query = _db.tblRequestHeaders
                .Include(r => r.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(r => r.RequestFridges).ThenInclude(d => d.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(r => r.Status == statusFilter);
            }

            var allRequests = await query.OrderByDescending(r => r.RequestDate).ToListAsync();

            // Summary counts for cards
            ViewBag.TotalPending = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Pending);
            ViewBag.TotalApproved = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Approved);
            ViewBag.TotalRejected = await _db.tblRequestHeaders.CountAsync(r => r.Status == SD.Rejected);
            ViewBag.TotalRelaunched = await _db.tblRequestHeaders.CountAsync(r => r.IsRelaunched);

            ViewBag.SelectedStatus = statusFilter;

            return View("SupportDashboard", allRequests);
        }

        // SUPPORT: VIEW ALL FAULT REPORTS
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<IActionResult> AllFaults(string statusFilter = null, string priorityFilter = null)
        {
            var query = _db.tblFaultReports
                .Include(fr => fr.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .Include(fr => fr.FaultTechnicians)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(fr => fr.Status == statusFilter);
            }

            if (!string.IsNullOrEmpty(priorityFilter))
            {
                query = query.Where(fr => fr.Priority == priorityFilter);
            }

            var faults = await query.OrderByDescending(fr => fr.ReportedDate).ToListAsync();

            ViewBag.StatusFilter = statusFilter;
            ViewBag.PriorityFilter = priorityFilter;
            ViewBag.TotalReported = await _db.tblFaultReports.CountAsync(fr => fr.Status == "Reported");
            ViewBag.TotalInProgress = await _db.tblFaultReports.CountAsync(fr => fr.Status == "In Progress");
            ViewBag.TotalResolved = await _db.tblFaultReports.CountAsync(fr => fr.Status == "Resolved");

            return View(faults);
        }

        // SUPPORT: UPDATE FAULT STATUS
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFaultStatus(int id, string status, string technicianNotes = null)
        {
            var fault = await _db.tblFaultReports
                .Include(fr => fr.FaultTechnicians)
                .FirstOrDefaultAsync(fr => fr.FaultReportId == id);

            if (fault == null)
            {
                return NotFound();
            }

            fault.Status = status;

            if (!string.IsNullOrEmpty(technicianNotes))
            {
                var faultTechnician = fault.FaultTechnicians.FirstOrDefault();
                if (faultTechnician != null)
                {
                    faultTechnician.ResolutionNotes = technicianNotes;
                    faultTechnician.Completion = DateTime.Now;
                }
            }

            await _db.SaveChangesAsync();

            TempData[SD.Success] = $"Fault status updated to {status} successfully.";
            return RedirectToAction(nameof(AllFaults));
        }

        // ====================== PRIVATE METHODS ======================

        private async Task ReserveApprovedFridges(RequestHeader requestHeader)
        {
            foreach (var detail in requestHeader.RequestFridges)
            {
                // Find available stock instances for this fridge model
                var availableStocks = await _db.tblFridgeInStocks
                    .Where(s => s.FridgeId == detail.FridgeId && s.IsAvailable)
                    .Take(detail.Count)
                    .ToListAsync();

                if (availableStocks.Count < detail.Count)
                {
                    throw new Exception($"Insufficient stock for fridge ID {detail.FridgeId}. Requested: {detail.Count}, Available: {availableStocks.Count}");
                }

                foreach (var stock in availableStocks)
                {
                    stock.IsAvailable = false;
                    _db.tblFridgeInStocks.Update(stock);

                    // Allocate to customer
                    var allocation = new CustomerFridge
                    {
                        CustomerID = requestHeader.CustomerID,
                        FridgeId = detail.FridgeId,
                        FridgeInStockId = stock.FridgeInStockId,
                        ReservedDate = DateTime.Now,
                        AllocatedDate = DateTime.Now
                    };
                    _db.tblCustomerFridge.Add(allocation);
                }
            }

            await _db.SaveChangesAsync();
        }

        private async Task<StockCheckResult> CheckStockAvailability(ICollection<RequestDetails> requestDetails)
        {
            var result = new StockCheckResult { IsAvailable = true };

            foreach (var detail in requestDetails)
            {
                var availableStockCount = await _db.tblFridgeInStocks
                    .CountAsync(s => s.FridgeId == detail.FridgeId && s.IsAvailable);

                if (availableStockCount < detail.Count)
                {
                    result.IsAvailable = false;
                    result.Message = $"Insufficient stock for {detail.Fridge?.Brand}. Requested: {detail.Count}, Available: {availableStockCount}";
                    break;
                }
            }

            return result;
        }

        private async Task<string?> SaveFaultImages(List<IFormFile> faultImages)
        {
            var imageUrls = new List<string>();
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "faults");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            foreach (var image in faultImages)
            {
                if (image.Length > 0 && image.Length < 5 * 1024 * 1024)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add($"/images/faults/{fileName}");
                }
            }

            return imageUrls.Count > 0 ? string.Join(",", imageUrls) : null;
        }

        // Helper method to get stock information for display
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        public async Task<JsonResult> GetStockInfo(int requestId)
        {
            var request = await _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                .ThenInclude(rd => rd.Fridge)
                .FirstOrDefaultAsync(r => r.RequestHeaderId == requestId);

            if (request == null)
            {
                return Json(new { success = false, message = "Request not found" });
            }

            var stockInfo = new List<object>();

            foreach (var detail in request.RequestFridges)
            {
                var availableStock = await _db.tblFridgeInStocks
                    .CountAsync(s => s.FridgeId == detail.FridgeId && s.IsAvailable);

                stockInfo.Add(new
                {
                    fridgeId = detail.FridgeId,
                    modelName = detail.Fridge?.Brand,
                    requested = detail.Count,
                    available = availableStock,
                    hasEnoughStock = availableStock >= detail.Count
                });
            }

            return Json(new { success = true, stockInfo });
        }
    }

    // Helper class for stock checking
    public class StockCheckResult
    {
        public bool IsAvailable { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}