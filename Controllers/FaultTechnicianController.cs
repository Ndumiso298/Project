
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
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
            return View();
        }
        public IActionResult Calendar()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var visits = _db.tblFaultTechnicians
                .Include(u => u.FridgeVisit)
                .ThenInclude(u=>u.RequestHeader)
                .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.FridgeVisit)
                .ThenInclude(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                //.Where(u => u.RequestHeader.ApplicationUserId == userId)
                .ToList();

            return View(visits);
        }

        public IActionResult Index()
        {
            var failedVisits =  _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.Customer.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(rh => rh.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .Where(v => v.CheckupStatus.ToLower() == "failed" ||
                 v.CheckupStatus =="Failed") 
                .OrderByDescending(v => v.VisitDate)
                .ToList();


               var ServiceIds = failedVisits
              .Select(u => u.VisitId)
              .ToList();
            var Repair = _db.tblFaultTechnicians
                .Where(u => ServiceIds
                .Contains(u.VisitId))
                .ToList();

            foreach (var fault in failedVisits)
            {
                fault.FaultTechnicians = Repair.Where(u => u.VisitId == fault.RequestHeaderId).ToList();
            }
            return View(failedVisits);
        }


        public IActionResult BookFaultVisit(int FaultId, int? visitId)
        {
            var requestRepair = _db.tblFaultTechnicians
                .Include(u=>u.FridgeVisit)
                .ThenInclude(r => r.RequestHeader)
                .ThenInclude(r => r.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(r => r.FaultId == FaultId && r.FridgeVisit.CheckupStatus == "Failed");

            if (requestRepair == null)
            {
                return NotFound();
            }
            ViewBag.CheckupStatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Scrapped", Value = "Scrapped" },
                new SelectListItem { Text = "Completed", Value = "Completed" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Not Started", Value = "Not Started" }
            };
            FaultTechnician visit;

            if (visitId.HasValue)
            {
                visit = _db.tblFaultTechnicians
                    .Include (u => u.FridgeVisit)
                    .ThenInclude(u => u.RequestHeader)
                    .ThenInclude(u => u.RequestFridges)
                    .ThenInclude(u => u.Fridge)
                    .FirstOrDefault(u => u.VisitId == visitId.Value);

                if (visit == null)
                {
                    return NotFound();
                }
            }
            else
            {
                visit = new FaultTechnician
                {
                    VisitId = FaultId,
                    //FridgeVisit = requestRepair,
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
                if (fault.VisitId == 0)
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
            ViewBag.CheckupStatusList = new List<SelectListItem>
            {
               new SelectListItem { Text = "Passed", Value = "Passed" },
               new SelectListItem { Text = "Failed", Value = "Failed" },
               new SelectListItem { Text = "In Progress", Value = "In Progress" },
            };


            return View(fault);
        }

    }

       
}


