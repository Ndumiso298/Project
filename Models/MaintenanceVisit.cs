using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class MaintenanceVisit
    {
        public MaintenanceVisit()
        {
            CreatedAt = DateTime.UtcNow;
            Status = ServicingStatus.Scheduled;
            CreatedFaults = new List<FaultRecord>();
        }

        [Key]
        public int Id { get; set; }

        // ===== SCHEDULING & BASIC INFORMATION =====
        [Required(ErrorMessage = "Scheduled date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; }

        // ===== CORE RELATIONSHIPS =====
        [Required(ErrorMessage = "Fridge is required.")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        //[Required(ErrorMessage = "Allocation is required.")]
        public int? AllocationId { get; set; }

        [ForeignKey(nameof(AllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation Allocation { get; set; } = null!;

        [Required(ErrorMessage = "Technician is required.")]
        public int AssignedTechnicianId { get; set; }

        [ForeignKey(nameof(AssignedTechnicianId))]
        [ValidateNever]
        public virtual Employee AssignedTechnician { get; set; } = null!;

        //[Required(ErrorMessage = "Location is required.")]
        public int? LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        public virtual Location Location { get; set; } = null!;

        // ===== SERVICE EXECUTION =====
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual Start Date")]
        public DateTime? ActualStartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual End Date")]
        public DateTime? ActualEndDate { get; set; }

        // ===== SERVICE CHECKLIST =====
        [Display(Name = "Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        [StringLength(1000, ErrorMessage = "Checklist notes cannot exceed 1000 characters.")]
        [Display(Name = "Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        // ===== TECHNICAL ASSESSMENT =====
        [Range(1, 5, ErrorMessage = "Condition rating must be between 1 and 5.")]
        [Display(Name = "Condition Rating")]
        public int? ConditionRating { get; set; }

        [Range(-30, 10, ErrorMessage = "Temperature must be between -30°C and 10°C.")]
        [Display(Name = "Temperature Reading")]
        public decimal? TemperatureReading { get; set; }

        // ===== FAULT & REPLACEMENT TRACKING =====
        [Display(Name = "Faults Found")]
        public bool FaultsFound { get; set; }

        [Display(Name = "Replacement Recommended")]
        public bool ReplacementRecommended { get; set; }

        [StringLength(1000, ErrorMessage = "Replacement reason cannot exceed 1000 characters.")]
        [Display(Name = "Replacement Reason")]
        public string? ReplacementReason { get; set; }

        // ===== MAINTENANCE DETAILS =====
        [Display(Name = "Maintenance Performed")]
        public bool MaintenancePerformed { get; set; }

        [StringLength(1000, ErrorMessage = "Maintenance details cannot exceed 1000 characters.")]
        [Display(Name = "Maintenance Details")]
        public string? MaintenanceDetails { get; set; }

        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        // ===== FOLLOW-UP INFORMATION =====
        [Display(Name = "Follow-up Required")]
        public bool FollowUpRequired { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Follow-up Date")]
        public DateTime? FollowUpDate { get; set; }

        [Display(Name = "Next Service Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NextServiceDue { get; set; }

        // ===== CUSTOMER FEEDBACK =====
        [StringLength(500, ErrorMessage = "Customer feedback cannot exceed 500 characters.")]
        [Display(Name = "Customer Feedback")]
        public string? CustomerFeedback { get; set; }

        [Range(1, 5, ErrorMessage = "Customer rating must be between 1 and 5.")]
        [Display(Name = "Customer Rating")]
        public int? CustomerRating { get; set; }

        // ===== NAVIGATION COLLECTIONS =====
        [ValidateNever]
        [Display(Name = "Created Faults")]
        public virtual ICollection<FaultRecord> CreatedFaults { get; set; }

        // ===== AUDIT FIELDS =====
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => Status != ServicingStatus.Completed &&
                                Status != ServicingStatus.Cancelled &&
                                ScheduledDate < DateTime.UtcNow;

        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => Status == ServicingStatus.Scheduled ||
                               Status == ServicingStatus.InProgress;

        [NotMapped]
        [Display(Name = "Is Completed")]
        public bool IsCompleted => Status == ServicingStatus.Completed;

        [NotMapped]
        [Display(Name = "Duration (Hours)")]
        public double? DurationHours => ActualStartDate.HasValue && ActualEndDate.HasValue
            ? (ActualEndDate.Value - ActualStartDate.Value).TotalHours
            : null;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Visit #{Id:00000} - {Fridge?.DisplayName ?? "Unknown Fridge"}";

        [NotMapped]
        [Display(Name = "Visit Summary")]
        public string VisitSummary => $"{Customer?.BusinessName} - {Fridge?.DisplayName} - {Status} on {ScheduledDate:dd/MM/yyyy}";

        [NotMapped]
        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            ServicingStatus.Scheduled => "bg-info",
            ServicingStatus.InProgress => "bg-warning",
            ServicingStatus.Completed => "bg-success",
            ServicingStatus.Cancelled => "bg-danger",
            ServicingStatus.Rescheduled => "bg-secondary",
            _ => "bg-secondary"
        };

        // ===== BUSINESS LOGIC METHODS =====
        public void StartVisit(string startedBy)
        {
            if (Status == ServicingStatus.Scheduled)
            {
                Status = ServicingStatus.InProgress;
                ActualStartDate = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = startedBy;
            }
        }

        public void CompleteVisit(string completedBy, string? notes = null)
        {
            if (Status == ServicingStatus.InProgress)
            {
                Status = ServicingStatus.Completed;
                ActualEndDate = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = completedBy;

                if (!string.IsNullOrEmpty(notes))
                {
                    TechnicianNotes += $"\n[Completed - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {completedBy}: {notes}";
                }

                // Calculate next service due date
                if (Fridge?.FridgeModel != null)
                {
                    NextServiceDue = DateTime.UtcNow.AddMonths(Fridge.FridgeModel.ServiceIntervalMonths);
                }
            }
        }

        public void CancelVisit(string cancelledBy, string reason)
        {
            if (Status == ServicingStatus.Scheduled || Status == ServicingStatus.InProgress)
            {
                Status = ServicingStatus.Cancelled;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = cancelledBy;
                TechnicianNotes += $"\n[Cancelled - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {cancelledBy}: {reason}";
            }
        }

        public void MarkNoAccess(string updatedBy, string reason)
        {
            if (Status == ServicingStatus.Scheduled)
            {
                Status = ServicingStatus.Rescheduled;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;
                TechnicianNotes += $"\n[No Access - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {updatedBy}: {reason}";
                FollowUpRequired = true;
                FollowUpDate = DateTime.UtcNow.AddDays(7); // Default follow-up in 7 days
            }
        }

        public void RecommendReplacement(string reason, string recommendedBy)
        {
            ReplacementRecommended = true;
            ReplacementReason = reason;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = recommendedBy;
            TechnicianNotes += $"\n[Replacement Recommended - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {recommendedBy}: {reason}";
        }

        public FaultRecord CreateFaultFromVisit(string title, string description, string createdBy)
        {
            var faultRecord = new FaultRecord
            {
                Title = title,
                Description = description,
                FridgeId = FridgeId,
                ReportedById = createdBy,
                FaultLocationId = LocationId,
                Category = FaultCategory.Mechanical,
                Status = FaultStatus.Reported,
                Priority = FaultPriority.Medium,
                ReportedDate = DateTime.UtcNow,
                CreatedBy = createdBy
            };

            CreatedFaults.Add(faultRecord);
            FaultsFound = true;

            return faultRecord;
        }

        public bool CanBeStarted => Status == ServicingStatus.Scheduled;
        public bool CanBeCompleted => Status == ServicingStatus.InProgress;
        public bool CanBeCancelled => Status == ServicingStatus.Scheduled || Status == ServicingStatus.InProgress;

        public (bool isValid, List<string> errors) ValidateForCompletion()
        {
            var errors = new List<string>();

            if (!IsChecklistCompleted)
                errors.Add("Maintenance checklist must be completed");

            if (ConditionRating == null)
                errors.Add("Condition rating is required");

            if (string.IsNullOrWhiteSpace(MaintenanceDetails) && MaintenancePerformed)
                errors.Add("Maintenance details are required when maintenance was performed");

            if (FaultsFound && !CreatedFaults.Any())
                errors.Add("Fault records must be created when faults are found");

            return (!errors.Any(), errors);
        }
    }
}
