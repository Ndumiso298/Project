using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Utility;
using Project.Utility.Enums;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, ILogger<LocationsController> logger)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // GET: Locations
        public async Task<IActionResult> Index(string searchString, string provinceFilter, string cityFilter, string typeFilter, string statusFilter, int page = 1, int pageSize = 10)
        {
            try
            {
                var locationsQuery = _db.tblLocations
                    .Include(l => l.Employees)
                    .Include(l => l.Customers)
                    .Include(l => l.Fridges)
                    .Where(l => l.IsActive)
                    .AsQueryable();

                // Apply filters
                if (!string.IsNullOrEmpty(searchString))
                {
                    locationsQuery = locationsQuery.Where(l =>
                        l.Suburb.Contains(searchString) ||
                        l.City.Contains(searchString) ||
                        l.Province.Contains(searchString) ||
                        l.PostalCode.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(provinceFilter) && provinceFilter != "All")
                {
                    locationsQuery = locationsQuery.Where(l => l.Province == provinceFilter);
                }

                if (!string.IsNullOrEmpty(cityFilter) && cityFilter != "All")
                {
                    locationsQuery = locationsQuery.Where(l => l.City == cityFilter);
                }

                // Pagination
                var totalLocations = await locationsQuery.CountAsync();
                var locations = await locationsQuery
                    .OrderBy(l => l.Province)
                    .ThenBy(l => l.City)
                    .ThenBy(l => l.Suburb)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Convert to ViewModel for display
                var locationVMs = locations.Select(l => new LocationVM
                {
                    Id = l.Id,
                    StreetAddress = l.StreetAddress,
                    Suburb = l.Suburb,
                    City = l.City,
                    Province = l.Province,
                    PostalCode = l.PostalCode,
                    Country = l.Country,
                    IsActive = l.IsActive,
                    CreatedAt = l.CreatedAt,
                    CreatedBy = l.CreatedBy,
                    ModifiedAt = l.ModifiedAt,
                    ModifiedBy = l.ModifiedBy,
                    TotalFridges = l.Fridges.Count(f => f.IsActive),
                    AvailableFridges = l.Fridges.Count(f => f.IsActive && f.AvailabilityStatus == "Available"),
                    TotalCustomers = l.Customers.Count(c => c.IsActive),
                    TotalEmployees = l.Employees.Count(e => e.IsActive),
                    PendingMaintenance = l.MaintenanceVisits.Count(m => m.VisitDate >= DateTime.Now && m.CheckupStatus == "Scheduled"),
                    OpenFaults = l.FaultReports.Count(f => f.RepairStatus == "Acknowledged" || f.RepairStatus == "In Progress")
                }).ToList();

                ViewBag.SearchString = searchString;
                ViewBag.ProvinceFilter = provinceFilter;
                ViewBag.CityFilter = cityFilter;
                ViewBag.TypeFilter = typeFilter;
                ViewBag.StatusFilter = statusFilter;
                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling(totalLocations / (double)pageSize);
                ViewBag.PageSize = pageSize;

                await PopulateFilterDropdowns();
                return View(locationVMs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading locations index");
                TempData["error"] = "An error occurred while loading locations.";
                return View(new List<LocationVM>());
            }
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var location = await _db.tblLocations
                    .Include(l => l.Employees).ThenInclude(e => e.ApplicationUser)
                    .Include(l => l.Customers).ThenInclude(c => c.ApplicationUser)
                    .Include(l => l.Fridges).ThenInclude(f => f.Model)
                    .Include(l => l.FridgeAllocations).ThenInclude(a => a.Fridge)
                    .Include(l => l.MaintenanceVisits).ThenInclude(m => m.TechnicianName)
                    .Include(l => l.FaultReports).ThenInclude(f => f.TechnicianAssigned)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (location == null || !location.IsActive)
                {
                    TempData["error"] = "Location not found or has been deactivated.";
                    return RedirectToAction(nameof(Index));
                }

                // Prepare statistics for the dashboard
                var stats = new
                {
                    EmployeeCount = location.Employees.Count(e => e.IsActive),
                    CustomerCount = location.Customers.Count(c => c.IsActive),
                    FridgeCount = location.Fridges.Count(f => f.IsActive),
                    AvailableFridges = location.Fridges.Count(f => f.IsActive && f.AvailabilityStatus == "Available"),
                    ActiveAllocations = location.FridgeAllocations.Count(a => a.Status == AllocationStatus.Active),
                    PendingMaintenance = location.MaintenanceVisits.Count(m => m.CheckupStatus == "Scheduled"),
                    OpenFaults = location.FaultReports.Count(f => f.RepairStatus == "Acknowledged" || f.RepairStatus == "In Progress")
                };

                ViewBag.Stats = stats;
                //ViewBag.RecentActivities = await GetRecentActivities(id);

                return View(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading location details for ID: {LocationId}", id);
                TempData["error"] = "An error occurred while loading location details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Locations/Upsert
        public async Task<IActionResult> Upsert(int? id)
        {
            try
            {
                var vm = new LocationVM();
                await PopulateDropdowns(vm);

                if (id == null || id == 0)
                {
                    // Create new location - set default values
                    vm.Country = "South Africa";
                    return View(vm);
                }

                // Edit existing location
                var location = await _db.tblLocations.FindAsync(id);
                if (location == null || !location.IsActive)
                {
                    TempData["error"] = "Location not found or has been deactivated.";
                    return RedirectToAction(nameof(Index));
                }

                // Map entity to ViewModel
                vm.Id = location.Id;
                vm.StreetAddress = location.StreetAddress;
                vm.Suburb = location.Suburb;
                vm.City = location.City;
                vm.Province = location.Province;
                vm.PostalCode = location.PostalCode;
                vm.Country = location.Country;
                vm.IsActive = location.IsActive;
                vm.CreatedAt = location.CreatedAt;
                vm.CreatedBy = location.CreatedBy;
                vm.ModifiedAt = location.ModifiedAt;
                vm.ModifiedBy = location.ModifiedBy;

                // Add statistics for context
                await PopulateLocationStatistics(vm, location.Id);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading location upsert page for ID: {LocationId}", id);
                TempData["error"] = "An error occurred while loading the location form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Locations/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(LocationVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ModelState.IsValid)
                    {
                        if (vm.Id == 0)
                        {
                            await CreateLocation(vm);
                            TempData["success"] = "Location created successfully";
                        }
                        else
                        {
                            await UpdateLocation(vm);
                            TempData["success"] = "Location updated successfully";
                        }

                        return RedirectToAction(nameof(Index));
                    }
                }

                // If validation fails, repopulate dropdowns
                await PopulateDropdowns(vm);
                TempData["error"] = "Please correct the validation errors.";
                return View(vm);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database error saving location");
                ModelState.AddModelError("", "A database error occurred while saving the location. This location may already exist.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving location");
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var location = await _db.tblLocations
                    .Include(l => l.Employees)
                    .Include(l => l.Customers)
                    .Include(l => l.Fridges)
                    .Include(l => l.FridgeAllocations)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (location == null || !location.IsActive)
                {
                    TempData["error"] = "Location not found or already deleted.";
                    return RedirectToAction(nameof(Index));
                }

                // Check dependencies for soft delete
                var dependencyCheck = await CheckLocationDependencies(location.Id);
                ViewBag.CanDelete = dependencyCheck.CanDelete;
                ViewBag.DependencyMessage = dependencyCheck.Message;

                // Convert to ViewModel for display
                var vm = new LocationVM
                {
                    Id = location.Id,
                    StreetAddress = location.StreetAddress,
                    Suburb = location.Suburb,
                    City = location.City,
                    Province = location.Province,
                    PostalCode = location.PostalCode,
                    Country = location.Country,
                    TotalEmployees = location.Employees.Count(e => e.IsActive),
                    TotalCustomers = location.Customers.Count(c => c.IsActive),
                    TotalFridges = location.Fridges.Count(f => f.IsActive)
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading delete confirmation for location ID: {LocationId}", id);
                TempData["error"] = "An error occurred while loading the delete confirmation.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var location = await _db.tblLocations
                    .Include(l => l.Employees)
                    .Include(l => l.Customers)
                    .Include(l => l.Fridges)
                    .Include(l => l.FridgeAllocations)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (location == null)
                {
                    TempData["error"] = "Location not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Check dependencies
                var dependencyCheck = await CheckLocationDependencies(location.Id);
                if (!dependencyCheck.CanDelete)
                {
                    TempData["error"] = dependencyCheck.Message;
                    return RedirectToAction(nameof(Delete), new { id });
                }

                // Soft delete (as per project checklist)
                location.IsActive = false;
                location.ModifiedAt = DateTime.UtcNow;
                location.ModifiedBy = User?.Identity?.Name ?? "System";

                await _db.SaveChangesAsync();
                TempData["success"] = "Location deactivated successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting location with ID: {LocationId}", id);
                TempData["error"] = "An error occurred while deactivating the location.";
            }

            return RedirectToAction(nameof(Index));
        }

        // AJAX: Check if location exists
        [AcceptVerbs("GET", "POST")]
        public async Task<JsonResult> CheckLocationExists(string suburb, string city, string province, int id = 0)
        {
            try
            {
                var exists = await _db.tblLocations
                    .AnyAsync(l => l.Id != id &&
                                  l.IsActive &&
                                  l.Suburb == suburb.Trim() &&
                                  l.City == city.Trim() &&
                                  l.Province == province.Trim());

                return Json(new { exists = !exists, message = exists ? "A location with this address already exists." : "" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking location existence");
                return Json(new { exists = false, message = "Error checking location existence." });
            }
        }

        // AJAX: Get locations by province
        [HttpGet]
        public async Task<JsonResult> GetLocationsByProvince(string province)
        {
            try
            {
                var locations = await _db.tblLocations
                    .Where(l => l.Province == province && l.IsActive)
                    .OrderBy(l => l.City)
                    .ThenBy(l => l.Suburb)
                    .Select(l => new { l.Id, DisplayName = $"{l.Suburb}, {l.City}" })
                    .ToListAsync();

                return Json(new { success = true, data = locations });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting locations by province: {Province}", province);
                return Json(new { success = false, message = "Error loading locations." });
            }
        }

        // AJAX: Get provinces
        [HttpGet]
        public async Task<JsonResult> GetProvinces()
        {
            try
            {
                var provinces = await _db.tblLocations
                    .Where(l => l.IsActive)
                    .Select(l => l.Province)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToListAsync();

                return Json(new { success = true, data = provinces });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting provinces");
                return Json(new { success = false, message = "Error loading provinces." });
            }
        }

        // AJAX: Get cities by province
        [HttpGet]
        public async Task<JsonResult> GetCities(string province)
        {
            try
            {
                var cities = await _db.tblLocations
                    .Where(l => l.Province == province && l.IsActive)
                    .Select(l => l.City)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToListAsync();

                return Json(new { success = true, data = cities });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cities for province: {Province}", province);
                return Json(new { success = false, message = "Error loading cities." });
            }
        }

        // AJAX: Get suburbs by city
        [HttpGet]
        public async Task<JsonResult> GetSuburbs(string province, string city)
        {
            try
            {
                var suburbs = await _db.tblLocations
                    .Where(l => l.Province == province && l.City == city && l.IsActive)
                    .Select(l => l.Suburb)
                    .Distinct()
                    .OrderBy(s => s)
                    .ToListAsync();

                return Json(new { success = true, data = suburbs });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting suburbs for city: {City}, province: {Province}", city, province);
                return Json(new { success = false, message = "Error loading suburbs." });
            }
        }

        // AJAX: Toggle location status
        [HttpPost]
        public async Task<JsonResult> ToggleStatus(int id)
        {
            try
            {
                var location = await _db.tblLocations.FindAsync(id);
                if (location == null)
                {
                    return Json(new { success = false, message = "Location not found." });
                }

                location.ModifiedAt = DateTime.UtcNow;
                location.ModifiedBy = User?.Identity?.Name ?? "System";

                await _db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling location status for ID: {LocationId}", id);
                return Json(new { success = false, message = "An error occurred while updating location status." });
            }
        }

        #region Private Methods

        private async Task CreateLocation(LocationVM vm)
        {
            var location = new Location
            {
                StreetAddress = vm.StreetAddress.Trim(),
                Suburb = vm.Suburb.Trim(),
                City = vm.City.Trim(),
                Province = vm.Province.Trim(),
                PostalCode = vm.PostalCode.Trim(),
                Country = vm.Country.Trim(),
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = User?.Identity?.Name ?? "System"
            };

            _db.tblLocations.Add(location);
            await _db.SaveChangesAsync();
        }

        private async Task UpdateLocation(LocationVM vm)
        {
            var location = await _db.tblLocations.FindAsync(vm.Id);
            if (location == null) throw new Exception("Location not found");

            location.StreetAddress = vm.StreetAddress.Trim();
            location.Suburb = vm.Suburb.Trim();
            location.City = vm.City.Trim();
            location.Province = vm.Province.Trim();
            location.PostalCode = vm.PostalCode.Trim();
            location.Country = vm.Country.Trim();
            location.IsActive = vm.IsActive;
            location.ModifiedAt = DateTime.UtcNow;
            location.ModifiedBy = User?.Identity?.Name ?? "System";

            _db.tblLocations.Update(location);
            await _db.SaveChangesAsync();
        }

        private async Task PopulateDropdowns(LocationVM vm)
        {

            // Province dropdown for filter
            var provinces = await _db.tblLocations
                .Where(l => l.IsActive)
                .Select(l => l.Province)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();

            ViewBag.ProvinceList = provinces;
        }

        private async Task PopulateFilterDropdowns()
        {
            // Province filter
            var provinces = await _db.tblLocations
                .Where(l => l.IsActive)
                .Select(l => l.Province)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();

            // City filter
            var cities = await _db.tblLocations
                .Where(l => l.IsActive)
                .Select(l => l.City)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            ViewBag.ProvinceList = provinces;
            ViewBag.CityList = cities;
        }

        private async Task PopulateLocationStatistics(LocationVM vm, int locationId)
        {
            var stats = await _db.tblLocations
                .Where(l => l.Id == locationId)
                .Select(l => new
                {
                    TotalFridges = l.Fridges.Count(f => f.IsActive),
                    AvailableFridges = l.Fridges.Count(f => f.IsActive && f.AvailabilityStatus == "Available"),
                    TotalCustomers = l.Customers.Count(c => c.IsActive),
                    TotalEmployees = l.Employees.Count(e => e.IsActive),
                    PendingMaintenance = l.MaintenanceVisits.Count(m => m.CheckupStatus == "Scheduled"),
                    OpenFaults = l.FaultReports.Count(f => f.RepairStatus == "Acknowledged"|| f.RepairStatus == "In Progress")
                })
                .FirstOrDefaultAsync();

            if (stats != null)
            {
                vm.TotalFridges = stats.TotalFridges;
                vm.AvailableFridges = stats.AvailableFridges;
                vm.TotalCustomers = stats.TotalCustomers;
                vm.TotalEmployees = stats.TotalEmployees;
                vm.PendingMaintenance = stats.PendingMaintenance;
                vm.OpenFaults = stats.OpenFaults;
            }
        }

        private async Task<(bool CanDelete, string Message)> CheckLocationDependencies(int locationId)
        {
            var activeEmployees = await _db.tblEmployees
                .AnyAsync(e => e.IsActive && e.ApplicationUser != null);
            var activeCustomers = await _db.tblCustomers.AnyAsync(c => c.IsActive);
            var activeFridges = await _db.tblFridges.AnyAsync(f => f.IsActive);
            var activeAllocations = await _db.tblAllocations.AnyAsync(a => a.Status == AllocationStatus.Active);

            if (activeEmployees || activeCustomers || activeFridges || activeAllocations)
            {
                var messages = new List<string>();
                if (activeEmployees) messages.Add("active employees");
                if (activeCustomers) messages.Add("active customers");
                if (activeFridges) messages.Add("active fridges");
                if (activeAllocations) messages.Add("active allocations");

                return (false, $"Cannot delete location. It has {string.Join(", ", messages)} assigned.");
            }

            return (true, "Location can be safely deleted.");
        }


        //private async Task<object> GetRecentActivities(int locationId)
        //{
        //    var recentActivities = new
        //    {
        //        RecentAllocations = await _db.tblAllocations
        //            .Where(a => a.DeliveryLocationId == locationId)
        //            .OrderByDescending(a => a.AllocationDate)
        //            .Take(5)
        //            .Select(a => new { a.Id, a.Fridge.SerialNumber, a.Customer.TradingName, a.AllocationDate })
        //            .ToListAsync(),

        //        RecentMaintenance = await _db.tblMaintenanceVisits
        //             .Where(m => m.Allocation != null && m.Allocation.DeliveryLocationId == locationId)
        //             .OrderByDescending(m => m.ScheduledDate)
        //            .Take(5)
        //            .Select(m => new { m.Id, m.ScheduledDate, m.Technician.UserAccount.FirstName, m.Status })
        //            .ToListAsync(),

        //        RecentFaults = await _db.tblFaults
        //            .Where(f => f.FaultLocationId == locationId)
        //            .OrderByDescending(f => f.ReportedDate)
        //            .Take(5)
        //            .Select(f => new { f.Id, f.Fridge.SerialNumber, f.ReportedDate, f.Status })
        //            .ToListAsync()
        //    };

        //    return recentActivities;
        //}

        #endregion
    }
}
