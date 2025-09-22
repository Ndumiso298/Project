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
            var allocatedRequests =  _db.RequestHeaders
                .Include(r => r.Customer)
                .Include(r => r.RequestFridges) 
                    .ThenInclude(f => f.Fridge)
                .Where(r => r.Status == "Allocated")
                .ToList();

            return View(allocatedRequests);
        }

       
        public  IActionResult Details(int id)
        {
            var request =  _db.RequestHeaders
                .Include(r => r.Customer)
                .Include(r => r.RequestFridges)
                    .ThenInclude(f => f.Fridge)
                .FirstOrDefault(r => r.Id == id && r.Status == "Allocated");

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

       
        public  IActionResult BookVisit(int allocationId)
        {
            var allocation =  _db.FridgeAllocations
                .Include(a => a.Fridge)
                .FirstOrDefault(a => a.Id == allocationId);

            if (allocation == null)
                return NotFound();

            var visit = new MaintenanceVisit { AllocationId = allocationId };
            ViewBag.FridgeInfo = allocation.Fridge.Manufacturer + " - " + allocation.Fridge.SerialNumber;

            return View(visit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookVisit(MaintenanceVisit visit)
        {
            if (ModelState.IsValid)
            {
                _db.MaintenanceVisits.Add(visit);
                 _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var allocation =  _db.FridgeAllocations.Include(a => a.Fridge)
             .FirstOrDefault(a => a.Id == visit.AllocationId);
            ViewBag.FridgeInfo = allocation?.Fridge.Manufacturer + " - " + allocation?.Fridge.SerialNumber;
            return View(visit);
        }

    }
}
