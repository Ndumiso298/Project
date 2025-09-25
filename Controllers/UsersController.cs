using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.ViewModels;
using Project.Models;
using Project.Utilities;
using Project.Data;
using Microsoft.EntityFrameworkCore;
using Project.Utilities.Enums;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsersController(ApplicationDbContext db,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _db.Users
                .Include(u => u.PrimaryLocation)
                .Include(u => u.Employee)
                .Include(u => u.Customer)
                .Where(u => u.IsActive)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();

            var userVMs = new List<UserManagementVM>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userVM = new UserManagementVM
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    DOB = user.DOB,
                    LocationId = user.LocationId,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    IsActive = user.IsActive,
                    UserRole = roles.FirstOrDefault() ?? "User",
                    CurrentRole = roles.FirstOrDefault()
                };

                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        // GET: Users/Upsert
        public async Task<IActionResult> Upsert(string? id)
        {
            var vm = new UserManagementVM();

            // Populate dropdowns
            await PopulateDropdowns(vm);

            if (string.IsNullOrEmpty(id))
            {
                // Create new user
                return View(vm);
            }

            // Edit existing user
            var user = await _db.Users
                .Include(u => u.Employee)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }


            var roles = await _userManager.GetRolesAsync(user);
            var currentRole = roles.FirstOrDefault();

            // FIXED: Use vm.Id instead of vm.UserId
            vm.UserId = user.Id;
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.Email = user.Email;
            vm.PhoneNumber = user.PhoneNumber;
            vm.DOB = user.DOB;
            vm.LocationId = user.LocationId;
            vm.ProfilePictureUrl = user.ProfilePictureUrl;
            vm.IsActive = user.IsActive;
            vm.UserRole = currentRole ?? "User";
            vm.CurrentRole = currentRole; // Now this property exists

            // Populate role-specific data
            if (user.Employee != null)
            {
                vm.EmployeeNumber = user.Employee.EmployeeNumber;
                vm.EmployeeType = user.Employee.EmployeeType;
                vm.AvailabilityStatus = user.Employee.AvailabilityStatus;
            }

            if (user.Customer != null)
            {
                vm.TradingName = user.Customer.TradingName;
                vm.BusinessType = user.Customer.BusinessType;
                vm.BusinessEmail = user.Customer.BusinessEmail;
                vm.BusinessPhoneNumber = user.Customer.BusinessPhoneNumber;
                vm.AddressLine1 = user.Customer.AddressLine1;
                vm.AddressLine2 = user.Customer.AddressLine2;
                vm.City = user.Customer.City;
                vm.Province = user.Customer.Province;
                vm.PostalCode = user.Customer.PostalCode;
            }

            if (user.PrimaryLocation != null)
            {
                ViewBag.LocationInfo = $"Current Location: {user.PrimaryLocation.Name} ({user.PrimaryLocation.City})";

                // Show location-specific stats if needed
                ViewBag.EmployeesAtLocation = user.PrimaryLocation.Employees.Count(e => e.IsActive);
                ViewBag.CustomersAtLocation = user.PrimaryLocation.Customers.Count(c => c.IsActive);
                ViewBag.FridgesAtLocation = user.PrimaryLocation.Fridges.Count(f => f.Status == FridgeStatus.Available);
            }

            return View(vm);
        }

        // POST: Users/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UserManagementVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(vm.UserId))
                    {
                        // Create new user
                        await CreateUser(vm);
                        TempData["success"] = "User created successfully";
                    }
                    else
                    {
                        // Update existing user
                        await UpdateUser(vm);
                        TempData["success"] = "User updated successfully";
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving user: {ex.Message}");
                }
            }

            // If we got this far, something failed; repopulate dropdowns
            await PopulateDropdowns(vm);
            return View(vm);
        }

        private async Task CreateUser(UserManagementVM vm)
        {
            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PhoneNumber = vm.PhoneNumber,
                DOB = vm.DOB,
                LocationId = vm.LocationId,
                ProfilePictureUrl = vm.ProfilePictureUrl,
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            // Create the user
            var result = await _userManager.CreateAsync(user, "TempPassword123!"); // Default password
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Assign role and create role-specific records
            await HandleRoleAssignment(user, vm);
        }

        private async Task UpdateUser(UserManagementVM vm)
        {
            var user = await _db.Users
                .Include(u => u.Employee)
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Id == vm.UserId);

            if (user == null) throw new Exception("User not found");

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.UserName = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;
            user.DOB = vm.DOB;
            user.LocationId = vm.LocationId;
            user.ProfilePictureUrl = vm.ProfilePictureUrl;
            user.IsActive = vm.IsActive;
            user.UpdatedAt = DateTime.UtcNow;

            // Update user
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Handle role changes and updates
            await HandleRoleAssignment(user, vm, true);
        }

        private async Task HandleRoleAssignment(ApplicationUser user, UserManagementVM vm, bool isUpdate = false)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Only remove from roles if the role is changing
            if (isUpdate && currentRoles.FirstOrDefault() != vm.UserRole)
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                // Remove existing role-specific records if changing roles
                if (user.EmployeeId.HasValue && !vm.UserRole.Contains("Employee")) // Check if new role is not employee-related
                {
                    var employee = await _db.Employees.FindAsync(user.EmployeeId);
                    if (employee != null)
                    {
                        employee.IsActive = false; // Soft delete
                        user.EmployeeId = null;
                    }
                }

                if (user.CustomerId.HasValue && vm.UserRole != "Customer")
                {
                    var customer = await _db.Customers.FindAsync(user.CustomerId);
                    if (customer != null)
                    {
                        customer.IsActive = false; // Soft delete
                        user.CustomerId = null;
                    }
                }
            }

            // Add to new role if not already in it
            if (!currentRoles.Contains(vm.UserRole))
            {
                await _userManager.AddToRoleAsync(user, vm.UserRole);
            }

            // Create/update role-specific records
            switch (vm.UserRole)
            {
                case "Administrator":
                case "CustomerLiaison":
                case "InventoryLiaison":
                case "MaintenanceTechnician":
                case "FaultTechnician":
                    await HandleEmployeeRecord(user, vm, isUpdate);
                    break;
                case "Customer":
                    await HandleCustomerRecord(user, vm, isUpdate);
                    break;
                    // Add more role cases as needed
            }
        }

        private async Task HandleEmployeeRecord(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            Employee employee;

            if (isUpdate && user.EmployeeId.HasValue)
            {
                employee = await _db.Employees.FindAsync(user.EmployeeId);
                if (employee == null)
                {
                    // Create new employee record if not found
                    employee = new Employee { UserId = user.Id, CreatedAt = DateTime.UtcNow };
                    _db.Employees.Add(employee);
                }
            }
            else
            {
                employee = new Employee
                {
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Employees.Add(employee);
            }

            employee.EmployeeNumber = vm.EmployeeNumber ?? GenerateEmployeeNumber();
            employee.EmployeeType = vm.EmployeeType ?? GetEmployeeTypeFromRole(vm.UserRole);
            employee.AvailabilityStatus = vm.AvailabilityStatus ?? AvailabilityStatus.Available;
            employee.IsActive = vm.IsActive;
            employee.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            user.EmployeeId = employee.Id;
            await _userManager.UpdateAsync(user);
        }

        private EmployeeType GetEmployeeTypeFromRole(string role)
        {
            return role switch
            {
                "Admin" => EmployeeType.Admin,
                "CustomerSupport" => EmployeeType.CustomerSupport,
                "StockController" => EmployeeType.StockController,
                "MaintenanceTechnician" => EmployeeType.MaintenanceTechnician,
                "FaultTechnician" => EmployeeType.FaultTechnician,
                _ => EmployeeType.CustomerSupport
            };
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Soft delete (as per project checklist)
            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;

            // Also soft delete related records
            if (user.EmployeeId.HasValue)
            {
                var employee = await _db.Employees.FindAsync(user.EmployeeId);
                if (employee != null) employee.IsActive = false;
            }

            if (user.CustomerId.HasValue)
            {
                var customer = await _db.Customers.FindAsync(user.CustomerId);
                if (customer != null) customer.IsActive = false;
            }

            await _db.SaveChangesAsync();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns(UserManagementVM vm)
        {
            vm.LocationList = await _db.Locations
                .Where(l => l.IsActive)
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                })
                .ToListAsync();

            var roles = await _roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToListAsync();

            // Add common roles used in the system
            vm.RoleList = roles;
        }

        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]

        private async Task HandleCustomerRecord(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            Customer customer;

            if (isUpdate && user.CustomerId.HasValue)
            {
                customer = await _db.Customers.FindAsync(user.CustomerId);
                if (customer == null)
                {
                    // Create new customer record if not found
                    customer = new Customer { UserId = user.Id, CreatedAt = DateTime.UtcNow };
                    _db.Customers.Add(customer);
                }
            }
            else
            {
                customer = new Customer
                {
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Customers.Add(customer);
            }

            // Set customer properties
            // Set customer properties including address
            customer.TradingName = vm.TradingName ?? $"{vm.FirstName} {vm.LastName}";
            customer.BusinessType = vm.BusinessType ?? BusinessType.Other;
            customer.BusinessEmail = vm.BusinessEmail ?? vm.Email;
            customer.BusinessPhoneNumber = vm.BusinessPhoneNumber ?? vm.PhoneNumber;

            // Keep the address fields from VM
            customer.AddressLine1 = vm.AddressLine1 ?? string.Empty;
            customer.AddressLine2 = vm.AddressLine2;
            customer.City = vm.City ?? string.Empty;
            customer.Province = vm.Province ?? string.Empty;
            customer.PostalCode = vm.PostalCode ?? string.Empty;

            // ADD: Set LocationId based on city/province lookup
            customer.LocationId = await GetOrCreateLocationId(vm.City, vm.Province);

            customer.IsActive = vm.IsActive;
            customer.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            user.CustomerId = customer.Id;
            await _userManager.UpdateAsync(user);
        }

        private async Task<int> GetOrCreateLocationId(string city, string province)
        {
            var locationName = $"{city}, {province}";
            var location = await _db.Locations
                .FirstOrDefaultAsync(l => l.City == city && l.Province == province);

            if (location == null)
            {
                location = new Location
                {
                    Name = locationName,
                    City = city,
                    Province = province,
                };
                _db.Locations.Add(location);
                await _db.SaveChangesAsync();
            }

            return location.Id;
        }

        private string GenerateEmployeeNumber()
        {
            var timestamp = DateTime.Now.ToString("yyMMddHHmmss");
            return $"EMP{timestamp}";
        }
    }
}

