using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;

namespace Project.Controllers
{
    public class FridgeInStockController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeInStockController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Manage(int? id)
        {
            if (id == null) return NotFound();

            var fridge = await _db.tblFridges
                .Include(f => f.FridgeInstances)
                .FirstOrDefaultAsync(m => m.FridgeId == id);

            if (fridge == null) return NotFound();

            var viewModel = new FridgeStockVM
            {
                FridgeModel = fridge,
                TotalInstances = fridge.FridgeInstances.Count,
                AvailableInstances = fridge.FridgeInstances.Count(i => i.IsAvailable),
                RentedInstances = fridge.FridgeInstances.Count(i => !i.IsAvailable),
                FridgeInstances = fridge.FridgeInstances.ToList()
            };

            return View(viewModel);
        }

        public IActionResult Create(int fridgeId)
        {
            var fridge = _db.tblFridges.Find(fridgeId);
            if (fridge == null) return NotFound();

            var fridgeInStock = new FridgeInStock
            {
                FridgeId = fridgeId,
                LastMaintenanceDate = DateTime.Now,
                Condition = "Excellent",
                IsAvailable = true
            };

            ViewData["FridgeModel"] = $"{fridge.Brand} {fridge.Model}";
            return View(fridgeInStock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeInStock fridgeInStock)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(fridgeInStock.FridgeNo))
                {
                    var fridge = await _db.tblFridges.FindAsync(fridgeInStock.FridgeId);
                    var existingCount = await _db.tblFridgeInStocks
                        .CountAsync(f => f.FridgeId == fridgeInStock.FridgeId);

                    fridgeInStock.FridgeNo = $"{fridge.Brand.Substring(0, 3).ToUpper()}-{fridge.Model.Substring(0, 3).ToUpper()}-{existingCount + 1:000}";
                }

                _db.Add(fridgeInStock);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Manage), new { id = fridgeInStock.FridgeId });
            }
            return View(fridgeInStock);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fridgeInStock = await _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .FirstOrDefaultAsync(m => m.FridgeInStockId == id);

            if (fridgeInStock == null) return NotFound();

            return View(fridgeInStock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FridgeInStock fridgeInStock)
        {
            if (id != fridgeInStock.FridgeInStockId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridgeInStock);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeInStockExists(fridgeInStock.FridgeInStockId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Manage), new { id = fridgeInStock.FridgeId });
            }
            return View(fridgeInStock);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAvailability(int id)
        {
            var fridgeInStock = await _db.tblFridgeInStocks.FindAsync(id);
            if (fridgeInStock == null)
            {
                return NotFound();
            }

            fridgeInStock.IsAvailable = !fridgeInStock.IsAvailable;
            _db.Update(fridgeInStock);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Manage), new { id = fridgeInStock.FridgeId });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeInStock = await _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .FirstOrDefaultAsync(m => m.FridgeInStockId == id);

            if (fridgeInStock == null) return NotFound();

            return View(fridgeInStock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fridgeInStock = await _db.tblFridgeInStocks.FindAsync(id);
            if (fridgeInStock != null)
            {
                var fridgeId = fridgeInStock.FridgeId;
                _db.tblFridgeInStocks.Remove(fridgeInStock);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Manage), new { id = fridgeId });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeInStockExists(int id)
        {
            return _db.tblFridgeInStocks.Any(e => e.FridgeInStockId == id);
        }
    }
}
