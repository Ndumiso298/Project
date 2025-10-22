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

            [Required]
            [StringLength(100, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string PostalCode { get; set; }
            public string CellNumber { get; set; }

            [Display(Name = "Business Proof Document")]
            public IFormFile? BusinessDocument { get; set; }

            [ValidateNever]
            public string Role { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            
            await EnsureRolesCreated();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            Input = new InputModel
            {
                RoleList = _roleManager.Roles
                    .Where(r => r.Name != SD.CustomerRole) // Exclude Customer role from dropdown
                    .Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Name
                    }).ToList()
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

         
            string roleToAssign = string.IsNullOrEmpty(Input.Role) ? SD.CustomerRole : Input.Role;

       
            if (!string.IsNullOrEmpty(Input.Role))
            {
                var roleExists = await _roleManager.RoleExistsAsync(Input.Role);
                if (!roleExists)
                {
                    ModelState.AddModelError("Input.Role", $"The role '{Input.Role}' does not exist.");
                    await RepopulateRoleList();
                    return Page();
                }
            }

            if (roleToAssign == SD.CustomerRole)
            {
                if (Input.BusinessDocument == null)
                {
                    ModelState.AddModelError("Input.BusinessDocument", "Business document is required for Customer accounts.");
                    await RepopulateRoleList();
                    return Page();
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    await RepopulateRoleList();
                    return Page();
                }
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
                    await RepopulateRoleList();
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
                
                user.IsApproved = true;
                user.Status = "Approved";
                user.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    await RepopulateRoleList();
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

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
        }

        private async Task EnsureRolesCreated()
        {
            
            var rolesToCreate = new[]
            {
                SD.AdminRole,
                SD.CustomerRole,
                SD.CustomerSupport,
                SD.StockController,
                SD.FaultTechnician,
                SD.MaintenanceTechnician
            };

            foreach (var roleName in rolesToCreate)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                    _logger.LogInformation("Created role: {RoleName}", roleName);
                }
            }
        }

        private async Task RepopulateRoleList()
        {
            Input.RoleList = _roleManager.Roles
                .Where(r => r.Name != SD.CustomerRole) // Exclude Customer role from dropdown
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();
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
    }
}