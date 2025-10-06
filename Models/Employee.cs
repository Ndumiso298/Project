using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        // Link to Identity user (employees must have accounts)
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual ApplicationUser UserAccount { get; set; } = null!;

        [Required(ErrorMessage = "Employee Number is required.")]
        [StringLength(50, ErrorMessage = "Employee Number cannot exceed 50 characters.")]
        [Display(Name = "Employee Number*")]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Display(Name = "Availability Status")]
        public string? AvailabilityStatus { get; set; }

        [Required]
        [MaxLength(21)]
        public string EmployeeType { get; set; }
        // Metadata
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Account Status")]
        public bool IsActive { get; set; } = true;

        //[Display(Name = "Deleted")]
        //public bool IsDeleted { get; set; } = false;
    }
}
