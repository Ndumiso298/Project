using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using Project.ViewModel;
using System.Security.Claims;

namespace Project.Controllers
{
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FaultTechnicianController(ApplicationDbContext db) => _db = db;

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

                // Faults by date for chart (last 30 days)
                var faultsByDate = _db.tblFaultTechnicians
                    .Where(ft => ft.ReportDate >= DateTime.Today.AddDays(-30))
                    .AsEnumerable()
                    .GroupBy(ft => ft.ReportDate?.Date)
                    .Select(g => new KeyValuePair<string, int>(g.Key.ToString(), g.Count()))
                    .OrderBy(x => x.Key)
                    .ToList();

                // Fault type distribution
                var faultTypeDistribution = _db.tblFaultTechnicians
                    .Where(ft => !string.IsNullOrEmpty(ft.FaultType))
                    .AsEnumerable()
                    .GroupBy(ft => ft.FaultType)
                    .Select(g => new KeyValuePair<string, int>(g.Key ?? "Unknown", g.Count()))
                    .ToList();

                // Repair status distribution
                var repairStatusDistribution = _db.tblFaultTechnicians
                    .Where(ft => !string.IsNullOrEmpty(ft.RepairStatus))
                    .AsEnumerable()
                    .GroupBy(ft => ft.RepairStatus)
                    .Select(g => new KeyValuePair<string, int>(g.Key ?? "Unknown", g.Count()))
                    .ToList();

                // Top technicians by assigned faults
                var topTechnicians = _db.tblFaultTechnicians
                    .Where(ft => !string.IsNullOrEmpty(ft.TechnicianAssigned))
                    .AsEnumerable()
                    .GroupBy(ft => ft.TechnicianAssigned)
                    .Select(g => new KeyValuePair<string, int>(g.Key ?? "Unknown", g.Count()))
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                // Recent activities (last 10 activities)
                var recentActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                    .OrderByDescending(ft => ft.ReportDate)
                    .Take(10)
                    .AsEnumerable()
                    .Select(ft => new KeyValuePair<string, int>(
                        $"{ft.FaultType} - {(ft.FridgeVisit?.RequestHeader?.Customer?.ApplicationUser?.FirstName ?? "Unknown")}",
                        ft.FaultId
                    ))
                    .ToList();

                var vm = new FaultTechnicianDashboardViewModel
                {
                    TotalFaults = totalFaults,
                    PendingAssignment = pendingFaults,
                    InProgress = inProgressFaults,
                    Completed = completedFaults,
                    TodaysBookings = todaysBookings,
                    FaultsByDate = faultsByDate,
                    FaultTypeDistribution = faultTypeDistribution,
                    RepairStatusDistribution = repairStatusDistribution,
                    TopTechnicians = topTechnicians,
                    RecentActivities = recentActivities
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                // Log the exception
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
                .Include(u => u.FridgeVisit)
                    .ThenInclude(u => u.RequestHeader)
                        .ThenInclude(u => u.RequestFridges)
                            .ThenInclude(u => u.FridgeInStock)
                                .ThenInclude(u => u.Fridge)
                .ToList();

            return View(visits);
        }

        // ===================================================================
        // 3. LIST OF FAILED VISITS (Technician View)
        // ===================================================================
        public IActionResult Index()
        {
            var failedVisits = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                    .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                    .ThenInclude(u => u.RequestFridges)
                        .ThenInclude(u => u.Fridge)
                .Include(u => u.RequestHeader)
                    .ThenInclude(u => u.RequestFridges)
                        .ThenInclude(u => u.CustomerFridges)
                            .ThenInclude(u => u.FridgeInStock)
                .Where(u => u.CheckupStatus != null && u.CheckupStatus.ToLower() == "failed")
                .OrderByDescending(u => u.VisitDate)
                .ToList();

            var serviceIds = failedVisits.Select(u => u.VisitId).ToList();
            var repairs = _db.tblFaultTechnicians
                .Where(u => serviceIds.Contains((int)u.VisitId))
                .ToList();

            foreach (var visit in failedVisits)
                visit.FaultTechnicians = repairs.Where(u => u.VisitId == visit.VisitId).ToList();

            return View(failedVisits);
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
                new() { Text = "Scrapped", Value = "Scrapped" },
                new() { Text = "In Progress", Value = "In Progress" },
                new() { Text = "Resolved", Value = "Resolved" },
                new() { Text = "Not Started", Value = "Not Started" }
            };

            FaultTechnician model = visitId.HasValue
                ? _db.tblFaultTechnicians
                     .Include(u => u.FridgeVisit)
                     .ThenInclude(u => u.RequestHeader)
                     .ThenInclude(u => u.RequestFridges)
                     .ThenInclude(u => u.Fridge)
                     .FirstOrDefault(u => u.FaultId == visitId.Value)
                : new FaultTechnician
                {
                    VisitId = RequestedFaultId,
                    FridgeVisit = requestRepair,
                    Bookingate = DateTime.Now.AddDays(1)
                };

