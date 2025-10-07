using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Linq;

namespace Project.Controllers
{
    public class FridgeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            var fridgeModels = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .ToList();

            var dashboard = new DashboardVM
            {
                TotalFridgeModels = fridgeModels.Count,
                TotalFridgeInstances = fridgeModels.Sum(f => f.FridgeInstances.Count),
                TotalAvailableInstances = fridgeModels.Sum(f => f.FridgeInstances.Count(i => i.IsAvailable)),
                TotalRentedInstances = fridgeModels.Sum(f => f.FridgeInstances.Count(i => !i.IsAvailable)),
                FridgeStock = fridgeModels.Select(f => new FridgeStockVM
                {
                    FridgeModel = f,
                    TotalInstances = f.FridgeInstances.Count,
                    AvailableInstances = f.FridgeInstances.Count(i => i.IsAvailable),
                    RentedInstances = f.FridgeInstances.Count(i => !i.IsAvailable),
                    FridgeInstances = f.FridgeInstances.ToList()
                }).ToList()
            };

            return View(dashboard);
        }

        public IActionResult Manage()
        {
            var fridges = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .ToList();
            return View(fridges);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fridge fridge)
        {
            if (ModelState.IsValid)
            {
                _db.Add(fridge);
                _db.SaveChanges();
                return RedirectToAction(nameof(Manage));
            }
            return View(fridge);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }
            var fridge = _db.tblFridges.FirstOrDefault(u => u.FridgeId == id);
            if (fridge == null) return NotFound();

            return View(fridge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Fridge fridge)
        {
            if (id != fridge.FridgeId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridge);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeExists(fridge.FridgeId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Manage));
            }
            return View(fridge);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var fridge =  _db.tblFridges
                .FirstOrDefault(m => m.FridgeId == id);
            if (fridge == null) return NotFound();

            return View(fridge);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var fridge =  _db.tblFridges.FirstOrDefault(u=>u.FridgeId==id);
            if (fridge != null)
            {
                _db.tblFridges.Remove(fridge);
            }

             _db.SaveChanges();
            return RedirectToAction(nameof(Manage));
        }

        private bool FridgeExists(int id)
        {
            return _db.tblFridges.Any(e => e.FridgeId == id);
        }
    }
}