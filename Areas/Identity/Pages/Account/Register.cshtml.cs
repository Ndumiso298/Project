using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Project.Data;
using Project.Models;
using Project.Utility;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace Project.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            // Make password optional since employees don't need to provide it
            [StringLength(100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            public string? StreetAddress { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? CellNumber { get; set; }

            [Display(Name = "Business Proof Document")]
            public IFormFile? BusinessDocument { get; set; }

            [ValidateNever]
            public string Role { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!await _roleManager.RoleExistsAsync(SD.AdminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.AdminRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.StockController));
                await _roleManager.CreateAsync(new IdentityRole(SD.CustomerSupport));
                await _roleManager.CreateAsync(new IdentityRole(SD.FaultTechnician));
                await _roleManager.CreateAsync(new IdentityRole(SD.MaintenanceTechnician));
                await _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole));
            }

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            Input = new InputModel
            {
                RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            string roleToAssign = string.IsNullOrEmpty(Input.Role) ? SD.CustomerRole : Input.Role;

         

            // CUSTOMER VALIDATION
            if (roleToAssign == SD.CustomerRole)
            {



                if (Input.BusinessDocument == null)
                {
                    ModelState.AddModelError("Input.BusinessDocument", "Business document is required for Customer accounts.");
                }

                // Validate password for customers only
                if (string.IsNullOrEmpty(Input.Password))
                {
                    ModelState.AddModelError("Input.Password", "Password is required for Customer accounts.");
                }
                else if (Input.Password.Length < 6)
                {
                    ModelState.AddModelError("Input.Password", "Password must be at least 6 characters long.");
                }
            }

            // For employees, clear password validation errors since we'll generate passwords
            if (roleToAssign != SD.CustomerRole)
            {
                // Remove any password-related validation errors
                ModelState.Remove("Input.Password");
                ModelState.Remove("Input.ConfirmPassword");

                // Clear the password fields since we'll generate them
                Input.Password = null;
                Input.ConfirmPassword = null;
            }

            // GENERAL VALIDATION (for all roles)
            if (!ModelState.IsValid)
            {
                Input.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                });
                return Page();
            }

            var user = CreateUser();
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.StreetAddress = Input.StreetAddress;
            user.City = Input.City;
            user.State = Input.State;
            user.PostalCode = Input.PostalCode;
            user.CellNumber = Input.CellNumber;
            user.Email = Input.Email;
            user.UserName = Input.Email;

            int count = 1;

            if (roleToAssign == SD.CustomerRole)
            {
                // CUSTOMER: Use the password they provided
                user.IsApproved = false;
                user.Status = "Pending";

                var uploadsFolder = Path.Combine("wwwroot", "uploads", "businessDocs");
                Directory.CreateDirectory(uploadsFolder);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Input.BusinessDocument.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await Input.BusinessDocument.CopyToAsync(stream);

                using var ms = new MemoryStream();
                await Input.BusinessDocument.CopyToAsync(ms);
                var documentData = ms.ToArray();

                user.EmailConfirmed = false;

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    Input.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Name
                    });
                    return Page();
                }

                await _userManager.AddToRoleAsync(user, roleToAssign);

                var customer = new Customer
                {
                    ApplicationUserId = user.Id,
                    CustomerNumber = "CUST-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + $"_0{count++}",
                    BusinessDocumentPath = "/uploads/businessDocs/" + fileName,
                    BusinessDocumentData = documentData
                };
                _db.tblCustomer.Add(customer);
                await _db.SaveChangesAsync();

                // For debugging - check if we're reaching the email sending code
                _logger.LogInformation("About to send welcome email for user: {Email}, Role: {Role}", user.Email, roleToAssign);

                // Send customer welcome email with THEIR chosen password
                await SendCustomerWelcomeEmail(user, customer, Input.Password);

                // For debugging - check if we're reaching the admin notification
                _logger.LogInformation("About to send admin notification for customer: {Email}", user.Email);

                // Send admin notification email
                await SendAdminNotificationEmail(user, customer);

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId, code, returnUrl },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                return RedirectToPage("/Account/PendingApproval");
            }
            else
            {
                // EMPLOYEE: Generate strong password automatically
                var generatedPassword = GenerateStrongPassword();
                user.IsApproved = true;
                user.Status = "Approved";
                user.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(user, generatedPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    Input.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Name
                    });
                    return Page();
                }

                await _userManager.AddToRoleAsync(user, roleToAssign);

                var employee = new Employee
                {
                    ApplicationUserId = user.Id,
                    EmployeeNumber = "EMP-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + $"_0{count++}"
                };
                _db.tblEmployee.Add(employee);
                await _db.SaveChangesAsync();

                // For debugging - check if we're reaching the employee email sending code
                _logger.LogInformation("About to send employee welcome email for: {Email}, Role: {Role}", user.Email, roleToAssign);

                // Send employee welcome email with AUTO-GENERATED password
                await SendEmployeeWelcomeEmail(user, employee, generatedPassword, roleToAssign);

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. Ensure it has a parameterless constructor.");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
                throw new NotSupportedException("The default UI requires a user store with email support.");
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        // ADDED: Generate Strong Password for Employees
        private string GenerateStrongPassword()
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "#$%@";

            var random = new Random();
            var password = new char[8];

            // Ensure at least one of each character type
            password[0] = uppercase[random.Next(uppercase.Length)];
            password[1] = lowercase[random.Next(lowercase.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = special[random.Next(special.Length)];

            // Fill the rest with random characters from all sets
            var allChars = uppercase + lowercase + digits + special;
            for (int i = 4; i < password.Length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password
            return new string(password.OrderBy(x => random.Next()).ToArray());
        }

        // ADDED: Send Customer Welcome Email with Password
        private async Task SendCustomerWelcomeEmail(ApplicationUser user, Customer customer, string password)
        {
            try
            {
                var subject = "Welcome to Our Platform - Account Registration Received";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Welcome to Our Platform!</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>Thank you for registering with us! Your account has been successfully created and is currently <strong>pending approval</strong>.</p>
                        
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #ffc107;'>
                            <h4 style='color: #856404; margin-top: 0;'>Your Login Credentials:</h4>
                            <p><strong>Login URL:</strong> Soit-iis.mandela.ac.za/grp-03-11</p>
                            <p><strong>Username/Email:</strong> {user.Email}</p>
                            <p><strong>Password:</strong> {password}</p>
                            <p><strong>Customer Number:</strong> {customer.CustomerNumber}</p>
                            <p><strong>Registration Date:</strong> {DateTime.Now:dd MMMM yyyy}</p>
                            <p><strong>Status:</strong> <span style='color: #ffc107; font-weight: bold;'>Pending Approval</span></p>
                        </div>

                        <div style='background-color: #e8f5e8; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #28a745;'>
                            <h4 style='color: #155724; margin-top: 0;'>What Happens Next?</h4>
                            <p>Our team will review your business documentation and account details. You will receive another email once your account has been approved.</p>
                            <p>Please ensure you complete the email verification process by clicking the confirmation link sent to your email.</p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>Important Security Note</h4>
                            <p>Please keep your login credentials secure. We recommend changing your password after your first login.</p>
                        </div>

                        <p>If you have any questions, please don't hesitate to contact our support team.</p>
                        
                        <p>Best regards,<br>
                        The Platform Team</p>
                    </div>";

                _logger.LogInformation("Attempting to send customer welcome email to: {Email}", user.Email);
                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Successfully sent customer welcome email to: {Email}", user.Email);
            }
            catch (Exception ex)
            {
                // Log the actual error details
                _logger.LogError(ex, "Failed to send customer welcome email to {Email}. Error: {ErrorMessage}", user.Email, ex.Message);

                // For debugging - you can remove this in production
                TempData["EmailError"] = $"Failed to send welcome email: {ex.Message}";
            }
        }

        // ADDED: Send Employee Welcome Email with Auto-Generated Password
        private async Task SendEmployeeWelcomeEmail(ApplicationUser user, Employee employee, string password, string role)
        {
            try
            {
                var subject = "Welcome to Our Platform - Employee Account Created";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>Welcome to the Team!</h2>
                        
                        <p>Dear {user.FirstName} {user.LastName},</p>
                        
                        <p>Your employee account has been successfully created and you can now access the system.</p>
                        
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #28a745;'>
                            <h4 style='color: #155724; margin-top: 0;'>Your Login Credentials:</h4>
                            <p><strong>Login URL:</strong> Soit-iis.mandela.ac.za/grp-03-11</p>
                            <p><strong>Username/Email:</strong> {user.Email}</p>
                            <p><strong>Password:</strong> {password}</p>
                            <p><strong>Employee Number:</strong> {employee.EmployeeNumber}</p>
                            <p><strong>Role:</strong> {role}</p>
                            <p><strong>Account Status:</strong> <span style='color: #28a745; font-weight: bold;'>Active</span></p>
                        </div>

                        <div style='background-color: #e3f2fd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #2196f3;'>
                            <h4 style='color: #0d47a1; margin-top: 0;'>Getting Started</h4>
                            <p>You can now log in to the system using the credentials above. Please make sure to:</p>
                            <ul>
                                <li>Change your password after first login for security</li>
                                <li>Complete your profile information</li>
                                <li>Familiarize yourself with the system features</li>
                            </ul>
                        </div>

                        <div style='background-color: #fff3cd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #ffc107;'>
                            <h4 style='color: #856404; margin-top: 0;'>Security Reminder</h4>
                            <p>This is an auto-generated strong password. Keep your login credentials confidential and never share your password with anyone.</p>
                        </div>

                        <p>If you need any assistance, please contact your supervisor or the IT department.</p>
                        
                        <p>Welcome aboard!<br>
                        The Management Team</p>
                    </div>";

                _logger.LogInformation("Attempting to send employee welcome email to: {Email}", user.Email);
                await _emailSender.SendEmailAsync(user.Email, subject, message);
                _logger.LogInformation("Successfully sent employee welcome email to: {Email}", user.Email);
            }
            catch (Exception ex)
            {
                // Log the actual error details
                _logger.LogError(ex, "Failed to send employee welcome email to {Email}. Error: {ErrorMessage}", user.Email, ex.Message);

                // For debugging - you can remove this in production
                TempData["EmailError"] = $"Failed to send welcome email: {ex.Message}";
            }
        }

        // ADDED: Send Admin Notification Email for New Customer Registration
        private async Task SendAdminNotificationEmail(ApplicationUser user, Customer customer)
        {
            try
            {
                // Get all admin users
                var adminUsers = await _userManager.GetUsersInRoleAsync(SD.AdminRole);

                if (!adminUsers.Any())
                {
                    _logger.LogWarning("No admin users found to send notification email");
                    return;
                }

                var subject = "New Customer Registration Requires Approval";

                var message = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #2c3e50;'>New Customer Registration</h2>
                        
                        <p>A new customer has registered and requires approval:</p>
                        
                        <div style='background-color: #fff3cd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #ffc107;'>
                            <h4 style='color: #856404; margin-top: 0;'>Customer Details:</h4>
                            <p><strong>Name:</strong> {user.FirstName} {user.LastName}</p>
                            <p><strong>Email:</strong> {user.Email}</p>
                            <p><strong>Customer Number:</strong> {customer.CustomerNumber}</p>
                            <p><strong>Phone:</strong> {user.CellNumber ?? "Not provided"}</p>
                            <p><strong>Address:</strong> {user.StreetAddress}, {user.City}, {user.State} {user.PostalCode}</p>
                            <p><strong>Registration Date:</strong> {DateTime.Now:dd MMMM yyyy HH:mm}</p>
                        </div>

                        <div style='background-color: #d1ecf1; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #17a2b8;'>
                            <h4 style='color: #0c5460; margin-top: 0;'>Action Required</h4>
                            <p>Please review the customer's business documentation and approve or reject their account in the admin panel.</p>
                            <p><strong>Admin Panel:</strong> Soit-iis.mandela.ac.za/grp-03-11</p>
                        </div>

                        <p>Please process this registration within 24-48 hours.</p>
                        
                        <p>Best regards,<br>
                        System Notification</p>
                    </div>";

                _logger.LogInformation("Attempting to send admin notification email to {AdminCount} admin users", adminUsers.Count);

                // Send to all admin users
                foreach (var adminUser in adminUsers)
                {
                    if (!string.IsNullOrEmpty(adminUser.Email))
                    {
                        _logger.LogInformation("Sending admin notification to: {AdminEmail}", adminUser.Email);
                        await _emailSender.SendEmailAsync(adminUser.Email, subject, message);
                        _logger.LogInformation("Successfully sent admin notification to: {AdminEmail}", adminUser.Email);
                    }
                    else
                    {
                        _logger.LogWarning("Admin user {AdminId} has no email address", adminUser.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the actual error details
                _logger.LogError(ex, "Failed to send admin notification email for new customer {Email}. Error: {ErrorMessage}", user.Email, ex.Message);

                // For debugging - you can remove this in production
                TempData["EmailError"] = $"Failed to send admin notification: {ex.Message}";
            }
        }
    }
}