using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.FridgeManagementSystem.Models;
using Project.Models.ViewModels;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize(Roles = StaticDetails.AdminRole + "," + StaticDetails.CustomerSupportRole)]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustomersController(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _db.Customers
                .Include(c => c.BusinessAddress)
                .Include(c => c.CustomerLiaison)
                .Include(c => c.UserAccount)
                .ToListAsync();

            return View(customers);
        }

        // GET: Customers/RoleManagement/5
        public async Task<IActionResult> RoleManagement(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _db.Customers
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            // Customers typically have just the "Customer" role
            // This method is mainly for consistency
            var roleManagementVM = new CustomerManagementVM
            {
                Customer = customer,
                CurrentRole = StaticDetails.CustomerRole // Customers always have the Customer role
            };

            return View(roleManagementVM);
        }

        // Lock/Unlock functionality for customers
        [HttpPost]
        public async Task<IActionResult> LockUnlock(int id)
        {
            var customer = await _db.Customers
                .Include(c => c.UserAccount)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return Json(new { success = false, message = "Customer not found" });
            }

            var user = await _userManager.FindByIdAsync(customer.UserId);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                // User is locked - unlock them
                user.LockoutEnd = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "Customer unlocked successfully" });
            }
            else
            {
                // User is not locked - lock them
                user.LockoutEnd = DateTime.Now.AddYears(100);
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "Customer locked successfully" });
            }
        }
    }
}
