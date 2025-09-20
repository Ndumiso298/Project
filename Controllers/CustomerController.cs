using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;
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
      
        public IActionResult Index()
        {
            IEnumerable<Fridge> fridgesList=_db.Fridges.ToList();
            return View(fridgesList);
        }
        public IActionResult Details(int id)
        {
            FridgeAllocation allocation = new()
            {
                Fridge = _db.Fridges.FirstOrDefault(u => u.Id == id),
                Quantity= 1,
                FridgeId=id
            };
          return View(allocation);
        
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(FridgeAllocation allocation)
        {
            var claimsIdedity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdedity.FindFirst(ClaimTypes.NameIdentifier).Value;
            allocation.Customer.UserId = userId;

            FridgeAllocation allocationFromDb = _db.FridgeAllocations.FirstOrDefault(u => u.Customer.UserId == userId &&
            u.FridgeId == allocation.FridgeId);

            if (allocationFromDb != null)
            {
                allocationFromDb.Quantity += allocation.Quantity;
                _db.FridgeAllocations.Update(allocationFromDb);
            }
            else
            {
                _db.FridgeAllocations.Add(allocation);
            }
            TempData["success"] = "cart updated successfully";
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
