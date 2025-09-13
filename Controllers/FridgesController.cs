using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.StockControllerRole)]
    public class FridgesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FridgesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Fridges
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Fridges.Include(f => f.StockController);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fridges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _db.Fridges
                .Include(f => f.StockController)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // GET: Fridges/Create
        public IActionResult Create()
        {
            ViewData["StockControllerId"] = new SelectList(_db.StockControllers, "Id", "Discriminator");
            return View();
        }

        // POST: Fridges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StockControllerId,SerialNumber,Manufacturer,Model,CapacityLiters,EnergyRating,Condition,Status,PurchaseDate,CreatedAt,UpdatedAt,WarrantyExpiryDate,ImageUrl")] Fridge fridge)
        {
            if (ModelState.IsValid)
            {
                _db.Add(fridge);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StockControllerId"] = new SelectList(_db.StockControllers, "Id", "Discriminator", fridge.StockControllerId);
            return View(fridge);
        }

        // GET: Fridges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _db.Fridges.FindAsync(id);
            if (fridge == null)
            {
                return NotFound();
            }
            ViewData["StockControllerId"] = new SelectList(_db.StockControllers, "Id", "Discriminator", fridge.StockControllerId);
            return View(fridge);
        }

        // POST: Fridges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StockControllerId,SerialNumber,Manufacturer,Model,CapacityLiters,EnergyRating,Condition,Status,PurchaseDate,CreatedAt,UpdatedAt,WarrantyExpiryDate,ImageUrl")] Fridge fridge)
        {
            if (id != fridge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(fridge);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeExists(fridge.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StockControllerId"] = new SelectList(_db.StockControllers, "Id", "Discriminator", fridge.StockControllerId);
            return View(fridge);
        }

        // GET: Fridges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fridge = await _db.Fridges
                .Include(f => f.StockController)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // POST: Fridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fridge = await _db.Fridges.FindAsync(id);
            if (fridge != null)
            {
                _db.Fridges.Remove(fridge);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeExists(int id)
        {
            return _db.Fridges.Any(e => e.Id == id);
        }
    }
}
