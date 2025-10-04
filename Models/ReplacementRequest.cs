using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class ReplacementRequest
    {
        public ReplacementRequest()
        {
            CreatedAt = DateTime.UtcNow;
            Status = CustomerRequestStatus.Draft; // Changed from PartiallyCompleted
            Priority = RequestPriority.Medium;
            RequestedDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int FridgeAllocationId { get; set; }

        [ForeignKey(nameof(FridgeAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation FridgeAllocation { get; set; } = null!;

        public int? FaultRecordId { get; set; }

        [ForeignKey(nameof(FaultRecordId))]
        [ValidateNever]
        public virtual FaultRecord? FaultRecord { get; set; }

        public int? MaintenanceRecordId { get; set; }

        [ForeignKey(nameof(MaintenanceRecordId))]
        [ValidateNever]
        public virtual MaintenanceRecord? MaintenanceRecord { get; set; }

        public int? AssignedEmployeeId { get; set; }

        [ForeignKey(nameof(AssignedEmployeeId))]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; }

        [NotMapped]
        public Customer RequestingCustomer => FridgeAllocation?.Customer;

        // Request Details
        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; } // Fixed type

        [Required(ErrorMessage = "Request reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Request Reason")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "The quantity of fridges is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Status")]
        public CustomerRequestStatus Status { get; set; } // Removed StringLength attribute

        [Display(Name = "Priority")]
        public RequestPriority Priority { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime RequestedDate { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "Response Date")]
        public DateTime? ResponseDate { get; set; }

        [StringLength(500, ErrorMessage = "Response notes cannot exceed 500 characters.")]
        [Display(Name = "Response Notes")]
        public string? ResponseNotes { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}