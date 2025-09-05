using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using System.Security.Claims;

namespace Project.Controllers
{
    public class AllocationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AllocationVM AllocationVM { get; set; }
        public AllocationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId= claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            //AllocationVM = new()
            //{
            //     FridgeList= _db.tblAllocation.Include(a => a.Fridge).Where(a => a.ApplicationUserId == userId).ToList()
                
            //};


            return View();
        }

        public IActionResult Upsert(int? id)
        {
            AllocationVM  = new()
            {
               


                UserList = _db.AppUser.Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.Id.ToString()
                }),
                Allocation = new Allocation()
            };

          return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AllocationVM allocationVM)
        {
            if (ModelState.IsValid)
            {
                var allocation = allocationVM.Allocation;

                if (allocationVM.Allocation.AllocationId == 0)
                {
                    _db.tblAllocation.Add(allocationVM.Allocation);
                }
                else
                {
                    _db.tblAllocation.Update(allocationVM.Allocation);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If model state is invalid, re-populate dropdowns for the view model
            allocationVM.FridgeList = _db.tblFridge.Select(u => new SelectListItem
            {
                Text = u.FridgeNo + " (" + u.Brand + " " + u.Type + ")",
                Value = u.FridgeId.ToString()
            }).ToList();

            allocationVM.UserList = _db.AppUser.Select(u => new SelectListItem
            {
                Text = u.FirstName + " " + u.LastName,
                Value = u.Id.ToString()
            }).ToList();

            return View(allocationVM);
        }

    }
}
