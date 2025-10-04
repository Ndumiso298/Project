
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Helpers;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.CustomerRole + "," + SD.FaultTechnicianRole)]
    public class FaultsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FaultsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Faults
        public async Task<IActionResult> Index(string status, string customerName, string location, string searchString)
        {
            IQueryable<FaultRecord> query = _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .Include(f => f.Fridge)
                .Include(f => f.MaintenanceVisits)
                .Where(f => f.Status != FaultStatus.Resolved);

            // Apply filters
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                if (Enum.TryParse<FaultStatus>(status, out var statusEnum))
                {
                    query = query.Where(f => f.Status == statusEnum);
                }
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                query = query.Where(f => f.ReportedBy.FirstName.Contains(customerName) ||
                                       f.ReportedBy.LastName.Contains(customerName));
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(f => f.FaultLocation.City.Contains(location));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(f =>
                    f.Description.Contains(searchString) ||
                    f.Fridge.SerialNumber.Contains(searchString) ||
                    f.ReportedBy.FirstName.Contains(searchString) ||
                    f.ReportedBy.LastName.Contains(searchString));
            }

            // Role-based filtering for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer != null)
                {
                    query = query.Where(f => f.ReportedById == customer.UserAccount.Id);
                }
            }

            var faults = await query.OrderByDescending(f => f.ReportedDate).ToListAsync();

            ViewBag.StatusList = GetFaultStatusList();
            ViewBag.CurrentStatus = status;
            ViewBag.CustomerName = customerName;
            ViewBag.Location = location;
            ViewBag.SearchString = searchString;

            return View(faults);
        }

        // GET: Faults/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var fault = await _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .Include(f => f.Fridge)
                .Include(f => f.MaintenanceVisits)
                .Include(f => f.FaultLocation)
                .FirstOrDefaultAsync(f => f.Id == id && f.Status != FaultStatus.Resolved);

            if (fault == null)
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || fault.ReportedById != customer.UserAccount.Id)
                {
                    return Forbid();
                }
            }

            return View(fault);
        }

        // GET: Faults/Upsert
        public async Task<IActionResult> Upsert(int? id, int? fridgeId, int? maintenanceVisitId)
        {
            var vm = new FaultRecordVM();
            await PopulateDropdowns(vm);

            if (id == null || id == 0)
            {
                // Create new fault
                vm.ReportedDate = DateTime.Now;
                vm.Status = FaultStatus.Reported; // CORRECT: Using Status property

                // Pre-populate from fridge or maintenance visit if provided
                if (fridgeId.HasValue)
                {
                    var fridge = await _db.Fridges
                        .Include(f => f.CurrentLocation)
                        .FirstOrDefaultAsync(f => f.Id == fridgeId);

                    if (fridge != null)
                    {
                        vm.FridgeId = fridgeId.Value;
                        vm.FaultLocationId = fridge.LocationId;
                        ViewBag.FridgeInfo = $"{fridge.SerialNumber} - {fridge.FridgeModel}";
                    }
                }

                if (maintenanceVisitId.HasValue)
                {
                    var visit = await _db.MaintenanceVisits
                        .Include(v => v.Fridge)
                        .Include(v => v.Customer)
                        .FirstOrDefaultAsync(v => v.Id == maintenanceVisitId);

                    if (visit != null)
                    {
                        vm.MaintenanceVisitId = maintenanceVisitId.Value;
                        vm.FridgeId = (int)visit.FridgeId;
                        vm.ReportedById = visit.Customer.UserAccount.Id;
                    }
                }

                // Pre-populate for customers
                if (User.IsInRole(SD.CustomerRole))
                {
                    var customer = await GetCurrentCustomerAsync();
                    if (customer != null)
                    {
                        vm.ReportedById = customer.UserAccount.Id;
                    }
                }

                return View(vm);
            }

            // Edit existing fault
            var fault = await _db.FaultRecords
                .Include(f => f.Fridge)
                .FirstOrDefaultAsync(f => f.Id == id && f.Status != FaultStatus.Resolved);

            if (fault == null)
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || fault.ReportedById != customer.UserAccount.Id)
                {
                    return Forbid();
                }
            }

            vm.Id = fault.Id;
            vm.FridgeId = fault.FridgeId;
            vm.ReportedById = fault.ReportedById;
            vm.AssignedTechnicianId = fault.AssignedTechnicianId;
            vm.FaultLocationId = fault.FaultLocationId ?? 0;
            vm.Description = fault.Description; // CORRECT: Using Description property
            vm.Status = fault.Status; // CORRECT: Using Status property
            vm.Priority = fault.Priority;
            vm.ReportedDate = fault.ReportedDate;
            vm.ResolvedDate = fault.ClosedDate;
            vm.ResolutionNotes = fault.ResolutionNotes;
            vm.PartsReplaced = fault.PartsReplaced;
            vm.RepairCost = fault.TotalCost;

            return View(vm);
        }

        // POST: Faults/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FaultRecordVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (vm.Id == 0)
                    {
                        // Create new fault
                        var fault = new FaultRecord
                        {
                            FridgeId = vm.FridgeId,
                            ReportedById = vm.ReportedById,
                            AssignedTechnicianId = vm.AssignedTechnicianId,
                            FaultLocationId = vm.FaultLocationId,
                            Description = vm.Description, // CORRECT: Using Description property
                            Status = vm.Status, // CORRECT: Using Status property
                            Priority = vm.Priority,
                            ReportedDate = vm.ReportedDate,
                            ResolvedDate = vm.ResolvedDate,
                            ResolutionNotes = vm.ResolutionNotes,
                            PartsReplaced = vm.PartsReplaced,
                            CreatedAt = DateTime.Now
                        };

                        _db.FaultRecords.Add(fault);
                        await _db.SaveChangesAsync();

                        TempData["success"] = "Fault reported successfully";
                    }
                    else
                    {
                        // Update existing fault
                        var fault = await _db.FaultRecords.FindAsync(vm.Id);
                        if (fault == null)
                        {
                            return NotFound();
                        }

                        // Authorization check for customers
                        if (User.IsInRole(SD.CustomerRole) && fault.Status != FaultStatus.Reported)
                        {
                            TempData["error"] = "Cannot edit fault after it has been processed";
                            return RedirectToAction(nameof(Details), new { id = vm.Id });
                        }

                        fault.FridgeId = vm.FridgeId;
                        fault.ReportedById = vm.ReportedById;
                        fault.AssignedTechnicianId = vm.AssignedTechnicianId;
                        fault.FaultLocationId = vm.FaultLocationId;
                        fault.Description = vm.Description; // CORRECT: Using Description property
                        fault.Status = vm.Status; // CORRECT: Using Status property
                        fault.Priority = vm.Priority;
                        fault.ReportedDate = vm.ReportedDate;
                        fault.ResolvedDate = vm.ResolvedDate;
                        fault.ResolutionNotes = vm.ResolutionNotes;
                        fault.PartsReplaced = vm.PartsReplaced;
                        fault.UpdatedAt = DateTime.Now;

                        // Update resolved date if status changed to resolved
                        if (vm.Status == FaultStatus.Resolved && !fault.ClosedDate.HasValue) // CORRECT: Using Status property
                        {
                            fault.ClosedDate = DateTime.Now;
                        }

                        _db.FaultRecords.Update(fault);
                        await _db.SaveChangesAsync();

                        TempData["success"] = "Fault updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving fault: {ex.Message}");
                }
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: Faults/Process/5
        [Authorize(Roles = SD.AdminRole + "," + SD.FaultTechnicianRole)]
        public async Task<IActionResult> Process(int id)
        {
            var fault = await _db.FaultRecords
                .Include(f => f.Fridge)
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .FirstOrDefaultAsync(f => f.Id == id && f.Status != FaultStatus.Resolved);

            if (fault == null)
            {
                return NotFound();
            }

            var vm = new ProcessFaultVM
            {
                Id = fault.Id,
                FridgeInfo = $"{fault.Fridge?.SerialNumber} - {fault.Fridge?.FridgeModel.ModelName}",
                CustomerInfo = $"{fault.ReportedBy?.FirstName} {fault.ReportedBy?.LastName}",
                FaultDescription = fault.Description,
                ReportedDate = fault.ReportedDate,
                AssignedTechnicianId = fault.AssignedTechnicianId,
                FaultStatus = fault.Status,
                Priority = fault.Priority
            };

            await PopulateProcessDropdowns(vm);
            return View(vm);
        }

        // POST: Faults/Process/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.FaultTechnicianRole)]
        public async Task<IActionResult> Process(ProcessFaultVM vm)
        {
            if (ModelState.IsValid)
            {
                var fault = await _db.FaultRecords.FindAsync(vm.Id);
                if (fault == null || fault.Status == FaultStatus.Resolved)
                {
                    return NotFound();
                }

                fault.AssignedTechnicianId = vm.AssignedTechnicianId;
                fault.Status = vm.FaultStatus;
                fault.Priority = vm.Priority;
                fault.ResolutionNotes = vm.ResolutionNotes;
                fault.PartsReplaced = vm.PartsReplaced;
                fault.UpdatedAt = DateTime.Now;

                // Update resolved date if status changed to resolved
                if (vm.FaultStatus == FaultStatus.Resolved && !fault.ClosedDate.HasValue)
                {
                    fault.ClosedDate = DateTime.Now;
                }

                _db.FaultRecords.Update(fault);
                await _db.SaveChangesAsync();

                TempData["success"] = "Fault processed successfully";
                return RedirectToAction(nameof(Details), new { id = vm.Id });
            }

            await PopulateProcessDropdowns(vm);
            return View(vm);
        }

        // GET: Faults/Print/5
        public async Task<IActionResult> Print(int id)
        {
            var fault = await _db.FaultRecords
                .Include(f => f.ReportedBy)
                .Include(f => f.AssignedTechnician)
                .Include(f => f.Fridge)
                .Include(f => f.FaultLocation)
                .FirstOrDefaultAsync(f => f.Id == id && f.Status != FaultStatus.Resolved);

            if (fault == null)
            {
                return NotFound();
            }

            // Authorization check for customers
            if (User.IsInRole(SD.CustomerRole))
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null || fault.ReportedById != customer.UserAccount.Id)
                {
                    return Forbid();
                }
            }

            return View(fault);
        }

        // POST: Faults/Delete/5 (Soft Delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var fault = await _db.FaultRecords.FindAsync(id);
            if (fault == null)
            {
                return NotFound();
            }

            // Soft delete
            fault.Status = FaultStatus.Closed;
            fault.UpdatedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            TempData["success"] = "Fault record deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: Faults/Dashboard
        [Authorize(Roles = SD.AdminRole + "," + SD.FaultTechnicianRole)]
        public async Task<IActionResult> Dashboard()
        {
            var dashboard = new FaultDashboardVM
            {
                TotalFaults = await _db.FaultRecords.CountAsync(f => f.Status == FaultStatus.Reported),
                OpenFaults = await _db.FaultRecords.CountAsync(f =>
                    f.Status == FaultStatus.Reported || f.Status == FaultStatus.Assigned || f.Status == FaultStatus.InProgress),
                ResolvedFaults = await _db.FaultRecords.CountAsync(f => f.Status == FaultStatus.Resolved),
                HighPriorityFaults = await _db.FaultRecords.CountAsync(f => f.Priority == FaultPriority.High),
                RecentFaults = await _db.FaultRecords
                    .Include(f => f.Fridge)
                    .Include(f => f.ReportedBy)
                    .Where(f => f.Status != FaultStatus.Resolved && f.ReportedDate >= DateTime.Now.AddDays(-7))
                    .OrderByDescending(f => f.ReportedDate)
                    .Take(10)
                    .Select(f => new FaultSummaryVM
                    {
                        Id = f.Id,
                        FaultDescription = f.Description,
                        Status = f.Status,
                        Priority = f.Priority,
                        ReportedDate = f.ReportedDate,
                    })
                    .ToListAsync()
            };

            return View(dashboard);
        }

        private async Task PopulateDropdowns(FaultRecordVM vm)
        {
            vm.FridgeList = await _db.Fridges
                .Where(f => f.Status != FridgeStatus.Scrapped)
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = $"{f.SerialNumber} - {f.FridgeModel.ModelName}"
                })
                .ToListAsync();

            vm.UserList = await _db.Users
                .Where(u => !u.IsDeleted)
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            vm.TechnicianList = await _db.Employees
                .Where(e => e.IsActive && (e.EmployeeType == EmployeeType.FaultTechnician || e.EmployeeType == EmployeeType.MaintenanceTechnician))
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName}"
                })
                .ToListAsync();

            vm.VisitList = await _db.MaintenanceVisits
                .Where(v => v.Status == ServicingStatus.Scheduled)
                .Select(v => new SelectListItem
                {
                    Value = v.Id.ToString(),
                    Text = $"Visit #{v.Id} - {v.ScheduledDate:dd/MM/yyyy}"
                })
                .ToListAsync();

            vm.LocationList = await _db.Locations
                .Where(l => !l.IsDeleted) // Fixed: changed from l.IsDeleted to !l.IsDeleted
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.City
                })
                .ToListAsync();

            vm.StatusList = GetFaultStatusList();
            vm.PriorityList = GetFaultPriorityList();
        }

        private async Task PopulateProcessDropdowns(ProcessFaultVM vm)
        {
            vm.TechnicianList = await _db.Employees
                .Where(e => e.IsActive && (e.EmployeeType == EmployeeType.FaultTechnician || e.EmployeeType == EmployeeType.MaintenanceTechnician))
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName}"
                })
                .ToListAsync();

            vm.StatusList = GetFaultStatusList();
            vm.PriorityList = GetFaultPriorityList();
        }

        private List<SelectListItem> GetFaultStatusList()
        {
            return Enum.GetValues(typeof(FaultStatus))
                .Cast<FaultStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString() // You can use GetDisplayName() if you have that extension method
                })
                .ToList();
        }

        private List<SelectListItem> GetFaultPriorityList()
        {
            return Enum.GetValues(typeof(FaultPriority))
                .Cast<FaultPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();
        }

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive);
        }
    }
}
        // Extension method to get Display Name from enum


        //public class FaultsController : Controller
        //{
        //    private readonly ApplicationDbContext _db;
        //    public FaultsController(ApplicationDbContext db)
        //    {
        //        _db = db;
        //    }
        //    public IActionResult Index(string customerName, string location, string status)
        //    {
        //        var faults = _db.FaultRecords
        //            .Include(f => f.ReportedBy)
        //            .Include(f => f.AssignedTechnician)
        //            .Include(f => f.Fridge)
        //            .AsQueryable();

        //        if (!string.IsNullOrEmpty(customerName))
        //            faults = faults.Where(f => f.ReportedBy.Customer.UserAccount.FirstName.Contains(customerName));

        //        if (!string.IsNullOrEmpty(location))
        //            faults = faults.Where(f => f.ReportedBy.Customer.BusinessName.Contains(location));

        //        if (!string.IsNullOrEmpty(status))
        //            faults = faults.Where(f => f.Status == Utilities.Enums.FaultStatus.Reported);

        //        ViewBag.CustomerName = customerName;
        //        ViewBag.Location = location;
        //        ViewBag.Status = status;

        //        return View(faults);
        //    }

        //    public IActionResult Create()
        //    {
        //        return View();
        //    }
        //    public IActionResult Details(int id)
        //    {
        //        var fault = _db.FaultRecords
        //            .Include(f => f.ReportedBy)
        //            .Include(f => f.AssignedTechnician)
        //            .Include(f => f.Fridge)
        //            .FirstOrDefault(f => f.Id == id);

        //        if (fault == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(fault);
        //    }

        //    [HttpGet]
        //    public IActionResult Process(int id)
        //    {
        //        var fault = _db.FaultRecords
        //            .Include(f => f.ReportedBy)
        //            .Include(f => f.Fridge)
        //            .FirstOrDefault(f => f.Id == id);

        //        if (fault == null) return NotFound();

        //        ViewBag.Technicians = _db.Employees
        //            .Select(t => new SelectListItem
        //            {
        //                Value = t.Id.ToString(),
        //                Text = t.UserAccount.FirstName,
        //            }).ToList();

        //        return View(fault);
        //    }


        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Process(FaultRecord input)
        //    {
        //        var fault = _db.FaultRecords.FirstOrDefault(f => f.Id == input.Id);
        //        if (fault == null) return NotFound();

        //        fault.Status = input.Status;
        //        fault.ResolutionNotes = input.ResolutionNotes;
        //        fault.AssignedTechnician = input.AssignedTechnician;
        //        if (fault.Status == FaultStatus.Resolved)
        //            fault.ResolvedDate = DateTime.Now;
        //        else
        //            fault.ResolvedDate = null;


        //        _db.SaveChanges();
        //        TempData["SuccessMessage"] = "FaultRecord processed successfully.";

        //        return RedirectToAction("Index");
        //    }
        //    public IActionResult Print(int id)
        //    {
        //        var fault = _db.FaultRecords
        //            .Include(f => f.ReportedBy)
        //            .Include(f => f.Fridge)
        //            .Include(f => f.AssignedTechnician)
        //            .FirstOrDefault(f => f.Id == id);

        //        if (fault == null)
        //        {
        //            return NotFound();
        //        }

        //        return View("Print", fault);
        //    }

        //}
