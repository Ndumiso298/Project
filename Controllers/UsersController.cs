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
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment webHostEnvironment,
            ILogger<UsersController> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString, string roleFilter, string statusFilter)
        {
            try
            {
                var query = _db.Users
                    .Include(u => u.PrimaryLocation)
                    .Include(u => u.Employee)
                    .Include(u => u.Customer)
                    .Where(u => u.IsActive);

                // Apply filters
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(u =>
                        u.FirstName.Contains(searchString) ||
                        u.LastName.Contains(searchString) ||
                        u.Email.Contains(searchString) ||
                        u.PhoneNumber.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(roleFilter) && roleFilter != "All")
                {
                    var usersInRole = await _userManager.GetUsersInRoleAsync(roleFilter);
                    var userIds = usersInRole.Select(u => u.Id);
                    query = query.Where(u => userIds.Contains(u.Id));
                }

                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                {
                    var status = Enum.Parse<AccountStatus>(statusFilter);
                    query = query.Where(u => u.AccountStatus == status);
                }

                var users = await query
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .ToListAsync();

                var userVMs = new List<UserManagementVM>();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userVMs.Add(MapToUserManagementVM(user, roles.FirstOrDefault()));
                }

                await PopulateFilterDropdowns();
                return View(userVMs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading users index");
                TempData["error"] = "An error occurred while loading users.";
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Users/Upsert/{id?}
        public async Task<IActionResult> Upsert(string? id)
        {
            try
            {
                var vm = new UserManagementVM();
                await PopulateDropdowns(vm);

                if (string.IsNullOrEmpty(id))
                {
                    // Create new user
                    ViewBag.Action = "Create";
                    return View(vm);
                }

                // Edit existing user
                ViewBag.Action = "Edit";
                var user = await GetUserWithRelatedData(id);
                if (user == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                var roles = await _userManager.GetRolesAsync(user);
                vm = await MapToUserManagementVMAsync(user, roles.FirstOrDefault());
                await PopulateDropdowns(vm);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading user upsert page for ID: {UserId}", id);
                TempData["error"] = "An error occurred while loading the user form.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UserManagementVM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropdowns(vm);
                    return View(vm);
                }

                if (string.IsNullOrEmpty(vm.UserId))
                {
                    // Create new user
                    await CreateNewUser(vm);
                    TempData["success"] = "User created successfully. Temporary password has been set.";
                }
                else
                {
                    // Update existing user
                    await UpdateExistingUser(vm);
                    TempData["success"] = "User updated successfully.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException vex)
            {
                ModelState.AddModelError("", vex.Message);
                await PopulateDropdowns(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error upserting user: {Email}", vm.Email);
                TempData["error"] = $"An error occurred: {ex.Message}";
                await PopulateDropdowns(vm);
                return View(vm);
            }
        }

        // POST: Users/ToggleStatus/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Prevent users from modifying their own status
                if (id == _userManager.GetUserId(User))
                {
                    TempData["error"] = "You cannot modify your own account status.";
                    return RedirectToAction(nameof(Index));
                }

                var previousStatus = user.AccountStatus;
                user.AccountStatus = user.AccountStatus == AccountStatus.Active
                    ? AccountStatus.Suspended
                    : AccountStatus.Active;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _userManager.GetUserId(User);

                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                _logger.LogInformation("User {UserId} status changed from {PreviousStatus} to {NewStatus} by {CurrentUser}",
                    id, previousStatus, user.AccountStatus, User.Identity.Name);

                TempData["success"] = $"User {(user.AccountStatus == AccountStatus.Active ? "activated" : "suspended")} successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling user status for ID: {UserId}", id);
                TempData["error"] = "An error occurred while updating user status.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                // Prevent users from resetting their own password via this method
                if (id == _userManager.GetUserId(User))
                {
                    TempData["error"] = "Please use the 'Forgot Password' feature to reset your own password.";
                    return RedirectToAction(nameof(Index));
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var newPassword = GenerateSecureTemporaryPassword();
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    // Log the password reset
                    _logger.LogInformation("Password reset for user: {Email} by {CurrentUser}",
                        user.Email, User.Identity.Name);

                    // In a real application, you might want to email the password to the user
                    // For now, we'll display it in the success message
                    TempData["success"] = $"Password reset successfully for {user.Email}. Temporary password: {newPassword}";

                    // You could also store it in TempData separately for the modal
                    TempData["ResetPassword"] = newPassword;
                    TempData["ResetUserEmail"] = user.Email;
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Password reset failed: {errors}");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting password for user ID: {UserId}", id);
                TempData["error"] = "An error occurred while resetting the password.";
                return RedirectToAction(nameof(Index));
            }
        }

        #region Private Methods

        private async Task<ApplicationUser?> GetUserWithRelatedData(string id)
        {
            return await _db.Users
                .Include(u => u.Employee)
                .Include(u => u.Customer)
                .Include(u => u.PrimaryLocation)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        private async Task CreateNewUser(UserManagementVM vm)
        {
            // Validate unique email
            if (await _userManager.FindByEmailAsync(vm.Email) != null)
            {
                throw new ValidationException("A user with this email already exists.");
            }

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
                AccountStatus = vm.IsActive ? AccountStatus.Active : AccountStatus.PendingApproval,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            // Create user with temporary password
            var temporaryPassword = GenerateSecureTemporaryPassword();
            var result = await _userManager.CreateAsync(user, temporaryPassword);

            if (!result.Succeeded)
            {
                throw new Exception($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            // Handle role assignment and entity creation
            await HandleUserRoleAssignment(user, vm);

            _logger.LogInformation("New user created: {Email} with role {Role}", user.Email, vm.UserRole);
        }

        private async Task UpdateExistingUser(UserManagementVM vm)
        {
            var user = await GetUserWithRelatedData(vm.UserId);
            if (user == null)
            {
                throw new ValidationException("User not found.");
            }

            // Check if email is being changed and validate uniqueness
            if (user.Email != vm.Email && await _userManager.FindByEmailAsync(vm.Email) != null)
            {
                throw new ValidationException("A user with this email already exists.");
            }

            // Update user properties
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.UserName = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;
            user.DOB = vm.DOB;
            user.LocationId = vm.LocationId;
            user.ProfilePictureUrl = vm.ProfilePictureUrl;
            user.AccountStatus = vm.IsActive ? AccountStatus.Active : AccountStatus.Suspended;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"User update failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            // Handle role assignment and entity updates
            await HandleUserRoleAssignment(user, vm, true);

            _logger.LogInformation("User updated: {Email}", user.Email);
        }

        private async Task HandleUserRoleAssignment(ApplicationUser user, UserManagementVM vm, bool isUpdate = false)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            var currentRole = currentRoles.FirstOrDefault();

            // Remove from current role if it's changing
            if (isUpdate && currentRole != vm.UserRole)
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                // Soft delete previous role-specific entities
                await HandleRoleChangeCleanup(user, currentRole);
            }

            // Add to new role
            if (!await _userManager.IsInRoleAsync(user, vm.UserRole))
            {
                await _userManager.AddToRoleAsync(user, vm.UserRole);
            }

            // Create/update role-specific entities
            await HandleRoleSpecificEntities(user, vm, isUpdate);
        }

        private async Task HandleRoleChangeCleanup(ApplicationUser user, string? previousRole)
        {
            if (previousRole?.Contains("Employee") == true && user.EmployeeId.HasValue)
            {
                var employee = await _db.Employees.FindAsync(user.EmployeeId);
                if (employee != null)
                {
                    employee.IsActive = false;
                    employee.UpdatedAt = DateTime.UtcNow;
                }
                user.EmployeeId = null;
            }

            if (previousRole == "Customer" && user.CustomerId.HasValue)
            {
                var customer = await _db.Customers.FindAsync(user.CustomerId);
                if (customer != null)
                {
                    customer.IsActive = false;
                    customer.UpdatedAt = DateTime.UtcNow;
                }
                user.CustomerId = null;
            }

            await _db.SaveChangesAsync();
        }

        private async Task HandleRoleSpecificEntities(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            if (IsEmployeeRole(vm.UserRole))
            {
                await HandleEmployeeEntity(user, vm, isUpdate);
            }
            else if (vm.UserRole == "Customer")
            {
                await HandleCustomerEntity(user, vm, isUpdate);
            }
        }

        private async Task HandleEmployeeEntity(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            var employee = isUpdate && user.EmployeeId.HasValue
                ? await _db.Employees.FindAsync(user.EmployeeId)
                : new Employee { UserId = user.Id };

            if (employee == null) return;

            employee.EmployeeNumber = vm.EmployeeNumber ?? GenerateEmployeeNumber();
            employee.EmployeeType = MapRoleToEmployeeType(vm.UserRole);
            employee.AvailabilityStatus = vm.AvailabilityStatus ?? AvailabilityStatus.Available;
            employee.IsActive = true;
            employee.UpdatedAt = DateTime.UtcNow;

            if (!isUpdate || !user.EmployeeId.HasValue)
            {
                employee.CreatedAt = DateTime.UtcNow;
                _db.Employees.Add(employee);
            }

            await _db.SaveChangesAsync();
            user.EmployeeId = employee.Id;
        }

        private async Task HandleCustomerEntity(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            var customer = isUpdate && user.CustomerId.HasValue
                ? await _db.Customers.FindAsync(user.CustomerId)
                : new Customer { UserId = user.Id };

            if (customer == null) return;

            customer.TradingName = vm.TradingName ?? $"{vm.FirstName} {vm.LastName}";
            customer.BusinessType = vm.BusinessType ?? BusinessType.SpazaShop;
            customer.BusinessEmail = vm.BusinessEmail ?? vm.Email;
            customer.BusinessPhoneNumber = vm.BusinessPhoneNumber ?? vm.PhoneNumber;
            customer.AddressLine1 = vm.AddressLine1 ?? string.Empty;
            customer.AddressLine2 = vm.AddressLine2;
            customer.Suburb = vm.Suburb ?? string.Empty;
            customer.City = vm.City ?? string.Empty;
            customer.Province = vm.Province ?? string.Empty;
            customer.PostalCode = vm.PostalCode ?? string.Empty;
            customer.LocationId = await GetOrCreateLocationId(vm.Suburb, vm.City, vm.Province);
            customer.IsActive = true;
            customer.UpdatedAt = DateTime.UtcNow;

            if (!isUpdate || !user.CustomerId.HasValue)
            {
                customer.CreatedAt = DateTime.UtcNow;
                _db.Customers.Add(customer);
            }

            await _db.SaveChangesAsync();
            user.CustomerId = customer.Id;
        }

        private async Task PopulateDropdowns(UserManagementVM vm)
        {
            vm.LocationList = await _db.Locations
                .Where(l => l.IsActive)
                .OrderBy(l => l.Province)
                .ThenBy(l => l.City)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Suburb}, {l.City}, {l.Province}"
                })
                .ToListAsync();

            vm.RoleList = await _roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToListAsync();

            // Add business type options for customer role
            ViewBag.BusinessTypes = Enum.GetValues<BusinessType>()
                .Select(bt => new SelectListItem
                {
                    Value = bt.ToString(),
                    Text = bt.ToString()
                })
                .ToList();

            // Add employee type options for employee roles
            ViewBag.EmployeeTypes = Enum.GetValues<EmployeeType>()
                .Select(et => new SelectListItem
                {
                    Value = et.ToString(),
                    Text = et.ToString()
                })
                .ToList();
        }

        private async Task PopulateFilterDropdowns()
        {
            ViewBag.RoleFilterList = await _roleManager.Roles
                .Select(r => new SelectListItem { Value = r.Name, Text = r.Name })
                .ToListAsync();

            ViewBag.StatusFilterList = Enum.GetValues<AccountStatus>()
                .Select(s => new SelectListItem { Value = s.ToString(), Text = s.ToString() })
                .ToList();
        }

        private UserManagementVM MapToUserManagementVM(ApplicationUser user, string? role)
        {
            return new UserManagementVM
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB,
                LocationId = user.LocationId,
                ProfilePictureUrl = user.ProfilePictureUrl,
                IsActive = user.IsActive && user.AccountStatus == AccountStatus.Active,
                UserRole = role ?? "User",
                AccountStatus = user.AccountStatus,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                LastLoginDate = user.LastLoginDate
            };
        }

        private async Task<UserManagementVM> MapToUserManagementVMAsync(ApplicationUser user, string? role)
        {
            var vm = MapToUserManagementVM(user, role);

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
                vm.Suburb = user.Customer.Suburb;
                vm.City = user.Customer.City;
                vm.Province = user.Customer.Province;
                vm.PostalCode = user.Customer.PostalCode;
            }

            return vm;
        }

        private string GenerateSecureTemporaryPassword()
        {
            const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowercase = "abcdefghijkmnpqrstuvwxyz";
            const string digits = "23456789";
            const string special = "!@#$%^&*";

            var random = new Random();
            var password = new char[12];

            // Ensure at least one character from each group
            password[0] = uppercase[random.Next(uppercase.Length)];
            password[1] = lowercase[random.Next(lowercase.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = special[random.Next(special.Length)];

            // Fill the rest with random characters from all groups
            var allChars = uppercase + lowercase + digits + special;
            for (int i = 4; i < 12; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password characters
            return new string(password.OrderBy(x => random.Next()).ToArray());
        }

        private string GenerateEmployeeNumber()
        {
            var timestamp = DateTime.Now.ToString("yyMMddHHmmss");
            return $"EMP{timestamp}";
        }

        private async Task<int> GetOrCreateLocationId(string suburb, string city, string province)
        {
            if (string.IsNullOrEmpty(suburb) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(province))
                return 1; // Default location ID

            var location = await _db.Locations
                .FirstOrDefaultAsync(l => l.Suburb == suburb && l.City == city && l.Province == province);

            if (location == null)
            {
                location = new Location
                {
                    Suburb = suburb,
                    City = city,
                    Province = province,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };
                _db.Locations.Add(location);
                await _db.SaveChangesAsync();
            }

            return location.Id;
        }

        private bool IsEmployeeRole(string role)
        {
            return role == SD.AdminRole ||
                   role == SD.CustomerSupportRole ||
                   role == SD.StockControllerRole ||
                   role == SD.MaintenanceTechnicianRole ||
                   role == SD.FaultTechnicianRole;
        }

        private EmployeeType MapRoleToEmployeeType(string role)
        {
            return role switch
            {
                SD.AdminRole => EmployeeType.Admin,
                SD.CustomerSupportRole => EmployeeType.CustomerSupport,
                SD.StockControllerRole => EmployeeType.StockController,
                SD.MaintenanceTechnicianRole => EmployeeType.MaintenanceTechnician,
                SD.FaultTechnicianRole => EmployeeType.FaultTechnician,
                _ => EmployeeType.CustomerSupport
            };
        }
        #endregion
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