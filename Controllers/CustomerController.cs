using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Security.Claims;
using static Project.Models.WishList;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string sortBy)
        {
            var fridges = _db.tblFridges.AsQueryable();

            switch (sortBy)
            {
                case "price_asc":
                    fridges = fridges.OrderBy(f => f.RentalPricePerMonth);
                    break;
                case "price_desc":
                    fridges = fridges.OrderByDescending(f => f.RentalPricePerMonth);
                    break;
                case "capacity":
                    fridges = fridges.OrderByDescending(f => f.CapacityLiters);
                    break;
                //case "newest":
                //    fridges = fridges.OrderByDescending(f => f.CreatedAt); // or UpdatedAt, or FridgeId
                //    break;
            }

            return View(fridges.ToList());
        }

        public IActionResult Details(int id)
        {
            Allocation allocation = new()
            {
                Fridge = _db.tblFridges.FirstOrDefault(u => u.FridgeId == id),
                Count= 1,
                FridgeId=id
            };
          return View(allocation);
        
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Allocation allocation)
        {
            var claimsIdedity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;
            allocation.ApplicationUserId = userId;

            Allocation allocationFromDb = _db.tblAllocations.FirstOrDefault(u => u.ApplicationUserId == userId &&
            u.FridgeId == allocation.FridgeId);

            if (allocationFromDb != null)
            {
                allocationFromDb.Count += allocation.Count;
                _db.tblAllocations.Update(allocationFromDb);
            }
            else
            {
                _db.tblAllocations.Add(allocation);
            }
            TempData["success"] = "cart updated successfully";
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddToWishlist(int fridgeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exists = _db.Wishlists.Any(w => w.FridgeId == fridgeId && w.CustomerId == userId);
            if (exists)
            {
                TempData["Info"] = "This fridge is already in your wishlist.";
                return RedirectToAction("Wishlist");
            }

            var wishlistItem = new Wishlist
            {
                FridgeId = fridgeId,
                CustomerId = userId,
                AddedOn = DateTime.Now
            };

            _db.Wishlists.Add(wishlistItem);
            _db.SaveChanges();

            TempData["Success"] = "Fridge added to your wishlist.";
            return RedirectToAction("Wishlist");
        }

        public IActionResult Wishlist()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var wishlist = _db.Wishlists
                .Where(w => w.CustomerId == userId)
                .Include(w => w.Fridge)
                .ToList();

            return View(wishlist);
        }

        [HttpPost]
        public IActionResult RentFridge(int fridgeId)
        {
            var fridge = _db.tblFridges.FirstOrDefault(f => f.FridgeId == fridgeId);

            if (fridge == null)
            {
                return NotFound();
            }

            // Check availability
            if (fridge.AvailabilityStatus != "Available")
            {
                // If not available, return an error message
                TempData["Error"] = "This fridge is currently unavailable for rent.";
                return RedirectToAction("Index");  // or wherever you want to redirect
            }

            // Update the fridge availability status to "Rented"
            fridge.AvailabilityStatus = "Rented";
            _db.SaveChanges();



            return RedirectToAction("Cart");
        }
    }
}
