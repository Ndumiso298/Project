using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;

        public int? CustomerId { get; set; }
        [ValidateNever]
        public virtual Customer? Customer { get; set; }

        public int? EmployeeId { get; set; }
        [ValidateNever]
        public virtual Employee? Employee { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [PersonalData]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; } // Date of Birth 

        [Required]
        public int LocationId { get; set; }

        [ValidateNever]
        public virtual Location PrimaryLocation { get; set; } = null!;

        [Display(Name = "Profile Picture URL")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(2048, ErrorMessage = "URL cannot exceed 2048 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ProfilePictureUrl { get; set; }
    }
}
