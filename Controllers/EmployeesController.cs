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
using Project.Models.ViewModels;
using Project.Utility;

namespace Project.Controllers
{
    [Authorize(Roles = StaticDetails.AdminRole)]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeesController(ApplicationDbContext db, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _db.Employees
                .Include(e => e.UserAccount)
                .ToListAsync();

            // Add role information to each employee
            foreach (var employee in employees)
            {
                var user = await _userManager.FindByIdAsync(employee.UserId);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    employee.EmployeeType = roles.FirstOrDefault();
                }
            }

            return View(employees);
        }

        // GET: Employees/RoleManagement/5
        public async Task<IActionResult> RoleManagement(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _db.Employees
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            // Get the user's current role
            var user = await _userManager.FindByIdAsync(employee.UserId);
            var currentRole = user != null ? (await _userManager.GetRolesAsync(user)).FirstOrDefault() : null;

            var employeeManagementVM = new EmployeeManagementVM
            {
                Employee = employee,
                RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }),
                CurrentRole = currentRole
            };

            return View(employeeManagementVM);
        }

        // POST: Employees/RoleManagement/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleManagement(int id, EmployeeManagementVM employeeManagementVM)
        {

            if (ModelState.IsValid)
            {

                if (id != employeeManagementVM.Employee.Id)
                {
                    return NotFound();
                }

                var employee = await _db.Employees
                    .Include(e => e.UserAccount)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                var user = await _userManager.FindByIdAsync(employee.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                // Get the current role
                var currentRoles = await _userManager.GetRolesAsync(user);
                var currentRole = currentRoles.FirstOrDefault();

                // Check if role has changed
                if (employeeManagementVM.SelectedRole != currentRole)
                {
                    // Remove from current role
                    if (!string.IsNullOrEmpty(currentRole))
                    {
                        await _userManager.RemoveFromRoleAsync(user, currentRole);
                    }

                    // Add to new role
                    if (!string.IsNullOrEmpty(employeeManagementVM.SelectedRole))
                    {
                        await _userManager.AddToRoleAsync(user, employeeManagementVM.SelectedRole);
                    }

                    // Update employee type if needed
                    employee.EmployeeType = employeeManagementVM.SelectedRole;
                    _db.Update(employee);
                    await _db.SaveChangesAsync();

                    TempData["Success"] = "Role updated successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            // If we got here, something went wrong
            employeeManagementVM.RoleList = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });
            return View(employeeManagementVM);
        }

        // Lock/Unlock functionality
        [HttpPost]
        public async Task<IActionResult> LockUnlock(int id)
        {
            var employee = await _db.Employees
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            var user = await _userManager.FindByIdAsync(employee.UserId);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                // User is locked - unlock them
                user.LockoutEnd = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "User unlocked successfully" });
            }
            else
            {
                // User is not locked - lock them
                user.LockoutEnd = DateTime.Now.AddYears(100);
                await _userManager.UpdateAsync(user);
                return Json(new { success = true, message = "User locked successfully" });
            }
        }
    }
}