            return model == null ? NotFound() : View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult BookFaultVisit(FaultTechnician fault)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RepairStatusList = new List<SelectListItem>
                {
                    new() { Text = "Scrapped", Value = "Scrapped" },
                    new() { Text = "In Progress", Value = "In Progress" },
                    new() { Text = "Resolved", Value = "Resolved" },
                    new() { Text = "Not Started", Value = "Not Started" }
                };
                return View(fault);
            }

            if (fault.FaultId == 0)
                _db.tblFaultTechnicians.Add(fault);
            else
                _db.tblFaultTechnicians.Update(fault);

            _db.SaveChanges();
            TempData[SD.Success] = "Booking saved successfully";
            return RedirectToAction(nameof(Index));
        }

        // ===================================================================
        // 5. CUSTOMER: REPORT FAULT (FORM) - FIXED
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

            // PROPERLY INCLUDE CustomerFridges
            var requestHeader = _db.tblRequestHeaders
                .Include(rh => rh.Customer).ThenInclude(c => c.ApplicationUser)
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.CustomerFridges)
                        .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefault(rh => rh.RequestHeaderId == requestHeaderId.Value &&
                                      rh.CustomerID == customerId &&
                                      rh.Status == SD.Approved);

            if (requestHeader == null)
            {
                TempData[SD.Error] = "Approved request not found or not assigned to you.";
                return RedirectToAction("Index", "Request");
            }

            var allocatedFridge = requestHeader.RequestFridges
                .SelectMany(rf => rf.CustomerFridges)
                .FirstOrDefault();

            if (allocatedFridge == null)
            {
                TempData[SD.Error] = "No fridge has been allocated yet. Please wait for delivery.";
                return RedirectToAction("Index", "Request");
            }

            var vm = new CustomerFaultReportViewModel
            {
                RequestHeaderId = requestHeaderId.Value,
                CustomerID = customerId,
                CustomerName = $"{requestHeader.Customer?.ApplicationUser?.FirstName} {requestHeader.Customer?.ApplicationUser?.LastName}",
                FridgeNo = allocatedFridge.FridgeInStock?.FridgeNo ?? "N/A",
                FridgeModel = requestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown",
                ReportDate = DateTime.Now
            };

            ViewBag.FaultTypes = new List<SelectListItem>
            {
                new() { Text = "-- Select Fault Type --", Value = "" },
                new() { Text = "Not Cooling", Value = "Not Cooling" },
                new() { Text = "Strange Noises", Value = "Strange Noises" },
                new() { Text = "Water Leakage", Value = "Water Leakage" },
                new() { Text = "Electrical Issues", Value = "Electrical Issues" },
                new() { Text = "Door Problems", Value = "Door Problems" },
                new() { Text = "Other", Value = "Other" }
            };

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CustomerFaultReport(CustomerFaultReportViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FaultTypes = new List<SelectListItem>
                {
                    new() { Text = "-- Select Fault Type --", Value = "" },
                    new() { Text = "Not Cooling", Value = "Not Cooling" },
                    new() { Text = "Strange Noises", Value = "Strange Noises" },
                    new() { Text = "Water Leakage", Value = "Water Leakage" },
                    new() { Text = "Electrical Issues", Value = "Electrical Issues" },
                    new() { Text = "Door Problems", Value = "Door Problems" },
                    new() { Text = "Other", Value = "Other" }
                };
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

            var existingReport = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                .FirstOrDefault(ft => ft.FridgeVisit != null &&
                                     ft.FridgeVisit.RequestHeaderId == vm.RequestHeaderId &&
                                     ft.TechnicianAssigned == null);

            if (existingReport != null)
            {
                TempData[SD.Error] = "You already have a pending fault report for this fridge";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var fridgeVisit = new FridgeVisit
            {
                RequestHeaderId = vm.RequestHeaderId,
                VisitDate = DateTime.Now,
                CheckupStatus = "Fault Reported",
                Notes = $"Customer reported: {vm.FaultType}"
            };

            _db.tblFridgeVisits.Add(fridgeVisit);
            _db.SaveChanges();

            var faultReport = new FaultTechnician
            {
                VisitId = fridgeVisit.VisitId,
                FaultType = vm.FaultType,
                FaultDescription = vm.FaultDescription,
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

        // ===================================================================
        // 6. CUSTOMER: VIEW MY FAULT REPORTS (List)
        // ===================================================================
        public IActionResult CustomerFaultReports()
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0) return RedirectToAction("Login", "Account");

            var reports = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges)
                            .ThenInclude(rf => rf.Fridge)
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges)
                            .ThenInclude(rf => rf.CustomerFridges)
                                .ThenInclude(cf => cf.FridgeInStock)
                .Where(ft => ft.FridgeVisit.RequestHeader.CustomerID == customerId)
                .OrderByDescending(ft => ft.ReportDate)
                .ToList();

            // Find active approved request WITH allocated fridge
            var activeRequest = _db.tblRequestHeaders
                .Include(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.CustomerFridges)
                .Where(rh => rh.CustomerID == customerId &&
                             rh.Status == SD.Approved &&
                             rh.RequestFridges.Any(rf => rf.CustomerFridges.Any()))
                .OrderByDescending(rh => rh.RequestDate)
                .FirstOrDefault();

            ViewBag.ActiveRequestId = activeRequest?.RequestHeaderId ?? 0;
            ViewBag.HasActiveFridge = activeRequest != null;

            return View(reports);
        }

        // ===================================================================
        // 7. TECHNICIAN: VIEW PENDING CUSTOMER FAULTS
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
        // 8. TECHNICIAN: ASSIGN SELF TO FAULT
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
        // HELPER: GET CURRENT CUSTOMER ID
        // ===================================================================
        private int GetCurrentCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _db.tblCustomer
                .Where(c => c.ApplicationUserId == userId)
                .Select(c => c.CustomerID)
                .FirstOrDefault();
        }
    }
}