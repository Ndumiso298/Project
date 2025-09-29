using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class MaintenanceVisit
    {
        [Key]
        public int Id { get; set; }

        // === SCHEDULING & BASIC INFORMATION ===
        [Required(ErrorMessage = "Scheduled date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Visit type is required.")]
        [Display(Name = "Visit Type")]
        public ServicingType VisitType { get; set; } = ServicingType.PreventiveMaintenance;

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public ServicingStatus Status { get; set; } = ServicingStatus.Scheduled;

        // === RELATIONSHIPS (Foreign Keys) ===
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [Display(Name = "Allocation")]
        public int? AllocationId { get; set; }

        [Required(ErrorMessage = "Technician is required.")]
        [Display(Name = "Technician")]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        // === SERVICE CHECKLIST (Mandatory per requirements) ===
        [Display(Name = "Service Checklist Completed")]
        public bool IsChecklistCompleted { get; set; }

        [StringLength(1000, ErrorMessage = "Checklist notes cannot exceed 1000 characters.")]
        [Display(Name = "Checklist Notes")]
        public string? ChecklistNotes { get; set; }

        // === TIMING INFORMATION ===
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual Start Time")]
        public DateTime? ActualStartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual End Time")]
        public DateTime? ActualEndTime { get; set; }

        // === TECHNICAL ASSESSMENT ===
        [Display(Name = "Condition Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Condition rating must be between 1 and 5.")]
        public int? ConditionRating { get; set; }

        [Display(Name = "Temperature Reading (°C)")]
        [Range(-30, 10, ErrorMessage = "Temperature must be between -30°C and 10°C.")]
        public decimal? TemperatureReading { get; set; }

        // === ISSUE TRACKING ===
        [Display(Name = "Issues Found")]
        public bool IssuesFound { get; set; }

        [StringLength(1000, ErrorMessage = "Issue description cannot exceed 1000 characters.")]
        [Display(Name = "Issue Description")]
        public string? IssueDescription { get; set; }

        // === MAINTENANCE DETAILS ===
        [Display(Name = "Maintenance Performed")]
        public bool MaintenancePerformed { get; set; }

        [StringLength(1000, ErrorMessage = "Maintenance details cannot exceed 1000 characters.")]
        [Display(Name = "Maintenance Details")]
        public string? MaintenanceDetails { get; set; }

        [StringLength(500, ErrorMessage = "Parts replaced cannot exceed 500 characters.")]
        [Display(Name = "Parts Replaced")]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Service Cost")]
        [Range(0, 100000, ErrorMessage = "Service cost must be a positive value.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ServiceCost { get; set; }

        // === FOLLOW-UP INFORMATION ===
        [Display(Name = "Follow-up Required")]
        public bool FollowUpRequired { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Follow-up Date")]
        public DateTime? FollowUpDate { get; set; }

        // === NOTES & FEEDBACK ===
        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [StringLength(500, ErrorMessage = "Customer note cannot exceed 500 characters.")]
        [Display(Name = "Customer Note")]
        public string? CustomerNote { get; set; }

        [Display(Name = "Customer Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? CustomerRating { get; set; }

        [StringLength(500, ErrorMessage = "Customer feedback cannot exceed 500 characters.")]
        [Display(Name = "Customer Feedback")]
        public string? CustomerFeedback { get; set; }

        // === AUDIT FIELDS ===
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }

        // === COMPUTED PROPERTIES ===
        [NotMapped]
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes => ActualStartTime.HasValue && ActualEndTime.HasValue
            ? (int)(ActualEndTime.Value - ActualStartTime.Value).TotalMinutes
            : null;

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => Status != ServicingStatus.Completed && ScheduledDate < DateTime.UtcNow;

        [NotMapped]
        [Display(Name = "Status Summary")]
        public string StatusSummary => IsOverdue ? "Overdue" :
                                     Status == ServicingStatus.InProgress && ActualStartTime.HasValue ? "In Progress"
                                     : Status.ToString();

        // === NAVIGATION PROPERTIES ===
        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; }

        [ForeignKey(nameof(AllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation? Allocation { get; set; }

        [ForeignKey(nameof(TechnicianId))]
        [ValidateNever]
        public virtual Employee Technician { get; set; }

        [ForeignKey(nameof(LocationId))]
        [ValidateNever]
        public virtual Location Location { get; set; }

        [ValidateNever]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        [ValidateNever]
        public virtual ICollection<FaultRecord> FaultRecords { get; set; } = new List<FaultRecord>();
    }
}