//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly ApplicationDbContext _db;

//        public UserManagementController(UserManager<IdentityUser> userManager,
//                                      RoleManager<IdentityRole> roleManager,
//                                      ApplicationDbContext db)
//        {
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _db = db;
//        }

//        // Main dashboard/index view
//        public IActionResult Index()
//        {
//            return View();
//        }

//        // USERS MANAGEMENT SECTION
//        public async Task<IActionResult> UserIndex()
//        {
//            var users = await _db.ApplicationUsers
//                .Include(u => u.Employee)
//                .Include(u => u.Customer)
//                .ToListAsync();

//            foreach (var user in users)
//            {
//                var roles = await _userManager.GetRolesAsync(user);
//                user.UserRole = roles.FirstOrDefault();

//                // Set display name based on role
//                if (user.UserRole == SD.CustomerRole && user.Customer != null)
//                {
//                    user.UserName = user.Customer.TradingName;
//                }
//                else if (user.Employee != null)
//                {
//                    user.UserName = $"{user.Employee.UserAccount.FirstName} {user.Employee.UserAccount.LastName}";
//                }
//                else
//                {
//                    user.UserName = user.Email;
//                }
//            }

//            return View(users);
//        }

//        public async Task<IActionResult> RoleManagement(string userId)
//        {
//            var applicationUser = await _db.ApplicationUsers
//                .Include(u => u.Employee)
//                .Include(u => u.Customer)
//                .FirstOrDefaultAsync(u => u.UserId == userId);

