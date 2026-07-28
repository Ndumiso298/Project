using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Models.ViewModels;
using Project.Utility;
using System.Security.Claims;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<UserController> _logger;

        public UserController(ApplicationDbContext db,
                            UserManager<IdentityUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IWebHostEnvironment hostingEnvironment,
                            IEmailSender emailSender,
                            ILogger<UserController> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
            _emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult CustomerList()
        {
            var customers = _db.tblCustomer.ToList();
            return View(customers);
        }

        public IActionResult EmployeeList()
        {
            var customers = _db.tblEmployee.ToList();
            return View(customers);
        }

        public async Task<IActionResult> Index()
        {
            var userList = _db.AppUser.ToList();

            foreach (var user in userList)
            {
                var userRoles = await _userManager.GetRolesAsync(user) as List<string>;
                user.Role = string.Join(",", userRoles);

                var userClaims = _userManager.GetClaimsAsync(user).GetAwaiter().GetResult().Select(c => c.Type);
                user.UserClaim = string.Join(",", userClaims);
            }

            return View(userList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockUnlock(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            var wasLocked = user.LockoutEnd != null && user.LockoutEnd > DateTime.Now;

            if (wasLocked)
            {
                user.LockoutEnd = DateTime.Now;
                await SendAccountUnlockEmail(user);
                TempData[SD.Success] = $"User {user.FirstName} unlocked successfully.";
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
                await SendAccountLockEmail(user);
                TempData[SD.Success] = $"User {user.FirstName} locked successfully.";
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            _db.AppUser.Remove(user);
            _db.SaveChanges();
            TempData[SD.Error] = $"User {user.FirstName} deleted.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManagerRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var existingRoles = await _userManager.GetRolesAsync(user) as List<string>;

            var model = new RolesViewModel
            {
                User = user as ApplicationUser ?? new ApplicationUser { Id = user.Id, Email = user.Email }
            };

            foreach (var role in _roleManager.Roles)
            {
                var roleSelection = new RoleSelection
                {
                    RoleName = role.Name,
                    IsSelected = existingRoles.Contains(role.Name)
                };
                model.RoleList.Add(roleSelection);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagerRole(RolesViewModel rolesViewModel)
        {
            var user = await _userManager.FindByIdAsync(rolesViewModel.User.Id);
            if (user == null) return NotFound();

            var oldRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, oldRoles);

            var newRoles = rolesViewModel.RoleList.Where(r => r.IsSelected).Select(r => r.RoleName);
            await _userManager.AddToRolesAsync(user, newRoles);

            // Send role update email
            await SendRoleUpdateEmail(user as ApplicationUser, newRoles);

            TempData[SD.Success] = $"User roles updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManagerUserClaim(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var existingClaims = await _userManager.GetClaimsAsync(user);

            var model = new ClaimsViewModel
            {
                User = user as ApplicationUser ?? new ApplicationUser { Id = user.Id, Email = user.Email }
            };

            foreach (var claim in ClaimsStore.claimsList)
            {
                var userClaim = new ClaimSelection
                {
                    ClaimType = claim.Type,
                    IsSelected = existingClaims.Any(c => c.Type == claim.Type)
                };
                model.ClaimList.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagerUserClaim(ClaimsViewModel claimsViewModel)
        {
            var user = await _userManager.FindByIdAsync(claimsViewModel.User.Id);
            if (user == null) return NotFound();

            var oldClaims = await _userManager.GetClaimsAsync(user);
            await _userManager.RemoveClaimsAsync(user, oldClaims);

            var newClaims = claimsViewModel.ClaimList
                .Where(c => c.IsSelected)
                .Select(c => new Claim(c.ClaimType, "true"));
            await _userManager.AddClaimsAsync(user, newClaims);

            TempData[SD.Success] = $"User claims updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound();

            user.IsApproved = true;
            user.Status = "Approved";
            user.RejectionReason = null;

            _db.SaveChanges();

            // Send approval email
            await SendUserApprovalEmail(user);

            TempData[SD.Success] = $"User {user.FirstName} {user.LastName} approved successfully.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeclineUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            user.IsApproved = false;
            user.Status = "Declined";
            user.RejectionReason = "Your account was declined due to failing verification requirements.";
            user.DeclinedAt = DateTime.UtcNow;

            _db.SaveChanges();

            // Send decline email
            await SendUserDeclineEmail(user, user.RejectionReason);

            TempData[SD.Error] = $"User {user.FirstName} declined.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApproveDeclineUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            string role = string.Join(",", userRoles);

            var vm = new UserVM
            {
                Id = user.Id,
                Role = role,
                IsApproved = _db.AppUser.FirstOrDefault(u => u.Id == userId)?.IsApproved ?? false,
                RejectionReason = _db.AppUser.FirstOrDefault(u => u.Id == userId)?.RejectionReason
            };

            // Common info from AppUser
            var appUser = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (appUser != null)
            {
                vm.FirstName = appUser.FirstName;
                vm.LastName = appUser.LastName;
                vm.Email = appUser.Email;
                vm.CellNumber = appUser.CellNumber;
            }

            if (role.Contains(SD.CustomerRole))
            {
                var customer = _db.tblCustomer.FirstOrDefault(c => c.ApplicationUserId == userId);
                if (customer != null)
                {
                    vm.CustomerNumber = customer.CustomerNumber;
                    vm.BusinessDocumentPath = customer.BusinessDocumentPath;
                    vm.StreetAddress = customer.ApplicationUser.StreetAddress;
                    vm.City = customer.ApplicationUser.City;
                    vm.State = customer.ApplicationUser.State;
                    vm.PostalCode = customer.ApplicationUser.PostalCode;
                }
            }
            else if (role.Contains(SD.CustomerSupport) || role.Contains(SD.AdminRole) || role.Contains(SD.StockController) || role.Contains(SD.MaintenanceTechnician) || role.Contains(SD.FaultTechnician))
            {
                var employee = _db.tblEmployee.FirstOrDefault(e => e.ApplicationUserId == userId);
                if (employee != null)
                {
                    vm.EmployeeNumber = employee.EmployeeNumber;
                    vm.StreetAddress = employee.ApplicationUser.StreetAddress;
                    vm.City = employee.ApplicationUser.City;
                    vm.State = employee.ApplicationUser.State;
                    vm.PostalCode = employee.ApplicationUser.PostalCode;
                }
            }

            return View(vm);
        }


        private async Task SendUserApprovalEmail(ApplicationUser user)
        {
            try
            {
                var subject = "Account Approved - Welcome to Our Platform!";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Account Approved!</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>We're excited to inform you that your account has been <strong>approved</strong> and is now active!</p>
                        
                        <div style='background-color: #e8f5e8; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #28a745;'>
                            <h4 style='color: #155724; margin-top: 0;'>Account Status: <span style='color: #28a745;'>ACTIVE</span></h4>
                            <p><strong>Login URL:</strong> Soit-iis.mandela.ac.za/grp-03-11</p>
                            <p><strong>Email:</strong> {user.Email}</p>
                            <p><strong>Approval Date:</strong> {DateTime.Now:dd MMMM yyyy}</p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>Next Steps</h4>
                            <p>You can now log in to your account and access all the platform features.</p>
                            <p>If you have any questions, please don't hesitate to contact our support team.</p>
                        </div>

                        <p>Welcome aboard!</p>
                        
                        <p>Best regards,<br>
                        The Platform Team</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Approval email sent to {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send approval email to {Email}", user.Email);
            }
        }

        private async Task SendUserDeclineEmail(ApplicationUser user, string reason)
        {
            try
            {
                var subject = "Account Application Update";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Account Application Status</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>After careful review, we regret to inform you that your account application has been <strong>declined</strong>.</p>
                        
                        <div style='background-color: #f8d7da; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #dc3545;'>
                            <h4 style='color: #721c24; margin-top: 0;'>Reason for Decline:</h4>
                            <p>{reason}</p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>Need Assistance?</h4>
                            <p>If you believe this was in error or would like more information, please contact our support team.</p>
                        </div>

                        <p>Thank you for your interest in our platform.</p>
                        
                        <p>Best regards,<br>
                        The Platform Team</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Decline email sent to {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send decline email to {Email}", user.Email);
            }
        }

        private async Task SendRoleUpdateEmail(ApplicationUser user, IEnumerable<string> newRoles)
        {
            try
            {
                var subject = "Account Role Updated";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Role Update Notification</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>Your account roles have been updated by an administrator.</p>
                        
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #6c757d;'>
                            <h4 style='color: #495057; margin-top: 0;'>Current Roles:</h4>
                            <p><strong>{string.Join(", ", newRoles)}</strong></p>
                            <p><strong>Update Date:</strong> {DateTime.Now:dd MMMM yyyy HH:mm}</p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>What This Means:</h4>
                            <p>Your access permissions and available features have been updated based on your new role(s).</p>
                            <p>You may need to log out and log back in to see all changes.</p>
                        </div>

                        <p>If you have any questions, please contact your administrator.</p>
                        
                        <p>Best regards,<br>
                        The Platform Team</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Role update email sent to {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send role update email to {Email}", user.Email);
            }
        }

        private async Task SendAccountLockEmail(ApplicationUser user)
        {
            try
            {
                var subject = "Account Locked";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Account Security Notice</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>Your account has been <strong>locked</strong> for security reasons.</p>
                        
                        <div style='background-color: #fff3cd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #ffc107;'>
                            <h4 style='color: #856404; margin-top: 0;'>Lock Details:</h4>
                            <p><strong>Lock Date:</strong> {DateTime.Now:dd MMMM yyyy HH:mm}</p>
                            <p><strong>Status:</strong> Account Locked</p>
                        </div>

                        <div style='background-color: #f8d7da; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #dc3545;'>
                            <h4 style='color: #721c24; margin-top: 0;'>Important:</h4>
                            <p>You will not be able to access your account until it is unlocked by an administrator.</p>
                            <p>If you believe this was done in error, please contact support immediately.</p>
                        </div>

                        <p>Best regards,<br>
                        Security Team</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Account lock email sent to {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send account lock email to {Email}", user.Email);
            }
        }

        private async Task SendAccountUnlockEmail(ApplicationUser user)
        {
            try
            {
                var subject = "Account Unlocked";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Account Access Restored</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>Your account has been <strong>unlocked</strong> and is now accessible.</p>
                        
                        <div style='background-color: #e8f5e8; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #28a745;'>
                            <h4 style='color: #155724; margin-top: 0;'>Account Status:</h4>
                            <p><strong>Unlock Date:</strong> {DateTime.Now:dd MMMM yyyy HH:mm}</p>
                            <p><strong>Status:</strong> Active</p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>You Can Now:</h4>
                            <p>• Log in to your account</p>
                            <p>• Access all platform features</p>
                            <p>• Continue your normal activities</p>
                        </div>

                        <p>If you experience any issues, please contact support.</p>
                        
                        <p>Best regards,<br>
                        Support Team</p>
                    </div>";

                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Account unlock email sent to {Email}", user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send account unlock email to {Email}", user.Email);
            }
        }
    }
}