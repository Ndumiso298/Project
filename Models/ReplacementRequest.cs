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
            Status = CustomerRequestStatus.Draft;
            Priority = CustomerRequestPriority.Medium;
            RequestedDate = DateTime.UtcNow;
            IsActive = true;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fridge Allocation")]
        public int FridgeAllocationId { get; set; }

        [ForeignKey(nameof(FridgeAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation FridgeAllocation { get; set; } = null!;

        [Display(Name = "Fault Record")]
        public int? FaultRecordId { get; set; }

        [ForeignKey(nameof(FaultRecordId))]
        [ValidateNever]
        public virtual FaultRecord? FaultRecord { get; set; }

        [Display(Name = "Maintenance Record")]
        public int? MaintenanceRecordId { get; set; }

        [ForeignKey(nameof(MaintenanceRecordId))]
        [ValidateNever]
        public virtual MaintenanceRecord? MaintenanceRecord { get; set; }

        [Display(Name = "Assigned Employee")]
        public int? AssignedEmployeeId { get; set; }

        [ForeignKey(nameof(AssignedEmployeeId))]
        [ValidateNever]
        public virtual Employee? AssignedEmployee { get; set; }

        // Request Details
        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type")]
        public CustomerRequestType RequestType { get; set; }

        [Required(ErrorMessage = "Request reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        [Display(Name = "Request Reason")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "The quantity of fridges is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        [Required]
        [Display(Name = "Status")]
        public CustomerRequestStatus Status { get; set; }

        [Display(Name = "Priority")]
        public CustomerRequestPriority Priority { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime RequestedDate { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime? AssignedDate { get; set; }

        [Display(Name = "Response Date")]
        public DateTime? ResponseDate { get; set; }

        [StringLength(500, ErrorMessage = "Response notes cannot exceed 500 characters.")]
        [Display(Name = "Response Notes")]
        public string? ResponseNotes { get; set; }

        // Replacement Information
        [Display(Name = "Replacement Fridge")]
        public int? ReplacementFridgeId { get; set; }

        [ForeignKey(nameof(ReplacementFridgeId))]
        [ValidateNever]
        public virtual Fridge? ReplacementFridge { get; set; }

        [Display(Name = "Replacement Date")]
        public DateTime? ReplacementDate { get; set; }

        [Display(Name = "Faulty Fridge Returned")]
        public bool FaultyFridgeReturned { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        // Audit Fields
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Created By")]
        [StringLength(450)]
        public string? CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        [StringLength(450)]
        public string? UpdatedBy { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;

        // Computed Properties
        [NotMapped]
        [Display(Name = "Requesting Customer")]
        public Customer? RequestingCustomer => FridgeAllocation?.Customer;

        [NotMapped]
        [Display(Name = "Faulty Fridge")]
        public Fridge? FaultyFridge => FridgeAllocation?.Fridge;

        [NotMapped]
        [Display(Name = "Days Since Request")]
        public int DaysSinceRequest => (int)(DateTime.UtcNow - RequestedDate).TotalDays;

        [NotMapped]
        [Display(Name = "Is Urgent")]
        public bool IsUrgent => Priority == CustomerRequestPriority.High ||
                               Priority == CustomerRequestPriority.Critical;

        [NotMapped]
        [Display(Name = "Can Be Processed")]
        public bool CanBeProcessed => Status == CustomerRequestStatus.Draft ||
                                     Status == CustomerRequestStatus.Approved;

        [NotMapped]
        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == CustomerRequestStatus.Completed;

        [NotMapped]
        [Display(Name = "Requires Approval")]
        public bool RequiresApproval => Priority == CustomerRequestPriority.High ||
                                       Priority == CustomerRequestPriority.Critical;

        // Business Logic Methods
        public bool CanTransitionTo(CustomerRequestStatus newStatus)
        {
            return Status switch
            {
                CustomerRequestStatus.Draft => newStatus == CustomerRequestStatus.Submitted,
                CustomerRequestStatus.Submitted => newStatus == CustomerRequestStatus.UnderReview ||
                                                    newStatus == CustomerRequestStatus.Rejected,
                CustomerRequestStatus.UnderReview => newStatus == CustomerRequestStatus.Approved ||
                                                      newStatus == CustomerRequestStatus.Rejected,
                CustomerRequestStatus.Approved => newStatus == CustomerRequestStatus.InProgress ||
                                                   newStatus == CustomerRequestStatus.Cancelled,
                CustomerRequestStatus.InProgress => newStatus == CustomerRequestStatus.Completed ||
                                                     newStatus == CustomerRequestStatus.Cancelled,
                _ => false
            };
        }

        public void UpdateStatus(CustomerRequestStatus newStatus, string updatedBy, string? notes = null)
        {
            if (CanTransitionTo(newStatus))
            {
                Status = newStatus;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;

                if (newStatus == CustomerRequestStatus.InProgress && !AssignedDate.HasValue)
                {
                    AssignedDate = DateTime.UtcNow;
                }

                if (newStatus == CustomerRequestStatus.Completed && !ResponseDate.HasValue)
                {
                    ResponseDate = DateTime.UtcNow;
                    ResponseNotes = notes;
                }
            }
        }

        public void AssignToEmployee(int employeeId, string assignedBy)
        {
            AssignedEmployeeId = employeeId;
            AssignedDate = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = assignedBy;
            UpdateStatus(CustomerRequestStatus.InProgress, assignedBy);
        }

        public void CompleteReplacement(int replacementFridgeId, string completedBy, string notes)
        {
            ReplacementFridgeId = replacementFridgeId;
            ReplacementDate = DateTime.UtcNow;
            ResponseNotes = notes;
            UpdateStatus(CustomerRequestStatus.Completed, completedBy);
        }
    }
}