using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using Project.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Project.Controllers
{
    [Authorize]
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FaultTechnicianController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
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

            var customer = _db.tblCustomer
                .FirstOrDefault(c => c.ApplicationUserId == userId);

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
        public IActionResult Index(string faultTypeFilter = "all")
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

            // Get customer-reported faults
            var customerFaults = _db.tblFaultReports
                .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .Where(fr => fr.Status == SD.Reported || fr.Status == SD.InProgress)
                .OrderByDescending(fr => fr.ReportedDate)
                .ToList();

            viewModel.CustomerReportedFaults = customerFaults;

            // Apply filters if needed
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
            ViewBag.TotalMaintenanceFaults = maintenanceFaults.Count;
            ViewBag.TotalCustomerFaults = customerFaults.Count;

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
        public async Task<IActionResult> CreateFault()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to report faults";
                return RedirectToAction("Login", "Account");
            }

            var customerFridges = await _db.tblCustomerFridge
                .Where(cf => cf.CustomerID == customerId)
                .Include(cf => cf.FridgeInStock)
                    .ThenInclude(fis => fis.Fridge)
                .ToListAsync();

            if (!customerFridges.Any())
            {
                TempData[SD.Error] = "You don't have any allocated fridges to report faults for.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var fridgeItems = customerFridges.Select(f => new SelectListItem
            {
                Value = f.FridgeInStockId.ToString(),
                Text = $"{f.FridgeInStock?.Fridge?.Brand} - {f.FridgeInStock?.FridgeNo}"
            }).ToList();

            ViewBag.FridgeList = fridgeItems;
            ViewBag.FaultTypes = GetFaultTypesSelectList();

            return View(new FaultReportVM());
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
                return RedirectToAction("Login", "Account");
            }

            // -----------------------------------------------------------------
            // 1. SECURITY: Verify the fridge belongs to the logged-in customer
            // -----------------------------------------------------------------
            var isAllocated = await _db.tblCustomerFridge
                .AnyAsync(cf => cf.CustomerID == customerId && cf.FridgeInStockId == vm.FridgeInStockId);

            if (!isAllocated)
                ModelState.AddModelError("FridgeInStockId", "You can only report faults for your allocated fridges.");

            // -----------------------------------------------------------------
            // 2. VALIDATION FAILED → RE-DISPLAY FORM WITH ALL DATA
            // -----------------------------------------------------------------
            if (!ModelState.IsValid)
            {
                // Re-populate FridgeInfo (so the card on the left shows the right fridge)
                var fridgeInStock = await _db.tblFridgeInStocks
                    .Include(f => f.Fridge)
                    .FirstOrDefaultAsync(f => f.FridgeInStockId == vm.FridgeInStockId);

                vm.FridgeInfo = fridgeInStock?.Fridge;
                vm.CustomerID = customerId;
                vm.CustomerName = await _db.tblCustomer
                    .Include(c => c.ApplicationUser)
                    .Where(c => c.CustomerID == customerId)
                    .Select(c => $"{c.ApplicationUser.FirstName} {c.ApplicationUser.LastName}")
                    .FirstOrDefaultAsync();

                // Re-populate ViewBag
                ViewBag.FaultTypes = GetFaultTypesSelectList();
                ViewBag.FridgeList = await _db.tblCustomerFridge
                    .Where(cf => cf.CustomerID == customerId)
                    .Include(cf => cf.FridgeInStock)
                        .ThenInclude(fis => fis.Fridge)
                    .Select(f => new SelectListItem
                    {
                        Value = f.FridgeInStockId.ToString(),
                        Text = $"{f.FridgeInStock.Fridge.Brand} - {f.FridgeInStock.FridgeNo}"
                    })
                    .ToListAsync();

                return View(vm);
            }

            // -----------------------------------------------------------------
            // 3. SUCCESS: Save fault report
            // -----------------------------------------------------------------
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
                    RequestReplacement = false, // Set to false since we removed this feature
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

                // Re-populate ViewBag on error
                ViewBag.FaultTypes = GetFaultTypesSelectList();
                ViewBag.FridgeList = await _db.tblCustomerFridge
                    .Where(cf => cf.CustomerID == customerId)
                    .Include(cf => cf.FridgeInStock)
                        .ThenInclude(fis => fis.Fridge)
                    .Select(f => new SelectListItem
                    {
                        Value = f.FridgeInStockId.ToString(),
                        Text = $"{f.FridgeInStock.Fridge.Brand} - {f.FridgeInStock.FridgeNo}"
                    })
                    .ToListAsync();

                return View(vm);
            }
        }

        // ===================================================================
        // 6. CUSTOMER: VIEW MY FAULT REPORTS
        // ===================================================================
        public IActionResult CustomerFaultReports()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0) return RedirectToAction("Login", "Account");

            var reports = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges)
                            .ThenInclude(rf => rf.Fridge)
                .Where(ft => ft.FridgeVisit != null && ft.FridgeVisit.RequestHeader.CustomerID == customerId)
                .OrderByDescending(ft => ft.ReportDate)
                .ToList();

            return View(reports);
        }

        // ===================================================================
        // 7. CUSTOMER: REPORT FAULT (LEGACY METHOD)
        // ===================================================================
        [HttpGet]
        public IActionResult CustomerFaultReport([FromQuery] int? requestHeaderId)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0)
            {
                TempData[SD.Error] = "Please log in to report faults";
                return RedirectToAction("Login", "Account");
            }

            if (!requestHeaderId.HasValue)
            {
                TempData[SD.Error] = "Invalid request";
                return RedirectToAction("Index", "Request");
            }

            var requestHeader = _db.tblRequestHeaders
                .Include(rh => rh.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(rh => rh.RequestHeaderId == requestHeaderId.Value &&
                                      rh.CustomerID == customerId &&
                                      rh.Status == SD.Approved);

            if (requestHeader == null)
            {
                TempData[SD.Error] = "Approved request not found or not assigned to you.";
                return RedirectToAction("Index", "Request");
            }

            var vm = new CustomerFaultReportViewModel
            {
                RequestHeaderId = requestHeaderId.Value,
                CustomerID = customerId,
                CustomerName = $"{requestHeader.Customer?.ApplicationUser?.FirstName} {requestHeader.Customer?.ApplicationUser?.LastName}",
                FridgeModel = requestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown",
                ReportDate = DateTime.Now
            };

            ViewBag.FaultTypes = GetFaultTypesSelectList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerFaultReport(CustomerFaultReportViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FaultTypes = GetFaultTypesSelectList();
                return View(vm);
            }

            var customerId = GetCurrentCustomerId();
            var requestHeader = _db.tblRequestHeaders
                .FirstOrDefault(rh => rh.RequestHeaderId == vm.RequestHeaderId &&
                                     rh.CustomerID == customerId &&
                                     rh.Status == SD.Approved);

            if (requestHeader == null)
            {
                TempData[SD.Error] = "Request not found or not approved";
                return RedirectToAction("Index", "Request");
            }

            try
            {
                var fridgeVisit = new FridgeVisit
                {
                    RequestHeaderId = vm.RequestHeaderId,
                    VisitDate = DateTime.Now,
                    CheckupStatus = "Fault Reported",
                    Notes = $"Customer reported: {vm.FaultType}",
                    TechnicianName = "Not Assigned"
                };

                _db.tblFridgeVisits.Add(fridgeVisit);
                _db.SaveChanges();

                var faultReport = new FaultTechnician
                {
                    VisitId = fridgeVisit.VisitId,
                    FaultType = vm.FaultType ?? "Unknown",
                    FaultDescription = vm.FaultDescription ?? "",
                    ResolutionNotes = vm.AdditionalNotes,
                    ReportDate = DateTime.Now,
                    RepairStatus = "Reported",
                    TechnicianAssigned = null,
                    CustomerBookingStatus = SD.Pending
                };

                _db.tblFaultTechnicians.Add(faultReport);
                _db.SaveChanges();

                TempData[SD.Success] = "Fault reported successfully!";
                return RedirectToAction(nameof(CustomerFaultReports));
            }
            catch (DbUpdateException)
            {
                TempData[SD.Error] = "Error reporting fault. Please try again or contact support.";
                return RedirectToAction(nameof(CustomerFaultReport), new { requestHeaderId = vm.RequestHeaderId });
            }
        }

        // ===================================================================
        // 8. CUSTOMER: FAULT SELECTION
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
                return RedirectToAction("Register", "Account");
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
        // 9. TECHNICIAN: VIEW PENDING CUSTOMER FAULTS
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
        // 10. TECHNICIAN: ASSIGN SELF TO FAULT
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
        // 11. SUPPORT: VIEW ALL FAULT REPORTS
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
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

            return View(faults);
        }

        // ===================================================================
        // 12. SUPPORT: UPDATE FAULT STATUS
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFaultStatus(int id, string status, string technicianNotes = null)
        {
            var fault = await _db.tblFaultReports
                .FirstOrDefaultAsync(fr => fr.FaultReportId == id);

            if (fault == null)
            {
                return NotFound();
            }

            fault.Status = status;
            if (!string.IsNullOrEmpty(technicianNotes))
            {
                // If you have a technician notes field, update it here
                // fault.TechnicianNotes = technicianNotes;
            }

            await _db.SaveChangesAsync();

            TempData[SD.Success] = $"Fault status updated to {status} successfully.";
            return RedirectToAction(nameof(AllFaults));
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
        // 14. CUSTOMER: FAULT DETAILS
        // ===================================================================
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

                if (originalFault.Status != "Declined")
                {
                    TempData[SD.Error] = "Only declined requests can be relaunched.";
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
        // 16. SUPPORT: PROCESS REPLACEMENT REQUEST
        // ===================================================================
        [Authorize(Roles = $"{SD.CustomerSupport},{SD.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessReplacement(int id, string action, string notes)
        {
            var fault = await _db.tblFaultReports
                .Include(fr => fr.Customer)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(fr => fr.FridgeInStock)
                .FirstOrDefaultAsync(fr => fr.FaultReportId == id);

            if (fault == null)
            {
                return NotFound();
            }

            if (!fault.RequestReplacement)
            {
                TempData[SD.Error] = "This is not a replacement request.";
                return RedirectToAction(nameof(AllFaults));
            }

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                if (action == "approve")
                {
                    if (fault.Customer == null || !fault.CustomerId.HasValue)
                    {
                        TempData[SD.Error] = "Customer not found for this fault report.";
                        return RedirectToAction(nameof(AllFaults));
                    }

                    var replacementRequest = new RequestHeader
                    {
                        CustomerID = fault.CustomerId.Value,
                        RequestDate = DateTime.Now,
                        RequestTotal = 0,
                        FirstName = fault.Customer.ApplicationUser?.FirstName ?? "Customer",
                        LastName = fault.Customer.ApplicationUser?.LastName ?? "",
                        StreetAddress = fault.Customer.ApplicationUser?.StreetAddress ?? "",
                        City = fault.Customer.ApplicationUser?.City ?? "",
                        State = fault.Customer.ApplicationUser?.State ?? "",
                        PostalCode = fault.Customer.ApplicationUser?.PostalCode ?? "",
                        CellNumber = fault.Customer.ApplicationUser?.PhoneNumber ?? "",
                        Status = SD.Approved,
                        PaymentDueDate = DateTime.Now.AddDays(30),
                    };

                    _db.tblRequestHeaders.Add(replacementRequest);
                    await _db.SaveChangesAsync();

                    if (fault.FridgeInStock?.FridgeId != null)
                    {
                        var fridge = await _db.tblFridges.FindAsync(fault.FridgeInStock.FridgeId);
                        if (fridge != null)
                        {
                            var requestDetail = new RequestDetails
                            {
                                RequestHeaderId = replacementRequest.RequestHeaderId,
                                FridgeId = fridge.FridgeId,
                                Count = 1,
                                Price = fridge.RentalPricePerMonth
                            };
                            _db.tblRequestDetais.Add(requestDetail);

                            replacementRequest.RequestTotal = fridge.RentalPricePerMonth;
                            _db.tblRequestHeaders.Update(replacementRequest);
                        }
                    }

                    fault.Status = "Replacement Approved";
                    TempData[SD.Success] = "Replacement request approved and new fridge allocation created.";
                }
                else if (action == "decline")
                {
                    fault.Status = "Replacement Declined";
                    fault.DeclineReason = notes;
                    TempData[SD.Success] = "Replacement request declined.";
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                TempData[SD.Error] = "Error processing replacement request. Please try again.";
            }

            return RedirectToAction(nameof(AllFaults));
        }
    }
}