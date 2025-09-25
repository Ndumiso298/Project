
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
        private readonly ApplicationDbContext _context;

        public MaintenanceVisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaintenanceVisits
        // GET: MaintenanceVisits with proper filtering
        public async Task<IActionResult> Index(string status, string search, DateTime? fromDate, DateTime? toDate,
                                              bool showCompleted = false, bool showCancelled = false)
        {
            IQueryable<MaintenanceVisit> query = _context.MaintenanceVisits
                .Include(v => v.Fridge)
                .Include(v => v.Customer)
                .Include(v => v.AssignedTechnician)
                .Where(v => v.IsActive); // Base soft delete filter

            // Status-based business filtering
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                if (Enum.TryParse<ServicingStatus>(status, out var statusEnum))
                {
                    query = query.Where(v => v.Status == statusEnum);
                }
            }
            else
            {
                // Default view: exclude completed and cancelled unless explicitly requested
                var statusesToShow = new List<ServicingStatus>
        {
            ServicingStatus.Scheduled,
            ServicingStatus.InProgress
        };

                if (showCompleted) statusesToShow.Add(ServicingStatus.Completed);
                if (showCancelled) statusesToShow.Add(ServicingStatus.Rescheduled);

                query = query.Where(v => statusesToShow.Contains(v.Status));
            }

            // Date filtering
            if (fromDate.HasValue)
            {
                query = query.Where(v => v.ScheduledDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(v => v.ScheduledDate <= toDate.Value);
            }

            // Search filtering
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(v =>
                    v.Fridge.SerialNumber.Contains(search) ||
                    v.Customer.TradingName.Contains(search) ||
                    (v.AssignedTechnician != null &&
                     (v.AssignedTechnician.UserAccount.FirstName.Contains(search) ||
                      v.AssignedTechnician.UserAccount.LastName.Contains(search))));
            }

            var visits = await query.OrderBy(v => v.ScheduledDate).ToListAsync();

            ViewBag.StatusList = GetServicingStatusList();
            ViewBag.CurrentStatus = status;
            ViewBag.SearchString = search;
            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");
            ViewBag.ShowCompleted = showCompleted;
            ViewBag.ShowCancelled = showCancelled;

            return View(visits);
        }

        // GET: MaintenanceVisits/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var visit = await _context.MaintenanceVisits
                .Include(v => v.Fridge)
                .Include(v => v.Customer)
                .Include(v => v.AssignedTechnician)
                .Include(v => v.MaintenanceRecords)
                .Include(v => v.FaultRecords)
                .FirstOrDefaultAsync(v => v.Id == id && v.IsActive); // Added IsActive filter

            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: MaintenanceVisits/Upsert
        public async Task<IActionResult> Upsert(int? id, int? allocationId)
        {
            var vm = new MaintenanceVisitVM();
            await PopulateDropdowns(vm);

            if (id == null || id == 0)
            {
                // Create new visit
                vm.ScheduledDate = DateTime.Now.AddDays(1); // Default to tomorrow
                vm.Status = ServicingStatus.Scheduled;
                vm.VisitType = ServicingType.PreventiveMaintenance; // Set default

                // Pre-populate from allocation if provided
                if (allocationId.HasValue)
                {
                    var allocation = await _context.FridgeAllocations
                        .Include(a => a.Fridge)
                        .Include(a => a.Customer)
                        .FirstOrDefaultAsync(a => a.Id == allocationId);

                    if (allocation != null)
                    {
                        vm.AllocationId = allocationId;
                        vm.FridgeId = allocation.FridgeId;
                        vm.CustomerId = allocation.CustomerId;
                        vm.LocationId = allocation.AllocationLocationId; // the FK
                        vm.LocationDisplay = allocation.AllocationLocation?.FullAddress
                                          ?? allocation.Customer?.AddressLine1;
                    }
                }

                return View(vm);
            }

            // Edit existing visit
            var visit = await _context.MaintenanceVisits
                .Include(v => v.Fridge)
                .Include(v => v.Customer)
                .Include(v => v.AssignedTechnician)
                .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

            if (visit == null)
            {
                return NotFound();
            }

            // Map entity to ViewModel
            vm.Id = visit.Id;
            vm.AllocationId = visit.AllocationId;
            vm.FridgeId = visit.FridgeId ?? 0; // Handle nullable
            vm.CustomerId = visit.CustomerId;
            vm.TechnicianId = visit.AssignedTechnicianId ?? 0; // Map to correct property
            vm.ScheduledDate = visit.ScheduledDate;
            vm.ActualDate = visit.ActualEndTime; // Map to correct property
            vm.Status = visit.Status;
            vm.VisitType = visit.VisitType;
            vm.Notes = visit.TechnicianNotes; // Map to correct property
            vm.TechnicianNotes = visit.TechnicianNotes;
            vm.PartsUsed = visit.PartsReplaced; // Map to correct property
            vm.ServiceCost = visit.ServiceCost;

            return View(vm);
        }

        // POST: MaintenanceVisits/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MaintenanceVisitVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new visit
                        var visit = new MaintenanceVisit
                        {
                            AllocationId = vm.AllocationId,
                            FridgeId = vm.FridgeId,
                            CustomerId = vm.CustomerId,
                            AssignedTechnicianId = vm.TechnicianId,
                            ScheduledDate = vm.ScheduledDate,
                            ActualStartTime = vm.ActualDate,
                            ActualEndTime = vm.ActualDate,
                            Status = vm.Status,
                            VisitType = vm.VisitType,
                            TechnicianNotes = vm.TechnicianNotes,
                            PartsReplaced = vm.PartsUsed,
                            ServiceCost = vm.ServiceCost, // Now this will work
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        };

                        _context.MaintenanceVisits.Add(visit);
                        await _context.SaveChangesAsync();

                        TempData["success"] = "Maintenance visit scheduled successfully";
                    }
                    else
                    {
                        // Update existing visit
                        var visit = await _context.MaintenanceVisits.FindAsync(vm.Id);
                        if (visit == null)
                        {
                            return NotFound();
                        }

                        visit.AllocationId = vm.AllocationId;
                        visit.FridgeId = vm.FridgeId;
                        visit.CustomerId = vm.CustomerId;
                        visit.AssignedTechnicianId = vm.TechnicianId;
                        visit.ScheduledDate = vm.ScheduledDate;
                        visit.ActualStartTime = vm.ActualDate;
                        visit.ActualEndTime = vm.ActualDate;
                        visit.Status = vm.Status;
                        visit.VisitType = vm.VisitType;
                        visit.TechnicianNotes = vm.TechnicianNotes;
                        visit.PartsReplaced = vm.PartsUsed;
                        visit.ServiceCost = vm.ServiceCost; // Now this will work
                        visit.ModifiedDate = DateTime.Now;
                        visit.IsActive = true;

                        _context.MaintenanceVisits.Update(visit);
                        await _context.SaveChangesAsync();

                        TempData["success"] = "Maintenance visit updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving maintenance visit: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: MaintenanceVisits/Complete/5
        [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole)]
        public async Task<IActionResult> Complete(int id)
        {
            var visit = await _context.MaintenanceVisits
                .Include(v => v.Fridge)
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);

            if (visit == null)
            {
                return NotFound();
            }

            var vm = new CompleteMaintenanceVM
            {
                VisitId = visit.Id,
                FridgeInfo = $"{visit.Fridge?.Manufacturer} - {visit.Fridge?.SerialNumber}",
                CustomerInfo = visit.Customer?.TradingName,
                ActualDate = DateTime.Now,
                Status = ServicingStatus.Completed
            };

            return View(vm);
        }

        // POST: MaintenanceVisits/Complete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.MaintenanceTechnicianRole)]
        public async Task<IActionResult> Complete(CompleteMaintenanceVM vm)
        {
            if (ModelState.IsValid)
            {
                var visit = await _context.MaintenanceVisits.FindAsync(vm.VisitId);
                if (visit == null)
                {
                    return NotFound();
                }

                visit.ActualEndTime = vm.ActualDate; // Map to correct property
                visit.Status = vm.Status;
                visit.TechnicianNotes = vm.TechnicianNotes;
                visit.PartsReplaced = vm.PartsUsed; // Map to correct property
                visit.ModifiedDate = DateTime.Now;

                // If start time wasn't set, set it to the same as end time
                if (!visit.ActualStartTime.HasValue)
                {
                    visit.ActualStartTime = vm.ActualDate;
                }

                _context.MaintenanceVisits.Update(visit);
                await _context.SaveChangesAsync();

                TempData["success"] = "Maintenance visit completed successfully";
                return RedirectToAction(nameof(Details), new { id = vm.VisitId });
            }

            return View(vm);
        }

        // POST: MaintenanceVisits/Delete/5 (Soft Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var visit = await _context.MaintenanceVisits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            // Soft delete
            visit.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            TempData["success"] = "Maintenance visit deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: MaintenanceVisits/Dashboard
        // For scheduling dashboard - show upcoming visits
        // GET: MaintenanceVisits/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var overdueVisits = await _context.MaintenanceVisits
                .Include(v => v.Fridge)
                .Include(v => v.Customer)
                .Where(v => v.IsActive &&
                           (v.Status == ServicingStatus.Scheduled || v.Status == ServicingStatus.InProgress) &&
                           v.ScheduledDate < DateTime.Today)
                .OrderBy(v => v.ScheduledDate)
                .ToListAsync();

            var dashboard = new MaintenanceDashboardVM
            {
                TotalVisits = await _context.MaintenanceVisits.CountAsync(v => v.IsActive),
                ScheduledVisits = await _context.MaintenanceVisits
                    .CountAsync(v => v.IsActive && v.Status == ServicingStatus.Scheduled),
                CompletedVisits = await _context.MaintenanceVisits
                    .CountAsync(v => v.IsActive && v.Status == ServicingStatus.Completed),
                InProgressVisits = await _context.MaintenanceVisits
                    .CountAsync(v => v.IsActive && v.Status == ServicingStatus.InProgress),
                OverdueVisits = overdueVisits, // Set the list
                UpcomingVisits = await _context.MaintenanceVisits
                    .Include(v => v.Fridge)
                    .Include(v => v.Customer)
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

        private async Task PopulateDropdowns(MaintenanceVisitVM vm)
        {
            vm.FridgeList = await _context.Fridges
                .Where(f => f.IsActive && f.Status != FridgeStatus.Scrapped)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.Model}"
                })
                .ToListAsync();

            vm.CustomerList = await _context.Customers
                .Where(c => c.IsActive)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.TradingName
                })
                .ToListAsync();

            vm.TechnicianList = await _context.Employees
                .Where(e => e.IsActive && e.EmployeeType == EmployeeType.MaintenanceTechnician)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName}"
                })
                .ToListAsync();

            vm.StatusList = GetServicingStatusList();
            vm.VisitTypeList = GetVisitTypeList();
        }

        private List<SelectListItem> GetServicingStatusList()
        {
            return Enum.GetValues(typeof(ServicingStatus))
                .Cast<ServicingStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();
        }

        private List<SelectListItem> GetVisitTypeList()
        {
            return Enum.GetValues(typeof(ServicingType))
                .Cast<ServicingType>()
                .Select(v => new SelectListItem
                {
                    Value = v.ToString(),
                    Text = v.ToString()
                })
                .ToList();
        }
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
    //                v.Fridge.Model.Contains(search));
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