//            if (applicationUser == null)
//            {
//                return NotFound();
//            }

//            var userRoles = await _userManager.GetRolesAsync(applicationUser);
//            var currentRole = userRoles.FirstOrDefault();

//            UserManagementVM roleVM = new()
//            {
//                ApplicationUser = applicationUser,
//                RoleList = _roleManager.Roles.Select(i => new SelectListItem
//                {
//                    Text = i.Name,
//                    Value = i.Name
//                }),
//                EmployeeList = await _db.Employees.Select(i => new SelectListItem
//                {
//                    Text = $"{i.UserAccount.FirstName} {i.UserAccount.LastName} ({i.EmployeeType})",
//                    Value = i.UserId.ToString()
//                }).ToListAsync(),
//                CustomerList = await _db.Customers.Select(i => new SelectListItem
//                {
//                    Text = i.TradingName,
//                    Value = i.UserId.ToString()
//                }).ToListAsync()
//            };

//            roleVM.ApplicationUser.UserRole = currentRole;

//            return View(roleVM);
//        }

//        [HttpPost]
//        public async Task<IActionResult> RoleManagement(UserManagementVM roleManagementVM)
//        {
//            var applicationUser = await _db.ApplicationUsers
//                .FirstOrDefaultAsync(u => u.UserId == roleManagementVM.ApplicationUser.UserId);

