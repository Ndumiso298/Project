
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
    [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole + "," + SD.CustomerSupportRole)]
    public class MaintenanceVisitsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MaintenanceVisitsController> _logger;

        public MaintenanceVisitsController(ApplicationDbContext db, ILogger<MaintenanceVisitsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: MaintenanceVisits
        public async Task<IActionResult> Index(string status, string search, DateTime? fromDate, DateTime? toDate,
                                              bool showCompleted = false, bool showCancelled = false)
        {
            try
            {
                IQueryable<MaintenanceVisit> query = _db.MaintenanceVisits
                    .Include(v => v.Fridge)
                    .Include(v => v.Customer)
                    .ThenInclude(c => c.UserAccount)
                    .Include(v => v.Technician)
                    .ThenInclude(t => t.UserAccount)
                    .Include(v => v.Location)
                    .Where(v => v.IsActive);

                // Status-based filtering
                if (!string.IsNullOrEmpty(status) && status != "All")
                {
                    if (Enum.TryParse<ServicingStatus>(status, out var statusEnum))
                    {
                        query = query.Where(v => v.Status == statusEnum);
                    }
                }
                else
                {
                    // Default view logic
                    var statusesToShow = new List<ServicingStatus>
                {
                    ServicingStatus.Scheduled,
                    ServicingStatus.InProgress
                };

                    if (showCompleted) statusesToShow.Add(ServicingStatus.Completed);
                    if (showCancelled) statusesToShow.Add(ServicingStatus.Cancelled);

                    query = query.Where(v => statusesToShow.Contains(v.Status));
                }

                // Date filtering
                if (fromDate.HasValue)
                {
                    query = query.Where(v => v.ScheduledDate >= fromDate.Value.Date);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(v => v.ScheduledDate <= toDate.Value.Date.AddDays(1).AddTicks(-1));
                }

                // Search filtering
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(v =>
                        v.Fridge.SerialNumber.Contains(search) ||
                        v.Customer.TradingName.Contains(search) ||
                        (v.Technician != null &&
                         (v.Technician.UserAccount.FirstName.Contains(search) ||
                          v.Technician.UserAccount.LastName.Contains(search))) ||
                        v.Location.FullAddress.Contains(search));
                }

                var visits = await query.OrderBy(v => v.ScheduledDate).ToListAsync();

                // Prepare view data
                ViewBag.StatusList = GetServicingStatusList();
                ViewBag.CurrentStatus = status;
                ViewBag.SearchString = search;
                ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
                ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");
                ViewBag.ShowCompleted = showCompleted;
                ViewBag.ShowCancelled = showCancelled;

                return View(visits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance visits index");
                TempData["error"] = "Error loading maintenance visits";
                return View(new List<MaintenanceVisit>());
            }
        }

        // GET: MaintenanceVisits/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var visit = await _db.MaintenanceVisits
                    .Include(v => v.Fridge)
                    .Include(v => v.Customer)
                    .ThenInclude(c => c.UserAccount)
                    .Include(v => v.Technician)
                    .ThenInclude(t => t.UserAccount)
                    .Include(v => v.Location)
                    .Include(v => v.MaintenanceRecords)
                    .Include(v => v.FaultRecords)
                    .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

                if (visit == null)
                {
                    TempData["error"] = "Maintenance visit not found";
                    return RedirectToAction(nameof(Index));
                }

                return View(visit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance visit details for ID {Id}", id);
                TempData["error"] = "Error loading maintenance visit details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MaintenanceVisits/Upsert
        public async Task<IActionResult> Upsert(int? id, int? allocationId)
        {
            try
            {
                var vm = new MaintenanceVisitVM();
                await PopulateDropdowns(vm);

                if (id == null || id == 0)
                {
                    // Create new visit - defaults are already set in VM
                    // Pre-populate from allocation if provided
                    if (allocationId.HasValue)
                    {
                        var allocation = await _db.FridgeAllocations
                            .Include(a => a.Fridge)
                            .Include(a => a.Customer)
                            .Include(a => a.DeliveryLocation)
                            .FirstOrDefaultAsync(a => a.Id == allocationId && a.IsActive);

                        if (allocation != null)
                        {
                            vm.AllocationId = allocationId;
                            vm.FridgeId = allocation.FridgeId;
                            vm.CustomerId = allocation.CustomerId;
                            vm.LocationId = allocation.DeliveryLocationId ?? 0;
                            vm.LocationInfo = allocation.DeliveryLocation?.FullAddress;
                            vm.CustomerInfo = allocation.Customer?.TradingName;
                            vm.FridgeInfo = $"{allocation.Fridge?.SerialNumber} - {allocation.Fridge?.FridgeModel?.ModelName}";
                        }
                    }

                    return View(vm);
                }

                // Edit existing visit
                var visit = await _db.MaintenanceVisits
                    .Include(v => v.Fridge)
                    .Include(v => v.Customer)
                    .Include(v => v.Technician)
                    .Include(v => v.Location)
                    .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

                if (visit == null)
                {
                    TempData["error"] = "Maintenance visit not found";
                    return RedirectToAction(nameof(Index));
                }

                // Map entity to ViewModel
                MapEntityToViewModel(visit, vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance visit upsert form");
                TempData["error"] = "Error loading form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: MaintenanceVisits/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MaintenanceVisitVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdowns(vm);
                    return View(vm);
                }

                // Business rule validation
                if (vm.ScheduledDate < DateTime.Today && vm.Id == 0)
                {
                    ModelState.AddModelError(nameof(vm.ScheduledDate), "Scheduled date cannot be in the past for new visits");
                    await PopulateDropdowns(vm);
                    return View(vm);
                }

                if (vm.Id == 0)
                {
                    // Create new visit
                    var visit = MapViewModelToEntity(vm);
                    _db.MaintenanceVisits.Add(visit);
                    await _db.SaveChangesAsync();

                    TempData["success"] = "Maintenance visit scheduled successfully";
                }
                else
                {
                    // Update existing visit
                    var visit = await _db.MaintenanceVisits
                        .FirstOrDefaultAsync(v => v.Id == vm.Id && v.IsActive);

                    if (visit == null)
                    {
                        TempData["error"] = "Maintenance visit not found";
                        return RedirectToAction(nameof(Index));
                    }

                    MapViewModelToEntity(vm, visit);
                    visit.ModifiedAt = DateTime.Now;

                    _db.MaintenanceVisits.Update(visit);
                    await _db.SaveChangesAsync();

                    TempData["success"] = "Maintenance visit updated successfully";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving maintenance visit");
                TempData["error"] = "Error saving maintenance visit";
                await PopulateDropdowns(vm);
                return View(vm);
            }
        }

        // GET: MaintenanceVisits/Complete/5
        [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole)]
        public async Task<IActionResult> Complete(int id)
        {
            try
            {
                var visit = await _db.MaintenanceVisits
                    .Include(v => v.Fridge)
                    .ThenInclude(f => f.FridgeModel)
                    .Include(v => v.Customer)
                    .Include(v => v.Location)
                    .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

                if (visit == null)
                {
                    TempData["error"] = "Maintenance visit not found";
                    return RedirectToAction(nameof(Index));
                }

                var vm = new CompleteMaintenanceVM
                {
                    VisitId = visit.Id,
                    FridgeInfo = $"{visit.Fridge?.FridgeModel?.Manufacturer} {visit.Fridge?.FridgeModel?.ModelName} - {visit.Fridge?.SerialNumber}",
                    CustomerInfo = $"{visit.Customer?.TradingName} - {visit.Location?.FullAddress}",
                    ActualDate = DateTime.Now,
                    Status = ServicingStatus.Completed
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading complete maintenance form for visit ID {Id}", id);
                TempData["error"] = "Error loading completion form";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: MaintenanceVisits/Complete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole)]
        public async Task<IActionResult> Complete(CompleteMaintenanceVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                var visit = await _db.MaintenanceVisits
                    .FirstOrDefaultAsync(v => v.Id == vm.VisitId && v.IsActive);

                if (visit == null)
                {
                    TempData["error"] = "Maintenance visit not found";
                    return RedirectToAction(nameof(Index));
                }

                // Update visit with completion details
                visit.ActualEndTime = vm.ActualDate;
                visit.Status = vm.Status;
                visit.TechnicianNotes = vm.TechnicianNotes;
                visit.PartsReplaced = vm.PartsUsed;
                visit.ServiceCost = vm.ServiceCost;
                visit.IsChecklistCompleted = vm.IsChecklistCompleted;
                visit.ChecklistNotes = vm.ChecklistNotes;
                visit.ModifiedAt = DateTime.Now;

                // Set start time if not already set
                if (!visit.ActualStartTime.HasValue)
                {
                    visit.ActualStartTime = vm.ActualDate;
                }

                _db.MaintenanceVisits.Update(visit);
                await _db.SaveChangesAsync();

                TempData["success"] = "Maintenance visit completed successfully";
                return RedirectToAction(nameof(Details), new { id = vm.VisitId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing maintenance visit {VisitId}", vm.VisitId);
                TempData["error"] = "Error completing maintenance visit";
                return View(vm);
            }
        }

        // POST: MaintenanceVisits/Delete/5 (Soft Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var visit = await _db.MaintenanceVisits
                    .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

                if (visit == null)
                {
                    TempData["error"] = "Maintenance visit not found";
                    return RedirectToAction(nameof(Index));
                }

                // Soft delete
                visit.IsActive = false;
                visit.ModifiedAt = DateTime.Now;

                await _db.SaveChangesAsync();
                TempData["success"] = "Maintenance visit deleted successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting maintenance visit with ID {Id}", id);
                TempData["error"] = "Error deleting maintenance visit";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceVisits/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                var dashboard = new MaintenanceDashboardVM
                {
                    TotalVisits = await _db.MaintenanceVisits.CountAsync(v => v.IsActive),
                    ScheduledVisits = await _db.MaintenanceVisits
                        .CountAsync(v => v.IsActive && v.Status == ServicingStatus.Scheduled),
                    CompletedVisits = await _db.MaintenanceVisits
                        .CountAsync(v => v.IsActive && v.Status == ServicingStatus.Completed),
                    InProgressVisits = await _db.MaintenanceVisits
                        .CountAsync(v => v.IsActive && v.Status == ServicingStatus.InProgress),
                    OverdueVisits = await _db.MaintenanceVisits
                        .Include(v => v.Fridge)
                        .Include(v => v.Customer)
                        .Include(v => v.Technician)
                        .ThenInclude(t => t.UserAccount)
                        .Where(v => v.IsActive &&
                                   (v.Status == ServicingStatus.Scheduled || v.Status == ServicingStatus.InProgress) &&
                                   v.ScheduledDate < DateTime.Today)
                        .OrderBy(v => v.ScheduledDate)
                        .ToListAsync(),
                    UpcomingVisits = await _db.MaintenanceVisits
                        .Include(v => v.Fridge)
                        .Include(v => v.Customer)
                        .Include(v => v.Technician)
                        .ThenInclude(t => t.UserAccount)
                        .Where(v => v.IsActive &&
                                   v.Status == ServicingStatus.Scheduled &&
                                   v.ScheduledDate >= DateTime.Today &&
                                   v.ScheduledDate <= DateTime.Today.AddDays(7))
                        .OrderBy(v => v.ScheduledDate)
                        .Take(10)
                        .ToListAsync()
                };

                return View(dashboard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading maintenance dashboard");
                TempData["error"] = "Error loading dashboard";
                return View(new MaintenanceDashboardVM());
            }
        }

        #region Private Methods

        private async Task PopulateDropdowns(MaintenanceVisitVM vm)
        {
            try
            {
                vm.CustomerList = await _db.Customers
                    .Where(c => c.IsActive)
                    .OrderBy(c => c.TradingName)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = $"{c.TradingName} - {c.UserAccount.FirstName} {c.UserAccount.LastName}"
                    })
                    .ToListAsync();

                vm.FridgeList = await _db.Fridges
                    .Where(f => f.IsActive && f.Status != FridgeStatus.Scrapped)
                    .Include(f => f.FridgeModel)
                    .OrderBy(f => f.SerialNumber)
                    .Select(f => new SelectListItem
                    {
                        Value = f.Id.ToString(),
                        Text = $"{f.SerialNumber} - {f.FridgeModel.Manufacturer} {f.FridgeModel.ModelName}"
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

                vm.LocationList = await _db.Locations
                    .Where(l => l.IsActive)
                    .OrderBy(l => l.FullAddress)
                    .Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = l.FullAddress
                    })
                    .ToListAsync();

                vm.StatusList = GetServicingStatusList();
                vm.VisitTypeList = GetVisitTypeList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error populating dropdowns");
                // Ensure lists are never null
                vm.CustomerList ??= new List<SelectListItem>();
                vm.FridgeList ??= new List<SelectListItem>();
                vm.TechnicianList ??= new List<SelectListItem>();
                vm.LocationList ??= new List<SelectListItem>();
                vm.StatusList ??= new List<SelectListItem>();
                vm.VisitTypeList ??= new List<SelectListItem>();
            }
        }

        private void MapEntityToViewModel(MaintenanceVisit entity, MaintenanceVisitVM vm)
        {
            vm.Id = entity.Id;
            vm.CustomerId = entity.CustomerId;
            vm.FridgeId = entity.FridgeId;
            vm.AllocationId = entity.AllocationId;
            vm.TechnicianId = entity.TechnicianId;
            vm.LocationId = entity.LocationId;
            vm.ScheduledDate = entity.ScheduledDate;
            vm.VisitType = entity.VisitType;
            vm.Status = entity.Status;
            vm.ActualStartTime = entity.ActualStartTime;
            vm.ActualEndTime = entity.ActualEndTime;
            vm.TechnicianNotes = entity.TechnicianNotes;
            vm.PartsReplaced = entity.PartsReplaced;
            vm.ServiceCost = entity.ServiceCost;
            vm.ConditionRating = entity.ConditionRating;
            vm.TemperatureReading = entity.TemperatureReading;
            vm.IssuesFound = entity.IssuesFound;
            vm.IssueDescription = entity.IssueDescription;
            vm.MaintenancePerformed = entity.MaintenancePerformed;
            vm.MaintenanceDetails = entity.MaintenanceDetails;
            vm.FollowUpRequired = entity.FollowUpRequired;
            vm.FollowUpDate = entity.FollowUpDate;
            vm.IsChecklistCompleted = entity.IsChecklistCompleted;
            vm.ChecklistNotes = entity.ChecklistNotes;
        }

        private MaintenanceVisit MapViewModelToEntity(MaintenanceVisitVM vm, MaintenanceVisit? entity = null)
        {
            entity ??= new MaintenanceVisit();

            entity.CustomerId = vm.CustomerId;
            entity.FridgeId = vm.FridgeId;
            entity.AllocationId = vm.AllocationId;
            entity.TechnicianId = vm.TechnicianId;
            entity.LocationId = vm.LocationId;
            entity.ScheduledDate = vm.ScheduledDate;
            entity.VisitType = vm.VisitType;
            entity.Status = vm.Status;
            entity.ActualStartTime = vm.ActualStartTime;
            entity.ActualEndTime = vm.ActualEndTime;
            entity.TechnicianNotes = vm.TechnicianNotes;
            entity.PartsReplaced = vm.PartsReplaced;
            entity.ServiceCost = vm.ServiceCost;
            entity.ConditionRating = vm.ConditionRating;
            entity.TemperatureReading = vm.TemperatureReading;
            entity.IssuesFound = vm.IssuesFound;
            entity.IssueDescription = vm.IssueDescription;
            entity.MaintenancePerformed = vm.MaintenancePerformed;
            entity.MaintenanceDetails = vm.MaintenanceDetails;
            entity.FollowUpRequired = vm.FollowUpRequired;
            entity.FollowUpDate = vm.FollowUpDate;
            entity.IsChecklistCompleted = vm.IsChecklistCompleted;
            entity.ChecklistNotes = vm.ChecklistNotes;
            entity.IsActive = true;

            if (entity.Id == 0)
            {
                entity.CreatedAt = DateTime.Now;
            }
            entity.ModifiedAt = DateTime.Now;

            return entity;
        }

        private List<SelectListItem> GetServicingStatusList()
        {
            return Enum.GetValues<ServicingStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();
        }

        private List<SelectListItem> GetVisitTypeList()
        {
            return Enum.GetValues<ServicingType>()
                .Select(v => new SelectListItem
                {
                    Value = v.ToString(),
                    Text = v.ToString()
                })
                .ToList();
        }

        #endregion
    }

    //public class MaintenanceVisitController : Controller
    //{
    //    private readonly ApplicationDbContext _db;

    //    public MaintenanceVisitController(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }
    //    public IActionResult Dashboard()
    //    {
    //        return View();
    //    }

    //    // GET: MaintenanceVisit
    //    public IActionResult Index(string search, string status, DateTime? fromDate, DateTime? toDate)
    //    {
    //        var visits = _db.MaintenanceVisits
    //            .Include(v => v.Customer)
    //            .Include(v => v.AssignedTechnician)
    //            .Include(v => v.Fridge)
    //            .AsQueryable();

    //        if (!string.IsNullOrEmpty(search))
    //        {
    //            visits = visits.Where(v =>
    //                v.Customer.UserAccount.FirstName.Contains(search) ||
    //                v.AssignedTechnician.UserAccount.FirstName.Contains(search) ||
    //                v.Fridge.SerialNumber.Contains(search) ||
    //                v.Fridge.ModelName.Contains(search));
    //        }

    //        if (!string.IsNullOrEmpty(status))
    //        {
    //            visits = visits.Where(v => v.Status == ServicingStatus.Scheduled);
    //        }

    //        if (fromDate.HasValue)
    //        {
    //            visits = visits.Where(v => v.ScheduledDate >= fromDate.Value);
    //        }

    //        if (toDate.HasValue)
    //        {
    //            visits = visits.Where(v => v.ScheduledDate <= toDate.Value);
    //        }

    //        // Pass filters back to View
    //        ViewBag.Search = search;
    //        ViewBag.Status = status;
    //        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
    //        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

    //        return View(visits);
    //    }

    //    // GET: MaintenanceVisit/Create
    //    public IActionResult Create(int maintenanceVisitId)
    //    {
    //        var visit = _db.MaintenanceVisits
    //            .Include(v => v.Fridge)
    //            .Include(v => v.Customer)
    //            .Include(v => v.AssignedTechnician)
    //            .FirstOrDefault(v => v.Id == maintenanceVisitId);

    //        if (visit == null)
    //        {
    //            return NotFound();
    //        }

    //        var fault = new FaultRecord
    //        {
    //            MaintenanceVisitId = maintenanceVisitId,
    //            FridgeId = visit.Fridge.Id,              
    //            ReportedById = visit.Customer.UserAccount.Id, 
    //            ReportedBy = visit.Customer.UserAccount,
    //            Fridge = visit.Fridge,
    //            ReportedDate = DateTime.Now
    //        };


    //        ViewBag.Technicians = new SelectList(_db.Employees, "TechnicianId", "Name");

    //        return View(visit);
    //    }


    //    // POST: MaintenanceVisit/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(FaultRecord fault)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            ViewBag.Technicians = new SelectList(_db.Employees, "TechnicianId", "Name", fault.AssignedTechnician);
    //            return View(fault);
    //        }

    //        fault.ReportedDate = DateTime.Now;

    //        _db.FaultRecords.Add(fault);
    //        _db.SaveChanges();

    //        return RedirectToAction("Details", "MaintenanceVisit", new { id = fault.MaintenanceVisitId });
    //    }


    //    // GET: MaintenanceVisit/Details/5
    //    public IActionResult Details(int id)
    //    {
    //        var visit = _db.MaintenanceVisits.FirstOrDefault(v => v.Id == id);
    //        if (visit == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(visit);
    //    }

    //    // GET: MaintenanceVisit/Edit/5
    //    public IActionResult Edit(int id)
    //    {
    //        var visit = _db.MaintenanceVisits
    //            .Include(v => v.Fridge)
    //            .Include(v => v.AssignedTechnician)
    //            .FirstOrDefault(v => v.Id == id);

    //        if (visit == null)
    //        {
    //            return NotFound();
    //        }

    //        ViewBag.TechnicianList = new SelectList(_db.Employees, "TechnicianId", "Name", visit.AssignedTechnicianId);

    //        return View(visit);
    //    }




    //    // POST: MaintenanceVisit/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]

    //    public IActionResult Edit(MaintenanceVisit visit)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            ViewBag.TechnicianList = new SelectList(_db.Employees, "TechnicianId", "Name", visit.AssignedTechnicianId);
    //            return View(visit);
    //        }

    //        var existingVisit = _db.MaintenanceVisits
    //            .FirstOrDefault(v => v.Id == visit.Id);

    //        if (existingVisit == null)
    //        {
    //            return NotFound();
    //        }

    //        existingVisit.ScheduledDate = visit.ScheduledDate;
    //        existingVisit.Status = visit.Status;
    //        existingVisit.TechnicianNotes = visit.TechnicianNotes;
    //        existingVisit.AssignedTechnicianId = visit.AssignedTechnicianId; 

    //        _db.SaveChanges();

    //        return RedirectToAction("Index");
    //    }



    //    // GET: MaintenanceVisit/Delete/5
    //    public IActionResult Delete(int id)
    //    {
    //        var visit = _db.MaintenanceVisits
    //            .Include(v => v.Customer)
    //            .FirstOrDefault(v => v.Id == id);

    //        if (visit == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(visit); 
    //    }


    //    // POST: MaintenanceVisit/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult DeleteConfirmed(int id)
    //    {
    //        var visit = _db.MaintenanceVisits
    //            .FirstOrDefault(v => v.Id == id);

    //        if (visit == null)
    //        {
    //            return NotFound();
    //        }


    //        _db.SaveChanges();

    //        return RedirectToAction("Index");
    //    }

    //    public IActionResult Print(int id)
    //    {
    //        var visit = _db.MaintenanceVisits
    //            .Include(v => v.AssignedTechnician)
    //            .Include(v => v.Fridge)
    //            .FirstOrDefault(v => v.Id == id);

    //        if (visit == null) return NotFound();

    //        return View("Print", visit);
    //    }

}
