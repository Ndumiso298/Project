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

        // Visit scheduling and basic info
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

        // TradingLocation information
        [Required(ErrorMessage = "TradingLocation is required.")]
        [StringLength(200, ErrorMessage = "TradingLocation cannot exceed 200 characters.")]
        [Display(Name = "TradingLocation")]
        public string Location { get; set; }

        // Foreign keys
        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Fridge")]
        public int? FridgeId { get; set; }

        [Display(Name = "Allocation")]
        public int? AllocationId { get; set; }

        [Display(Name = "Technician")]
        public int? TechnicianId { get; set; }

        // Timing information
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual Start Time")]
        public DateTime? ActualStartTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual End Time")]
        public DateTime? ActualEndTime { get; set; }

        [NotMapped]
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes =>
            (ActualStartTime.HasValue && ActualEndTime.HasValue)
                ? (int)(ActualEndTime.Value - ActualStartTime.Value).TotalMinutes
                : null;

        // Technical assessment
        [Display(Name = "Fridge Condition Rating")]
        [Range(1, 5, ErrorMessage = "Condition rating must be between 1 and 5.")]
        public int? FridgeConditionRating { get; set; }

        [Display(Name = "Temperature Reading (°C)")]
        [Range(-30, 10, ErrorMessage = "Temperature must be between -30°C and 10°C.")]
        public decimal? TemperatureReading { get; set; }

        // Issue tracking
        [Display(Name = "Issues Found")]
        public bool IssuesFound { get; set; }

        [StringLength(1000, ErrorMessage = "Issue description cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Issue Description")]
        public string? IssueDescription { get; set; }

        // Maintenance details
        [Display(Name = "Maintenance Performed")]
        public bool MaintenancePerformed { get; set; }

        [StringLength(1000, ErrorMessage = "Maintenance details cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Maintenance Details")]
        public string? MaintenanceDetails { get; set; }

        [Display(Name = "Parts Replaced")]
        [StringLength(500, ErrorMessage = "Parts replaced cannot exceed 500 characters.")]
        public string? PartsReplaced { get; set; }

        // Follow-up information
        [Display(Name = "Follow-up Required")]
        public bool FollowUpRequired { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Follow-up Date")]
        public DateTime? FollowUpDate { get; set; }

        // Notes and feedback
        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Technician Notes")]
        public string? TechnicianNotes { get; set; }

        [StringLength(500, ErrorMessage = "Customer note cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Customer Note")]
        public string? CustomerNote { get; set; }

        [Display(Name = "Customer Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? CustomerRating { get; set; }

        [StringLength(500, ErrorMessage = "Customer feedback cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Customer Feedback")]
        public string? CustomerFeedback { get; set; }

        // Audit fields
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Modified")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        [Display(Name = "Customer")]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        [Display(Name = "Fridge")]
        public virtual Fridge Fridge { get; set; }

        [ForeignKey(nameof(AllocationId))]
        [ValidateNever]
        [Display(Name = "Allocation")]
        public virtual FridgeAllocation Allocation { get; set; }

        [ForeignKey(nameof(TechnicianId))]
        [ValidateNever]
        [Display(Name = "Technician")]
        public virtual Employee Technician { get; set; }

        [ValidateNever]
        [Display(Name = "Maintenance Records")]
        public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

        // Computed properties
        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => Status != ServicingStatus.Completed && ScheduledDate < DateTime.UtcNow;

        [NotMapped]
        [Display(Name = "Visit Status Summary")]
        public string VisitStatusSummary
        {
            get
            {
                if (IsOverdue) return "Overdue";
                if (Status == ServicingStatus.InProgress && ActualStartTime.HasValue) return "In Progress";
                return Status.ToString();
            }
        }
    }
}
