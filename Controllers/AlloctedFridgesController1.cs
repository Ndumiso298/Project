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

       
        public  IActionResult Index()
        {
            var allocatedRequests =  _db.tblRequestHeaders
                .Include(r => r.ApplicationUser)
                .Include(r => r.RequestFridges) 
                    .ThenInclude(f => f.Fridge)
                .Where(r => r.Status == "Allocated")
                .ToList();

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

       
        public  IActionResult BookVisit(int allocationId)
        {
            var allocation =  _db.tblAllocations
                .Include(a => a.Fridge)
                .FirstOrDefault(a => a.AllocationId == allocationId);

            if (allocation == null)
                return NotFound();

            var visit = new FridgeVisit { AllocationId = allocationId };
            ViewBag.FridgeInfo = allocation.Fridge.Brand + " - " + allocation.Fridge.FridgeNo;

            return View(visit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookVisit(FridgeVisit visit)
        {
            if (ModelState.IsValid)
            {
                _db.tblFridgeVisits.Add(visit);
                 _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var allocation =  _db.tblAllocations.Include(a => a.Fridge)
             .FirstOrDefault(a => a.AllocationId == visit.AllocationId);
            ViewBag.FridgeInfo = allocation?.Fridge.Brand + " - " + allocation?.Fridge.FridgeNo;
            return View(visit);
        }

    }
}
