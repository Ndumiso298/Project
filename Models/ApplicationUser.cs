using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [Display(Name = "User Role")]
        public string UserRole { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; } = string.Empty;

        [PersonalData]
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [PersonalData]
        [Display(Name = "Primary Location")]
        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        [ValidateNever]
        public virtual Location? Location { get; set; }

        [InverseProperty(nameof(Customer.UserAccount))]
        public virtual Customer? CustomerProfile { get; set; }

        [InverseProperty(nameof(Employee.UserAccount))]
        public virtual Employee? EmployeeProfile { get; set; }

        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string LastName { get; set; }
        //public string? StreetAddress { get; set; }
        //public string? City { get; set; }
        //public string? State { get; set; }
        //public string? PostalCode { get; set; }
        //public string? CellNumber { get; set; }
    }
}
