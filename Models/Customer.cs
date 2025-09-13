namespace Project.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Net;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    namespace FridgeManagementSystem.Models
    {
        public class Customer
        {
            [Key]
            public int Id { get; set; }

            //Required link to Identity user(customers must have accounts)
            [Required]
            public string UserId { get; set; } = string.Empty;

            [ForeignKey("UserId")]
            [ValidateNever]
            public virtual ApplicationUser UserAccount { get; set; } = null!;

            //Link to Customer Liaison(from Subsystem A: Customer Management)
            [Required]
            public int? CustomerLiaisonId { get; set; }

            [Display(Name = "Assigned Customer Liaison*")]
            [ForeignKey("CustomerLiaisonId")]
            [ValidateNever]
            public virtual CustomerSupport? CustomerLiaison { get; set; } = null!;

            // Business Information
            [Required(ErrorMessage = "Business Name is required.")]
            [StringLength(200, ErrorMessage = "Business Name cannot exceed 200 characters.")]
            [Display(Name = "Business Name*")]
            public string BusinessName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Business Type is required.")]
            [Display(Name = "Business Type*")]
            public string BusinessType { get; set; } // Using enum instead of string

            [Required(ErrorMessage = "Business Registration Number is required.")]
            [StringLength(50, ErrorMessage = "Business Registration Number cannot exceed 50 characters.")]
            [Display(Name = "Business Registration Number*")]
            public string BusinessRegistrationNumber { get; set; } = string.Empty;

            [StringLength(50, ErrorMessage = "VAT Number cannot exceed 50 characters.")]
            [Display(Name = "VAT Number")]
            public string? VATNumber { get; set; }

            // Contact Information
            [Required(ErrorMessage = "Business Email is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            [StringLength(200, ErrorMessage = "Business Email cannot exceed 200 characters.")]
            [Display(Name = "Business Email*")]
            public string BusinessEmail { get; set; } = string.Empty;

            [Required(ErrorMessage = "Business Phone Number is required.")]
            [StringLength(20, ErrorMessage = "Business Phone Number cannot exceed 20 characters.")]
            [Display(Name = "Business Phone*")]
            public string BusinessPhoneNumber { get; set; } = string.Empty;

            // Business address (using Location entity for consistency)
            [Required(ErrorMessage = "Business Address Id is required.")]
            [Display(Name = "Business Address*")]
            public int BusinessAddressId { get; set; }

            [ForeignKey("BusinessAddressId")]
            [ValidateNever]
            public virtual Location BusinessAddress { get; set; } = null!;

            // Metadata
            [Display(Name = "Created At")]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            [Display(Name = "Updated At")]
            public DateTime? UpdatedAt { get; set; }

            [Display(Name = "Account Status")]
            public bool IsActive { get; set; } = true;

            // Navigation properties
            [Display(Name = "Fridge Allocations")]
            [ValidateNever]
            public virtual ICollection<FridgeAllocation> FridgeAllocations { get; set; } = new List<FridgeAllocation>();

            [Display(Name = "Fault Reports")]
            [ValidateNever]
            public virtual ICollection<FridgeFault> FaultReports { get; set; } = new List<FridgeFault>();

            [Display(Name = "Fridge Requests")]
            [ValidateNever]
            public virtual ICollection<FridgeRequest> FridgeRequests { get; set; } = new List<FridgeRequest>();

            [Display(Name = "Maintenance Schedules")]
            [ValidateNever]
            public virtual ICollection<FridgeMaintenance> MaintenanceSchedules { get; set; } = new List<FridgeMaintenance>();
        }
    }
}
