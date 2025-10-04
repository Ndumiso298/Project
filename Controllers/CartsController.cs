using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
using Project.Utilities;
using Project.Utilities.Enums;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.CustomerRole)]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CartsController> _logger;

        public CartsController(ApplicationDbContext db, ILogger<CartsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            try
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    TempData["error"] = "Customer not found.";
                    return RedirectToAction("Index", "Home");
                }

                var cartVM = new AllocationCartVM();
                cartVM.UpdateCustomerInfo(customer);

                // Get cart items from session or database
                var cartItems = await GetCustomerCartItemsAsync(customer.Id);
                cartVM.Items = cartItems;

                await PopulateCartDropdowns(cartVM);
                return View(cartVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading cart index for user {UserId}", User.FindFirstValue(ClaimTypes.NameIdentifier));
                TempData["error"] = "Error loading cart items";
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Cart/AddItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(AllocationCartItemVM itemVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Invalid item data";
                    return RedirectToAction(nameof(Index));
                }

                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    TempData["error"] = "Customer not found";
                    return RedirectToAction(nameof(Index));
                }

                // Verify fridge model and stock
                var fridgeModel = await _db.FridgeModels.FindAsync(itemVm.FridgeModelId);
                if (fridgeModel == null)
                {
                    TempData["error"] = "Fridge model not found";
                    return RedirectToAction(nameof(Index));
                }

                var availableStock = await _db.Fridges
                    .CountAsync(f => f.FridgeModelId == itemVm.FridgeModelId &&
                                   f.Status == FridgeStatus.Available &&
                                   f.IsActive);

                itemVm.AvailableStock = availableStock;
                itemVm.UpdateFromFridgeModel(new FridgeModelVM
                {
                    Id = fridgeModel.Id,
                    Manufacturer = fridgeModel.Manufacturer,
                    ModelName = fridgeModel.ModelName,
                    MonthlyRentalPrice = fridgeModel.MonthlyRentalPrice,
                    CapacityLiters = fridgeModel.CapacityLiters
                }, availableStock);

                if (!itemVm.IsValid)
                {
                    TempData["error"] = "Invalid item configuration or insufficient stock";
                    return RedirectToAction(nameof(Index));
                }

                // Add to cart (in session for now, could be saved to database)
                var cart = await GetOrCreateCartAsync(customer.Id);
                if (cart.ContainsFridgeModel(itemVm.FridgeModelId))
                {
                    // Update existing item
                    var existingItem = cart.GetItem(cart.Items.First(i => i.FridgeModelId == itemVm.FridgeModelId).TempId);
                    if (existingItem != null)
                    {
                        existingItem.UpdateQuantity(existingItem.Quantity + itemVm.Quantity);
                    }
                }
                else
                {
                    cart.Items.Add(itemVm);
                }

                await SaveCartAsync(customer.Id, cart);

                TempData["success"] = "Item added to cart successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding item to cart");
                TempData["error"] = "Error adding item to cart";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Cart/UpdateItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UpdateItem(Guid tempId, int quantity, int rentalDuration)
        {
            try
            {
                if (quantity <= 0 || rentalDuration <= 0)
                {
                    return Json(new { success = false, message = "Quantity and duration must be greater than 0" });
                }

                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    return Json(new { success = false, message = "Customer not found" });
                }

                var cart = await GetOrCreateCartAsync(customer.Id);
                var item = cart.GetItem(tempId);

                if (item == null)
                {
                    return Json(new { success = false, message = "Item not found in cart" });
                }

                item.UpdateQuantity(quantity);
                item.UpdateRentalDuration(rentalDuration);

                // Re-validate stock
                var availableStock = await _db.Fridges
                    .CountAsync(f => f.FridgeModelId == item.FridgeModelId &&
                                   f.Status == FridgeStatus.Available &&
                                   f.IsActive);

                item.AvailableStock = availableStock;

                if (!item.HasSufficientStock)
                {
                    return Json(new { success = false, message = "Insufficient stock available" });
                }

                await SaveCartAsync(customer.Id, cart);

                var summary = AllocationCartSummaryVM.FromCart(cart);
                return Json(new
                {
                    success = true,
                    message = "Item updated successfully",
                    summary = new
                    {
                        itemCount = summary.ItemCount,
                        totalMonthlyRental = summary.TotalMonthlyRental,
                        totalContractValue = summary.TotalContractValue,
                        displayText = summary.DisplayText
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart item {TempId}", tempId);
                return Json(new { success = false, message = "Error updating item" });
            }
        }

        // POST: Cart/RemoveItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(Guid tempId)
        {
            try
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    TempData["error"] = "Customer not found";
                    return RedirectToAction(nameof(Index));
                }

                var cart = await GetOrCreateCartAsync(customer.Id);
                cart.RemoveItem(tempId);
                await SaveCartAsync(customer.Id, cart);

                TempData["success"] = "Item removed from cart";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing item {TempId} from cart", tempId);
                TempData["error"] = "Error removing item from cart";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Cart/SubmitRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitRequest(AllocationCartVM cartVm)
        {
            try
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    TempData["error"] = "Customer not found";
                    return RedirectToAction(nameof(Index));
                }

                var cart = await GetOrCreateCartAsync(customer.Id);

                // Validate cart
                if (!cart.IsValid)
                {
                    var errors = cart.GetValidationErrors();
                    TempData["error"] = $"Please correct the following errors: {string.Join(", ", errors)}";
                    return RedirectToAction(nameof(Index));
                }

                // Convert cart to allocation request
                var requestVm = cart.ToRequestHeaderVM();
                requestVm.CustomerId = customer.Id;

                // Create the allocation request
                var requestId = await CreateAllocationRequestFromCartAsync(requestVm);

                // Clear the cart
                cart.ClearCart();
                await SaveCartAsync(customer.Id, cart);

                TempData["success"] = "Allocation request submitted successfully";
                return RedirectToAction("Details", "AllocationRequests", new { id = requestId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting cart request");
                TempData["error"] = "Error submitting allocation request";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Cart/GetSummary
        [HttpGet]
        public async Task<JsonResult> GetSummary()
        {
            try
            {
                var customer = await GetCurrentCustomerAsync();
                if (customer == null)
                {
                    return Json(new { success = false, message = "Customer not found" });
                }

                var cart = await GetOrCreateCartAsync(customer.Id);
                var summary = AllocationCartSummaryVM.FromCart(cart);

                return Json(new
                {
                    success = true,
                    summary = new
                    {
                        itemCount = summary.ItemCount,
                        totalMonthlyRental = summary.TotalMonthlyRental,
                        totalContractValue = summary.TotalContractValue,
                        hasItems = summary.HasItems,
                        displayText = summary.DisplayText
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cart summary");
                return Json(new { success = false, message = "Error getting cart summary" });
            }
        }

        #region Private Methods

        private async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _db.Customers
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.UserAccount.IsDeleted);
        }

        private async Task<AllocationCartVM> GetOrCreateCartAsync(int customerId)
        {
            // For simplicity, using session storage. Could be moved to database.
            var sessionKey = $"Cart_{customerId}";
            var cartJson = HttpContext.Session.GetString(sessionKey);

            if (!string.IsNullOrEmpty(cartJson))
            {
                return System.Text.Json.JsonSerializer.Deserialize<AllocationCartVM>(cartJson) ?? new AllocationCartVM();
            }

            return new AllocationCartVM();
        }

        private async Task SaveCartAsync(int customerId, AllocationCartVM cart)
        {
            var sessionKey = $"Cart_{customerId}";
            var cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(sessionKey, cartJson);
        }

        private async Task<List<AllocationCartItemVM>> GetCustomerCartItemsAsync(int customerId)
        {
            var cart = await GetOrCreateCartAsync(customerId);
            return cart.Items;
        }

        private async Task PopulateCartDropdowns(AllocationCartVM vm)
        {
            vm.CustomerList = await _db.Customers
                .Where(c => !c.UserAccount.IsDeleted)
                .OrderBy(c => c.BusinessName)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.BusinessName} ({c.BusinessType})"
                })
                .ToListAsync();

            vm.LocationList = await _db.Locations
                .Where(l => l.IsDeleted)
                .OrderBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.ToString()
                })
                .ToListAsync();

            // Populate fridge models for add item form
            ViewBag.FridgeModelList = await _db.FridgeModels
                .Where(fm => fm.IsActive)
                .OrderBy(fm => fm.Manufacturer)
                .ThenBy(fm => fm.ModelName)
                .Select(fm => new SelectListItem
                {
                    Value = fm.Id.ToString(),
                    Text = $"{fm.Manufacturer} {fm.ModelName} ({fm.CapacityLiters}L) - R{fm.MonthlyRentalPrice}/month"
                })
                .ToListAsync();
        }

        private async Task<int> CreateAllocationRequestFromCartAsync(AllocationRequestHeaderVM vm)
        {
            var request = vm.ToEntity();
            request.CreatedAt = DateTime.UtcNow;
            request.CreatedBy = User.Identity?.Name;
            request.Status = AllocationRequestStatus.Draft;

            _db.AllocationRequestHeaders.Add(request);
            await _db.SaveChangesAsync();

            // Add request details
            foreach (var detailVm in vm.RequestDetails)
            {
                var detail = detailVm.ToEntity();
                detail.AllocationRequestHeaderId = request.Id;
                _db.AllocationRequestDetails.Add(detail);
            }

            await _db.SaveChangesAsync();
            return request.Id;
        }

        #endregion
    }

    //[Authorize(Roles = Roles.AdminRole + "," + Roles.CustomerSupportRole)]
    //public class CartsController : Controller
    //{
    //    private readonly ApplicationDbContext _db;
    //    public CartsController(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }

    //    public IActionResult Index()
    //    {
    //        IEnumerable<Fridge> fridgesList = _db.Fridges.ToList();
    //        return View(fridgesList);
    //    }
    //    public IActionResult Details(int id)
    //    {
    //        RelatedAllocation allocation = new()
    //        {
    //            Fridge = _db.Fridges.FirstOrDefault(u => u.Id == id),
    //            Quantity = 1,
    //            FridgeId = id
    //        };
    //        return View(allocation);

    //    }
    //    [HttpPost]
    //    [Authorize]
    //    public IActionResult Details(RelatedAllocation allocation)
    //    {
    //        var claimsIdedity = (ClaimsIdentity)User.Identity;
    //        var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;
    //        allocation.Customer.UserId = userId;

    //        RelatedAllocation allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Customer.UserId == userId &&
    //        u.FridgeId == allocation.FridgeId);

    //        if (allocationFromDb != null)
    //        {
    //            allocationFromDb.Quantity += allocation.Quantity;
    //            _db.FridgeAllocations.Update(allocationFromDb);
    //        }
    //        else
    //        {
    //            _db.FridgeAllocations.Add(allocation);
    //        }
    //        TempData["success"] = "Cart updated successfully";
    //        _db.SaveChanges();

    //        return RedirectToAction(nameof(Index));
    //    }
    //}
}
