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
    [Authorize(Roles = StaticDetails.AdminRole)]
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LocationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Locations.Include(l => l.Suburb);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _db.Locations
                .Include(l => l.Suburb)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["SuburbId"] = new SelectList(_db.Suburbs, "Id", "Name");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SuburbId,AddressLine1,AddressLine2,CreatedAt,UpdatedAt,IsDeleted")] Location location)
        {
            if (ModelState.IsValid)
            {
                _db.Add(location);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuburbId"] = new SelectList(_db.Suburbs, "Id", "Name", location.SuburbId);
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _db.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["SuburbId"] = new SelectList(_db.Suburbs, "Id", "Name", location.SuburbId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SuburbId,AddressLine1,AddressLine2,CreatedAt,UpdatedAt,IsDeleted")] Location location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(location);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.Id))
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
            ViewData["SuburbId"] = new SelectList(_db.Suburbs, "Id", "Name", location.SuburbId);
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _db.Locations
                .Include(l => l.Suburb)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _db.Locations.FindAsync(id);
            if (location != null)
            {
                _db.Locations.Remove(location);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _db.Locations.Any(e => e.Id == id);
        }
    }
}
