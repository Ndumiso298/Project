using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.ViewModels;
using Project.Models;
using Project.Utilities.Enums;
using Project.Utilities;
using System.Data;
using Project.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.StockControllerRole)]
    public class FridgesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<FridgesController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public FridgesController(
            ApplicationDbContext db,
            ILogger<FridgesController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        // ===== INDEX & LISTING =====
        public async Task<IActionResult> Index(string searchString, string statusFilter, string conditionFilter, string locationFilter, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _db.Fridges
                    .Include(f => f.FridgeModel)
                    .Include(f => f.CurrentLocation)
                    .Include(f => f.CurrentCustomer)
                    .Where(f => f.IsActive);

                // Apply search filter
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    query = query.Where(f =>
                        f.SerialNumber.ToLower().Contains(searchString) ||
                        f.FridgeModel.Manufacturer.ToLower().Contains(searchString) ||
                        f.FridgeModel.ModelName.ToLower().Contains(searchString) ||
                        f.FridgeModel.ModelCode.ToLower().Contains(searchString) ||
                        (f.Supplier != null && f.Supplier.ToLower().Contains(searchString)) ||
                        (f.CurrentCustomer != null && f.CurrentCustomer.BusinessName.ToLower().Contains(searchString))
                    );
                }

                // Apply status filter
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                {
                    if (Enum.TryParse<FridgeStatus>(statusFilter, out var status))
                    {
                        query = query.Where(f => f.Status == status);
                    }
                }

                // Apply condition filter
                if (!string.IsNullOrEmpty(conditionFilter) && conditionFilter != "All")
                {
                    if (Enum.TryParse<FridgeCondition>(conditionFilter, out var condition))
                    {
                        query = query.Where(f => f.Condition == condition);
                    }
                }

                // Apply location filter
                if (!string.IsNullOrEmpty(locationFilter) && locationFilter != "All")
                {
                    if (int.TryParse(locationFilter, out var locationId))
                    {
                        query = query.Where(f => f.LocationId == locationId);
                    }
                }

                // Pagination
                var totalCount = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                page = Math.Max(1, Math.Min(page, totalPages));

                var fridges = await query
                    .OrderBy(f => f.FridgeModel.Manufacturer)
                    .ThenBy(f => f.FridgeModel.ModelName)
                    .ThenBy(f => f.SerialNumber)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var fridgeVMs = new List<FridgeVM>();
                foreach (var fridge in fridges)
                {
                    var fridgeVM = await MapToViewModelAsync(fridge);
                    fridgeVMs.Add(fridgeVM);
                }

                await PopulateFilterDropdowns();

                // ViewBag for filters and pagination
                ViewBag.SearchString = searchString;
                ViewBag.StatusFilter = statusFilter;
                ViewBag.ConditionFilter = conditionFilter;
                ViewBag.LocationFilter = locationFilter;
                ViewBag.Page = page;
                ViewBag.TotalPages = totalPages;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalCount = totalCount;

                return View(fridgeVMs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading fridge index page");
                TempData["error"] = "An error occurred while loading fridges.";
                return RedirectToAction("Index", "Home");
            }
        }

        // ===== DETAILS =====
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    TempData["error"] = "Fridge ID is required.";
                    return RedirectToAction(nameof(Index));
                }

                var fridge = await GetFridgeWithRelatedData(id.Value);
                if (fridge == null)
                {
                    TempData["error"] = "Fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                var fridgeVM = await MapToViewModelAsync(fridge);
                return View(fridgeVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading fridge details for ID: {FridgeId}", id);
                TempData["error"] = "An error occurred while loading fridge details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // ===== CREATE/EDIT =====
        public async Task<IActionResult> Upsert(int? id)
        {
            try
            {
                var fridgeVM = new FridgeVM();
                await PopulateDropdowns(fridgeVM);

                if (id == null || id == 0)
                {
                    ViewBag.Action = "Create";
                    fridgeVM.Status = FridgeStatus.Available;
                    fridgeVM.Condition = FridgeCondition.Excellent;
                    fridgeVM.PurchaseDate = DateTime.Today;
                    return View(fridgeVM);
                }

                ViewBag.Action = "Edit";
                var fridge = await _db.Fridges
                    .Include(f => f.FridgeModel)
                    .Include(f => f.CurrentLocation)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                if (fridge == null)
                {
                    TempData["error"] = "Fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                fridgeVM = await MapToViewModelAsync(fridge);
                await PopulateDropdowns(fridgeVM);

                return View(fridgeVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading fridge upsert page for ID: {FridgeId}", id);
                TempData["error"] = "An error occurred while loading the fridge form.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FridgeVM fridgeVM)
        {
            try
            {
                // Clean input data
                fridgeVM.SerialNumber = fridgeVM.SerialNumber?.Trim().ToUpper();
                fridgeVM.Supplier = fridgeVM.Supplier?.Trim();

                if (!ModelState.IsValid)
                {
                    await PopulateDropdowns(fridgeVM);
                    ViewBag.Action = fridgeVM.Id == 0 ? "Create" : "Edit";
                    return View(fridgeVM);
                }

                if (fridgeVM.Id == 0)
                {
                    await CreateFridge(fridgeVM);
                    TempData["success"] = $"Fridge {fridgeVM.SerialNumber} created successfully.";
                    return RedirectToAction(nameof(Details), new { id = fridgeVM.Id });
                }
                else
                {
                    await UpdateFridge(fridgeVM);
                    TempData["success"] = $"Fridge {fridgeVM.SerialNumber} updated successfully.";
                    return RedirectToAction(nameof(Details), new { id = fridgeVM.Id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving fridge: {SerialNumber}", fridgeVM.SerialNumber);
                TempData["error"] = $"An error occurred: {ex.Message}";
                await PopulateDropdowns(fridgeVM);
                ViewBag.Action = fridgeVM.Id == 0 ? "Create" : "Edit";
                return View(fridgeVM);
            }
        }

        // ===== STATUS MANAGEMENT =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, FridgeStatus status)
        {
            try
            {
                var fridge = await _db.Fridges
                    .Include(f => f.CurrentAllocation)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                if (fridge == null)
                {
                    TempData["error"] = "Fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Validate status change
                if (!IsValidStatusChange(fridge.Status, status))
                {
                    TempData["error"] = $"Cannot change status from {fridge.Status} to {status}.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                // Check if fridge is allocated and trying to change to non-operational status
                if (fridge.CurrentAllocation != null &&
                    (status == FridgeStatus.Scrapped || status == FridgeStatus.LostStolen))
                {
                    TempData["error"] = "Cannot scrap or mark as lost/stolen while fridge is allocated to a customer.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                fridge.Status = status;
                fridge.UpdatedAt = DateTime.UtcNow;
                fridge.UpdatedBy = _userManager.GetUserId(User);

                _db.Fridges.Update(fridge);
                await _db.SaveChangesAsync();

                _logger.LogInformation("Fridge status updated: {SerialNumber} from {OldStatus} to {NewStatus} by {User}",
                    fridge.SerialNumber, fridge.Status, status, User.Identity?.Name);

                TempData["success"] = $"Fridge status updated to {status}.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating fridge status for ID: {FridgeId}", id);
                TempData["error"] = "An error occurred while updating fridge status.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Scrap(int id, string reason)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(reason))
                {
                    TempData["error"] = "Scrap reason is required.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                var fridge = await _db.Fridges
                    .Include(f => f.CurrentAllocation)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                if (fridge == null)
                {
                    TempData["error"] = "Fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (fridge.CurrentAllocation != null)
                {
                    TempData["error"] = "Cannot scrap fridge that is currently allocated to a customer.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                if (!fridge.CanBeScrapped())
                {
                    TempData["error"] = "Fridge cannot be scrapped in its current condition/status.";
                    return RedirectToAction(nameof(Details), new { id });
                }

                fridge.Status = FridgeStatus.Scrapped;
                fridge.UpdatedAt = DateTime.UtcNow;
                fridge.UpdatedBy = _userManager.GetUserId(User);

                // TODO: Create a ScrapRecord to store the reason
                _db.Fridges.Update(fridge);
                await _db.SaveChangesAsync();

                _logger.LogInformation("Fridge scrapped: {SerialNumber} by {User}. Reason: {Reason}",
                    fridge.SerialNumber, User.Identity?.Name, reason);

                TempData["success"] = $"Fridge {fridge.SerialNumber} has been scrapped.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error scrapping fridge with ID: {FridgeId}", id);
                TempData["error"] = "An error occurred while scrapping the fridge.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // ===== MAINTENANCE ACTIONS =====
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecordService(int id, DateTime serviceDate, string serviceNotes)
        {
            try
            {
                var fridge = await _db.Fridges
                    .Include(f => f.FridgeModel)
                    .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);

                if (fridge == null)
                {
                    TempData["error"] = "Fridge not found.";
                    return RedirectToAction(nameof(Index));
                }

                fridge.LastServiceDate = serviceDate;
                fridge.NextServiceDue = serviceDate.AddMonths(fridge.FridgeModel.ServiceIntervalMonths);
                fridge.TotalServiceCount++;
                fridge.UpdatedAt = DateTime.UtcNow;
                fridge.UpdatedBy = _userManager.GetUserId(User);

                // TODO: Create a MaintenanceRecord with the service details
                _db.Fridges.Update(fridge);
                await _db.SaveChangesAsync();

                _logger.LogInformation("Service recorded for fridge: {SerialNumber} by {User}",
                    fridge.SerialNumber, User.Identity?.Name);

                TempData["success"] = "Service recorded successfully.";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording service for fridge ID: {FridgeId}", id);
                TempData["error"] = "An error occurred while recording the service.";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // ===== AJAX METHODS =====
        [AcceptVerbs("GET", "POST")]
        public async Task<JsonResult> VerifySerialNumber(string serialNumber, int id = 0)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(serialNumber))
                {
                    return Json(new { isValid = false, message = "Serial number is required." });
                }

                serialNumber = serialNumber.Trim().ToUpper();
                var exists = await _db.Fridges
                    .AnyAsync(f => f.SerialNumber == serialNumber && f.Id != id && f.IsActive);

                return Json(new
                {
                    isValid = !exists,
                    message = exists ? "A fridge with this serial number already exists." : "Serial number is available."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying serial number: {SerialNumber}", serialNumber);
                return Json(new { isValid = false, message = "Error verifying serial number." });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetFridgeModelDetails(int modelId)
        {
            try
            {
                var model = await _db.FridgeModels
                    .Where(fm => fm.Id == modelId && fm.IsActive)
                    .Select(fm => new
                    {
                        fm.Manufacturer,
                        fm.ModelName,
                        fm.ModelCode,
                        fm.ServiceIntervalMonths,
                        fm.MonthlyRentalPrice,
                        fm.WarrantyPeriodMonths
                    })
                    .FirstOrDefaultAsync();

                if (model == null)
                {
                    return Json(new { error = "Fridge model not found." });
                }

                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting fridge model details for ID: {ModelId}", modelId);
                return Json(new { error = "Error retrieving fridge model details." });
            }
        }

        #region Private Methods

        private async Task<Fridge?> GetFridgeWithRelatedData(int id)
        {
            return await _db.Fridges
                .Include(f => f.FridgeModel)
                .Include(f => f.CurrentLocation)
                .Include(f => f.CurrentCustomer)
                .Include(f => f.MaintenanceRecords.OrderByDescending(mr => mr.ServiceDate).Take(5))
                .Include(f => f.AllocationHistory.Where(a => a.IsActive).OrderByDescending(a => a.AllocationDate).Take(5))
                .Include(f => f.FaultReports.OrderByDescending(fr => fr.ReportedDate).Take(5))
                .FirstOrDefaultAsync(f => f.Id == id && f.IsActive);
        }

        private async Task<FridgeVM> MapToViewModelAsync(Fridge fridge)
        {
            var vm = new FridgeVM
            {
                Id = fridge.Id,
                SerialNumber = fridge.SerialNumber,
                FridgeModelId = fridge.FridgeModelId,
                LocationId = fridge.LocationId,
                CustomerId = fridge.CustomerId,
                Condition = fridge.Condition,
                Status = fridge.Status,
                PurchaseDate = fridge.PurchaseDate,
                PurchasePrice = fridge.PurchasePrice,
                Supplier = fridge.Supplier,
                WarrantyExpiryDate = fridge.WarrantyExpiryDate,
                LastServiceDate = fridge.LastServiceDate,
                NextServiceDue = fridge.NextServiceDue,
                TotalServiceCount = fridge.TotalServiceCount,
                LastFaultDate = fridge.LastFaultDate
            };

            // Populate navigation properties for display
            if (fridge.FridgeModel != null)
            {
                vm.FridgeModelDetails = new FridgeModelVM
                {
                    Manufacturer = fridge.FridgeModel.Manufacturer,
                    ModelName = fridge.FridgeModel.ModelName,
                    ModelCode = fridge.FridgeModel.ModelCode,
                    ServiceIntervalMonths = fridge.FridgeModel.ServiceIntervalMonths
                };
            }

            if (fridge.CurrentLocation != null)
            {
                vm.LocationDetails = new LocationVM
                {
                    Name = fridge.CurrentLocation.Name,
                    Suburb = fridge.CurrentLocation.Suburb,
                    City = fridge.CurrentLocation.City,
                    Province = fridge.CurrentLocation.Province,
                    StreetAddress = fridge.CurrentLocation.StreetAddress
                };
            }

            if (fridge.CurrentCustomer != null)
            {
                vm.CustomerDetails = new UserManagementVM
                {
                    BusinessName = fridge.CurrentCustomer.BusinessName,
                    BusinessType = fridge.CurrentCustomer.BusinessType
                };
            }

            // Populate computed statistics
            vm.AllocationHistoryCount = fridge.AllocationHistory?.Count ?? 0;
            vm.MaintenanceHistoryCount = fridge.MaintenanceRecords?.Count ?? 0;
            vm.FaultReportCount = fridge.FaultReports?.Count ?? 0;
            vm.OpenFaultCount = fridge.FaultReports?.Count(f =>
                f.Status == FaultStatus.Reported ||
                f.Status == FaultStatus.Assigned ||
                f.Status == FaultStatus.InProgress) ?? 0;

            return vm;
        }

        private async Task PopulateDropdowns(FridgeVM fridgeVM)
        {
            fridgeVM.FridgeModelList = await _db.FridgeModels
                .Where(fm => fm.Status == FridgeModelStatus.Active)
                .OrderBy(fm => fm.Manufacturer)
                .ThenBy(fm => fm.ModelName)
                .Select(fm => new SelectListItem
                {
                    Value = fm.Id.ToString(),
                    Text = $"{fm.Manufacturer} {fm.ModelName} ({fm.ModelCode})"
                })
                .ToListAsync();

            fridgeVM.LocationList = await _db.Locations
                .Where(l => !l.IsDeleted)
                .OrderBy(l => l.Province)
                .ThenBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Suburb}, {l.City}, {l.Province}"
                })
                .ToListAsync();

            fridgeVM.CustomerList = await _db.Customers
                .Where(c => c.AccountStatus == AccountStatus.Approved)
                .OrderBy(c => c.BusinessName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.BusinessName
                })
                .ToListAsync();

            fridgeVM.ConditionList = Enum.GetValues<FridgeCondition>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.GetDisplayName()
                })
                .ToList();

            fridgeVM.StatusList = Enum.GetValues<FridgeStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.GetDisplayName()
                })
                .ToList();

            // Get distinct suppliers for dropdown
            //fridgeVM.SupplierList = await _db.Fridges
            //    .Where(f => f.Supplier != null && f.IsActive)
            //    .Select(f => f.Supplier)
            //    .Distinct()
            //    .OrderBy(s => s)
            //    .Select(s => new SelectListItem
            //    {
            //        Value = s,
            //        Text = s
            //    })
            //    .ToListAsync();
        }

        private async Task PopulateFilterDropdowns()
        {
            ViewBag.StatusList = await GetStatusSelectListAsync();
            ViewBag.ConditionList = await GetConditionSelectListAsync();
            ViewBag.LocationList = await GetLocationSelectListAsync();
        }

        private async Task<IEnumerable<SelectListItem>> GetStatusSelectListAsync()
        {
            var items = Enum.GetValues<FridgeStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.GetDisplayName()
                })
                .ToList();

            items.Insert(0, new SelectListItem { Value = "All", Text = "All Statuses" });
            return items;
        }

        private async Task<IEnumerable<SelectListItem>> GetConditionSelectListAsync()
        {
            var items = Enum.GetValues<FridgeCondition>()
                .Select(c => new SelectListItem
                {
                    Value = c.ToString(),
                    Text = c.GetDisplayName()
                })
                .ToList();

            items.Insert(0, new SelectListItem { Value = "All", Text = "All Conditions" });
            return items;
        }

        private async Task<IEnumerable<SelectListItem>> GetLocationSelectListAsync()
        {
            var locations = await _db.Locations
                .Where(l => !l.IsDeleted)
                .OrderBy(l => l.Province)
                .ThenBy(l => l.City)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Suburb}, {l.City}"
                })
                .ToListAsync();

            locations.Insert(0, new SelectListItem { Value = "All", Text = "All Locations" });
            return locations;
        }

        private async Task CreateFridge(FridgeVM fridgeVM)
        {
            var validationResult = await ValidateFridgeForCreation(fridgeVM);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            var fridge = new Fridge
            {
                SerialNumber = fridgeVM.SerialNumber,
                FridgeModelId = fridgeVM.FridgeModelId,
                LocationId = fridgeVM.LocationId,
                CustomerId = fridgeVM.CustomerId,
                Condition = fridgeVM.Condition,
                Status = fridgeVM.Status,
                PurchaseDate = fridgeVM.PurchaseDate,
                PurchasePrice = fridgeVM.PurchasePrice,
                Supplier = fridgeVM.Supplier,
                WarrantyExpiryDate = fridgeVM.WarrantyExpiryDate,
                LastServiceDate = fridgeVM.LastServiceDate,
                NextServiceDue = await CalculateNextServiceDue(fridgeVM.LastServiceDate, fridgeVM.FridgeModelId),
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _userManager.GetUserId(User),
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = _userManager.GetUserId(User)
            };

            _db.Fridges.Add(fridge);
            await _db.SaveChangesAsync();

            fridgeVM.Id = fridge.Id; // Set the ID for redirect

            _logger.LogInformation("Fridge created: {SerialNumber} by {User}", fridge.SerialNumber, User.Identity?.Name);
        }

        private async Task UpdateFridge(FridgeVM fridgeVM)
        {
            var fridge = await _db.Fridges
                .FirstOrDefaultAsync(f => f.Id == fridgeVM.Id && f.IsActive);

            if (fridge == null)
            {
                throw new Exception("Fridge not found.");
            }

            var validationResult = await ValidateFridgeForUpdate(fridgeVM, fridge);
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            // Update fridge properties
            fridge.SerialNumber = fridgeVM.SerialNumber;
            fridge.FridgeModelId = fridgeVM.FridgeModelId;
            fridge.LocationId = fridgeVM.LocationId;
            fridge.CustomerId = fridgeVM.CustomerId;
            fridge.Condition = fridgeVM.Condition;
            fridge.Status = fridgeVM.Status;
            fridge.PurchaseDate = fridgeVM.PurchaseDate;
            fridge.PurchasePrice = fridgeVM.PurchasePrice;
            fridge.Supplier = fridgeVM.Supplier;
            fridge.WarrantyExpiryDate = fridgeVM.WarrantyExpiryDate;
            fridge.LastServiceDate = fridgeVM.LastServiceDate;
            fridge.NextServiceDue = await CalculateNextServiceDue(fridgeVM.LastServiceDate, fridgeVM.FridgeModelId);
            fridge.UpdatedAt = DateTime.UtcNow;
            fridge.UpdatedBy = _userManager.GetUserId(User);

            _db.Fridges.Update(fridge);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Fridge updated: {SerialNumber} by {User}", fridge.SerialNumber, User.Identity?.Name);
        }

        private async Task<ValidationResult> ValidateFridgeForCreation(FridgeVM fridgeVM)
        {
            // Check serial number uniqueness
            if (await _db.Fridges.AnyAsync(f => f.SerialNumber == fridgeVM.SerialNumber && f.IsActive))
            {
                return ValidationResult.Error("A fridge with this serial number already exists.");
            }

            // Validate fridge model exists and is active
            var fridgeModel = await _db.FridgeModels
                .FirstOrDefaultAsync(fm => fm.Id == fridgeVM.FridgeModelId && fm.Status == FridgeModelStatus.Active);

            if (fridgeModel == null)
            {
                return ValidationResult.Error("Selected fridge model is not available.");
            }

            return ValidationResult.Success;
        }

        private async Task<ValidationResult> ValidateFridgeForUpdate(FridgeVM fridgeVM, Fridge existingFridge)
        {
            // Check serial number uniqueness (excluding current fridge)
            if (await _db.Fridges.AnyAsync(f => f.SerialNumber == fridgeVM.SerialNumber && f.Id != existingFridge.Id && f.IsActive))
            {
                return ValidationResult.Error("A fridge with this serial number already exists.");
            }

            return ValidationResult.Success;
        }

        private async Task<DateTime?> CalculateNextServiceDue(DateTime? lastServiceDate, int fridgeModelId)
        {
            if (!lastServiceDate.HasValue) return null;

            var fridgeModel = await _db.FridgeModels.FindAsync(fridgeModelId);
            return lastServiceDate.Value.AddMonths(fridgeModel?.ServiceIntervalMonths ?? 6);
        }

        private bool IsValidStatusChange(FridgeStatus currentStatus, FridgeStatus newStatus)
        {
            // Define valid status transitions
            var validTransitions = new Dictionary<FridgeStatus, FridgeStatus[]>
            {
                [FridgeStatus.Available] = new[] { FridgeStatus.Allocated, FridgeStatus.UnderMaintenance, FridgeStatus.Faulty, FridgeStatus.Scrapped },
                [FridgeStatus.Allocated] = new[] { FridgeStatus.Available, FridgeStatus.UnderMaintenance, FridgeStatus.Faulty },
                [FridgeStatus.UnderMaintenance] = new[] { FridgeStatus.Available, FridgeStatus.Faulty, FridgeStatus.Quarantined },
                [FridgeStatus.Faulty] = new[] { FridgeStatus.UnderMaintenance, FridgeStatus.Available, FridgeStatus.Scrapped },
                [FridgeStatus.InTransit] = new[] { FridgeStatus.Available, FridgeStatus.Allocated },
                [FridgeStatus.Quarantined] = new[] { FridgeStatus.Available, FridgeStatus.Scrapped },
            };

            return validTransitions.ContainsKey(currentStatus) &&
                   validTransitions[currentStatus].Contains(newStatus);
        }

        #endregion
    }

    // Helper class for validation results
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult(bool isValid, string errorMessage = "")
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success => new ValidationResult(true);
        public static ValidationResult Error(string message) => new ValidationResult(false, message);
    }
}
