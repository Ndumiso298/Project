using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
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

        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
        }
        public  IActionResult CustomerList()
        {
            var customers = _db.tblCustomer
                 .Include(c => c.ApplicationUser)
                 .Where(c => !c.ApplicationUser.IsDeleted)
                 .ToList();
            return View(customers);
        }
        public IActionResult EmployeeList()
        {
            var employees = _db.tblEmployee
                .Include(e => e.ApplicationUser)
                .Where(e => !e.ApplicationUser.IsDeleted)
                .ToList();
            return View(employees);
        }


        public async Task<IActionResult> Index()
        {
            var userList = await _db.AppUser
                .Where(u => !u.IsDeleted)
                .ToListAsync();

            var userVMs = new List<UserVM>();

            foreach (var user in userList)
            {
                var userRoles = await _userManager.GetRolesAsync(user) as List<string>;
                var role = string.Join(",", userRoles);

                var userVM = new UserVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = role,
                    IsApproved = user.IsApproved,
                    Status = user.Status,
                    RejectionReason = user.RejectionReason,
                    LockoutEnd = user.LockoutEnd?.DateTime,

                };

                if (userVM.IsCustomer)
                {
                    var customer = await _db.tblCustomer
                        .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);
                    if (customer != null)
                    {
                        userVM.CustomerNumber = customer.CustomerNumber;
                        userVM.BusinessDocumentPath = customer.BusinessDocumentPath;
                    }
                }

                if (userVM.IsEmployee)
                {
                    var employee = await _db.tblEmployee
                        .FirstOrDefaultAsync(e => e.ApplicationUserId == user.Id);
                    if (employee != null)
                    {
                        userVM.EmployeeNumber = employee.EmployeeNumber;
                    }
                }

                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockUnlock(string userId)
        {
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
                user.LockoutEnd = DateTime.Now; 
            else
                user.LockoutEnd = DateTime.Now.AddYears(1000); 

            _db.SaveChanges();
            TempData[SD.Success] = $"Operation Successfully.";
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
            TempData[SD.Error] = $"User {user.FirstName} Delete.";

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
            TempData[SD.Success] = $"User {user.FirstName} {user.LastName} approved successfully.";

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





    }
}

