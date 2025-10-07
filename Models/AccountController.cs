using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;
using Project.Utility;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterVM
            {
                RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList()
            };
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                model.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();
                return View(model);
            }

            // Create ApplicationUser with common fields only
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                Province = model.State,
                PostalCode = model.PostalCode,
                CellNumber = model.CellNumber,
                IsApproved = true, // default for employees
                Status = "Approved" // default for employees
            };

            string roleToAssign = string.IsNullOrEmpty(model.Role) ? SD.CustomerRole : model.Role;

            // Customers require approval and document upload
            if (roleToAssign == SD.CustomerRole)
            {
                user.IsApproved = false;
                user.Status = "Pending";

                if (model.BusinessDocument == null)
                {
                    ModelState.AddModelError("BusinessDocument", "Business document is required.");
                    model.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Name
                    }).ToList();
                    return View(model);
                }
            }

            // Create user in Identity
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                model.RoleList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();
                return View(model);
            }

            // Assign role
            await _userManager.AddToRoleAsync(user, roleToAssign);

            // Add role-specific data to normalized tables
            if (roleToAssign == SD.CustomerRole)
            {
                // Upload and save document
                var uploadsFolder = Path.Combine("wwwroot", "uploads", "businessDocs");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + System.IO.Path.GetExtension(model.BusinessDocument.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.BusinessDocument.CopyToAsync(stream);
                }

                var customer = new Customer
                {
                    ApplicationUserId = user.Id,
                    CustomerNumber = "CUST-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                    BusinessDocumentPath = "/uploads/businessDocs/" + fileName,
                    BusinessDocumentData = await System.IO.File.ReadAllBytesAsync(filePath)
                };
                _db.tblCustomerS.Add(customer);
            }
            else
            {
                var employee = new Employee
                {
                    UserId = user.Id,
                    EmployeeNumber = "EMP-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss")
                };
                _db.tblEmployees.Add(employee);
            }

            await _db.SaveChangesAsync();

            // Redirect based on role
            if (roleToAssign == SD.CustomerRole)
                return RedirectToAction("PendingApproval", "Account");

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }
    }
}
