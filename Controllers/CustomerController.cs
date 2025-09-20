using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Security.Claims;

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

    }
}
