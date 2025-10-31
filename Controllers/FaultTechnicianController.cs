using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class FaultTechnicianController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FaultTechnicianController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            try
            {
                var totalFaults = _db.tblFridgeVisits
                    .Count(v => v.CheckupStatus.ToLower() == "failed" || v.CheckupStatus == "Failed");

                var pendingFaults = _db.tblFridgeVisits
                    .Count(v => (v.CheckupStatus.ToLower() == "failed" || v.CheckupStatus == "Failed") &&
                               !v.FaultTechnicians.Any());

                var inProgress = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "In Progress");

                // Get completed repair
                var completed = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "Completed");

                // Get recent activities
                var recentActivities = _db.tblFaultTechnicians
                    .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                    .ThenInclude(rh => rh.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                    .OrderByDescending(ft => ft.Bookingate)
                    .Take(5)
                    .Select(ft => new
                    {
                        Type = ft.RepairStatus == "Completed" ? "Repair completed" :
                               ft.RepairStatus == "In Progress" ? "Repair started" : "New repair assigned",
                        FridgeModel = ft.FridgeVisit.RequestHeader.RequestFridges.FirstOrDefault().Fridge.Model,
                        CustomerName = ft.FridgeVisit.RequestHeader.FirstName + " " + ft.FridgeVisit.RequestHeader.LastName,
                        TimeAgo = ft.Bookingate
                    })
                    .ToList();

                // Get today's bookings
                var todaysBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue &&
                                ft.Bookingate.Value.Date == DateTime.Today);

                // Get upcoming bookings
                var upcomingBookings = _db.tblFaultTechnicians
                    .Count(ft => ft.Bookingate.HasValue &&
                                ft.Bookingate.Value.Date > DateTime.Today);

                ViewBag.TotalFaults = totalFaults;
                ViewBag.PendingFaults = pendingFaults;
                ViewBag.InProgress = inProgress;
                ViewBag.Completed = completed;
                ViewBag.TodaysBookings = todaysBookings;
                ViewBag.UpcomingBookings = upcomingBookings;
                ViewBag.RecentActivities = recentActivities;

                return View();
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error loading dashboard: {ex.Message}");

                // Set default values in case of error
                ViewBag.TotalFaults = 0;
                ViewBag.PendingFaults = 0;
                ViewBag.InProgress = 0;
                ViewBag.Completed = 0;
                ViewBag.TodaysBookings = 0;
                ViewBag.UpcomingBookings = 0;
                ViewBag.RecentActivities = new List<dynamic>();

                return View();
            }
        }

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
                .Where(u => u.CheckupStatus.ToLower() == "failed" || u.CheckupStatus == "Failed")
                .OrderByDescending(u => u.VisitDate)
                .ToList();

            var serviceIds = failedVisits.Select(u => u.VisitId).ToList();
            var repair = _db.tblFaultTechnicians
                .Where(u => serviceIds.Contains((int)u.VisitId))
                .ToList();

            foreach (var fault in failedVisits)
            {
                fault.FaultTechnicians = repair.Where(u => u.VisitId == fault.VisitId).ToList();
            }

            return View(failedVisits);
        }

        public IActionResult BookFaultVisit(int RequestedFaultId, int? visitId)
        {
            var requestRepair = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                .ThenInclude(r => r.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(r => r.VisitId == RequestedFaultId && r.CheckupStatus == "Failed");

            if (requestRepair == null)
            {
                return NotFound();
            }

            ViewBag.RepairStatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Scrapped", Value = "Scrapped" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Resolved", Value = "Resolved" },
                new SelectListItem { Text = "Not Started", Value = "Not Started" }
            };

            FaultTechnician visit;

            if (visitId.HasValue)
            {
                visit = _db.tblFaultTechnicians
                       .Include(u => u.FridgeVisit)
                       .ThenInclude(u => u.RequestHeader)
                       .ThenInclude(u => u.RequestFridges)
                       .ThenInclude(u => u.Fridge)
                       .FirstOrDefault(u => u.FaultId == visitId.Value);

                if (visit == null)
                {
                    return NotFound();
                }
            }
            else
            {
                visit = new FaultTechnician
                {
                    VisitId = RequestedFaultId,
                    FridgeVisit = requestRepair,
                    Bookingate = DateTime.Now.AddDays(1)
                };
            }

            return View(visit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookFaultVisit(FaultTechnician fault)
        {
            if (ModelState.IsValid)
            {
                if (fault.FaultId == 0)
                {
                    _db.tblFaultTechnicians.Add(fault);
                }
                else
                {
                    _db.tblFaultTechnicians.Update(fault);
                }
                _db.SaveChanges();
                TempData[SD.Success] = "Booking successfully";

                return RedirectToAction("Index", new { id = fault.FaultId });
            }

            ViewBag.RepairStatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Scrapped", Value = "Scrapped" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Resolved", Value = "Resolved" },
                new SelectListItem { Text = "Not Started", Value = "Not Started" }
            };

            return View(fault);
        }

        // CUSTOMER FAULT REPORTING SECTION
        public IActionResult CustomerFaultReport(int visitId)
        {
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
                .FirstOrDefault(v => v.VisitId == visitId);

            if (visit == null)
            {
                TempData[SD.Error] = "Visit not found";
                return RedirectToAction("Index");
            }

            var customerFridge = visit.RequestHeader.RequestFridges
                .FirstOrDefault()?.CustomerFridges?.FirstOrDefault();

            if (customerFridge == null)
            {
                TempData[SD.Error] = "Customer fridge not found";
                return RedirectToAction("Index");
            }

            var viewModel = new CustomerFaultReportViewModel
            {
                VisitId = visitId,
                CustomerID = visit.RequestHeader.CustomerID,
                CustomerName = visit.RequestHeader.Customer.ApplicationUser?.FirstName + " " +
                            visit.RequestHeader.Customer.ApplicationUser?.LastName,
                FridgeNo = customerFridge.FridgeInStock?.FridgeNo ?? "Unknown",
                FridgeModel = visit.RequestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown Model",
                ReportDate = DateTime.Now
            };

            ViewBag.FaultTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Not Cooling", Value = "Not Cooling" },
                new SelectListItem { Text = "Strange Noises", Value = "Strange Noises" },
                new SelectListItem { Text = "Water Leakage", Value = "Water Leakage" },
                new SelectListItem { Text = "Electrical Issues", Value = "Electrical Issues" },
                new SelectListItem { Text = "Door Problems", Value = "Door Problems" },
                new SelectListItem { Text = "Other", Value = "Other" }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerFaultReport(CustomerFaultReportViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var visit = _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .FirstOrDefault(v => v.VisitId == viewModel.VisitId &&
                                       v.RequestHeader.CustomerID == viewModel.CustomerID);

                if (visit == null)
                {
                    TempData[SD.Error] = "Visit not found or doesn't belong to this customer";
                    return RedirectToAction("Index");
                }

                // Check if customer fault report already exists for this visit
                var existingFaultReport = _db.tblFaultTechnicians
                    .FirstOrDefault(ft => ft.VisitId == viewModel.VisitId && ft.TechnicianAssigned == null);

                if (existingFaultReport != null)
                {
                    TempData[SD.Error] = "A fault report already exists for this visit";
                    return RedirectToAction("CustomerFaultReports");
                }

                // Create customer fault report
                var faultReport = new FaultTechnician
                {
                    VisitId = viewModel.VisitId,
                    FaultDescription = viewModel.FaultDescription,
                    FaultType = viewModel.FaultType,
                    CustomerBookingStatus = SD.Pending,
                    RepairStatus = "Reported",
                    TechnicianAssigned = null,
                    ReportDate = DateTime.Now,
                    ResolutionNotes = viewModel.AdditionalNotes,
                    Bookingate = null,
                    Completion = null
                };

                _db.tblFaultTechnicians.Add(faultReport);
                _db.SaveChanges();

                TempData[SD.Success] = "Fault report submitted successfully! Our technicians will review it soon.";
                return RedirectToAction("CustomerFaultReports");
            }

            ViewBag.FaultTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Not Cooling", Value = "Not Cooling" },
                new SelectListItem { Text = "Strange Noises", Value = "Strange Noises" },
                new SelectListItem { Text = "Water Leakage", Value = "Water Leakage" },
                new SelectListItem { Text = "Electrical Issues", Value = "Electrical Issues" },
                new SelectListItem { Text = "Door Problems", Value = "Door Problems" },
                new SelectListItem { Text = "Other", Value = "Other" }
            };

            return View(viewModel);
        }

        // View customer's fault reports
        public IActionResult CustomerFaultReports()
        {
            var customerId = GetCurrentCustomerId();

            var faultReports = _db.tblFaultTechnicians
                .Include(ft => ft.FridgeVisit)
                    .ThenInclude(fv => fv.RequestHeader)
                        .ThenInclude(rh => rh.RequestFridges)
                            .ThenInclude(rf => rf.Fridge)
                .Where(ft => ft.FridgeVisit.RequestHeader.CustomerID == customerId &&
                             ft.TechnicianAssigned == null)
                .OrderByDescending(ft => ft.ReportDate)
                .ToList();

            return View(faultReports);
        }

        // Technicians view customer-reported faults
        public IActionResult PendingCustomerFaults()
        {
            var customerFaults = _db.tblFaultTechnicians
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

            return View(customerFaults);
        }

        // Technician assigns themselves to customer fault
        public IActionResult AssignToFault(int faultId)
        {
            var faultReport = _db.tblFaultTechnicians.Find(faultId);

            if (faultReport != null)
            {
                faultReport.TechnicianAssigned = User.Identity.Name;
                faultReport.RepairStatus = "Not Started";
                faultReport.CustomerBookingStatus = SD.Approved;
                _db.SaveChanges();

                TempData[SD.Success] = "Fault assigned to you successfully!";
                return RedirectToAction("BookFaultVisit", new { RequestedFaultId = faultReport.VisitId, visitId = faultId });
            }

            TempData[SD.Error] = "Fault report not found";
            return RedirectToAction("PendingCustomerFaults");
        }

        private int GetCurrentCustomerId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
            return customer?.CustomerID ?? 0;
        }
    }
}