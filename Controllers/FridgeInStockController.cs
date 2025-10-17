using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;

namespace Project.Controllers
{
    public class FridgeInStockController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgeInStockController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Manage(int? id)
        {
            if (id == null) return NotFound();

            var fridge = _db.tblFridges
                .Include(f => f.FridgeInstances)
                .FirstOrDefault(m => m.FridgeId == id);

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

            var viewModel = new CreateFridgeInstancesVM
            {
                FridgeId = fridgeId,
                FridgeModel = $"{fridge.Brand} {fridge.Model}",
                Quantity = 1,
                LastMaintenanceDate = DateTime.Now,
                Condition = "Excellent",
                Location = fridge.Location ?? "Warehouse"
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateFridgeInstancesVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var fridge = _db.tblFridges.Find(viewModel.FridgeId);
                if (fridge == null)
                {
                    ModelState.AddModelError("", "Fridge model not found");
                    return View(viewModel);
                }

                var existingInstancesCount =  _db.tblFridgeInStocks
                    .Count(f => f.FridgeId == viewModel.FridgeId);

                var fridgeInstances = new List<FridgeInStock>();

                for (int i = 1; i <= viewModel.Quantity; i++)
                {
                    var fridgeNo = GenerateFridgeNumber(fridge, existingInstancesCount + i);

                    var fridgeInstance = new FridgeInStock
                    {
                        FridgeId = viewModel.FridgeId,
                        FridgeNo = fridgeNo,
                        LastMaintenanceDate = viewModel.LastMaintenanceDate,
                        Condition = viewModel.Condition,
                        IsAvailable = true,
                        Quantity = 1,
                        Location = viewModel.Location
                    };

                    fridgeInstances.Add(fridgeInstance);
                }

                _db.tblFridgeInStocks.AddRange(fridgeInstances);
                _db.SaveChanges();

                TempData[SD.Success] = $"{viewModel.Quantity} fridge instance(s) created successfully!";
                return RedirectToAction(nameof(Manage), new { id = viewModel.FridgeId });
            }

            // Reload fridge model name if validation fails
            var fridgeReload = _db.tblFridges.Find(viewModel.FridgeId);
            if (fridgeReload != null)
            {
                viewModel.FridgeModel = $"{fridgeReload.Brand} {fridgeReload.Model}";
            }

            return View(viewModel);
        }

        private string GenerateFridgeNumber(Fridge fridge, int sequenceNumber)
        {
            var brandCode = fridge.Brand.Length >= 3 ? fridge.Brand.Substring(0, 3)
                .ToUpper() : fridge.Brand.ToUpper().PadRight(3, 'X');
            var modelCode = fridge.Model.Length >= 3 ? fridge.Model.Substring(0, 3)
                .ToUpper() : fridge.Model.ToUpper().PadRight(3, 'X');

            brandCode = System.Text.RegularExpressions.Regex
                .Replace(brandCode, "[^A-Z0-9]", "X");
            modelCode = System.Text.RegularExpressions
                .Regex.Replace(modelCode, "[^A-Z0-9]", "X");

            return $"FRG-{brandCode}-{modelCode}-{sequenceNumber:000}";
        }

        public  IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var fridgeInStock = _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .FirstOrDefault(m => m.FridgeInStockId == id);

            if (fridgeInStock == null) return NotFound();

            return View(fridgeInStock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FridgeInStock fridgeInStock)
        {
            if (id != fridgeInStock.FridgeInStockId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridgeInStock);
                    _db.SaveChanges();
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
        public IActionResult ToggleAvailability(int id)
        {
            var fridgeInStock = _db.tblFridgeInStocks.Find(id);
            if (fridgeInStock == null)
            {
                return NotFound();
            }

            fridgeInStock.IsAvailable = !fridgeInStock.IsAvailable;
            _db.Update(fridgeInStock);
            _db.SaveChangesAsync();

            return RedirectToAction(nameof(Manage), new { id = fridgeInStock.FridgeId });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridgeInStock = _db.tblFridgeInStocks
                .Include(f => f.Fridge)
                .FirstOrDefault(m => m.FridgeInStockId == id);

            if (fridgeInStock == null) return NotFound();

            return View(fridgeInStock);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var fridgeInStock = _db.tblFridgeInStocks.Find(id);
            if (fridgeInStock != null)
            {
                var fridgeId = fridgeInStock.FridgeId;
                _db.tblFridgeInStocks.Remove(fridgeInStock);
                _db.SaveChangesAsync();
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