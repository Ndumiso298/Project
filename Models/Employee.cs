using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utility.Enums;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        // Link to Identity user (employees must have accounts)
        [Required]
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        public string? EmployeeNumber { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; } = string.Empty;

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; } = string.Empty;

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Customer> ManagedCustomers { get; set; } = new List<Customer>();

        //[InverseProperty(nameof(Allocation.AllocatedBy))]
        public virtual ICollection<Allocation> AllocatedFridges { get; set; } = new List<Allocation>();

        // Maintenance tech navigations
        [ValidateNever]
        public virtual ICollection<FridgeVisit> MaintenanceVisits { get; set; } = new List<FridgeVisit>();

        [NotMapped]
        public virtual ICollection<FaultTechnician> FaultReports { get; set; } = new List<FaultTechnician>();

        // Stock controller navigations
        [ValidateNever]
        public virtual ICollection<Fridge> ManagedFridges { get; set; } = new List<Fridge>();

        //[InverseProperty(nameof(Allocation.ProcessedBy))]
        public virtual ICollection<Allocation> ProcessedAllocations { get; set; } = new List<Allocation>();

        [InverseProperty(nameof(PurchaseRequest.RequestedBy))]
        public virtual ICollection<PurchaseRequest> RequestedPurchaseRequests { get; set; } = new List<PurchaseRequest>();

        [InverseProperty(nameof(PurchaseRequest.ApprovedBy))]
        public virtual ICollection<PurchaseRequest> ApprovedPurchaseRequests { get; set; } = new List<PurchaseRequest>();
    }
}
