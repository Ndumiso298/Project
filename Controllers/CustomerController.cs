using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
      
        public IActionResult Index()
        {
            IEnumerable<Fridge> fridgesList=_db.tblFridge.ToList();
            return View(fridgesList);
        }
        public IActionResult Details(int id)
        {
            Allocation allocation = new()
            {
                Fridge = _db.tblFridge.FirstOrDefault(u => u.FridgeId == id),
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

            Allocation allocationFromDb = _db.tblAllocation.FirstOrDefault(u => u.ApplicationUserId == userId &&
            u.FridgeId == allocation.FridgeId);

            if (allocationFromDb != null)
            {
                allocationFromDb.Count += allocation.Count;
                _db.tblAllocation.Update(allocationFromDb);
            }
            else
            {
                _db.tblAllocation.Add(allocation);
            }
            TempData["success"] = "cart updated successfully";
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
