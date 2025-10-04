using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Models.ViewModels;
using Project.Models;
using Project.Utilities.Enums;
using Project.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Project.Models.ViewModels.UserManagementVM;

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
        public async Task<IActionResult> Index(string searchString, string roleFilter, string statusFilter, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _db.Users
                    .Include(u => u.Employee)
                    .Include(u => u.Customer)
                    .Where(u => !u.IsDeleted);

                // Search filter
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(u =>
                        u.FirstName!.Contains(searchString) ||
                        u.LastName!.Contains(searchString) ||
                        u.Email!.Contains(searchString) ||
                        (u.PhoneNumber ?? "").Contains(searchString) ||
                        (u.Employee != null && u.Employee.EmployeeNumber.Contains(searchString)) ||
                        (u.Customer != null && u.Customer.BusinessName.Contains(searchString)));
                }

                // Role filter
                if (!string.IsNullOrEmpty(roleFilter) && roleFilter != "All")
                {
                    var usersInRole = await _userManager.GetUsersInRoleAsync(roleFilter);
                    var userIds = usersInRole.Select(u => u.Id);
                    query = query.Where(u => userIds.Contains(u.Id));
                }

                // Status filter
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
                {
                    switch (statusFilter)
                    {
                        case "Active":
                            query = query.Where(u => u.IsAccountActive);
                            break;
                        case "Inactive":
                            query = query.Where(u => !u.IsAccountActive);
                            break;
                        case "Pending":
                            query = query.Where(u => u.Customer != null && u.Customer.AccountStatus == AccountStatus.PendingApproval);
                            break;
                    }
                }

                // Pagination
                var totalCount = await query.CountAsync();
                var users = await query
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var userVMs = new List<UserManagementVM>();
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var vm = await MapToUserManagementVMAsync(user, roles.FirstOrDefault());
                    userVMs.Add(vm);
                }

                ViewBag.TotalCount = totalCount;
                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                ViewBag.SearchString = searchString;
                ViewBag.RoleFilter = roleFilter;
                ViewBag.StatusFilter = statusFilter;

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
                    ViewBag.Action = "Create";
                    return View(vm);
                }

                ViewBag.Action = "Edit";
                var user = await GetUserWithRelatedData(id);
                if (user == null || user.IsDeleted)
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
                    await CreateNewUser(vm);
                    TempData["success"] = "User created successfully. Temporary password has been set.";
                }
                else
                {
                    await UpdateExistingUser(vm);
                    TempData["success"] = "User updated successfully.";
                }

                return RedirectToAction(nameof(Index));
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
                if (user == null || user.IsDeleted)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (id == _userManager.GetUserId(User))
                {
                    TempData["error"] = "You cannot modify your own account status.";
                    return RedirectToAction(nameof(Index));
                }

                user.IsDeleted = !user.IsAccountActive;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _userManager.GetUserId(User);

                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                _logger.LogInformation("User {UserId} status changed to {NewStatus} by {CurrentUser}",
                    id, user.IsAccountActive ? "Active" : "Inactive", User.Identity.Name);

                TempData["success"] = $"User {(user.IsAccountActive ? "activated" : "suspended")} successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling user status for ID: {UserId}", id);
                TempData["error"] = "An error occurred while updating user status.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/ResetPassword/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null || user.IsDeleted)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

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
                    _logger.LogInformation("Password reset for user: {Email} by {CurrentUser}",
                        user.Email, User.Identity.Name);

                    TempData["success"] = $"Password reset successfully for {user.Email}. Temporary password: {newPassword}";
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

        // POST: Users/ApproveCustomer/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCustomer(string id)
        {
            try
            {
                var user = await GetUserWithRelatedData(id);
                if (user == null || user.IsDeleted)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (user.Customer == null)
                {
                    TempData["error"] = "User is not a customer.";
                    return RedirectToAction(nameof(Index));
                }

                user.Customer.AccountStatus = AccountStatus.Approved;
                user.Customer.RejectionReason = null;
                user.Customer.DeclinedAt = null;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _userManager.GetUserId(User);

                await _db.SaveChangesAsync();

                _logger.LogInformation("Customer approved: {BusinessName} by {CurrentUser}",
                    user.Customer.BusinessName, User.Identity.Name);

                TempData["success"] = $"Customer {user.Customer.BusinessName} approved successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving customer: {UserId}", id);
                TempData["error"] = "An error occurred while approving the customer.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/RejectCustomer/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectCustomer(string id, string rejectionReason)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rejectionReason))
                {
                    TempData["error"] = "Rejection reason is required.";
                    return RedirectToAction(nameof(Index));
                }

                var user = await GetUserWithRelatedData(id);
                if (user == null || user.IsDeleted)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (user.Customer == null)
                {
                    TempData["error"] = "User is not a customer.";
                    return RedirectToAction(nameof(Index));
                }

                user.Customer.AccountStatus = AccountStatus.Rejected;
                user.Customer.RejectionReason = rejectionReason;
                user.Customer.DeclinedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _userManager.GetUserId(User);

                await _db.SaveChangesAsync();

                _logger.LogInformation("Customer rejected: {BusinessName} by {CurrentUser}",
                    user.Customer.BusinessName, User.Identity.Name);

                TempData["success"] = $"Customer {user.Customer.BusinessName} rejected successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting customer: {UserId}", id);
                TempData["error"] = "An error occurred while rejecting the customer.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/UpdateEmployeeAvailability/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployeeAvailability(string id, AvailabilityStatus status)
        {
            try
            {
                var user = await GetUserWithRelatedData(id);
                if (user == null || user.IsDeleted)
                {
                    TempData["error"] = "User not found.";
                    return RedirectToAction(nameof(Index));
                }

                if (user.Employee == null)
                {
                    TempData["error"] = "User is not an employee.";
                    return RedirectToAction(nameof(Index));
                }

                user.Employee.AvailabilityStatus = status;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedBy = _userManager.GetUserId(User);

                await _db.SaveChangesAsync();

                _logger.LogInformation("Employee availability updated: {EmployeeName} to {Status} by {CurrentUser}",
                    user.FullName, status, User.Identity.Name);

                TempData["success"] = $"Employee {user.FullName} availability updated to {status}.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee availability: {UserId}", id);
                TempData["error"] = "An error occurred while updating employee availability.";
                return RedirectToAction(nameof(Index));
            }
        }

        #region Private Methods

        private async Task<ApplicationUser?> GetUserWithRelatedData(string id)
        {
            return await _db.Users
                .Include(u => u.Employee)
                .ThenInclude(e => e.WorkLocation)
                .Include(u => u.Customer)
                .ThenInclude(c => c.TradingLocation)
                .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }

        private async Task CreateNewUser(UserManagementVM vm)
        {
            // Check if email already exists
            if (await _userManager.FindByEmailAsync(vm.Email) != null)
            {
                throw new Exception("A user with this email already exists.");
            }

            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                PhoneNumber = vm.PhoneNumber,
                DOB = vm.DOB,
                ProfilePictureUrl = vm.ProfilePictureUrl,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _userManager.GetUserId(User),
                IsDeleted = false
            };

            // Generate temporary password
            var temporaryPassword = GenerateSecureTemporaryPassword();
            var result = await _userManager.CreateAsync(user, temporaryPassword);

            if (!result.Succeeded)
            {
                throw new Exception($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            // Assign role
            await _userManager.AddToRoleAsync(user, vm.UserRole);

            // Handle role-specific entities
            await HandleRoleSpecificEntities(user, vm, false);

            _logger.LogInformation("New user created: {Email} with role {Role}", user.Email, vm.UserRole);

            // Store temporary password for display
            TempData["NewUserPassword"] = temporaryPassword;
        }

        private async Task UpdateExistingUser(UserManagementVM vm)
        {
            var user = await GetUserWithRelatedData(vm.UserId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Check if email is being changed and if new email already exists
            if (user.Email != vm.Email && await _userManager.FindByEmailAsync(vm.Email) != null)
            {
                throw new Exception("A user with this email already exists.");
            }

            // Update basic user info
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.UserName = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;
            user.DOB = vm.DOB;
            user.ProfilePictureUrl = vm.ProfilePictureUrl;
            user.UpdatedAt = DateTime.UtcNow;
            user.UpdatedBy = _userManager.GetUserId(User);

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception($"User update failed: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
            }

            // Handle role changes
            var currentRoles = await _userManager.GetRolesAsync(user);
            var currentRole = currentRoles.FirstOrDefault();

            if (currentRole != vm.UserRole)
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, vm.UserRole);
                await HandleRoleChangeCleanup(user, currentRole);
            }

            // Handle role-specific entities
            await HandleRoleSpecificEntities(user, vm, true);

            _logger.LogInformation("User updated: {Email}", user.Email);
        }

        private async Task HandleRoleChangeCleanup(ApplicationUser user, string? previousRole)
        {
            // Remove employee record if switching from employee role
            if (IsEmployeeRole(previousRole) && user.Employee != null)
            {
                _db.Employees.Remove(user.Employee);
            }

            // Remove customer record if switching from customer role
            if (previousRole == SD.CustomerRole && user.Customer != null)
            {
                _db.Customers.Remove(user.Customer);
            }

            await _db.SaveChangesAsync();
        }

        private async Task HandleRoleSpecificEntities(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            if (IsEmployeeRole(vm.UserRole))
            {
                await HandleEmployeeEntity(user, vm, isUpdate);
            }
            else if (vm.UserRole == SD.CustomerRole)
            {
                await HandleCustomerEntity(user, vm, isUpdate);
            }
        }

        private async Task HandleEmployeeEntity(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            var employee = isUpdate && user.Employee != null
                ? user.Employee
                : new Employee { UserId = user.Id };

            employee.EmployeeNumber = vm.EmployeeNumber ?? GenerateEmployeeNumber();
            employee.EmployeeType = vm.EmployeeType != 0
                ? vm.EmployeeType
                : EmployeeType.CustomerSupport;
            employee.AvailabilityStatus = vm.AvailabilityStatus ?? AvailabilityStatus.Available;
            employee.WorkLocationId = vm.LocationId;

            if (!isUpdate || user.Employee == null)
            {
                _db.Employees.Add(employee);
            }
            else
            {
                _db.Employees.Update(employee);
            }

            await _db.SaveChangesAsync();
        }

        private async Task HandleCustomerEntity(ApplicationUser user, UserManagementVM vm, bool isUpdate)
        {
            var customer = isUpdate && user.Customer != null
                ? user.Customer
                : new Customer { UserId = user.Id };

            customer.BusinessName = vm.BusinessName ?? $"{vm.FirstName} {vm.LastName}";
            customer.BusinessType = vm.BusinessType ?? BusinessType.SpazaShop;
            customer.BusinessEmail = vm.BusinessEmail ?? vm.Email;
            customer.BusinessPhoneNumber = vm.BusinessPhoneNumber ?? vm.PhoneNumber;
            customer.TradingLocationId = vm.LocationId;
            customer.StreetAddress = vm.StreetAddress ?? string.Empty;
            customer.Suburb = vm.Suburb ?? string.Empty;
            customer.City = vm.City ?? string.Empty;
            customer.Province = vm.Province ?? string.Empty;
            customer.PostalCode = vm.PostalCode ?? string.Empty;
            customer.AccountStatus = AccountStatus.PendingApproval;

            if (customer.TradingLocationId == null)
            {
                var newLocation = new Location
                {
                    Name = customer.BusinessName,
                    LocationType = LocationType.CustomerSite,
                    StreetAddress = customer.StreetAddress,
                    Suburb = customer.Suburb,
                    City = customer.City,
                    Province = customer.Province,
                    PostalCode = customer.PostalCode,
                    Country = "South Africa",
                };
                _db.Locations.Add(newLocation);
                await _db.SaveChangesAsync();  // Save to get Id
                customer.TradingLocationId = newLocation.Id;
            }

            if (!isUpdate || user.Customer == null)
            {
                _db.Customers.Add(customer);
            }
            else
            {
                _db.Customers.Update(customer);
            }

            await _db.SaveChangesAsync();
        }

        private async Task PopulateDropdowns(UserManagementVM vm)
        {
            vm.RoleList = await _roleManager.Roles
                .Where(r => r.Name != SD.CustomerRole) // Customers register themselves
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name.Replace("Role", "").Replace("_", " ")
                })
                .ToListAsync();

            ViewBag.BusinessTypes = Enum.GetValues<BusinessType>()
                .Select(bt => new SelectListItem
                {
                    Value = bt.ToString(),
                    Text = bt.ToString().Replace("_", " ")
                })
                .ToList();

            ViewBag.EmployeeTypes = Enum.GetValues<EmployeeType>()
                .Select(et => new SelectListItem
                {
                    Value = et.ToString(),
                    Text = et.ToString().Replace("_", " ")
                })
                .ToList();

            ViewBag.AvailabilityStatuses = Enum.GetValues<AvailabilityStatus>()
                .Select(asr => new SelectListItem
                {
                    Value = asr.ToString(),
                    Text = asr.ToString().Replace("_", " ")
                })
                .ToList();

            ViewBag.AccountStatuses = Enum.GetValues<AccountStatus>()
                .Select(acs => new SelectListItem
                {
                    Value = acs.ToString(),
                    Text = acs.ToString().Replace("_", " ")
                })
                .ToList();

            // Location dropdown for employees
            ViewBag.LocationList = await _db.Locations
                .Where(l => !l.IsDeleted)
                .OrderBy(l => l.City)
                .ThenBy(l => l.Suburb)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Suburb}, {l.City}"
                })
                .ToListAsync();
        }

        private async Task PopulateFilterDropdowns()
        {
            ViewBag.RoleFilterList = await _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name.Replace("Role", "").Replace("_", " ")
                })
                .ToListAsync();

            ViewBag.StatusFilterList = new List<SelectListItem>
        {
            new SelectListItem { Value = "All", Text = "All Statuses" },
            new SelectListItem { Value = "Active", Text = "Active" },
            new SelectListItem { Value = "Inactive", Text = "Inactive" },
            new SelectListItem { Value = "Pending", Text = "Pending Approval" }
        };
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
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserRole = role ?? "User",
                CurrentRole = role,
                AccountStatus = user.Customer?.AccountStatus ?? AccountStatus.Approved,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                LastLoginDate = user.LastLoginDate,
                IsDeleted = user.IsDeleted,
                EmployeeNumber = user.Employee?.EmployeeNumber,
                EmployeeType = user.Employee?.EmployeeType ?? EmployeeType.CustomerSupport,
                AvailabilityStatus = user.Employee?.AvailabilityStatus,
                WorkEmail = user.Employee?.WorkEmail,
                WorkPhone = user.Employee?.WorkPhone,
                LocationId = user.Employee?.WorkLocationId ?? user.Customer?.TradingLocationId,
                BusinessName = user.Customer?.BusinessName,
                BusinessType = user.Customer?.BusinessType,
                BusinessEmail = user.Customer?.BusinessEmail,
                BusinessPhoneNumber = user.Customer?.BusinessPhoneNumber,
                StreetAddress = user.Customer?.StreetAddress,
                Suburb = user.Customer?.Suburb,
                City = user.Customer?.City,
                Province = user.Customer?.Province,
                PostalCode = user.Customer?.PostalCode,
                //LocationId = user.Employee?.WorkLocationId
            };
        }

        private async Task<UserManagementVM> MapToUserManagementVMAsync(ApplicationUser user, string? role)
        {
            var vm = MapToUserManagementVM(user, role);

            // Populate computed properties
            await PopulateUserStatisticsAsync(vm, user.Id);

            return vm;
        }

        private async Task PopulateUserStatisticsAsync(UserManagementVM vm, string userId)
        {
            try
            {
                if (vm.UserRole == SD.CustomerRole)
                {
                    vm.CurrentFridgeCount = await _db.Fridges
                        .CountAsync(f => f.CurrentAllocation.Customer.UserId == userId && f.IsActive);

                    vm.ActiveAllocations = await _db.FridgeAllocations
                        .CountAsync(fa => fa.Customer.UserId == userId && fa.AllocationStatus == AllocationStatus.Active);

                    vm.HasActiveFridgeAllocations = vm.ActiveAllocations > 0;

                    // Credit status logic
                    var customer = await _db.Customers
                        .FirstOrDefaultAsync(c => c.UserId == userId);
                    if (customer != null)
                    {
                        vm.IsCreditLimited = customer.CreditStatus == CreditStatus.Limited;
                        vm.HasOverduePayments = customer.OutstandingBalance > 0 &&
                            customer.PaymentTermsDays > 0 &&
                            customer.CustomerSince.AddDays(customer.PaymentTermsDays) < DateTime.UtcNow;
                    }
                }
                else if (IsEmployeeRole(vm.UserRole))
                {
                    // Employee statistics
                    var employee = await _db.Employees
                        .FirstOrDefaultAsync(e => e.UserId == userId);

                    if (employee != null)
                    {
                        // Maintenance technician stats
                        if (vm.UserRole == SD.MaintenanceTechnicianRole)
                        {
                            vm.CurrentFridgeCount = await _db.MaintenanceVisits
                                .CountAsync(mv => mv.AssignedTechnicianId == employee.Id &&
                                                mv.Status == ServicingStatus.Scheduled);
                        }
                        // Fault technician stats
                        else if (vm.UserRole == SD.FaultTechnicianRole)
                        {
                            vm.CurrentFridgeCount = await _db.FaultRecords
                                .CountAsync(fr => fr.AssignedTechnicianId == employee.Id &&
                                                fr.Status == FaultStatus.Assigned);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error populating user statistics for user: {UserId}", userId);
            }
        }

        private string GenerateSecureTemporaryPassword()
        {
            const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowercase = "abcdefghijkmnpqrstuvwxyz";
            const string digits = "23456789";
            const string special = "!@#$%^&*";

            var random = new Random();
            var password = new char[12];

            password[0] = uppercase[random.Next(uppercase.Length)];
            password[1] = lowercase[random.Next(lowercase.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = special[random.Next(special.Length)];

            var allChars = uppercase + lowercase + digits + special;
            for (int i = 4; i < 12; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            return new string(password.OrderBy(x => random.Next()).ToArray());
        }

        private string GenerateEmployeeNumber()
        {
            return EmployeeNumberGenerator.GenerateEmployeeNumber();
        }

        private bool IsEmployeeRole(string role)
        {
            return role == SD.AdminRole ||
                   role == SD.CustomerSupportRole ||
                   role == SD.StockControllerRole ||
                   role == SD.MaintenanceTechnicianRole ||
                   role == SD.FaultTechnicianRole;
        }

        #endregion
    }
}