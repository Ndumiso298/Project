using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public virtual ApplicationUser? UserAccount { get; set; } = null!;

        public int? CustomerLiaisonId { get; set; }

        [ForeignKey(nameof(CustomerLiaisonId))]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; } = null!;

        [Required(ErrorMessage = "Trading Name is required.")]
        [StringLength(200, ErrorMessage = "Trading Name cannot exceed 200 characters.")]
        [Display(Name = "Trading Name")]
        public string TradingName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Business Type is required.")]
        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }

        [Required(ErrorMessage = "Business Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(200, ErrorMessage = "Business Email cannot exceed 200 characters.")]
        [Display(Name = "Business Email")]
        public string BusinessEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Business Phone Number is required.")]
        [StringLength(20, ErrorMessage = "Business Phone Number cannot exceed 20 characters.")]
        [Display(Name = "Business Phone")]
        public string BusinessPhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address Line 1 is required.")]
        [StringLength(200, ErrorMessage = "Address Line 1 cannot exceed 200 characters.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Address Line 2 cannot exceed 200 characters.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(200, ErrorMessage = "City cannot exceed 200 characters.")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(200, ErrorMessage = "Province cannot exceed 200 characters.")]
        [Display(Name = "Province")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        [ValidateNever]
        [Display(Name = "Trading Location")]
        public virtual Location TradingLocation { get; set; } = null!;

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        [ValidateNever]
        [Display(Name = "FridgeAllocation History")]
        public virtual ICollection<FridgeAllocation> AllocationHistory { get; set; } = new List<FridgeAllocation>();

        [Display(Name = "Reported Faults")]
        [ValidateNever]
        public virtual ICollection<FaultRecord>? ReportedFaults { get; set; } = new List<FaultRecord>();

        [Display(Name = "Fridge Requests")]
        [ValidateNever]
        public virtual ICollection<ReplacementRequest>? FridgeRequests { get; set; } = new List<ReplacementRequest>();

        [Display(Name = "Maintenance Schedules")]
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> MaintenanceSchedules { get; set; } = new List<MaintenanceVisit>();
    }
}
