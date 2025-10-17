
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;
using System.Security.Claims;


namespace Project.Controllers
{
    public class AllocatedFridgesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AllocatedFridgesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Calendar()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var visits = _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                //.Where(u => u.RequestHeader.ApplicationUserId == userId)
                .ToList();

            return View(visits);
        }


        public IActionResult Index()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var allocatedRequests = _db.tblRequestHeaders
                .Include(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Where(u => u.Status ==SD.Approved) 
                .ToList();

            var requestIds = allocatedRequests
                .Select(u => u.RequestHeaderId)
                .ToList();
            var visits = _db.tblFridgeVisits
                .Where(u => requestIds
                .Contains(u.RequestHeaderId))
                .ToList();

            foreach (var request in allocatedRequests)
            {
                request.FridgeVisits = visits.Where(u => u.RequestHeaderId == request.RequestHeaderId).ToList();
            }

            return View(allocatedRequests);
        }
        public IActionResult CustomerBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var requests = _db.tblRequestHeaders
                .Include(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .Include(u => u.FridgeVisits) 
                .Where(u => u.Customer.ApplicationUserId == userId && u.Status == SD.Approved)
                .ToList();

            return View(requests);
        }

        public IActionResult DetailsFoRProcessing(int id)
        {
            var request = _db.tblRequestHeaders
                .Include(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)
                .FirstOrDefault(u => u.RequestHeaderId == id && u.Status == SD.Approved);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        public IActionResult SafetyGuideLines()
        {
            return View();
        }

        public  IActionResult Completed()
        {
            var visits =  _db.tblFridgeVisits
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.Customer.ApplicationUser)
                .Include(u => u.RequestHeader)
                .ThenInclude(u => u.RequestFridges)
                .ThenInclude(u => u.Fridge)      
                .ToList();

            return View(visits);
        }

        public IActionResult BookVisit(int requestId, int? visitId)
        {
            var request = _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(r => r.RequestHeaderId == requestId && r.Status == SD.Approved);

            if (request == null)
            {
                return NotFound();
            }
            ViewBag.CheckupStatusList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Passed", Value = "Passed" },
                new SelectListItem { Text = "Failed", Value = "Failed" },
                new SelectListItem { Text = "In Progress", Value = "In Progress" },
                new SelectListItem { Text = "Not Started", Value = "Not Started" }
            };
            FridgeVisit visit;

            if (visitId.HasValue)
            {
                visit = _db.tblFridgeVisits
                    .Include(u => u.RequestHeader)
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
                visit = new FridgeVisit
                {
                    RequestHeaderId = requestId,
                    RequestHeader = request,
                    VisitDate = DateTime.Now.AddDays(1)
                };
            }

            return View(visit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookVisit(FridgeVisit visit)
        {
            if (ModelState.IsValid)
            {
                if (visit.VisitId == 0)
                {
                    _db.tblFridgeVisits.Add(visit);
                }
                else
                {
                    _db.tblFridgeVisits.Update(visit);
                }
                _db.SaveChanges();
                TempData[SD.Success] = "Booking successfully";

                return RedirectToAction("Index", new { id = visit.RequestHeaderId });
            }
            ViewBag.CheckupStatusList = new List<SelectListItem>
            {
               new SelectListItem { Text = "Passed", Value = "Passed" },
               new SelectListItem { Text = "Failed", Value = "Failed" },
               new SelectListItem { Text = "In Progress", Value = "In Progress" },
            };

            
            return View(visit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveVisit(int visitId)
        {
            var visit = _db.tblFridgeVisits.Find(visitId);
            if (visit == null)
            {
                return NotFound();
            }

            visit.CustomerApproval = SD.Approved;
            _db.SaveChanges();
            TempData[SD.Success] = "Visit successfully Approved";

            return RedirectToAction("CustomerBookings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineVisit(int visitId)
        {
            var visit = _db.tblFridgeVisits.Find(visitId);
            if (visit == null)
            {
                return NotFound();
            }

            visit.CustomerApproval = SD.Declined;
            _db.SaveChanges();
            TempData[SD.Error] = "Visit successfully Decline";

            return RedirectToAction("CustomerBookings");
        }
    }
}


