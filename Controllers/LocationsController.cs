using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocationsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var locations = await _context.Locations
                .Include(l => l.Employees)
                .Include(l => l.Customers)
                .Include(l => l.Fridges)
                .Where(l => l.IsActive)
                .OrderBy(l => l.Province)
                .ThenBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .ToListAsync();

            return View(locations);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Employees).ThenInclude(e => e.UserAccount)
                .Include(l => l.Customers).ThenInclude(c => c.UserAccount)
                .Include(l => l.Fridges).ThenInclude(f => f.Status)
                .Include(l => l.FridgeAllocations).ThenInclude(a => a.Fridge)
                .Include(l => l.MaintenanceVisits).ThenInclude(m => m.AssignedTechnician)
                .Include(l => l.FaultReports).ThenInclude(f => f.AssignedTechnician)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null || !location.IsActive)
            {
                return NotFound();
            }

            // Get statistics for the dashboard
            ViewBag.EmployeeCount = location.Employees.Count(e => e.IsActive);
            ViewBag.CustomerCount = location.Customers.Count(c => c.IsActive);
            ViewBag.FridgeCount = location.Fridges.Count(f => f.Status == FridgeStatus.Available);
            ViewBag.ActiveAllocations = location.FridgeAllocations.Count(a => a.IsActive);
            ViewBag.PendingMaintenance = location.MaintenanceVisits.Count(m => m.Status == ServicingStatus.Scheduled);
            ViewBag.OpenFaults = location.FaultReports.Count(f => f.Status == FaultStatus.Reported || f.Status == FaultStatus.InProgress);

            return View(location);
        }

        // GET: Locations/Upsert
        public async Task<IActionResult> Upsert(int? id)
        {
            var vm = new LocationVM();

            if (id == null || id == 0)
            {
                // Create new location
                return View(vm);
            }
            else
            {
                // Edit existing location
                var location = await _context.Locations.FindAsync(id);
                if (location == null || !location.IsActive)
                {
                    return NotFound();
                }

                vm.Id = location.Id;
                vm.Name = location.Name;
                vm.AddressLine1 = location.AddressLine1;
                vm.AddressLine2 = location.AddressLine2;
                vm.Suburb = location.Suburb;
                vm.City = location.City;
                vm.Province = location.Province;
                vm.PostalCode = location.PostalCode;
                vm.Country = location.Country;
                vm.IsActive = location.IsActive;

                return View(vm);
            }
        }

        // POST: Locations/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(LocationVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new location
                        var location = new Location
                        {
                            Name = vm.Name?.Trim(),
                            AddressLine1 = vm.AddressLine1.Trim(),
                            AddressLine2 = vm.AddressLine2?.Trim(),
                            Suburb = vm.Suburb.Trim(),
                            City = vm.City.Trim(),
                            Province = vm.Province.Trim(),
                            PostalCode = vm.PostalCode.Trim(),
                            Country = vm.Country.Trim(),
                            IsActive = vm.IsActive,
                            CreatedAt = DateTime.UtcNow
                        };

                        _context.Locations.Add(location);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Location created successfully";
                    }
                    else
                    {
                        // Update existing location
                        var location = await _context.Locations.FindAsync(vm.Id);
                        if (location == null)
                        {
                            return NotFound();
                        }

                        location.Name = vm.Name?.Trim();
                        location.AddressLine1 = vm.AddressLine1.Trim();
                        location.AddressLine2 = vm.AddressLine2?.Trim();
                        location.Suburb = vm.Suburb.Trim();
                        location.City = vm.City.Trim();
                        location.Province = vm.Province.Trim();
                        location.PostalCode = vm.PostalCode.Trim();
                        location.Country = vm.Country.Trim();
                        location.IsActive = vm.IsActive;
                        location.UpdatedAt = DateTime.UtcNow;

                        _context.Locations.Update(location);
                        await _context.SaveChangesAsync();
                        TempData["success"] = "Location updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error saving location. Please check your data and try again.");
                    // Log the exception details
                    System.Diagnostics.Debug.WriteLine($"Database update error: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            // If we got here, something went wrong
            return View(vm);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Employees)
                .Include(l => l.Customers)
                .Include(l => l.Fridges)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null || !location.IsActive)
            {
                return NotFound();
            }

            // Check if location can be deleted (has no active references)
            ViewBag.CanDelete = !location.Employees.Any(e => e.IsActive) &&
                               !location.Customers.Any(c => c.IsActive) &&
                               !location.Fridges.Any(f => f.Status == FridgeStatus.Available);

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Employees)
                .Include(l => l.Customers)
                .Include(l => l.Fridges)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            // Check if location has active references
            if (location.Employees.Any(e => e.IsActive) ||
                location.Customers.Any(c => c.IsActive) ||
                location.Fridges.Any(f => f.Status == FridgeStatus.Available))
            {
                TempData["error"] = "Cannot delete location. It has active employees, customers, or fridges assigned.";
                return RedirectToAction(nameof(Delete), new { id });
            }

            // Soft delete (as per project checklist)
            location.IsActive = false;
            location.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            TempData["success"] = "Location deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // AJAX: Check if location name exists
        [AcceptVerbs("GET", "POST")]
        public async Task<JsonResult> CheckLocationNameExists(string name, int id = 0)
        {
            var exists = await _context.Locations
                .AnyAsync(l => l.Name == name.Trim() && l.Id != id && l.IsActive);

            return Json(!exists);
        }

        // AJAX: Get locations by province
        public async Task<JsonResult> GetLocationsByProvince(string province)
        {
            var locations = await _context.Locations
                .Where(l => l.Province == province && l.IsActive)
                .OrderBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .Select(l => new { l.Id, DisplayName = $"{l.Suburb}, {l.City} - {l.Name}" })
                .ToListAsync();

            return Json(locations);
        }

        // AJAX: Get provinces
        public async Task<JsonResult> GetProvinces()
        {
            var provinces = await _context.Locations
                .Where(l => l.IsActive)
                .Select(l => l.Province)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();

            return Json(provinces);
        }

        // AJAX: Get cities by province
        public async Task<JsonResult> GetCities(string province)
        {
            var cities = await _context.Locations
                .Where(l => l.Province == province && l.IsActive)
                .Select(l => l.City)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            return Json(cities);
        }

        // AJAX: Get suburbs by city
        public async Task<JsonResult> GetSuburbs(string province, string city)
        {
            var suburbs = await _context.Locations
                .Where(l => l.Province == province && l.City == city && l.IsActive)
                .Select(l => l.Suburb)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();

            return Json(suburbs);
        }
    }
}
