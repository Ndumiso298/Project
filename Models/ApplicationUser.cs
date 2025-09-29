using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;

        // Employee relationship
        [Display(Name = "Employee ID")]
        public int? EmployeeId { get; set; }

        [ValidateNever]
        [Display(Name = "Employee Profile")]
        public virtual Employee? Employee { get; set; }

        // Customer relationship
        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; }

        [ValidateNever]
        [Display(Name = "Customer Profile")]
        public virtual Customer? Customer { get; set; }

        // Personal Information
        [PersonalData]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [PersonalData]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Birth")]
        [Range(typeof(DateTime), "01/01/1900", "01/01/2007", ErrorMessage = "Date of birth must be between 01/01/1900 and 01/01/2007.")]
        public DateTime? DOB { get; set; }

        // Location (for employee/customer physical location tracking)
        [Display(Name = "Primary Location")]
        [Required(ErrorMessage = "Primary location is required for system operations.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid location.")]
        public int? LocationId { get; set; }

        [ValidateNever]
        [Display(Name = "Location")]
        public virtual Location? PrimaryLocation { get; set; } = null!;

        // Profile Management
        [Display(Name = "Profile Picture URL")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(500, ErrorMessage = "URL cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL starting with http:// or https://")]
        public string? ProfilePictureUrl { get; set; }

        // User Status Management
        [Display(Name = "Account Status")]
        public AccountStatus AccountStatus { get; set; } = AccountStatus.PendingApproval;

        [Display(Name = "Email Verified")]
        public bool IsEmailVerified { get; set; } = false;

        [Display(Name = "Phone Verified")]
        public bool IsPhoneVerified { get; set; } = false;

        // Audit Fields
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        [StringLength(450, ErrorMessage = "Created by cannot exceed 450 characters.")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        [StringLength(450, ErrorMessage = "Updated by cannot exceed 450 characters.")]
        public string? UpdatedBy { get; set; }

        [Display(Name = "Last Login")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastLoginDate { get; set; }

        [Display(Name = "Last Password Change")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastPasswordChangeDate { get; set; }

        [Display(Name = "Failed Login Attempts")]
        [Range(0, 10, ErrorMessage = "Failed login attempts must be between 0 and 10.")]
        public int FailedLoginAttempts { get; set; } = 0;

        [Display(Name = "Lockout End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LockoutEndDate { get; set; }
    }
}