//            if (applicationUser == null)
//            {
//                return NotFound();
//            }

//            var userRoles = await _userManager.GetRolesAsync(applicationUser);
//            var oldRole = userRoles.FirstOrDefault();

//            if (!(roleManagementVM.ApplicationUser.UserRole == oldRole))
//            {
//                // A role was updated
//                if (roleManagementVM.ApplicationUser.UserRole == SD.CustomerRole)
//                {
//                    applicationUser.CustomerId = roleManagementVM.ApplicationUser.CustomerId;
//                    applicationUser.EmployeeId = null;
//                }
//                else // It's an employee role
//                {
//                    applicationUser.EmployeeId = roleManagementVM.ApplicationUser.EmployeeId;
//                    applicationUser.CustomerId = null;
//                }

//                _db.ApplicationUsers.Update(applicationUser);
//                await _db.SaveChangesAsync();

//                await _userManager.RemoveFromRoleAsync(applicationUser, oldRole);
//                await _userManager.AddToRoleAsync(applicationUser, roleManagementVM.ApplicationUser.UserRole);
//            }
//            else
//            {
//                // Same role but might need to update associated employee/customer
//                if (oldRole == SD.CustomerRole && applicationUser.CustomerId != roleManagementVM.ApplicationUser.CustomerId)
//                {
//                    applicationUser.CustomerId = roleManagementVM.ApplicationUser.CustomerId;
//                    applicationUser.EmployeeId = null;
//                    _db.ApplicationUsers.Update(applicationUser);
//                    await _db.SaveChangesAsync();
//                }
//                else if (oldRole != SD.CustomerRole && applicationUser.EmployeeId != roleManagementVM.ApplicationUser.EmployeeId)
//                {
//                    applicationUser.EmployeeId = roleManagementVM.ApplicationUser.EmployeeId;
//                    applicationUser.CustomerId = null;
//                    _db.ApplicationUsers.Update(applicationUser);
//                    await _db.SaveChangesAsync();
//                }
//            }

//            return RedirectToAction("UserIndex");
//        }

//        // EMPLOYEES MANAGEMENT SECTION
//        public IActionResult EmployeeIndex()
//        {
//            var employees = _db.Employees.Include(e => e.UserAccount).ToList();
//            return View(employees);
//        }

//        public IActionResult EmployeeCreate()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> EmployeeCreate(Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Employees.Add(employee);
//                await _db.SaveChangesAsync();
//                TempData["success"] = "Employee created successfully";
//                return RedirectToAction(nameof(EmployeeIndex));
//            }
//            return View(employee);
//        }

