using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Project.Models;
using Project.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager,
                          ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(Input.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            var appUser = user as ApplicationUser;

            // Only Customers require admin approval
            var isCustomer = await _userManager.IsInRoleAsync(user, SD.CustomerRole);

            if (isCustomer && appUser != null)
            {
                if (!appUser.IsApproved)
                {
                    if (!string.IsNullOrEmpty(appUser.RejectionReason))
                    {
                        // Account declined
                        ModelState.AddModelError(string.Empty, $"Your account was declined: {appUser.RejectionReason}");
                    }
                    else
                    {
                        // Pending approval
                        ModelState.AddModelError(string.Empty, "Your account is pending admin approval.");
                    }
                    return Page();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");

                // Redirect based on role
                if (await _userManager.IsInRoleAsync(user, SD.AdminRole))
                    return RedirectToAction("Dashboard", "Admin");
                if (await _userManager.IsInRoleAsync(user, SD.CustomerRole))
                    return RedirectToAction("Index", "Customer");
                if (await _userManager.IsInRoleAsync(user, SD.CustomerSupport))
                    return RedirectToAction("Dashboard", "CustomerSupport");
                if (await _userManager.IsInRoleAsync(user, SD.StockController))
                    return RedirectToAction("Dashboard", "StockController");
                if (await _userManager.IsInRoleAsync(user, SD.FaultTechnician))
                    return RedirectToAction("Dashboard", "FaultTechnician");
                if (await _userManager.IsInRoleAsync(user, SD.MaintenanceTechnician))
                    return RedirectToAction("Dashbord", "AllocatedFridges");

                return LocalRedirect(returnUrl);
            }

            if (result.RequiresTwoFactor)
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
