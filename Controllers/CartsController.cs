using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Utilities;
using Project.Utilities.Enums;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole + "," + SD.CustomerRole)]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartsController(ApplicationDbContext db)
        {
            _db = db;
        }

        private int GetCartItemCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.FirstOrDefault(c => c.UserId == userId);

            if (customer == null) return 0;

            return _db.FridgeAllocations
                .Count(a => a.CustomerId == customer.Id && a.IsActive && a.AllocationDate == null);
        }

        // GET: Cart
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = _db.FridgeAllocations
                .Include(a => a.Fridge)
                .Where(a => a.Customer.UserId == userId && a.IsActive && a.AllocationDate == null)
                .ToList();

            ViewBag.CartItemCount = GetCartItemCount();
            return View(cartItems);
        }

        // GET: Cart/Add/5 (Add fridge to cart)
        public IActionResult Add(int id)
        {
            var fridge = _db.Fridges
                .Include(f => f.Model)
                .FirstOrDefault(f => f.Id == id && f.Status == FridgeStatus.Available);

            if (fridge == null)
            {
                return NotFound();
            }

            var allocation = new FridgeAllocation
            {
                Fridge = fridge,
                FridgeId = id,
                Quantity = 1,
            };

            return View(allocation);
        }

        // POST: Cart/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(FridgeAllocation allocation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.FirstOrDefault(c => c.UserId == userId);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            var existingAllocation = _db.FridgeAllocations
                .FirstOrDefault(a => a.CustomerId == customer.Id && a.FridgeId == allocation.FridgeId && a.AllocationDate == null);

            if (existingAllocation != null)
            {
                existingAllocation.Quantity += allocation.Quantity;
                _db.FridgeAllocations.Update(existingAllocation);
            }
            else
            {
                allocation.CustomerId = customer.Id;
                allocation.CreatedAt = DateTime.Now;
                _db.FridgeAllocations.Add(allocation);
            }

            _db.SaveChanges();
            TempData["success"] = "Fridge added to cart successfully";
            return RedirectToAction(nameof(Index));
        }

        // POST: Cart/Remove/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allocation = _db.FridgeAllocations
                .FirstOrDefault(a => a.Id == id && a.Customer.UserId == userId && a.AllocationDate == null);

            if (allocation != null)
            {
                _db.FridgeAllocations.Remove(allocation);
                _db.SaveChanges();
                TempData["success"] = "Fridge removed from cart";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public JsonResult UpdateQuantity(int id, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allocation = _db.FridgeAllocations
                .FirstOrDefault(a => a.Id == id && a.Customer.UserId == userId && a.AllocationDate == null);

            if (allocation != null && quantity > 0)
            {
                allocation.Quantity = quantity;
                _db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }

    //[Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
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
    //        FridgeAllocation allocation = new()
    //        {
    //            Fridge = _db.Fridges.FirstOrDefault(u => u.Id == id),
    //            Quantity = 1,
    //            FridgeId = id
    //        };
    //        return View(allocation);

    //    }
    //    [HttpPost]
    //    [Authorize]
    //    public IActionResult Details(FridgeAllocation allocation)
    //    {
    //        var claimsIdedity = (ClaimsIdentity)User.Identity;
    //        var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;
    //        allocation.Customer.UserId = userId;

    //        FridgeAllocation allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Customer.UserId == userId &&
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