//        public async Task<IActionResult> EmployeeEdit(int id)
//        {
//            var employee = await _db.Employees
//                .Include(e => e.UserAccount)
//                .FirstOrDefaultAsync(e => e.UserId == id);

//            if (employee == null)
//            {
//                return NotFound();
//            }
//            return View(employee);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> EmployeeEdit(int id, Employee employee)
//        {
//            if (id != employee.UserId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _db.Employees.Update(employee);
//                    await _db.SaveChangesAsync();
//                    TempData["success"] = "Employee updated successfully";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!EmployeeExists(employee.UserId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(EmployeeIndex));
//            }
//            return View(employee);
//        }

//        // CUSTOMERS MANAGEMENT SECTION
//        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
//        public IActionResult CustomerIndex()
//        {
//            var customers = _db.Customers.Include(c => c.Location).ToList();
//            return View(customers);
//        }

//        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
//        public IActionResult CustomerCreate()
//        {
//            return View();
//        }

//        [HttpPost]
//        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CustomerCreate(Customer customer)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.Customers.Add(customer);
//                await _db.SaveChangesAsync();
//                TempData["success"] = "Customer created successfully";
//                return RedirectToAction(nameof(CustomerIndex));
//            }
//            return View(customer);
//        }

//        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
//        public async Task<IActionResult> CustomerEdit(int id)
//        {
//            var customer = await _db.Customers
//                .Include(c => c.Location)
//                .FirstOrDefaultAsync(c => c.UserId == id);

//            if (customer == null)
//            {
//                return NotFound();
//            }
//            return View(customer);
//        }

//        [HttpPost]
//        [Authorize(Roles = SD.AdminRole + "," + SD.CustomerSupportRole)]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CustomerEdit(int id, Customer customer)
//        {
//            if (id != customer.UserId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _db.Customers.Update(customer);
//                    await _db.SaveChangesAsync();
//                    TempData["success"] = "Customer updated successfully";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CustomerExists(customer.UserId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(CustomerIndex));
//            }
//            return View(customer);
//        }
//        #region API CALLS

//        [HttpGet]
//        public async Task<IActionResult> GetAllUsers()
//        {
//            var objUserList = await _db.ApplicationUsers
//                .Include(u => u.Employee)
//                .Include(u => u.Customer)
//                .ToListAsync();

//            foreach (var user in objUserList)
//            {
//                var roles = await _userManager.GetRolesAsync(user);
//                user.UserRole = roles.FirstOrDefault();

//                if (user.UserRole == SD.CustomerRole && user.Customer != null)
//                {
//                    user.UserName = user.Customer.TradingName;
//                }
//                else if (user.Employee != null)
//                {
//                    user.UserName = $"{user.Employee.UserAccount.FirstName} {user.Employee.UserAccount.LastName}";
//                }
//                else
//                {
//                    user.UserName = user.Email;
//                }
//            }

//            return Json(new { data = objUserList });
//        }

//        [HttpPost]
//        public async Task<IActionResult> LockUnlockUser([FromBody] string id)
//        {
//            var objFromDb = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.UserId == id);
//            if (objFromDb == null)
//            {
//                return Json(new { success = false, message = "Error while Locking/Unlocking" });
//            }

//            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
//            {
//                // User is currently locked - unlock them
//                objFromDb.LockoutEnd = DateTime.Now;
//            }
//            else
//            {
//                // Lock user
//                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
//            }

//            _db.ApplicationUsers.Update(objFromDb);
//            await _db.SaveChangesAsync();

//            return Json(new { success = true, message = "Operation Successful" });
//        }

//        #endregion

//        #region PRIVATE METHODS

//        private bool EmployeeExists(int id)
//        {
//            return _db.Employees.Any(e => e.UserId == id);
//        }

//        private bool CustomerExists(int id)
//        {
//            return _db.Customers.Any(c => c.UserId == id);
//        }

//        #endregion
//    }
//}