using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        // Link to Identity user (employees must have accounts)
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public virtual ApplicationUser UserAccount { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{UserAccount?.FirstName} {UserAccount?.LastName}";

        [Required(ErrorMessage = "Employee Number is required.")]
        [StringLength(50, ErrorMessage = "Employee Number cannot exceed 50 characters.")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Display(Name = "Availability Status")]
        public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Available;

        [Required]
        public EmployeeType EmployeeType { get; set; }

        // Metadata
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;

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

        [NotMapped]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

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

