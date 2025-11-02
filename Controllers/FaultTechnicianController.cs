using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
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
        public IActionResult Dashboard()
        {
            try
            {
                var totalFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed");

                var pendingFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed" && !v.FaultTechnicians.Any());

                var inProgress = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "In Progress");

                var completed = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "Completed");

                var todaysBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date == DateTime.Today);

                var upcomingBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue && ft.Bookingate.Value.Date > DateTime.Today);

                // ----- FIXED: Pull data first, then use ?. in memory -----
                var recentActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FridgeVisit)
                        .ThenInclude(fv => fv.RequestHeader)
                            .ThenInclude(rh => rh.RequestFridges)
                                .ThenInclude(rf => rf.Fridge)
                    .OrderByDescending(ft => ft.Bookingate)
                    .Take(5)
                    .Select(ft => new
                    {
                        ft.RepairStatus,
                        ft.Bookingate,
                        RequestFridge = ft.FridgeVisit.RequestHeader.RequestFridges.FirstOrDefault(),
                        CustomerName = $"{ft.FridgeVisit.RequestHeader.FirstName} {ft.FridgeVisit.RequestHeader.LastName}"
                    })
                    .AsEnumerable()                     // <-- Switch to in-memory
                    .Select(x => new
                    {
                        Type = x.RepairStatus == "Completed" ? "Repair completed" :
                               x.RepairStatus == "In Progress" ? "Repair started" : "New repair assigned",
                        FridgeModel = x.RequestFridge?.Fridge?.Brand ?? "Unknown",
                        x.CustomerName,
                        TimeAgo = x.Bookingate
                    })
                    .ToList();

                // ----- ViewBag assignments -----
                ViewBag.TotalFaults = totalFaults;
                ViewBag.PendingFaults = pendingFaults;
                ViewBag.InProgress = inProgress;
                ViewBag.Completed = completed;
                ViewBag.TodaysBookings = todaysBookings;
                ViewBag.UpcomingBookings = upcomingBookings;
                ViewBag.RecentActivities = recentActivities;

                return View();
            }
            catch
            {
                // Graceful fallback
                ViewBag.TotalFaults = ViewBag.PendingFaults = ViewBag.InProgress = ViewBag.Completed = 0;
                ViewBag.TodaysBookings = ViewBag.UpcomingBookings = 0;
                ViewBag.RecentActivities = new List<dynamic>();
                return View();
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
                .Where(u => u.CheckupStatus.ToLower() == "failed")
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
        // 5. CUSTOMER: REPORT FAULT (FORM)
        // ===================================================================
        [HttpGet]
        public IActionResult CustomerFaultReport(int visitId)
        {
            var customerId = GetCurrentCustomerId();
            if (customerId == 0) return RedirectToAction("Login", "Account");

            if (visitId <= 0)
            {
                TempData[SD.Error] = "Please select a fridge to report a fault.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var visit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                        .ThenInclude(rf => rf.Fridge)
                .Include(v => v.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                        .ThenInclude(rf => rf.CustomerFridges)
                            .ThenInclude(cf => cf.FridgeInStock)
                .FirstOrDefault(v => v.VisitId == visitId && v.RequestHeader.CustomerID == customerId);

            if (visit == null)
            {
                TempData[SD.Error] = "Fridge not found or not assigned to you.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var customerFridge = visit.RequestHeader.RequestFridges
                .SelectMany(rf => rf.CustomerFridges)
                .FirstOrDefault();

            var vm = new CustomerFaultReportViewModel
            {
                VisitId = visitId,
                CustomerID = customerId,
                CustomerName = $"{visit.RequestHeader.Customer.ApplicationUser?.FirstName} {visit.RequestHeader.Customer.ApplicationUser?.LastName}",
                FridgeNo = customerFridge?.FridgeInStock?.FridgeNo ?? "N/A",
                FridgeModel = visit.RequestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown",
                ReportDate = DateTime.Now
            };

            ViewBag.FaultTypes = new List<SelectListItem>
            {
                new() { Text = "-- Select Fault Type --", Value = "" },
                new() { Text = "Not Cooling",       Value = "Not Cooling" },
                new() { Text = "Strange Noises",    Value = "Strange Noises" },
                new() { Text = "Water Leakage",     Value = "Water Leakage" },
                new() { Text = "Electrical Issues", Value = "Electrical Issues" },
                new() { Text = "Door Problems",     Value = "Door Problems" },
                new() { Text = "Other",             Value = "Other" }
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
                    new() { Text = "Not Cooling",       Value = "Not Cooling" },
                    new() { Text = "Strange Noises",    Value = "Strange Noises" },
                    new() { Text = "Water Leakage",     Value = "Water Leakage" },
                    new() { Text = "Electrical Issues", Value = "Electrical Issues" },
                    new() { Text = "Door Problems",     Value = "Door Problems" },
                    new() { Text = "Other",             Value = "Other" }
                };
                return View(vm);
            }

            var customerId = GetCurrentCustomerId();
            var visit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .FirstOrDefault(v => v.VisitId == vm.VisitId && v.RequestHeader.CustomerID == customerId);

            if (visit == null)
            {
                TempData[SD.Error] = "Invalid visit.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            if (_db.tblFaultTechnicians.Any(ft => ft.VisitId == vm.VisitId && ft.TechnicianAssigned == null))
            {
                TempData[SD.Error] = "You have already reported a fault for this fridge.";
                return RedirectToAction(nameof(CustomerFaultReports));
            }

            var faultReport = new FaultTechnician
            {
                VisitId = vm.VisitId,
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

            TempData[SD.Success] = "Fault reported successfully! We’ll contact you soon.";
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

            var activeVisit = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .Where(v => v.RequestHeader.CustomerID == customerId &&
                           (v.RequestHeader.Status == SD.Approved ||
                            v.RequestHeader.Status == SD.Shipped))
                .OrderByDescending(v => v.VisitDate)
                .FirstOrDefault();

            ViewBag.ActiveVisitId = activeVisit?.VisitId ?? 0;
            ViewBag.HasActiveFridge = activeVisit != null;

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

 
        // TECHNICIAN: ASSIGN SELF TO FAULT
    
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