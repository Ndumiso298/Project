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

            [Required(ErrorMessage = "Date of Birth is required")]
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

            [Display(Name = "User Role")]
            public string? UserRole { get; set; } = string.Empty;

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> ProvinceOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> CityOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> SuburbOptions { get; set; } = new List<SelectListItem>();

            [ValidateNever]
            public IEnumerable<SelectListItem> LocationOptions { get; set; } = new List<SelectListItem>();

            public Location Location { get; set; } = new Location();
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
                user.PrimaryLocation = new Location();

                // Safe way to assign with null checks
            if (Input.Location != null)
            {
                user.PrimaryLocation.AddressLine1 = Input.Location.AddressLine1 ?? string.Empty;
                user.PrimaryLocation.AddressLine2 = Input.Location.AddressLine2 ?? string.Empty;
                user.PrimaryLocation.City = Input.Location.City ?? string.Empty;
                user.PrimaryLocation.Province = Input.Location.Province ?? string.Empty;
                user.PrimaryLocation.PostalCode = Input.Location.PostalCode ?? string.Empty;
                }
                else
                {
                    // Handle the case where Location is null
                    user.PrimaryLocation.CreatedAt = DateTime.UtcNow;
                    user.PrimaryLocation.IsActive = true;
                }


                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    if (!String.IsNullOrEmpty(Input.UserRole))
                    {
                        await _userManager.AddToRoleAsync(user, Input.UserRole);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.CustomerRole);
                    }

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

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
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
                    Text = $"{l.AddressLine1}, {l.Suburb}, {l.City}, {l.Province} ({l.PostalCode})"
                })
                .ToList();
        }
    }
}
