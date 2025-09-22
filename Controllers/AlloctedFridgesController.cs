using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;


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
            var visits = _db.tblFridgeVisits
                .Include(v => v.RequestHeader)
                .ThenInclude(r => r.ApplicationUser)
                .Include(v => v.RequestHeader)
                .ThenInclude(r => r.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .ToList();

            return View(visits);
        }

        public IActionResult Index()
        {

            var allocatedRequests = _db.tblRequestHeaders
              .Include(r => r.ApplicationUser)
              .Include(r => r.RequestFridges)
              .ThenInclude(f => f.Fridge)
              .Where(r => r.Status == "Allocated")
              .ToList();

            var requestIds = allocatedRequests.Select(r => r.RequestHeaderId).ToList();
            var visits = _db.tblFridgeVisits.Where(v => requestIds.Contains(v.RequestHeaderId)).ToList();

            foreach (var request in allocatedRequests)
            {
                request.FridgeVisits = visits.Where(v => v.RequestHeaderId == request.RequestHeaderId).ToList();
            }

            return View(allocatedRequests);


        }


        public  IActionResult Details(int id)
        {
            var request =  _db.tblRequestHeaders
                .Include(r => r.ApplicationUser)
                .Include(r => r.RequestFridges)
                .ThenInclude(f => f.Fridge)
                .FirstOrDefault(r => r.RequestHeaderId == id && r.Status == "Allocated");

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }
        public IActionResult BookVisit(int requestId, int? visitId)
        {
            var request = _db.tblRequestHeaders
                .Include(r => r.RequestFridges)
                .ThenInclude(rf => rf.Fridge)
                .FirstOrDefault(r => r.RequestHeaderId == requestId && r.Status == "Allocated");

            if (request == null)
            {
                return NotFound();
            }

            FridgeVisit visit;

            if (visitId.HasValue)
            {
                visit = _db.tblFridgeVisits
                    .Include(v => v.RequestHeader)
                    .ThenInclude(r => r.RequestFridges)
                    .ThenInclude(rf => rf.Fridge)
                    .FirstOrDefault(v => v.VisitId == visitId.Value);

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
                return RedirectToAction("Index", new { id = visit.RequestHeaderId });
            }

            return View(visit);
        }
    }

}

