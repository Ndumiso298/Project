
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

        public MaintenanceRecordsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: MaintenanceRecords
        public async Task<IActionResult> Index(int? fridgeId, DateTime? fromDate, DateTime? toDate)
        {
            IQueryable<MaintenanceRecord> query = _db.MaintenanceRecords
                .Include(r => r.Fridge)
                .Include(r => r.Technician)
                .Include(r => r.MaintenanceVisit)
                .Where(r => r.IsActive); // Added IsActive filter

            if (fridgeId.HasValue)
            {
                query = query.Where(r => r.FridgeId == fridgeId.Value);
            }

            if (fromDate.HasValue)
            {
                query = query.Where(r => r.ServiceDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(r => r.ServiceDate <= toDate.Value);
            }

            var records = await query.OrderByDescending(r => r.ServiceDate).ToListAsync();

            ViewBag.FridgeList = await GetFridgeListAsync();
            ViewBag.SelectedFridgeId = fridgeId;
            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

            return View(records);
        }

        // GET: MaintenanceRecords/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var record = await _db.MaintenanceRecords
                .Include(r => r.Fridge)
                .Include(r => r.Technician)
                .Include(r => r.MaintenanceVisit)
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive); // Fixed condition

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: MaintenanceRecords/Upsert
        public async Task<IActionResult> Upsert(int? id, int? visitId)
        {
            var vm = new MaintenanceRecordVM();
            await PopulateDropdowns(vm);

            if (id == null || id == 0)
            {
                // Create new record
                vm.ServiceDate = DateTime.Now; // Changed from MaintenanceDate to ServiceDate

                // Pre-populate from visit if provided
                if (visitId.HasValue)
                {
                    var visit = await _db.MaintenanceVisits
                        .Include(v => v.Fridge)
                        .Include(v => v.AssignedTechnician)
                        .FirstOrDefaultAsync(v => v.Id == visitId);

                    if (visit != null)
                    {
                        vm.MaintenanceVisitId = visitId;
                        vm.FridgeId = visit.Fridge.Id;
                        vm.TechnicianId = visit.AssignedTechnician.Id; // Fixed property name
                        vm.ServiceDate = visit.ScheduledDate; // Changed from MaintenanceDate
                    }
                }

                return View(vm);
            }

            // Edit existing record
            var record = await _db.MaintenanceRecords
                .Include(r => r.Fridge)
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive);

            if (record == null)
            {
                return NotFound();
            }

            vm.Id = record.Id;
            vm.FridgeId = record.FridgeId;
            vm.TechnicianId = record.TechnicianId;
            vm.MaintenanceVisitId = record.MaintenanceVisitId;
            vm.ServiceDate = record.ServiceDate;
            vm.ServiceType = record.ServiceType;
            vm.Description = record.Description;
            vm.ServiceNotes = record.ServiceNotes;
            vm.ServiceCost = record.Cost;
            vm.PartsUsed = record.PartsUsed;
            vm.StartTime = record.StartTime;
            vm.EndTime = record.EndTime;
            vm.IsWarrantyClaim = record.IsWarrantyClaim;
            vm.WarrantyReference = record.WarrantyReference;

            return View(vm);
        }

        // POST: MaintenanceRecords/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MaintenanceRecordVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new record
                        var record = new MaintenanceRecord
                        {
                            FridgeId = vm.FridgeId,
                            TechnicianId = vm.TechnicianId,
                            MaintenanceVisitId = vm.MaintenanceVisitId,
                            ServiceDate = vm.ServiceDate, // Now property names match
                            ServiceType = vm.ServiceType,
                            Description = vm.Description, // Now property names match
                            ServiceNotes = vm.ServiceNotes,
                            Cost = vm.ServiceCost, // Now property names match
                            PartsUsed = vm.PartsUsed, // Now property names match
                            StartTime = vm.StartTime,
                            EndTime = vm.EndTime,
                            IsWarrantyClaim = vm.IsWarrantyClaim,
                            WarrantyReference = vm.WarrantyReference,
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        };

                        _db.MaintenanceRecords.Add(record);
                        await _db.SaveChangesAsync();

                        // Update fridge's last service date
                        await UpdateFridgeServiceInfo(vm.FridgeId, vm.ServiceDate, vm.NextServiceDue);

                        TempData["success"] = "Maintenance record created successfully";
                    }
                    else
                    {
                        // Update existing record
                        var record = await _db.MaintenanceRecords.FindAsync(vm.Id);
                        if (record == null)
                        {
                            return NotFound();
                        }

                        record.FridgeId = vm.FridgeId;
                        record.TechnicianId = vm.TechnicianId;
                        record.MaintenanceVisitId = vm.MaintenanceVisitId;
                        record.ServiceDate = vm.ServiceDate; // Changed from MaintenanceDate
                        record.Description = vm.Description; // Map to correct property
                        record.ServiceNotes = vm.ServiceNotes;
                        record.PartsUsed = vm.PartsUsed; // Map to correct property
                        record.ModifiedDate = DateTime.Now;
                        record.IsActive = true;

                        _db.MaintenanceRecords.Update(record);
                        await _db.SaveChangesAsync();

                        // Update fridge's service info
                        await UpdateFridgeServiceInfo(vm.FridgeId, vm.ServiceDate, vm.NextServiceDue);

                        TempData["success"] = "Maintenance record updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving maintenance record: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: MaintenanceRecords/Delete/5 (Soft Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _db.MaintenanceRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            // Soft delete
            record.IsActive = false;
            record.ModifiedDate = DateTime.Now;

            await _db.SaveChangesAsync();
            TempData["success"] = "Maintenance record deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns(MaintenanceRecordVM vm)
        {
            vm.FridgeList = await _db.Fridges
                .Where(f => f.Status != FridgeStatus.Scrapped && f.IsActive)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.Model}"
                })
                .ToListAsync();

            vm.TechnicianList = await _db.Employees
                .Where(e => e.IsActive && e.EmployeeType == EmployeeType.MaintenanceTechnician)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName}"
                })
                .ToListAsync();

            vm.VisitList = await _db.MaintenanceVisits
                .Where(v => v.Status == ServicingStatus.Scheduled || v.Status == ServicingStatus.Completed) // Fixed condition
                .Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = $"Visit #{v.Id} - {v.ScheduledDate:dd/MM/yyyy}"
                })
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetFridgeListAsync()
        {
            return await _db.Fridges
                .Where(f => f.Status != FridgeStatus.Scrapped && f.IsActive)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.Model}"
                })
                .ToListAsync();
        }

        private async Task UpdateFridgeServiceInfo(int fridgeId, DateTime serviceDate, DateTime? nextServiceDue)
        {
            var fridge = await _db.Fridges.FindAsync(fridgeId);
            if (fridge != null)
            {
                fridge.LastServiceDate = serviceDate;
                fridge.NextServiceDue = nextServiceDue;
                fridge.ModifiedDate = DateTime.Now;
                _db.Fridges.Update(fridge);
                await _db.SaveChangesAsync();
            }
        }
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