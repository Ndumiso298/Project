
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole)]
    public class MaintenanceRecordsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MaintenanceRecordsController> _logger;

        public MaintenanceRecordsController(ApplicationDbContext db, ILogger<MaintenanceRecordsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: MaintenanceRecords
        public async Task<IActionResult> Index(int? fridgeId, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                // Build query with includes and active filter
                var query = _db.MaintenanceRecords
                    .Include(r => r.Fridge)
                    .Include(r => r.Technician)
                    .Include(r => r.MaintenanceVisit)
                    .Where(r => !r.IsDeleted);

                // Apply filters
                if (fridgeId.HasValue)
                {
                    query = query.Where(r => r.FridgeId == fridgeId.Value);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(r => r.ServiceDate >= fromDate.Value.Date);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(r => r.ServiceDate <= toDate.Value.Date.AddDays(1).AddTicks(-1));
                }

                var records = await query.OrderByDescending(r => r.ServiceDate).ToListAsync();

                // Prepare view data for filters
                ViewBag.FridgeList = await GetFridgeListAsync();
                ViewBag.SelectedFridgeId = fridgeId;
                ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
                ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

                return View(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance records index");
                TempData["error"] = "Error loading maintenance records";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MaintenanceRecords/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var record = await _db.MaintenanceRecords
                    .Include(r => r.Fridge)
                    .Include(r => r.Technician)
                    .Include(r => r.MaintenanceVisit)
                    .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

                if (record == null)
                {
                    TempData["error"] = "Maintenance record not found";
                    return RedirectToAction(nameof(Index));
                }

                return View(record);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance record details for ID {Id}", id);
                TempData["error"] = "Error loading maintenance record details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MaintenanceRecords/Upsert
        public async Task<IActionResult> Upsert(int? id, int? visitId)
        {
            try
            {
                var vm = new MaintenanceRecordVM();
                await PopulateDropdowns(vm);

                if (id == null || id == 0)
                {
                    // Create new record
                    vm.ServiceDate = DateTime.Now;

                    // Pre-populate from visit if provided
                    if (visitId.HasValue)
                    {
                        var visit = await _db.MaintenanceVisits
                            .Include(v => v.Fridge)
                            .Include(v => v.AssignedTechnician)
                            .FirstOrDefaultAsync(v => v.Id == visitId && !v.IsDeleted);

                        if (visit != null)
                        {
                            vm.MaintenanceVisitId = visitId;
                            vm.FridgeId = visit.FridgeId;
                            vm.TechnicianId = visit.AssignedTechnicianId;
                            vm.ServiceDate = visit.ScheduledDate;
                        }
                    }

                    return View(vm);
                }

                // Edit existing record
                var record = await _db.MaintenanceRecords
                    .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

                if (record == null)
                {
                    TempData["error"] = "Maintenance record not found";
                    return RedirectToAction(nameof(Index));
                }

                // Map entity to view model
                MapEntityToViewModel(record, vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance record upsert form");
                TempData["error"] = "Error loading form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: MaintenanceRecords/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MaintenanceRecordVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdowns(vm);
                    return View(vm);
                }
                if (vm.Id == 0)
                {
                    // Create new record
                    var record = MapViewModelToEntity(vm);
                    _db.MaintenanceRecords.Add(record);
                    await _db.SaveChangesAsync();

                    // Update fridge service information
                    await UpdateFridgeServiceInfo(vm.FridgeId, vm.ServiceDate);

                    TempData["success"] = "Maintenance record created successfully";
                }
                else
                {
                    // Update existing record
                    var record = await _db.MaintenanceRecords
                        .FirstOrDefaultAsync(r => r.Id == vm.Id && !r.IsDeleted);

                    if (record == null)
                    {
                        TempData["error"] = "Maintenance record not found";
                        return RedirectToAction(nameof(Index));
                    }

                    MapViewModelToEntity(vm, record);
                    record.UpdatedAt = DateTime.Now;

                    _db.MaintenanceRecords.Update(record);
                    await _db.SaveChangesAsync();

                    // Update fridge service information
                    await UpdateFridgeServiceInfo(vm.FridgeId, vm.ServiceDate);

                    TempData["success"] = "Maintenance record updated successfully";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving maintenance record");
                TempData["error"] = "Error saving maintenance record";
                await PopulateDropdowns(vm);
                return View(vm);
            }
        }

        // POST: MaintenanceRecords/Delete/5 (Soft Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _db.MaintenanceRecords
                    .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

                if (record == null)
                {
                    TempData["error"] = "Maintenance record not found";
                    return RedirectToAction(nameof(Index));
                }

                // Soft delete
                record.IsDeleted = true;
                record.UpdatedAt = DateTime.Now;

                await _db.SaveChangesAsync();
                TempData["success"] = "Maintenance record deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting maintenance record with ID {Id}", id);
                TempData["error"] = "Error deleting maintenance record";
            }

            return RedirectToAction(nameof(Index));
        }

        #region Private Methods

        private async Task PopulateDropdowns(MaintenanceRecordVM vm)
        {
            try
            {
                vm.FridgeList = await _db.Fridges
                    .Where(f => f.Status != FridgeStatus.Scrapped && f.IsActive)
                    .OrderBy(f => f.SerialNumber)
                    .Select(f => new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = $"{f.SerialNumber} - {f.FridgeModel.ModelName ?? "Unknown Model"}"
                    })
                    .ToListAsync();

                vm.TechnicianList = await _db.Employees
                    .Where(e => e.IsActive && e.EmployeeType == EmployeeType.MaintenanceTechnician)
                    .Include(e => e.UserAccount)
                    .OrderBy(e => e.UserAccount.FirstName)
                    .Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName}"
                    })
                    .ToListAsync();

                vm.VisitList = await _db.MaintenanceVisits
                    .Where(v => !v.IsDeleted && (v.Status == ServicingStatus.Scheduled || v.Status == ServicingStatus.InProgress))
                    .OrderByDescending(v => v.ScheduledDate)
                    .Select(v => new SelectListItem
                    {
                        Value = v.Id.ToString(),
                        Text = $"Visit #{v.Id} - {v.ScheduledDate:dd/MM/yyyy HH:mm} - {v.Customer.UserAccount.FirstName}"
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error populating dropdowns");
                // Ensure lists are never null
                vm.FridgeList ??= new List<SelectListItem>();
                vm.TechnicianList ??= new List<SelectListItem>();
                vm.VisitList ??= new List<SelectListItem>();
            }
        }

        private async Task<List<SelectListItem>> GetFridgeListAsync()
        {
            return await _db.Fridges
                .Where(f => f.Status != FridgeStatus.Scrapped && f.IsActive)
                .OrderBy(f => f.SerialNumber)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.FridgeModel.ModelName ?? "Unknown Model"}"
                })
                .ToListAsync();
        }

        private void MapEntityToViewModel(MaintenanceRecord entity, MaintenanceRecordVM vm)
        {
            vm.Id = entity.Id;
            vm.FridgeId = entity.FridgeId;
            vm.TechnicianId = entity.TechnicianId;
            vm.MaintenanceVisitId = entity.MaintenanceVisitId;
            vm.ServiceDate = entity.ServiceDate;
            vm.ServiceNotes = entity.ServiceNotes;
        }

        private MaintenanceRecord MapViewModelToEntity(MaintenanceRecordVM vm, MaintenanceRecord? entity = null)
        {
            entity ??= new MaintenanceRecord();

            entity.FridgeId = vm.FridgeId;
            entity.TechnicianId = vm.TechnicianId;
            entity.MaintenanceVisitId = vm.MaintenanceVisitId;
            entity.ServiceDate = vm.ServiceDate;
            entity.ServiceNotes = vm.ServiceNotes;
            entity.IsDeleted = false;

            if (entity.Id == 0)
            {
                entity.CreatedAt = DateTime.Now;
            }
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }

        private async Task UpdateFridgeServiceInfo(int fridgeId, DateTime? serviceDate)
        {
            try
            {
                var fridge = await _db.Fridges.FindAsync(fridgeId);
                if (fridge != null)
                {
                    fridge.LastServiceDate = serviceDate;
                    fridge.UpdatedAt = DateTime.Now;
                    _db.Fridges.Update(fridge);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to update fridge service info for fridge ID {FridgeId}", fridgeId);
                // Don't throw - this is a secondary operation
            }
        }

        #endregion
    }
    //public class MaintenanceRecordController : Controller
    //{
    //    private readonly ApplicationDbContext _db;

    //    public MaintenanceRecordController(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }

    //    // GET: MaintenanceRecord
    //    public IActionResult Index()
    //    {
    //        List<MaintenanceRecord> records = _db.MaintenanceRecords.ToList();
    //        return View(records);
    //    }

    //    // GET: MaintenanceRecord/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: MaintenanceRecord/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(MaintenanceRecord record)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _db.MaintenanceRecords.Add(record);
    //            _db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(record);
    //    }

    //    // GET: MaintenanceRecord/Details/5
    //    public IActionResult Details(int id)
    //    {
    //        var record = _db.MaintenanceRecords.FirstOrDefault(r => r.Id == id);
    //        if (record == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(record);
    //    }

    //    // GET: MaintenanceRecord/Edit/5
    //    public IActionResult Edit(int id)
    //    {
    //        var record = _db.MaintenanceRecords.FirstOrDefault(r => r.Id == id);
    //        if (record == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(record);
    //    }

    //    // POST: MaintenanceRecord/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(MaintenanceRecord record)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _db.MaintenanceRecords.Update(record);
    //            _db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(record);
    //    }

    //    // GET: MaintenanceRecord/Delete/5
    //    public IActionResult Delete(int id)
    //    {
    //        var record = _db.MaintenanceRecords.FirstOrDefault(r => r.Id == id);
    //        if (record == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(record);
    //    }

    //    // POST: MaintenanceRecord/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult DeleteConfirmed(int id)
    //    {
    //        var record = _db.MaintenanceRecords.FirstOrDefault(r => r.Id == id);
    //        if (record == null)
    //        {
    //            return NotFound();
    //        }

    //        _db.MaintenanceRecords.Remove(record);
    //        _db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
}