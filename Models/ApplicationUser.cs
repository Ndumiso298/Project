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
        public ApplicationUser()
        {
            CreatedAt = DateTime.UtcNow;
            SecurityStamp = Guid.NewGuid().ToString();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

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
        public string FullName => $"{FirstName} {LastName}".Trim();

        [PersonalData]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        //[Required(ErrorMessage = "Date of birth is required")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Profile Picture URL")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(500, ErrorMessage = "URL cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL starting with http:// or https://")]
        public string? ProfilePictureUrl { get; set; }

        public byte[]? ProfilePictureData { get; set; }
        public string? ProfilePictureContentType { get; set; }

        // User Account Management
        [NotMapped]
        [Display(Name = "Account Status")]
        public bool IsAccountActive => !IsDeleted && !LockoutEnabled
            && (LockoutEnd == null || LockoutEnd < DateTimeOffset.UtcNow)
            && EmailConfirmed;

        [Display(Name = "Last Login")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastLoginDate { get; set; }

        [Display(Name = "Last Password Change")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? LastPasswordChangeDate { get; set; }

        // Audit Fields
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // Relationships
        [NotMapped]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;

        [ValidateNever]
        [Display(Name = "Employee Profile")]
        public virtual Employee? Employee { get; set; }

        [ValidateNever]
        [Display(Name = "Customer Profile")]
        public virtual Customer? Customer { get; set; }

        public bool IsApproved { get; set; } = false;
        public string? RejectionReason { get; set; }
        public string? BusinessDocumentPath { get; set; }

        //[NotMapped]
        //public string RoleId { get; set; }
        //[NotMapped]
        //public string Role { get; set; }
        //[NotMapped]
        //public string UserClaim { get; set; }
        //public string Status { get; internal set; }
        //public DateTime? DeclinedAt { get; set; }

        ////[Required(ErrorMessage = "Location is required.")]
        //[Display(Name = "Primary Location")]
        //public int? LocationId { get; set; }

        //public virtual Location? PrimraryLocation { get; set; }

        [ValidateNever]
        [Display(Name = "Reported Faults")]
        public virtual ICollection<FaultRecord> ReportedFaults { get; set; } = new List<FaultRecord>();
    }
}