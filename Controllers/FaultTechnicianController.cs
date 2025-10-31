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
    }
}