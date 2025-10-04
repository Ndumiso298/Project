using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Project.Utilities.Enums;
using Project.Models.ViewModels;
using Project.Utilities;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        // ===== IDENTITY & BASIC INFO =====
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public virtual ApplicationUser UserAccount { get; set; } = null!;

        [Required(ErrorMessage = "Employee Number is required.")]
        [StringLength(20, ErrorMessage = "Employee Number cannot exceed 20 characters.")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; } = string.Empty;

        // ===== EMPLOYEE DETAILS =====
        [Required(ErrorMessage = "Employee Type is required.")]
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Required(ErrorMessage = "Availability Status is required.")]
        [Display(Name = "Availability Status")]
        public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Available;

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // ===== CONTACT INFORMATION =====
        [Display(Name = "Work Phone")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(15, ErrorMessage = "Work phone cannot exceed 15 characters.")]
        public string? WorkPhone { get; set; }

        [Display(Name = "Work Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Work email cannot exceed 100 characters.")]
        public string? WorkEmail { get; set; }

        // ===== LOCATION INFORMATION (Optional) =====
        [Display(Name = "Work Address")]
        public int? WorkLocationId { get; set; }

        [ForeignKey(nameof(WorkLocationId))]
        [ValidateNever]
        public virtual Location? WorkLocation { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{UserAccount?.FirstName} {UserAccount?.LastName}".Trim();

        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => UserAccount?.IsAccountActive == true && AvailabilityStatus == AvailabilityStatus.Available;

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Customer> ManagedCustomers { get; set; } = new List<Customer>();

        [InverseProperty(nameof(FridgeAllocation.AllocatedBy))]
        public virtual ICollection<FridgeAllocation> AllocatedFridges { get; set; } = new List<FridgeAllocation>();

        // Maintenance tech navigations
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        [ValidateNever]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        //[ValidateNever]
        //[InverseProperty(nameof(FaultRecord.ReportedBy))]
        //public virtual ICollection<FaultRecord> ReportedFaults { get; set; } = new();

        // FaultRecord tech navigations
        [InverseProperty(nameof(FaultRecord.AssignedTechnician))]
        public virtual ICollection<FaultRecord> AssignedFaults { get; set; } = new List<FaultRecord>();

        // Stock controller navigations
        [ValidateNever]
        public virtual ICollection<Fridge> ManagedFridges { get; set; } = new List<Fridge>();

        [InverseProperty(nameof(FridgeAllocation.ProcessedBy))]
        public virtual ICollection<FridgeAllocation> ProcessedAllocations { get; set; } = new List<FridgeAllocation>();

        [InverseProperty(nameof(PurchaseRequest.RequestedBy))]
        public virtual ICollection<PurchaseRequest> RequestedPurchaseRequests { get; set; } = new List<PurchaseRequest>();

        [InverseProperty(nameof(PurchaseRequest.ApprovedBy))]
        public virtual ICollection<PurchaseRequest> ApprovedPurchaseRequests { get; set; } = new List<PurchaseRequest>();
    }
}

