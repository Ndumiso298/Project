using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Utility;
using Microsoft.EntityFrameworkCore;
using Project.Models.ViewModel;
using Project.Models;
using Project.Utility.Enums;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockController)]
    public class PurchaseRequestsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: PurchaseRequests
        public async Task<IActionResult> Index()
        {
            var requests = await _db.tblPurchaseRequests
                .Include(r => r.RequestedBy)
                .Include(r => r.ApprovedBy)
                .Include(r => r.Items)
                    .ThenInclude(i => i.FridgeModel)
                .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

            return View(requests);
        }

        // GET: PurchaseRequests/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            var vm = new PurchaseRequestVM();
            await PopulateDropdowns(vm);

            if (id == null)
                return View(vm); // New

            var entity = await _db.tblPurchaseRequests
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (entity == null) return NotFound();

            vm = MapToViewModel(entity);
            await PopulateDropdowns(vm);
            return View(vm);
        }

        // POST: PurchaseRequests/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PurchaseRequestVM vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            if (vm.Id == 0)
            {
                // Create new
                var entity = MapToEntity(vm);
                entity.CreatedAt = DateTime.UtcNow;
                _db.tblPurchaseRequests.Add(entity);
            }
            else
            {
                // Update existing
                var entity = await _db.tblPurchaseRequests
                    .Include(r => r.Items)
                    .FirstOrDefaultAsync(r => r.Id == vm.Id);

                if (entity == null) return NotFound();

                // Update header
                entity.RequestedById = vm.RequestedById;
                entity.Status = vm.Status;
                entity.Reason = vm.Reason;
                entity.CustomReason = vm.CustomReason;
                entity.Urgency = vm.Urgency;
                entity.RequiredByDate = vm.RequiredByDate;
                entity.EstimatedTotalCost = vm.EstimatedTotalCost;
                entity.ApprovedBudget = vm.ApprovedBudget;
                entity.UpdatedAt = DateTime.UtcNow;

                // Sync items
                var updatedItemIds = vm.Items.Select(i => i.Id).ToList();

                // Remove items not in VM
                var toRemove = entity.Items.Where(i => !updatedItemIds.Contains(i.Id)).ToList();
                _db.tblPurchaseRequestItems.RemoveRange(toRemove);

                // Update or add items
                foreach (var itemVm in vm.Items)
                {
                    var existing = entity.Items.FirstOrDefault(i => i.Id == itemVm.Id);
                    if (existing != null)
                    {
                        existing.FridgeModelId = itemVm.FridgeModelId;
                        existing.Quantity = itemVm.Quantity;
                        existing.EstimatedUnitPrice = itemVm.EstimatedUnitPrice;
                        existing.Notes = itemVm.Notes;
                        existing.ModifiedDate = DateTime.UtcNow;
                    }
                    else
                    {
                        entity.Items.Add(new PurchaseRequestItem
                        {
                            FridgeModelId = itemVm.FridgeModelId,
                            Quantity = itemVm.Quantity,
                            EstimatedUnitPrice = itemVm.EstimatedUnitPrice,
                            Notes = itemVm.Notes,
                            CreatedDate = DateTime.UtcNow,
                            ModifiedDate = DateTime.UtcNow
                        });
                    }
                }
            }

            await _db.SaveChangesAsync();
            TempData["success"] = "Purchase Request saved successfully";
            return RedirectToAction(nameof(Index));
        }

        // POST: PurchaseRequests/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.tblPurchaseRequests
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (entity == null) return NotFound();

            _db.tblPurchaseRequestItems.RemoveRange(entity.Items);
            _db.tblPurchaseRequests.Remove(entity);

            await _db.SaveChangesAsync();
            TempData["success"] = "Purchase Request deleted";
            return RedirectToAction(nameof(Index));
        }

        #region Helpers

        private async Task PopulateDropdowns(PurchaseRequestVM vm)
        {
            vm.FridgeModelList = await _db.tblFridges
                .Where(m => m.AvailabilityStatus == "Available")
                .Select(m => new SelectListItem
                {
                    Value = m.FridgeId.ToString(),
                    Text = $"{m.Brand} {m.Model}"
                })
                .ToListAsync();

            vm.EmployeeList = await _db.tblEmployees
                .Where(e => e.IsActive)
                .Select(e => new SelectListItem
                {
                    Value = e.EmployeeID.ToString(),
                    Text = $"{e.EmployeeNumber} - {e.ApplicationUser!.FullName}"
                })
                .ToListAsync();

            // Enums to dropdowns
            vm.StatusList = Enum.GetValues(typeof(PurchaseRequestStatus))
                .Cast<PurchaseRequestStatus>()
                .Select(s => new SelectListItem { Value = s.ToString(), Text = s.ToString() });

            vm.ReasonList = Enum.GetValues(typeof(PurchaseRequestReason))
                .Cast<PurchaseRequestReason>()
                .Select(r => new SelectListItem { Value = r.ToString(), Text = r.ToString() });

            vm.UrgencyList = Enum.GetValues(typeof(PurchaseRequestUrgency))
                .Cast<PurchaseRequestUrgency>()
                .Select(u => new SelectListItem { Value = u.ToString(), Text = u.ToString() });
        }

        private PurchaseRequestVM MapToViewModel(PurchaseRequest entity)
        {
            return new PurchaseRequestVM
            {
                Id = entity.Id,
                RequestedById = entity.RequestedById,
                Status = entity.Status,
                Reason = entity.Reason,
                CustomReason = entity.CustomReason,
                Urgency = entity.Urgency,
                RequiredByDate = entity.RequiredByDate,
                EstimatedTotalCost = entity.EstimatedTotalCost,
                ApprovedBudget = entity.ApprovedBudget,
                Items = entity.Items.Select(i => new PurchaseRequestItemVM
                {
                    Id = i.Id,
                    FridgeModelId = i.FridgeModelId,
                    Quantity = i.Quantity,
                    EstimatedUnitPrice = i.EstimatedUnitPrice,
                    Notes = i.Notes
                }).ToList()
            };
        }

        private PurchaseRequest MapToEntity(PurchaseRequestVM vm)
        {
            return new PurchaseRequest
            {
                RequestedById = vm.RequestedById,
                Status = vm.Status,
                Reason = vm.Reason,
                CustomReason = vm.CustomReason,
                Urgency = vm.Urgency,
                RequiredByDate = vm.RequiredByDate,
                EstimatedTotalCost = vm.EstimatedTotalCost,
                ApprovedBudget = vm.ApprovedBudget,
                Items = vm.Items.Select(i => new PurchaseRequestItem
                {
                    FridgeModelId = i.FridgeModelId,
                    Quantity = i.Quantity,
                    EstimatedUnitPrice = i.EstimatedUnitPrice,
                    Notes = i.Notes,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                }).ToList()
            };
        }
        #endregion
    }
}
