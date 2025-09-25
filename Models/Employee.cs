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

        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual ApplicationUser UserAccount { get; set; } = null!;

        [Required(ErrorMessage = "Employee Number is required.")]
        [StringLength(50, ErrorMessage = "Employee Number cannot exceed 50 characters.")]
        [Display(Name = "Employee Number*")]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Display(Name = "Availability Status")]
        public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Available;

        [Required]
        public EmployeeType EmployeeType { get; set; }
        // Metadata
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Account Status")]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Customer> ManagedCustomers { get; set; } = new List<Customer>();

        [InverseProperty(nameof(FridgeAllocation.AllocatedBy))]
        public virtual ICollection<FridgeAllocation> AllocatedFridges { get; set; } = new List<FridgeAllocation>();

        // Maintenance tech navigations
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        [ValidateNever]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }

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

