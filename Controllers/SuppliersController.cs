using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Utility;
using Microsoft.EntityFrameworkCore;
using Project.Models.ViewModel;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockController)]
public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SuppliersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Supplier
        public async Task<IActionResult> Index()
        {
            var suppliers = await _db.tblSuppliers
                .Include(s => s.Location)
                .ToListAsync();
            return View(suppliers);
        }

        // GET: Supplier/Upsert/{id?}
        public async Task<IActionResult> Upsert(int? id)
        {
            var vm = new SupplierVM
            {
                AvailableFridges = _db.tblFridges
                    .Select(f => new SelectListItem
                    {
                        Value = f.FridgeId.ToString(),
                        Text = $"{f.Brand} {f.Model}"
                    })
                    .ToList(),
                LocationId = 0
            };

            if (id == null || id == 0)
            {
                // Create mode
                ViewBag.Locations = new SelectList(_db.tblLocations, "LocationId", "DisplayName");
                return View(vm);
            }

            // Edit mode
            var supplier = await _db.tblSuppliers
                .Include(s => s.SuppliedFridges)
                .FirstOrDefaultAsync(s => s.SupplierId == id);

            if (supplier == null) return NotFound();

            vm.SupplierId = supplier.SupplierId;
            vm.Name = supplier.Name;
            vm.ContactPerson = supplier.ContactPerson;
            vm.Email = supplier.Email;
            vm.Phone = supplier.Phone;
            vm.LocationId = supplier.LocationId;
            vm.SelectedFridgeIds = supplier.SuppliedFridges?.Select(sf => sf.FridgeId).ToList();

            ViewBag.Locations = new SelectList(_db.tblLocations, "LocationId", "DisplayName", supplier.LocationId);
            return View(vm);
        }

        // POST: Supplier/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SupplierVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locations = new SelectList(_db.tblLocations, "LocationId", "DisplayName", vm.LocationId);
                vm.AvailableFridges = _db.tblFridges.Select(f => new SelectListItem
                {
                    Value = f.FridgeId.ToString(),
                    Text = $"{f.Brand} {f.Model}"
                });
                return View(vm);
            }

            Supplier supplier;

            if (vm.SupplierId == 0)
            {
                // Create new
                supplier = new Supplier
                {
                    Name = vm.Name,
                    ContactPerson = vm.ContactPerson,
                    Email = vm.Email,
                    Phone = vm.Phone,
                    LocationId = vm.LocationId
                };
                _db.tblSuppliers.Add(supplier);
            }
            else
            {
                // Update existing
                supplier = await _db.tblSuppliers
                    .Include(s => s.SuppliedFridges)
                    .FirstOrDefaultAsync(s => s.SupplierId == vm.SupplierId);

                if (supplier == null) return NotFound();

                supplier.Name = vm.Name;
                supplier.ContactPerson = vm.ContactPerson;
                supplier.Email = vm.Email;
                supplier.Phone = vm.Phone;
                supplier.LocationId = vm.LocationId;

                // Update fridge relationships
                supplier.SuppliedFridges.Clear();
            }

            // Re-attach fridge links
            if (vm.SelectedFridgeIds != null && vm.SelectedFridgeIds.Any())
            {
                supplier.SuppliedFridges = vm.SelectedFridgeIds
                    .Select(fid => new SupplierFridge { SupplierId = supplier.SupplierId, FridgeId = fid })
                    .ToList();
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _db.tblSuppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            _db.tblSuppliers.Remove(supplier);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
