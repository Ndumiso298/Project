using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.ViewModels;
using Project.Models;
using Project.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class UsersController : Controller
    {
            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly ApplicationDbContext _db;

            public UsersController(UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                ApplicationDbContext db)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _db = db;
            }

            public IActionResult Index()
            {
                return View();
            }

            public async Task<IActionResult> RoleManagement(string userId)
            {
                var applicationUser = await _db.ApplicationUsers
                    .Include(u => u.Employee)
                    .Include(u => u.Customer)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (applicationUser == null)
                {
                    return NotFound();
                }

                var userRoles = await _userManager.GetRolesAsync(applicationUser);
                var currentRole = userRoles.FirstOrDefault();

                RoleManagementVM roleVM = new()
                {
                    ApplicationUser = applicationUser,
                    RoleList = _roleManager.Roles.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Name
                    }),
                    EmployeeList = await _db.Employees.Select(i => new SelectListItem
                    {
                        Text = $"{i.UserAccount.FirstName} {i.UserAccount.LastName} ({i.EmployeeType})",
                        Value = i.Id.ToString()
                    }).ToListAsync(),
                    CustomerList = await _db.Customers.Select(i => new SelectListItem
                    {
                        Text = i.TradingName,
                        Value = i.Id.ToString()
                    }).ToListAsync()
                };

                roleVM.ApplicationUser.UserRole = currentRole;

                return View(roleVM);
            }

            [HttpPost]
            public async Task<IActionResult> RoleManagement(RoleManagementVM roleManagementVM)
            {
                var applicationUser = await _db.ApplicationUsers
                    .FirstOrDefaultAsync(u => u.Id == roleManagementVM.ApplicationUser.Id);

                if (applicationUser == null)
                {
                    return NotFound();
                }

                var userRoles = await _userManager.GetRolesAsync(applicationUser);
                var oldRole = userRoles.FirstOrDefault();

                if (!(roleManagementVM.ApplicationUser.UserRole == oldRole))
                {
                    // A role was updated
                    if (roleManagementVM.ApplicationUser.UserRole == SD.CustomerRole)
                    {
                        applicationUser.CustomerId = roleManagementVM.ApplicationUser.CustomerId;
                        applicationUser.EmployeeId = null; // Remove employee association
                    }
                    else // It'CustomersController an employee role
                    {
                        applicationUser.EmployeeId = roleManagementVM.ApplicationUser.EmployeeId;
                        applicationUser.CustomerId = null; // Remove customer association
                    }

                    _db.ApplicationUsers.Update(applicationUser);
                    await _db.SaveChangesAsync();

                    await _userManager.RemoveFromRoleAsync(applicationUser, oldRole);
                    await _userManager.AddToRoleAsync(applicationUser, roleManagementVM.ApplicationUser.UserRole);
                }
                else
                {
                    // Same role but might need to update associated employee/customer
                    if (oldRole == SD.CustomerRole && applicationUser.CustomerId != roleManagementVM.ApplicationUser.CustomerId)
                    {
                        applicationUser.CustomerId = roleManagementVM.ApplicationUser.CustomerId;
                        applicationUser.EmployeeId = null;
                        _db.ApplicationUsers.Update(applicationUser);
                        await _db.SaveChangesAsync();
                    }
                    else if (oldRole != SD.CustomerRole && applicationUser.EmployeeId != roleManagementVM.ApplicationUser.EmployeeId)
                    {
                        applicationUser.EmployeeId = roleManagementVM.ApplicationUser.EmployeeId;
                        applicationUser.CustomerId = null;
                        _db.ApplicationUsers.Update(applicationUser);
                        await _db.SaveChangesAsync();
                    }
                }

                return RedirectToAction("Index");
            }

            #region API CALLS

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var objUserList = await _db.ApplicationUsers
                    .Include(u => u.Employee)
                    .Include(u => u.Customer)
                    .ToListAsync();

                foreach (var user in objUserList)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    user.UserRole = roles.FirstOrDefault();

                    // Set display name based on role
                    if (user.UserRole == SD.CustomerRole && user.Customer != null)
                    {
                        user.UserName = user.Customer.TradingName;
                    }
                    else if (user.Employee != null)
                    {
                        user.UserName = $"{user.Employee.UserAccount.FirstName} {user.Employee.UserAccount.LastName}";
                    }
                    else
                    {
                        user.UserName = user.Email;
                    }
                }

                return Json(new { data = objUserList });
            }

            [HttpPost]
            public async Task<IActionResult> LockUnlock([FromBody] string id)
            {
                var objFromDb = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while Locking/Unlocking" });
                }

                if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
                {
                    // User is currently locked - unlock them
                    objFromDb.LockoutEnd = DateTime.Now;
                }
                else
                {
                    // Lock user
                    objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
                }

                _db.ApplicationUsers.Update(objFromDb);
                await _db.SaveChangesAsync();

                return Json(new { success = true, message = "Operation Successful" });
            }
            #endregion
        }
    }