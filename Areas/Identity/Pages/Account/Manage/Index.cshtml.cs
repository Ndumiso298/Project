// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "First name is required.")]
            [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Last name is required.")]
            [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Date of Birth is required.")]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime? DOB { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [Phone(ErrorMessage = "Please enter a valid phone number.")]
            [Display(Name = "Cell/Tel Number")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Display(Name = "User Role")]
            public string? UserRole { get; set; } = string.Empty;

            //[Required(ErrorMessage = "Location is required.")]
            //[Display(Name = "Primary Location")]
            //public int? LocationId { get; set; }

            [BindProperty]
            [Display(Name = "Profile Picture")]
            [DataType(DataType.Upload)]
            public IFormFile? ProfilePictureFile { get; set; }

            [Display(Name = "Profile Picture URL")]
            [DataType(DataType.ImageUrl)]
            [MaxLength(2048, ErrorMessage = "URL cannot exceed 2048 characters.")]
            [Url(ErrorMessage = "Please enter a valid URL.")]
            public string? ProfilePictureUrl { get; set; }

            // For dropdown binding
            [ValidateNever]
            public IEnumerable<SelectListItem> LocationOptions { get; set; } = new List<SelectListItem>();
        }


        private async Task LoadAsync(ApplicationUser user)
        {
            Username = await _userManager.GetUserNameAsync(user);

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                PhoneNumber = user.PhoneNumber,
                UserRole = user.UserRole,
                ProfilePictureUrl = user.ProfilePictureUrl,
                LocationOptions = _db.Locations
                    .OrderBy(l => l.City)
                    .Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = $"{l.City}, {l.Suburb}, {l.Province}"
                    }).ToList()
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // --- Start: Handle File Upload ---
            if (Input.ProfilePictureFile != null && Input.ProfilePictureFile.Length > 0)
            {
                    // Validate file size (e.g., 5MB limit)
                if (Input.ProfilePictureFile.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Input.ProfilePictureFile", "The file is too large. Maximum size is 5MB.");
                    return Page();
                }

                // Validate file extension
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(Input.ProfilePictureFile.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("Input.ProfilePictureFile", "Invalid file type. Allowed types: JPG, PNG, GIF.");
                    return Page();
                }

                // Option 1: Convert to byte array and store in the database
                using (var memoryStream = new MemoryStream())
                {
                    await Input.ProfilePictureFile.CopyToAsync(memoryStream);
                    // Upload the file if less than 2 MB (example additional check)
                    if (memoryStream.Length < 2097152)
                    {
                        user.ProfilePictureData = memoryStream.ToArray(); // Save byte array to user entity
                        user.ProfilePictureContentType = Input.ProfilePictureFile.ContentType;
                        // Optionally clear the URL if storing in database
                        user.ProfilePictureUrl = null;
                    }
                    else
                    {
                        ModelState.AddModelError("Input.ProfilePictureFile", "The file is too large.");
                    }
                }

                // Option 2: Save as a physical file to wwwroot
                /*
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "avatars");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.ProfilePictureFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Directory.CreateDirectory(uploadsFolder); // Ensure directory exists
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ProfilePictureFile.CopyToAsync(fileStream);
                }
                user.ProfilePictureUrl = "/uploads/avatars/" + uniqueFileName; // Save URL to user entity
                */
            }
            // --- End: Handle File Upload ---

            // ... your existing code to update other user properties (FirstName, PhoneNumber, etc.)

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            // Update other user properties
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.DOB = Input.DOB;
            user.PhoneNumber = Input.PhoneNumber;
            //user.LocationId = Input.LocationId;


            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
