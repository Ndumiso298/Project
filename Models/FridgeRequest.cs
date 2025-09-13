using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FridgeRequest
    {
        public FridgeRequest()
        {
            CreatedAt = DateTime.UtcNow;
            Status = "Pending";
            Priority = "Medium";
        }
        [Key]
        [Display(Name = "TicketId*")]
        public int Id { get; set; }

        // Relationships
        [Required(ErrorMessage = "Related allocation is required.")]
        [Display(Name = "Related Allocation*")]
        public int FridgeAllocationId { get; set; }

        [ForeignKey("FridgeAllocationId")]
        [ValidateNever]
        public virtual FridgeAllocation FridgeAllocation { get; set; } = null!;

        // Link to the specific issue that prompted this request
        [Display(Name = "FaultRecordId")]
        public int? FaultRecordId { get; set; }

        [ForeignKey("FaultRecordId")]
        [ValidateNever]
        public virtual FridgeFault? FaultRecord { get; set; }

        [Display(Name = "MaintenanceRecordId")]
        public int? MaintenanceRecordId { get; set; }

        [ForeignKey("MaintenanceRecordId")]
        [ValidateNever]
        public virtual FridgeMaintenance? MaintenanceRecord { get; set; }

        [Display(Name = "Assigned To")]
        public int? AssignedEmployeeId { get; set; }

        [ForeignKey("AssignedEmployeeId")]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; }

        // Request Details
        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type*")]
        public string RequestType { get; set; } = "Replacement";

        [Required(ErrorMessage = "Request reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Request Reason*")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "The quantity of fridges is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity*")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Status")]
        public string Status { get; set; } // Possible values: Pending, Approved, Rejected, Completed

        [Display(Name = "Priority")]
        public string Priority { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime RequestedDate { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "Response Date")]
        public DateTime? ResponseDate { get; set; }

        [StringLength(500, ErrorMessage = "Response notes cannot exceed 500 characters.")]
        [Display(Name = "Response Notes")]
        public string? ResponseNotes { get; set; }

        // Metadata
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
