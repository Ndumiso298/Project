// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Models;
using Project.Utilities;
using Project.Utilities.Enums;

namespace Project.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "First name is required")]
            [DataType(DataType.Text)]
            [Display(Name = "First name(CustomersController)")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required")]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            //[Required(ErrorMessage = "Date of Birth is required")]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime? DOB { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [Phone(ErrorMessage = "Please enter a valid phone number")]
            [Display(Name = "Cell/Tel Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            // Business Information (Conditional - for Customers)
            [Display(Name = "Business Name")]
            [StringLength(200, ErrorMessage = "Business Name cannot exceed 200 characters.")]
            public string? BusinessName { get; set; }

            [Display(Name = "Business Type")]
            public BusinessType? BusinessType { get; set; }

            [Display(Name = "Registration Number")]
            [StringLength(30, ErrorMessage = "Registration number cannot exceed 30 characters.")]
            public string? RegistrationNumber { get; set; }

            [Display(Name = "VAT Number")]
            [StringLength(20, ErrorMessage = "VAT number cannot exceed 20 characters.")]
            [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "VAT number must be 10 digits.")]
            public string? VATNumber { get; set; }

            // Employee Information (Conditional - for Employees)
            [Display(Name = "Employee Number")]
            [StringLength(20, ErrorMessage = "Employee Number cannot exceed 20 characters.")]
            public string? EmployeeNumber { get; set; }

            // Enhanced role list to exclude Customer role for non-admin registrations
            [ValidateNever]
            public IEnumerable<SelectListItem> FilteredRoleList { get; set; } = new List<SelectListItem>();
            [Display(Name = "Business Proof Document")]
            public IFormFile BusinessDocument { get; set; }

            [Display(Name = "User Role")]
            public string? UserRole { get; set; } = string.Empty;

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> BusinessTypeOptions { get; set; } = Enum.GetValues<BusinessType>()
            .Cast<BusinessType>()
            .Select(bt => new SelectListItem { Value = bt.ToString(), Text = bt.ToString().Replace("_", " ") })
            .OrderBy(x => x.Text)
            .ToList();

            [ValidateNever]
            public IEnumerable<SelectListItem> ProvinceOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> CityOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> SuburbOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> LocationOptions { get; set; } = new List<SelectListItem>();

            public Location? Location { get; set; } = new Location();
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            // Check and create roles if they do not exist
            if ((!_roleManager.RoleExistsAsync(SD.AdminRole).GetAwaiter().GetResult()))

            {
                await _roleManager.CreateAsync(new IdentityRole(SD.AdminRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.CustomerSupportRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.StockControllerRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.FaultTechnicianRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.MaintenanceTechnicianRole));
                await _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole));
            }

            Input = new InputModel();
            Input.RoleList = _roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem { Text = r.Name, Value = r.Name })
                .ToList();
            Input.BusinessTypeOptions = Input.BusinessTypeOptions;
            PopulateLocationOptions();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if (Input.Location == null)
                {
                    Input.Location = new Location();
                }
                var user = CreateUser();
                user.UserName = Input.Email;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.DOB = Input.DOB;
                user.Email = Input.Email;
                user.PhoneNumber = Input.PhoneNumber;

                // Determine role
                string roleToAssign = string.IsNullOrEmpty(Input.UserRole) ? SD.CustomerRole : Input.UserRole;

                // Customer-specific: require business document
                if (roleToAssign == SD.CustomerRole)
                {
                    if (Input.BusinessDocument == null)
                    {
                        ModelState.AddModelError("Input.BusinessDocument", "Business document is required for Customer accounts.");
                        Input.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                        {
                            Text = r.Name,
                            Value = r.Name
                        });
                        return Page();
                    }

                    var uploadsFolder = Path.Combine("wwwroot", "uploads", "businessDocs");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Input.BusinessDocument.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Input.BusinessDocument.CopyToAsync(stream);
                    }

                    user.BusinessDocumentPath = "/uploads/businessDocs/" + fileName;

                    // Customer requires admin approval and email confirmation
                    user.IsDeleted = false;
                    user.EmailConfirmed = false;
                }
                else
                {
                    // Other roles approved immediately
                    user.IsDeleted = false;
                    user.EmailConfirmed = true;
                }


                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Assign role
                    if (!string.IsNullOrEmpty(Input.UserRole))
                    {
                        await _userManager.AddToRoleAsync(user, Input.UserRole);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.CustomerRole);
                    }

                    // Enhanced Customer/Employee record creation
                    if (roleToAssign == SD.CustomerRole)
                    {
                        // Create Customer record
                        var customer = new Customer
                        {
                            UserId = user.Id,
                            BusinessName = !string.IsNullOrEmpty(Input.BusinessName)
                                ? Input.BusinessName
                                : $"{user.FirstName} {user.LastName}",
                            BusinessType = Input.BusinessType ?? BusinessType.Shebeen, // Default value
                            RegistrationNumber = Input.RegistrationNumber,
                            VATNumber = Input.VATNumber,
                            BusinessEmail = user.Email,
                            BusinessPhoneNumber = user.PhoneNumber,
                            StreetAddress = Input.Location.StreetAddress,
                            Suburb = Input.Location.Suburb,
                            City = Input.Location.City,
                            Province = Input.Location.Province,
                            PostalCode = Input.Location.PostalCode,
                            BusinessDocumentPath = user.BusinessDocumentPath,
                            AccountStatus = AccountStatus.PendingApproval,
                            CustomerSince = DateTime.UtcNow
                        };
                        _db.Customers.Add(customer);
                    }
                    else
                    {
                        // Create Employee record
                        var employee = new Employee
                        {
                            UserId = user.Id,
                            EmployeeNumber = !string.IsNullOrEmpty(Input.EmployeeNumber)
                                ? Input.EmployeeNumber
                                : GenerateEmployeeNumber(),
                            EmployeeType = MapRoleToEmployeeType(roleToAssign),
                            WorkEmail = user.Email,
                            WorkPhone = user.PhoneNumber,
                            AvailabilityStatus = AvailabilityStatus.Available
                        };
                        _db.Employees.Add(employee);
                    }

                    await _db.SaveChangesAsync();


                    if (roleToAssign == SD.CustomerRole)
                    {
                        // Generate email confirmation
                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        // Redirect to Pending Approval page
                        return RedirectToPage("/Account/PendingApproval");
                    }
                    else
                    {
                        // Other roles login immediately
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            // If we got this far, something failed, redisplay form
            Input = new InputModel();
            Input.RoleList = _roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();


            PopulateLocationOptions();
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch            
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        private void PopulateLocationOptions()
        {
            var locations = _db.Locations.AsNoTracking().ToList();

            Input.ProvinceOptions = locations
                .Select(l => l.Province)
                .Distinct()
                .OrderBy(p => p)
                .Select(p => new SelectListItem { Value = p, Text = p })
                .ToList();

            Input.CityOptions = locations
                .Select(l => l.City)
                .Distinct()
                .OrderBy(c => c)
                .Select(c => new SelectListItem { Value = c, Text = c })
                .ToList();

            Input.SuburbOptions = locations
                .Select(l => l.Suburb)
                .Distinct()
                .OrderBy(s => s)
                .Select(s => new SelectListItem { Value = s, Text = s })
                .ToList();

            Input.LocationOptions = locations
                .OrderBy(l => l.City)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.StreetAddress}, {l.Suburb}, {l.City}, {l.Province} ({l.PostalCode})"
                })
                .ToList();
        }

        private string GenerateEmployeeNumber()
        {
            // Simple implementation - you might want a more robust one
            return $"EMP{DateTime.Now:yyMMddHHmmss}";
        }

        private EmployeeType MapRoleToEmployeeType(string role)
        {
            return role switch
            {
                SD.AdminRole => EmployeeType.Administrator,
                SD.CustomerSupportRole => EmployeeType.CustomerSupport,
                SD.StockControllerRole => EmployeeType.StockController,
                SD.FaultTechnicianRole => EmployeeType.FaultTechnician,
                SD.MaintenanceTechnicianRole => EmployeeType.MaintenanceTechnician,
                _ => EmployeeType.CustomerSupport // Default fallback
            };
        }

        public IEnumerable<ValidationResult> ValidateDOB(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Input.DOB.HasValue)
            {
                var minDate = new DateTime(1900, 1, 1);
                var maxDate = new DateTime(2007, 1, 1);

                if (Input.DOB.Value < minDate || Input.DOB.Value > maxDate)
                {
                    results.Add(new ValidationResult("Date of birth must be between 01/01/1900 and 01/01/2007.", new[] { nameof(Input.DOB) }));
                }
            }

            return results;
        }
    }
}
