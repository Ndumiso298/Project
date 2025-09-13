using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Security.Claims;

namespace Project.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            return View(user);
        }
    }
}
