
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using Project.Models.ViewModels;
using Project.Utilities;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole + "," + SD.CustomerSupportRole)]
    public class ReplacementRequestsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReplacementRequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: ReplacementRequest
        public async Task<IActionResult> Index()
        {
            var requests = await _db.ReplacementRequests
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Customer)
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Fridge)
                .Include(r => r.AssignedEmployee)
                .Include(r => r.FaultRecord)
                .Where(r => !r.IsDeleted)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(requests);
        }

        // GET: ReplacementRequest/Create
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Create()
        {
            var vm = new ReplacementRequestVM();
            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: ReplacementRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Create(ReplacementRequestVM vm)
        {
            if (ModelState.IsValid)
            {
                var request = new ReplacementRequest
                {
                    FridgeAllocationId = vm.FridgeAllocationId,
                    FaultRecordId = vm.FaultRecordId,
                    RequestType = vm.RequestType,
                    Reason = vm.Reason,
                    Quantity = vm.Quantity,
                    Priority = vm.Priority,
                    RequestedDate = vm.RequestedDate,
                    CreatedAt = DateTime.UtcNow
                };

                _db.ReplacementRequests.Add(request);
                await _db.SaveChangesAsync();

                TempData["Success"] = "Replacement request created successfully!";
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: ReplacementRequest/Details/5
        [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole + "," + SD.CustomerSupportRole)]
        public async Task<IActionResult> Details(int id)
        {
            var request = await _db.ReplacementRequests
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Customer)
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Fridge)
                .Include(r => r.AssignedEmployee)
                .Include(r => r.FaultRecord)
                .Include(r => r.MaintenanceRecord)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: ReplacementRequest/Edit/5
        [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _db.ReplacementRequests
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (request == null)
            {
                return NotFound();
            }

            var vm = new ReplacementRequestVM
            {
                Id = request.Id,
                FridgeAllocationId = request.FridgeAllocationId,
                FaultRecordId = request.FaultRecordId,
                RequestType = request.RequestType,
                Reason = request.Reason,
                Quantity = request.Quantity,
                Priority = request.Priority,
                RequestedDate = request.RequestedDate,
                Status = request.Status,
                AssignedEmployeeId = request.AssignedEmployeeId,
                ResponseNotes = request.ResponseNotes
            };

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: ReplacementRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
        public async Task<IActionResult> Edit(int id, ReplacementRequestVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var request = await _db.ReplacementRequests.FindAsync(id);
                if (request == null || request.IsDeleted)
                {
                    return NotFound();
                }

                request.FridgeAllocationId = vm.FridgeAllocationId;
                request.FaultRecordId = vm.FaultRecordId;
                request.RequestType = vm.RequestType;
                request.Reason = vm.Reason;
                request.Quantity = vm.Quantity;
                request.Priority = vm.Priority;
                request.RequestedDate = vm.RequestedDate;
                request.Status = vm.Status;
                request.AssignedEmployeeId = vm.AssignedEmployeeId;
                request.ResponseNotes = vm.ResponseNotes;
                request.UpdatedAt = DateTime.UtcNow;

                if (vm.Status == CustomerRequestStatus.Completed && !request.ResponseDate.HasValue)
                {
                    request.ResponseDate = DateTime.UtcNow;
                }

                _db.ReplacementRequests.Update(request);
                await _db.SaveChangesAsync();

                TempData["Success"] = "Replacement request updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        // GET: ReplacementRequest/Delete/5
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _db.ReplacementRequests
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Customer)
                .Include(r => r.FridgeAllocation)
                    .ThenInclude(fa => fa.Fridge)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: ReplacementRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.AdminRole)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _db.ReplacementRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            // Soft delete
            request.IsDeleted = true;
            request.UpdatedAt = DateTime.UtcNow;

            _db.ReplacementRequests.Update(request);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Replacement request deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
        public async Task<IActionResult> Assign(int id, int employeeId)
        {
            var request = await _db.ReplacementRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.AssignedEmployeeId = employeeId;
            request.AssignedDate = DateTime.UtcNow;
            request.Status = CustomerRequestStatus.InProgress;
            request.UpdatedAt = DateTime.UtcNow;

            _db.ReplacementRequests.Update(request);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Request assigned successfully!";
            return RedirectToAction(nameof(Details), new { id });
        }

        private async Task PopulateDropdowns(ReplacementRequestVM vm)
        {
            vm.FridgeAllocationList = await _db.FridgeAllocations
                .Include(fa => fa.Customer)
                .Include(fa => fa.Fridge)
                .Where(fa => fa.Status != AllocationStatus.Terminated)
                .Select(fa => new SelectListItem
                {
                    Value = fa.Id.ToString(),
                    Text = $"{fa.Customer.TradingName} - {fa.Fridge.Model} (Allocation: {fa.Id})"
                })
                .ToListAsync();

            vm.FaultRecordList = await _db.FaultRecords
                .Include(fr => fr.FridgeAllocation)
                .Where(fr => fr.Status != FaultStatus.Resolved)
                .Select(fr => new SelectListItem
                {
                    Value = fr.Id.ToString(),
                    Text = $"Fault #{fr.Id} - {fr.FridgeAllocation.Customer.TradingName}"
                })
                .ToListAsync();

            vm.EmployeeList = await _db.Employees
                .Where(e => e.IsActive && (e.EmployeeType == EmployeeType.StockController || e.EmployeeType == EmployeeType.CustomerSupport))
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = $"{e.UserAccount.FirstName} {e.UserAccount.LastName} ({e.EmployeeType})"
                })
                .ToListAsync();

            vm.RequestTypeList = Enum.GetValues(typeof(CustomerRequestType))
                .Cast<CustomerRequestType>()
                .Select(rt => new SelectListItem
                {
                    Value = rt.ToString(),
                    Text = rt.ToString()
                })
                .ToList();

            vm.PriorityList = Enum.GetValues(typeof(RequestPriority))
                .Cast<RequestPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();

            vm.StatusList = Enum.GetValues(typeof(CustomerRequestStatus))
                .Cast<CustomerRequestStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();
        }
    }
}
