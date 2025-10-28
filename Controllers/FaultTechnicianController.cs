
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

                // Get pending faults (faults without any technician assignment)
                var pendingFaults = _db.tblFridgeVisits
                    .Count(v => (v.CheckupStatus.ToLower() == "failed" || v.CheckupStatus == "Failed") &&
                               !v.FaultTechnicians.Any());

                // Get in-progress repairs
                var inProgress = _db.tblFaultTechnicians
                    .Count(ft => ft.RepairStatus == "In Progress");

                // Get completed repairs
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
                .Where(u => serviceIds.Contains(u.VisitId))
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

        public IActionResult RequestReplacement(int visitId)
        {
            // Get the visit details
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

            // Get customer's current fridge
            var customerFridge = visit.RequestHeader.RequestFridges
                .FirstOrDefault()?.CustomerFridges
                .FirstOrDefault();

            if (customerFridge == null)
            {
                TempData[SD.Error] = "Customer fridge not found";
                return RedirectToAction("Index");
            }

            var viewModel = new FridgeReplacementViewModel
            {
                VisitId = visitId,
                CustomerID = visit.RequestHeader.CustomerID,
                CustomerName = visit.RequestHeader.Customer.ApplicationUser?.FirstName + " " +
                              visit.RequestHeader.Customer.ApplicationUser?.LastName,
                OldFridgeNo = customerFridge.FridgeInStock?.FridgeNo ?? "Unknown",
                FridgeModel = visit.RequestHeader.RequestFridges.FirstOrDefault()?.Fridge?.Model ?? "Unknown Model",
                ReplacementDate = DateTime.Now
            };

            ViewBag.ReplacementReasons = new List<SelectListItem>
            {
                new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
                new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
                new SelectListItem { Text = "Old Age", Value = "Old Age" },
                new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
                new SelectListItem { Text = "Other", Value = "Other" }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult RequestReplacement(FridgeReplacementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              
                    var visit = _db.tblFridgeVisits
                        .Include(v => v.RequestHeader)
                        .FirstOrDefault(v => v.VisitId == viewModel.VisitId &&
                                           v.RequestHeader.CustomerID == viewModel.CustomerID);

                    if (visit == null)
                    {
                        TempData[SD.Error] = "Visit not found or doesn't belong to this customer";
                        return RedirectToAction("Index");
                    }

                    var customer = _db.tblCustomer.Find(viewModel.CustomerID);
                    if (customer == null)
                    {
                        TempData[SD.Error] = "Customer not found";
                        return RedirectToAction("Index");
                    }

                    var existingReplacement = _db.tblFridgeReplacements
                        .FirstOrDefault(fr => fr.VisitId == viewModel.VisitId &&
                                             fr.ReplacementStatus != "Rejected");

                    if (existingReplacement != null)
                    {
                        TempData[SD.Error] = "A replacement request already exists for this visit";
                        return RedirectToAction("ReplacementRequests");
                    }

                    var replacement = new FridgeReplacement
                    {
                        VisitId = viewModel.VisitId,
                        CustomerID = viewModel.CustomerID,
                        OldFridgeNo = viewModel.OldFridgeNo,
                        ReasonForReplacement = viewModel.ReasonForReplacement,
                        AdditionalNotes = viewModel.AdditionalNotes,
                        ReplacementDate = viewModel.ReplacementDate,
                        RequestDate = DateTime.Now,
                        ReplacementStatus = "Pending"
                    };

                    _db.tblFridgeReplacements.Add(replacement);
                    _db.SaveChanges();

                    TempData[SD.Success] = "Fridge replacement request submitted successfully!";
                    return RedirectToAction("ReplacementRequests");
               
            }

            ViewBag.ReplacementReasons = new List<SelectListItem>
            {
               new SelectListItem { Text = "Fridge Beyond Repair", Value = "Fridge Beyond Repair" },
               new SelectListItem { Text = "Frequent Breakdowns", Value = "Frequent Breakdowns" },
               new SelectListItem { Text = "Old Age", Value = "Old Age" },
               new SelectListItem { Text = "Customer Request", Value = "Customer Request" },
               new SelectListItem { Text = "Other", Value = "Other" }
             };

            var customerData = _db.tblCustomer
                .Include(c => c.ApplicationUser)
                .FirstOrDefault(c => c.CustomerID == viewModel.CustomerID);

            if (customerData != null)
            {
                viewModel.CustomerName = customerData.ApplicationUser?.FirstName + " " +
                                       customerData.ApplicationUser?.LastName;
            }

            return View(viewModel);
        }

        public IActionResult ReplacementRequests()
        {
            var customerId = GetCurrentCustomerId();

            var replacements = _db.tblFridgeReplacements
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .Where(fr => fr.CustomerID == customerId)
                .OrderByDescending(fr => fr.OldFridgeNo)
                .ToList();

            return View(replacements);
        }

        // GET: Replacement request details
        public IActionResult ReplacementDetails(int id)
        {
            var customerId = GetCurrentCustomerId();

            var replacement = _db.tblFridgeReplacements
                .Include(fr => fr.FridgeVisit)
                .ThenInclude(fv => fv.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Include(fr => fr.NewFridgeInStock)
                .ThenInclude(nf => nf.Fridge)
                .FirstOrDefault(fr => fr.FridgeReplacementId == id && fr.CustomerID == customerId);

            if (replacement == null)
            {
                TempData[SD.Error] = "Replacement request not found";
                return RedirectToAction("ReplacementRequests");
            }

            return View(replacement);
        }

        // Helper method to get current customer ID
        private int GetCurrentCustomerId()
        {
            // Adjust this based on your authentication system
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
            return customer?.CustomerID ?? 0;
        }
    

    }
} 




