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
using Microsoft.Extensions.Logging;
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

        public RegisterModel(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IUserStore<ApplicationUser> userStore,
            IEmailSender emailSender)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
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

            public Location Location { get; set; } = new();
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

            Input = new InputModel(); // ensure it'CustomersController not null
            Input.RoleList = _roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
       }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.UserName = Input.Email;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.DOB = Input.DOB;
                user.Email = Input.Email;
                user.PhoneNumber = Input.PhoneNumber;
                user.PrimaryLocation.AddressLine1 = Input.Location.AddressLine1;
                user.PrimaryLocation.AddressLine2 = Input.Location.AddressLine2;
                user.PrimaryLocation.City = Input.Location.City;
                user.PrimaryLocation.Province = Input.Location.Province;
                user.PrimaryLocation.PostalCode = Input.Location.PostalCode;


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
    }
}
