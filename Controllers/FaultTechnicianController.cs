using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using Project.ViewModel;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FaultTechnicianController> _logger;

        public FaultTechnicianController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, ILogger<FaultTechnicianController> logger)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // ===================================================================
        // PRIVATE HELPER METHODS
        // ===================================================================
        private async Task<string?> SaveFaultImages(List<IFormFile> faultImages)
        {
            if (faultImages == null || !faultImages.Any())
                return null;

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

        private int GetCurrentCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return 0;

            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
            return customer?.CustomerID ?? 0;
        }

        // -----------------------------------------------------------------
        // Helper: Fault Types Dropdown
        // -----------------------------------------------------------------
        private List<SelectListItem> GetFaultTypesSelectList()
        {
            return new List<SelectListItem>
            {
                new() { Value = "", Text = "-- Select Fault Type --", Disabled = true, Selected = true },
                new() { Value = "Not Cooling", Text = "❄️ Not Cooling" },
                new() { Value = "Noisy", Text = "🔊 Noisy Operation" },
                new() { Value = "Door Seal", Text = "🚪 Door Not Sealing" },
                new() { Value = "Frost", Text = "🧊 Frost Build-up" },
                new() { Value = "Light", Text = "💡 Light Not Working" },
                new() { Value = "Leak", Text = "💧 Water Leak" },
                new() { Value = "Display", Text = "📱 Display Issues" },
                new() { Value = "Temperature", Text = "🌡️ Temperature Fluctuation" },
                new() { Value = "Other", Text = "🔧 Other Issue" }
            };
        }

        // ===================================================================
        // 1. TECHNICIAN DASHBOARD
        // ===================================================================
        [HttpGet]
        public IActionResult Dashboard()
        {
            try
            {
                var totalFaults = _db.tblFaultTechnicians.Count();
                var pendingFaults = _db.tblFaultTechnicians.Count(ft => ft.TechnicianAssigned == null);
                var inProgressFaults = _db.tblFaultTechnicians.Count(ft => ft.RepairStatus == "In Progress");
                var completedFaults = _db.tblFaultTechnicians.Count(ft => ft.RepairStatus == "Completed");

                var today = DateTime.Today;
                var todaysBookings = _db.tblFaultTechnicians.Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date == today);

                var vm = new FaultTechnicianDashboardViewModel
                {
                    TotalFaults = totalFaults,
                    PendingAssignment = pendingFaults,
                    InProgress = inProgressFaults,
                    Completed = completedFaults,
                    TodaysBookings = todaysBookings,
                    FaultsByDate = new List<KeyValuePair<string, int>>(),
                    FaultTypeDistribution = new List<KeyValuePair<string, int>>(),
                    RepairStatusDistribution = new List<KeyValuePair<string, int>>(),
                    TopTechnicians = new List<KeyValuePair<string, int>>(),
                    RecentActivities = new List<KeyValuePair<string, int>>()
                };

                return View(vm);
            }
            catch (Exception)
            {
                var vm = new FaultTechnicianDashboardViewModel
                {
                    TotalFaults = 0,
                    PendingAssignment = 0,
                    InProgress = 0,
                    Completed = 0,
                    TodaysBookings = 0,
                    FaultsByDate = new List<KeyValuePair<string, int>>(),
                    FaultTypeDistribution = new List<KeyValuePair<string, int>>(),
                    RepairStatusDistribution = new List<KeyValuePair<string, int>>(),
                    TopTechnicians = new List<KeyValuePair<string, int>>(),
                    RecentActivities = new List<KeyValuePair<string, int>>()
                };

                return View(vm);
            }
        }

        // ===================================================================
        // 2. TECHNICIAN CALENDAR
        // ===================================================================
        public IActionResult Calendar()
        {
            var visits = _db.tblFaultTechnicians
                .Include(u => u.FridgeVisit)
                    .ThenInclude(u => u.RequestHeader)
                        .ThenInclude(u => u.Customer.ApplicationUser)
                .ToList();

            return View(visits);
        }

        // ===================================================================
        // 3. LIST OF ALL FAULTS (Technician View - Both Maintenance and Customer Reported)
        // ===================================================================
        public IActionResult Index(string faultTypeFilter = "all", string statusFilter = "all")
        {
            var viewModel = new TechnicianFaultsViewModel();

            // Get maintenance faults (failed visits)
            var maintenanceFaults = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                    .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                    .ThenInclude(u => u.RequestFridges)
                        .ThenInclude(u => u.Fridge)
                .Where(u => u.CheckupStatus != null && u.CheckupStatus.ToLower() == "failed")
                .OrderByDescending(u => u.VisitDate)
                .ToList();

            var serviceIds = maintenanceFaults.Select(u => u.VisitId).ToList();
            var maintenanceRepairs = _db.tblFaultTechnicians
                .Where(u => serviceIds.Contains((int)u.VisitId))
                .ToList();

            foreach (var visit in maintenanceFaults)
            {
                visit.FaultTechnicians = maintenanceRepairs.Where(u => u.VisitId == visit.VisitId).ToList();
            }

            viewModel.MaintenanceFaults = maintenanceFaults;

            // Get ALL customer-reported faults (including resolved and closed)
            var allCustomerFaults = _db.tblFaultReports
                .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .OrderByDescending(fr => fr.ReportedDate)
                .ToList();

            // Apply status filter to customer faults
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
            {
                if (statusFilter == "active")
                {
                    viewModel.CustomerReportedFaults = allCustomerFaults
                        .Where(fr => fr.Status == SD.Reported || fr.Status == SD.InProgress)
                        .ToList();
                }
                else if (statusFilter == "resolved")
                {
                    viewModel.CustomerReportedFaults = allCustomerFaults
                        .Where(fr => fr.Status == SD.FaultResolved)
                        .ToList();
                }
                else if (statusFilter == "closed")
                {
                    viewModel.CustomerReportedFaults = allCustomerFaults
                        .Where(fr => fr.Status == SD.Closed)
                        .ToList();
                }
                else if (statusFilter == "scrapped")
                {
                    viewModel.CustomerReportedFaults = allCustomerFaults
                        .Where(fr => fr.Status == SD.FaultScrapped)
                        .ToList();
                }
                else
                {
                    viewModel.CustomerReportedFaults = allCustomerFaults;
                }
            }
            else
            {
                // Show all faults by default
                viewModel.CustomerReportedFaults = allCustomerFaults;
            }

            // Apply fault type filter if needed
            if (!string.IsNullOrEmpty(faultTypeFilter) && faultTypeFilter != "all")
            {
                if (faultTypeFilter == "maintenance")
                {
                    viewModel.CustomerReportedFaults = new List<FaultReport>();
                }
                else if (faultTypeFilter == "customer")
                {
                    viewModel.MaintenanceFaults = new List<FridgeVisit>();
                }
            }

            ViewBag.FaultTypeFilter = faultTypeFilter;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.TotalMaintenanceFaults = maintenanceFaults.Count;
            ViewBag.TotalCustomerFaults = allCustomerFaults.Count;

            return View(viewModel);
        }
        // ===================================================================
        // 4. BOOK FAULT VISIT (Technician)
        // ===================================================================
        [HttpGet]
        public IActionResult BookFaultVisit(int RequestedFaultId, int? visitId)
        {
            var requestRepair = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                    .ThenInclude(r => r.RequestFridges)
                        .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(r => r.VisitId == RequestedFaultId && r.CheckupStatus == "Failed");

            if (requestRepair == null) return NotFound();

            ViewBag.RepairStatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Scrapped", Value = "Scrapped" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Resolved", Value = "Resolved" },
                new SelectListItem { Text = "Not Started", Value = "Not Started" }
            };

            FaultTechnician model;
            if (visitId.HasValue)
            {
                model = _db.tblFaultTechnicians
                     .Include(u => u.FridgeVisit)
                     .ThenInclude(u => u.RequestHeader)
                     .ThenInclude(u => u.RequestFridges)
                     .ThenInclude(u => u.Fridge)
                     .FirstOrDefault(u => u.FaultId == visitId.Value);
            }
            else
            {
                model = new FaultTechnician
                {
                    VisitId = RequestedFaultId,
                    FridgeVisit = requestRepair,
                    Bookingate = DateTime.Now.AddDays(1)
                };
            }

            return model == null ? NotFound() : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookFaultVisit(FaultTechnician fault)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RepairStatusList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Scrapped", Value = "Scrapped" },
                    new SelectListItem { Text = "In Progress", Value = "In Progress" },
                    new SelectListItem { Text = "Resolved", Value = "Resolved" },
                    new SelectListItem { Text = "Not Started", Value = "Not Started" }
                };
                return View(fault);
            }

            if (fault.FaultId == 0)
            {
                _db.tblFaultTechnicians.Add(fault);
            }
            else
            {
                _db.tblFaultTechnicians.Update(fault);
            }

            _db.SaveChanges();
            TempData[SD.Success] = "Booking saved successfully";
            return RedirectToAction(nameof(Index));
        }

        // ===================================================================
        // 5. CUSTOMER: CREATE FAULT REPORT
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        [HttpGet]
        public async Task<IActionResult> CreateFault(int? fridgeInStockId = null)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to report faults";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // If no fridge is specified, redirect to selection page
            if (!fridgeInStockId.HasValue || fridgeInStockId == 0)
            {
                return RedirectToAction("CreateFaultSelection");
            }

            // Verify the fridge belongs to the customer and get fridge info
            var customerFridge = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customerId && cf.FridgeInStockId == fridgeInStockId && cf.IsActive)
                .Include(cf => cf.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .FirstOrDefaultAsync();

            if (customerFridge == null)
            {
                TempData[SD.Error] = "Fridge not found or not allocated to you.";
                return RedirectToAction("CreateFaultSelection");
            }

            var vm = new FaultReportVM
            {
                CustomerID = customerId,
                CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}",
                FridgeInStockId = fridgeInStockId.Value,
                FridgeInfo = customerFridge.FridgeInStock?.Fridge
            };

            await PopulateCreateFaultViewData(customerId);
            return View(vm);
        }

        [Authorize(Roles = SD.CustomerRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFault(FaultReportVM vm, List<IFormFile> FaultImages)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to report faults.";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Validate required fields
            if (vm.FridgeInStockId == 0)
            {
                ModelState.AddModelError("FridgeInStockId", "Please select a fridge.");
            }

            if (string.IsNullOrEmpty(vm.FaultType))
            {
                ModelState.AddModelError("FaultType", "Please select a fault type.");
            }

            if (string.IsNullOrEmpty(vm.Description))
            {
                ModelState.AddModelError("Description", "Please provide a description of the fault.");
            }

            // Security check - verify the fridge belongs to the customer
            if (vm.FridgeInStockId > 0)
            {
                var isAllocated = await _db.tblCustomerFridge
                    .AnyAsync(cf => cf.CustomerID == customerId && cf.FridgeInStockId == vm.FridgeInStockId);

                if (!isAllocated)
                {
                    ModelState.AddModelError("FridgeInStockId", "You can only report faults for your allocated fridges.");
                }
            }

            // If validation fails, repopulate the view data and return
            if (!ModelState.IsValid)
            {
                await PopulateCreateFaultViewData(customerId);

                // Repopulate the fridge info for the selected fridge
                if (vm.FridgeInStockId > 0)
                {
                    var selectedFridge = await _db.tblFridgeInStocks
                        .Include(f => f.Fridge)
                        .FirstOrDefaultAsync(f => f.FridgeInStockId == vm.FridgeInStockId);
                    vm.FridgeInfo = selectedFridge?.Fridge;
                }

                return View(vm);
            }

            // SUCCESS: Save fault report
            try
            {
                string? imageUrls = null;
                if (FaultImages?.Count > 0)
                    imageUrls = await SaveFaultImages(FaultImages);

                var fault = new FaultReport
                {
                    CustomerId = customerId,
                    FridgeInStockId = vm.FridgeInStockId,
                    FaultType = vm.FaultType ?? "Unknown",
                    Description = vm.Description ?? "",
                    Priority = vm.Priority ?? "Medium",
                    RequestReplacement = false,
                    Status = SD.Reported,
                    ReportedDate = DateTime.Now,
                    ImageUrl = imageUrls
                };

                _db.tblFaultReports.Add(fault);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault reported successfully! A technician will contact you soon.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }
            catch (Exception ex)
            {
                TempData[SD.Error] = "An error occurred while saving the fault. Please try again.";

                // Repopulate view data on error
                await PopulateCreateFaultViewData(customerId);
                return View(vm);
            }
        }

        // Helper method to populate view data for CreateFault
        private async Task PopulateCreateFaultViewData(int customerId)
        {
            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customerId && cf.IsActive)
                .Include(cf => cf.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            ViewBag.FridgeList = customerFridges.Select(f => new SelectListItem
            {
                Value = f.FridgeInStockId.ToString(),
                Text = $"{f.FridgeInStock?.Fridge?.Brand} {f.FridgeInStock?.Fridge?.Model} - {f.FridgeInStock?.FridgeNo}"
            }).ToList();

            ViewBag.FaultTypes = GetFaultTypesSelectList();
        }

        // ===================================================================
        // 6. CUSTOMER: VIEW MY FAULT REPORTS
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public IActionResult CustomerFaultReports()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0) return RedirectToPage("/Account/Login", new { area = "Identity" });

            var reports = _db.tblFaultReports
                .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .Where(fr => fr.CustomerId == customerId)
                .OrderByDescending(fr => fr.ReportedDate)
                .ToList();

            return View(reports);
        }

        // ===================================================================
        // 7. CUSTOMER: FAULT SELECTION
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> CreateFaultSelection()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found. Please complete your registration.";
                return RedirectToPage("/Account/Register", new { area = "Identity" });
            }

            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customer.CustomerID)
                .Include(cf => cf.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            if (!customerFridges.Any())
            {
                TempData[SD.Error] = "You don't have any allocated fridges to report faults for.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var viewModel = new FaultReportVM
            {
                CustomerID = customer.CustomerID,
                AvailableFridges = customerFridges,
                CustomerName = $"{customer.ApplicationUser.FirstName} {customer.ApplicationUser.LastName}"
            };

            return View(viewModel);
        }

        // ===================================================================
        // 8. TECHNICIAN: VIEW PENDING CUSTOMER FAULTS
        // ===================================================================
        public IActionResult PendingCustomerFaults()
        {
            var faults = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges)
                            .ThenInclude(rf => rf.Fridge)
                .Where(ft => ft.TechnicianAssigned == null && ft.RepairStatus == "Reported")
                .OrderByDescending(ft => ft.ReportDate)
                .ToList();

            return View(faults);
        }

        // ===================================================================
        // 9. TECHNICIAN: ASSIGN SELF TO FAULT
        // ===================================================================
        public IActionResult AssignToFault(int faultId)
        {
            var fault = _db.tblFaultTechnicians.Find(faultId);
            if (fault == null)
            {
                TempData[SD.Error] = "Fault not found.";
                return RedirectToAction(nameof(PendingCustomerFaults));
            }

            fault.TechnicianAssigned = User.Identity?.Name;
            fault.RepairStatus = "Not Started";
            fault.CustomerBookingStatus = SD.Approved;
            _db.SaveChanges();

            TempData[SD.Success] = "Fault assigned to you!";
            return RedirectToAction(nameof(BookFaultVisit), new { RequestedFaultId = fault.VisitId, visitId = faultId });
        }

        // ===================================================================
        // 10. SUPPORT: VIEW ALL FAULT REPORTS
        // ===================================================================
        [Authorize(Roles = $"{SD.FaultTechnician},{SD.AdminRole}")]
        public async Task<IActionResult> AllFaults(string statusFilter = null)
        {
            var query = _db.tblFaultReports
                .Include(fr => fr.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock).ThenInclude(fis => fis.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(fr => fr.Status == statusFilter);
            }

            var faults = await query.OrderByDescending(fr => fr.ReportedDate).ToListAsync();

            ViewBag.StatusFilter = statusFilter;
            ViewBag.TotalReported = await _db.tblFaultReports.CountAsync(fr => fr.Status == "Reported");
            ViewBag.TotalInProgress = await _db.tblFaultReports.CountAsync(fr => fr.Status == "In Progress");
            ViewBag.TotalResolved = await _db.tblFaultReports.CountAsync(fr => fr.Status == "Resolved");
            ViewBag.TotalScrapped = await _db.tblFaultReports.CountAsync(fr => fr.Status == "Scrapped");

            return View(faults);
        }

        // ===================================================================
        // 11. TECHNICIAN: UPDATE FAULT STATUS (INCLUDES SCRAPPED)
        // ===================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.FaultTechnician},{SD.AdminRole}")]
        public async Task<IActionResult> UpdateFaultStatus(int id, string status, string? technicianNotes = null)
        {
            try
            {
                var fault = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == id);

                if (fault == null)
                {
                    return NotFound();
                }

                // Update status and corresponding date
                fault.Status = status;
                fault.TechnicianNotes = technicianNotes;

                switch (status)
                {
                    case SD.InProgress:
                        fault.InProgressDate = DateTime.Now;
                        break;
                    case SD.FaultResolved:
                        fault.ResolvedDate = DateTime.Now;
                        break;
                    case "Scrapped":
                        fault.ScrappedDate = DateTime.Now;
                        // Automatically create replacement request for scrapped fridges
                        await CreateReplacementRequestForScrappedFridge(fault);
                        break;
                }

                // Add technician comment for status change
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _db.AppUser.FindAsync(userId);

                var comment = new FaultComment
                {
                    FaultReportId = id,
                    Comment = $"Status changed to: {status}" + (string.IsNullOrEmpty(technicianNotes) ? "" : $". Notes: {technicianNotes}"),
                    CommentBy = "Technician",
                    UserId = userId!,
                    UserName = $"{user?.FirstName} {user?.LastName}",
                    CommentDate = DateTime.Now,
                    IsInternalNote = false
                };

                _db.tblFaultComments.Add(comment);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = $"Fault status updated to {status} successfully.";
                return RedirectToAction(nameof(ProcessFault));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating fault status {FaultId} to {Status}", id, status);
                TempData[SD.Error] = $"Error updating fault status: {ex.Message}";
                return RedirectToAction(nameof(ProcessFault));
            }
        }

        // ===================================================================
        // 12. TECHNICIAN: CREATE REPLACEMENT FOR SCRAPPED FRIDGE
        // ===================================================================
        private async Task CreateReplacementRequestForScrappedFridge(FaultReport fault)
        {
            if (fault.FridgeInStockId == null) return;

            try
            {
                var fridge = await _db.tblFridgeInStocks
                    .Include(f => f.Fridge)
                    .FirstOrDefaultAsync(f => f.FridgeInStockId == fault.FridgeInStockId);

                if (fridge == null) return;

                // Check if replacement already exists
                var existingReplacement = await _db.tblFridgeReplacements
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == fault.FaultReportId);

                if (existingReplacement != null) return;

                var replacement = new FridgeReplacement
                {
                    FaultReportId = fault.FaultReportId,
                    CustomerID = fault.CustomerId,
                    OldFridgeNo = fridge.FridgeNo,
                    ReasonForReplacement = $"Fridge scrapped due to: {fault.FaultType}",
                    ReplacementDate = DateTime.Now.AddDays(7), // Schedule replacement in 7 days
                    RequestDate = DateTime.Now,
                    ReplacementStatus = SD.Pending,
                    ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _db.tblFridgeReplacements.Add(replacement);
                await _db.SaveChangesAsync();

                // Link replacement to fault
                fault.ReplacementRequestId = replacement.FridgeReplacementId;
                fault.IsReplacementRequested = true;

                // Mark fridge as pending scrapping
                fridge.Status = "Pending Scrapping";
                fridge.IsAvailable = false;

                await _db.SaveChangesAsync();

                _logger.LogInformation("Auto-created replacement request for scrapped fridge {FridgeNo}", fridge.FridgeNo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating replacement request for scrapped fridge in fault {FaultId}", fault.FaultReportId);
            }
        }

        // ===================================================================
        // 13. CUSTOMER: VIEW FAULT STATUS
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> ViewFaultStatus(string sortOrder, string currentFilter, string searchString, string statusFilter, int? page)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _db.tblCustomer
                .FirstOrDefaultAsync(c => c.ApplicationUserId == userId);

            if (customer == null)
            {
                TempData[SD.Error] = "Customer profile not found.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["StatusFilter"] = statusFilter;
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["FaultTypeSortParm"] = sortOrder == "faulttype" ? "faulttype_desc" : "faulttype";
            ViewData["PrioritySortParm"] = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";

            var faults = _db.tblFaultReports
                .Where(fr => fr.CustomerId == customer.CustomerID)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                faults = faults.Where(fr => fr.FaultType != null && (fr.FaultType.Contains(searchString) || fr.Status != null && fr.Status.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                faults = faults.Where(fr => fr.Status == statusFilter);
            }

            faults = sortOrder switch
            {
                "date_desc" => faults.OrderByDescending(fr => fr.ReportedDate),
                "faulttype" => faults.OrderBy(fr => fr.FaultType ?? ""),
                "faulttype_desc" => faults.OrderByDescending(fr => fr.FaultType ?? ""),
                "priority" => faults.OrderBy(fr => fr.Priority ?? ""),
                "priority_desc" => faults.OrderByDescending(fr => fr.Priority ?? ""),
                "status" => faults.OrderBy(fr => fr.Status ?? ""),
                "status_desc" => faults.OrderByDescending(fr => fr.Status ?? ""),
                _ => faults.OrderByDescending(fr => fr.ReportedDate)
            };

            int pageSize = 10;
            int pageNumber = page ?? 1;
            var totalItems = await faults.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var paginatedFaults = await faults
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;

            return View(paginatedFaults);
        }

        // ===================================================================
        // 14. CUSTOMER: FAULT DETAILS WITH TIMELINE AND COMMENTS
        // ===================================================================
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> FaultDetails(int id)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to view fault details";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            try
            {
                var fault = await _db.tblFaultReports
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.FridgeInStock)
                        .ThenInclude(fis => fis.Fridge)
                    .Include(fr => fr.FaultComments.Where(fc => !fc.IsInternalNote))
                    .Include(fr => fr.ReplacementRequest)
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == id && fr.CustomerId == customerId);

                if (fault == null)
                {
                    TempData[SD.Error] = "Fault report not found or you don't have permission to view it";
                    return RedirectToAction(nameof(CustomerFaultReports));
                }

                var timelineEvents = GenerateTimelineEvents(fault);
                var comments = fault.FaultComments.OrderBy(c => c.CommentDate).ToList();

                var viewModel = new FaultDetailsViewModel
                {
                    FaultReport = fault,
                    Comments = comments,
                    TimelineEvents = timelineEvents,
                    IsCustomerView = true,
                    IsTechnicianView = false
                };

                return View("CustomerFaultDetails", viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading fault details {FaultId} for customer {CustomerId}", id, customerId);
                TempData[SD.Error] = "An error occurred while loading fault details";
                return RedirectToAction(nameof(CustomerFaultReports));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.CustomerRole)]
        public async Task<IActionResult> AddComment(int faultReportId, string newComment)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                return Json(new { success = false, message = "Please log in to add comments" });
            }

            if (string.IsNullOrWhiteSpace(newComment))
            {
                return Json(new { success = false, message = "Comment cannot be empty" });
            }

            try
            {
                var fault = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == faultReportId && fr.CustomerId == customerId);

                if (fault == null)
                {
                    return Json(new { success = false, message = "Fault report not found" });
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _db.AppUser.FindAsync(userId);

                var comment = new FaultComment
                {
                    FaultReportId = faultReportId,
                    Comment = newComment.Trim(),
                    CommentBy = "Customer",
                    UserId = userId!,
                    UserName = $"{user?.FirstName} {user?.LastName}",
                    CommentDate = DateTime.Now,
                    IsInternalNote = false
                };

                _db.tblFaultComments.Add(comment);
                await _db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Comment added successfully",
                    commentId = comment.FaultCommentId,
                    userName = comment.UserName,
                    commentDate = comment.CommentDate.ToString("MMM dd, yyyy HH:mm"),
                    commentText = comment.Comment
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding comment to fault {FaultId} by customer {CustomerId}", faultReportId, customerId);
                return Json(new { success = false, message = "Error adding comment" });
            }
        }

        // ===================================================================
        // 15. CUSTOMER: RELAUNCH FAULT
        // ===================================================================
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

                if (originalFault.Status != "Scrapped")
                {
                    TempData[SD.Error] = "Only scrapped requests can be relaunched.";
                    return RedirectToAction(nameof(ViewFaultStatus));
                }

                var newFaultReport = new FaultReport
                {
                    CustomerId = customer.CustomerID,
                    FridgeInStockId = originalFault.FridgeInStockId,
                    FaultType = originalFault.FaultType ?? "Unknown",
                    Description = originalFault.Description + (string.IsNullOrEmpty(additionalInfo) ? "" : $"\n\nAdditional Info: {additionalInfo}"),
                    ReportedDate = DateTime.Now,
                    Status = "Reported",
                    Priority = originalFault.Priority,
                    ImageUrl = originalFault.ImageUrl,
                    RequestReplacement = false,
                    IsReplacementRequested = false,
                    DeclineReason = null,
                    IsRelaunched = true,
                    OriginalFaultReportId = faultReportId
                };

                _db.tblFaultReports.Add(newFaultReport);
                await _db.SaveChangesAsync();

                TempData[SD.Success] = "Fault request relaunched successfully!";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
            catch (Exception)
            {
                TempData[SD.Error] = "Error relaunching fault request. Please try again.";
                return RedirectToAction(nameof(ViewFaultStatus));
            }
        }

        // ===================================================================
        // 16. GET FRIDGE INFO FOR AJAX CALL
        // ===================================================================
        [HttpGet]
        public async Task<IActionResult> GetFridgeInfo(int fridgeInStockId)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                return Json(new { success = false, message = "Please log in" });
            }

            // Verify the fridge belongs to the customer
            var isAllocated = await _db.tblCustomerFridge
                .AnyAsync(cf => cf.CustomerID == customerId && cf.FridgeInStockId == fridgeInStockId);

            if (!isAllocated)
            {
                return Json(new { success = false, message = "Fridge not allocated to you" });
            }

            var fridgeInfo = await _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .Where(f => f.FridgeInStockId == fridgeInStockId)
                .Select(f => new
                {
                    success = true,
                    brand = f.Fridge.Brand,
                    model = f.Fridge.Model,
                    capacity = f.Fridge.CapacityLiters,
                    type = f.Fridge.Type,
                    condition = f.Condition,
                    lastMaintenance = f.LastMaintenanceDate.ToString("yyyy-MM-dd"),
                    fridgeNo = f.FridgeNo
                })
                .FirstOrDefaultAsync();

            return fridgeInfo == null
                ? Json(new { success = false, message = "Fridge not found" })
                : Json(fridgeInfo);
        }
        // ===================================================================
        // TECHNICIAN: PROCESS FAULT DETAILS
        // ===================================================================
        [Authorize(Roles = $"{SD.FaultTechnician},{SD.AdminRole}")]
        public async Task<IActionResult> ProcessFault(int id)
        {
            try
            {
                var fault = await _db.tblFaultReports
                    .Include(fr => fr.Customer)
                        .ThenInclude(c => c.ApplicationUser)
                    .Include(fr => fr.FridgeInStock)
                        .ThenInclude(fis => fis.Fridge)
                    .Include(fr => fr.FaultComments.Where(fc => !fc.IsInternalNote))
                    .Include(fr => fr.ReplacementRequest)
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == id);

                if (fault == null)
                {
                    TempData[SD.Error] = "Fault report not found";
                    return RedirectToAction(nameof(AllFaults));
                }

                var timelineEvents = GenerateTimelineEvents(fault);
                var comments = fault.FaultComments.OrderBy(c => c.CommentDate).ToList();

                var viewModel = new FaultDetailsViewModel
                {
                    FaultReport = fault,
                    Comments = comments,
                    TimelineEvents = timelineEvents,
                    IsTechnicianView = true,
                    IsCustomerView = false
                };

                return View("TechnicianFaultDetails", viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading fault details {FaultId} for processing", id);
                TempData[SD.Error] = "An error occurred while loading fault details";
                return RedirectToAction(nameof(ProcessFault));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{SD.FaultTechnician},{SD.AdminRole}")]
        public async Task<IActionResult> AddTechnicianComment(int faultReportId, string comment, string? technicianNotes = null)
        {
            try
            {
                var fault = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == faultReportId);

                if (fault == null)
                {
                    return Json(new { success = false, message = "Fault report not found" });
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _db.AppUser.FindAsync(userId);

                // Update technician notes if provided
                if (!string.IsNullOrEmpty(technicianNotes))
                {
                    fault.TechnicianNotes = technicianNotes;
                }

                // Add comment
                var faultComment = new FaultComment
                {
                    FaultReportId = faultReportId,
                    Comment = comment.Trim(),
                    CommentBy = "Technician",
                    UserId = userId!,
                    UserName = $"{user?.FirstName} {user?.LastName}",
                    CommentDate = DateTime.Now,
                    IsInternalNote = false
                };

                _db.tblFaultComments.Add(faultComment);
                await _db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Comment added successfully",
                    commentId = faultComment.FaultCommentId,
                    userName = faultComment.UserName,
                    commentDate = faultComment.CommentDate.ToString("MMM dd, yyyy HH:mm"),
                    commentText = faultComment.Comment
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding technician comment to fault {FaultId}", faultReportId);
                return Json(new { success = false, message = "Error adding comment" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CloseFaultReport(int faultReportId)
        {
            try
            {
                var faultReport = await _db.tblFaultReports
                    .FirstOrDefaultAsync(fr => fr.FaultReportId == faultReportId);

                if (faultReport == null)
                {
                    TempData[SD.Error] = "Fault report not found";
                    return RedirectToAction(nameof(AllFaults));
                }

                // Get resolved status from constants or configuration
                var resolvedStatus = SD.FaultResolved ?? "Resolved";
                var closedStatus = SD.FaultClosed ?? "Closed";

                if (faultReport.Status != resolvedStatus)
                {
                    TempData[SD.Error] = $"Only {resolvedStatus.ToLower()} fault reports can be closed";
                    return RedirectToAction(nameof(Details), new { id = faultReportId });
                }

                faultReport.Status = closedStatus;
                faultReport.ClosedDate = DateTime.Now;

                await _db.SaveChangesAsync();
                TempData[SD.Success] = "Fault report closed successfully";

                // Redirect based on user role
                if (User.IsInRole(SD.CustomerRole))
                {
                    return RedirectToAction(nameof(FaultDetails), new { id = faultReportId });
                }
                else
                {
                    return RedirectToAction(nameof(ProcessFault), new { id = faultReportId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error closing fault report {FaultId}", faultReportId);
                TempData[SD.Error] = "An error occurred while closing the fault report";
                return RedirectToAction(nameof(Details), new { id = faultReportId });
            }
        }
        // ===================================================================
        // PRIVATE HELPER METHODS
        // ===================================================================
        private List<FaultTimelineEvent> GenerateTimelineEvents(FaultReport fault)
        {
            var events = new List<FaultTimelineEvent>();

            // Status change events using constants
            events.Add(new FaultTimelineEvent
            {
                EventType = SD.Reported,
                Description = "Fault reported by customer",
                EventDate = fault.ReportedDate,
                Icon = "fas fa-flag",
                Color = "primary"
            });

            // In Progress status
            if (fault.InProgressDate.HasValue)
            {
                events.Add(new FaultTimelineEvent
                {
                    EventType = SD.InProgress,
                    Description = "Technician started working on the fault",
                    EventDate = fault.InProgressDate.Value,
                    Icon = "fas fa-tools",
                    Color = "warning"
                });
            }

            // Resolved status
            if (fault.ResolvedDate.HasValue)
            {
                events.Add(new FaultTimelineEvent
                {
                    EventType = SD.FaultResolved,
                    Description = "Fault has been resolved successfully",
                    EventDate = fault.ResolvedDate.Value,
                    Icon = "fas fa-check-circle",
                    Color = "success"
                });
            }

            // Scrapped status
            if (fault.ScrappedDate.HasValue)
            {
                events.Add(new FaultTimelineEvent
                {
                    EventType = SD.FaultScrapped,
                    Description = "Fridge marked for replacement due to irreparable fault",
                    EventDate = fault.ScrappedDate.Value,
                    Icon = "fas fa-recycle",
                    Color = "danger"
                });

                // Add replacement request event if exists
                if (fault.ReplacementRequest != null)
                {
                    events.Add(new FaultTimelineEvent
                    {
                        EventType = "Replacement Requested",
                        Description = $"Replacement requested: {fault.ReplacementRequest.ReasonForReplacement}",
                        EventDate = fault.ReplacementRequest.RequestDate,
                        Icon = "fas fa-exchange-alt",
                        Color = "warning"
                    });

                    if (fault.ReplacementRequest.ReplacementStatus == SD.Approved)
                    {
                        events.Add(new FaultTimelineEvent
                        {
                            EventType = "Replacement Approved",
                            Description = $"New fridge allocated: {fault.ReplacementRequest.NewFridgeInStock?.FridgeNo ?? "Pending"}",
                            EventDate = fault.ReplacementRequest.ActionDate ?? DateTime.Now,
                            Icon = "fas fa-check-double",
                            Color = "success"
                        });
                    }
                    else if (fault.ReplacementRequest.ReplacementStatus == SD.Rejected)
                    {
                        events.Add(new FaultTimelineEvent
                        {
                            EventType = "Replacement Rejected",
                            Description = $"Replacement request rejected: {fault.ReplacementRequest.DeclineReason}",
                            EventDate = fault.ReplacementRequest.ActionDate ?? DateTime.Now,
                            Icon = "fas fa-times-circle",
                            Color = "danger"
                        });
                    }
                }
            }

            // Closed status
            if (fault.ClosedDate.HasValue)
            {
                events.Add(new FaultTimelineEvent
                {
                    EventType = SD.FaultClosed,
                    Description = "Fault report has been closed",
                    EventDate = fault.ClosedDate.Value,
                    Icon = "fas fa-lock",
                    Color = "secondary"
                });
            }

            // Add comment events using constants
            var customerRole = SD.CustomerRole;
            var technicianRole = SD.FaultTechnician;

            foreach (var comment in fault.FaultComments.Where(c => !c.IsInternalNote).OrderBy(c => c.CommentDate))
            {
                var isCustomerComment = comment.CommentBy?.Equals(customerRole, StringComparison.OrdinalIgnoreCase) == true;
                var isTechnicianComment = comment.CommentBy?.Equals(technicianRole, StringComparison.OrdinalIgnoreCase) == true ||
                                         comment.CommentBy?.Equals("Technician", StringComparison.OrdinalIgnoreCase) == true;

                string eventType;
                string icon;
                string color;

                if (isCustomerComment)
                {
                    eventType = "Customer Comment";
                    icon = "fas fa-comment";
                    color = "secondary";
                }
                else if (isTechnicianComment)
                {
                    eventType = "Technician Update";
                    icon = "fas fa-clipboard-check";
                    color = "info";
                }
                else
                {
                    eventType = $"{comment.CommentBy} Comment";
                    icon = "fas fa-comment";
                    color = "primary";
                }

                events.Add(new FaultTimelineEvent
                {
                    EventType = eventType,
                    Description = comment.Comment,
                    EventDate = comment.CommentDate,
                    Icon = icon,
                    Color = color
                });
            }

            return events.OrderBy(e => e.EventDate).ToList();
        }
    }
}