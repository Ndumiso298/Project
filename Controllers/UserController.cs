using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Models.ViewModels;
using System.Security.Claims;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // List all users
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

        // Lock/Unlock user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockUnlock(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
                user.LockoutEnd = DateTime.Now; // unlock
            else
                user.LockoutEnd = DateTime.Now.AddYears(1000); // lock

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Delete user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            _db.AppUser.Remove(user);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Manage user roles - GET
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

        // Manage user roles - POST
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

            return RedirectToAction(nameof(Index));
        }

        // Manage user claims - GET
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

        // Manage user claims - POST
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

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound();

            user.IsApproved = true;
            user.Status = "Approved";
            user.RejectionReason = null; 

            _db.SaveChanges();
            TempData["Success"] = $"User {user.FirstName} {user.LastName} approved successfully.";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

           

            user.IsApproved = false;
            user.Status = "Declined";
            user.RejectionReason = "Your account was declined due to failing verification requirements.";
            user.DeclinedAt = DateTime.UtcNow;  

            _db.SaveChanges();

            TempData["Success"] = $"User {user.FirstName} declined.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ApproveDeclineUser(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound();

            return View(user);
        }
      

    }
}

