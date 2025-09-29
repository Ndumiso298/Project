using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Project.Models
{
    public class FaultRecord
    {
        public FaultRecord()
        {
            CreatedAt = DateTime.UtcNow;
            ReportedDate = DateTime.UtcNow;
            Status = FaultStatus.Reported;
            Priority = DetermineInitialPriority();
            FaultCode = GenerateFaultCode();
        }

        [Key]
        public int Id { get; set; }

        // Fault Identification
        [Display(Name = "Fault Code")]
        [StringLength(20)]
        public string FaultCode { get; set; } = string.Empty;

        // Core Relationships (Required)
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        // Optional Relationships (Business context determines if allocation exists)
        [Display(Name = "Related Allocation")]
        public int? FridgeAllocationId { get; set; }

        [ForeignKey(nameof(FridgeAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation? RelatedAllocation { get; set; }

        // Location (Derived from Fridge or Allocation)
        [Display(Name = "Fault Location")]
        public int? FaultLocationId { get; set; }

        [ForeignKey(nameof(FaultLocationId))]
        [ValidateNever]
        public virtual Location? FaultLocation { get; set; }

        // Personnel Assignment
        [Display(Name = "Assigned Technician")]
        public int? AssignedTechnicianId { get; set; }

        [ForeignKey(nameof(AssignedTechnicianId))]
        [ValidateNever]
        [Display(Name = "Assigned Technician")]
        public virtual Employee? AssignedTechnician { get; set; }

        [Required]
        [Display(Name = "Reported By")]
        public string ReportedById { get; set; } = string.Empty;

        [ForeignKey(nameof(ReportedById))]
        [ValidateNever]
        [Display(Name = "Reported By")]
        public virtual ApplicationUser ReportedBy { get; set; } = null!;

        // Fault Details
        [Required(ErrorMessage = "Fault title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        [Display(Name = "Fault Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fault category is required.")]
        [Display(Name = "Category")]
        public FaultCategory Category { get; set; }

        [Required(ErrorMessage = "Fault description is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        // Status & Priority
        [Required]
        [Display(Name = "Status")]
        public FaultStatus Status { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }

        // Timeline (Audit Trail)
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Acknowledged Date")]
        public DateTime? AcknowledgedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Scheduled Date")]
        public DateTime? ScheduledDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Estimated Completion")]
        public DateTime? EstimatedCompletionDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Work Started Date")]
        public DateTime? WorkStartedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Closed Date")]
        public DateTime? ClosedDate { get; set; }

        // Diagnosis & Resolution
        [Display(Name = "Technical Diagnosis")]
        [StringLength(2000, ErrorMessage = "Diagnosis cannot exceed 2000 characters.")]
        [DataType(DataType.MultilineText)]
        public string? TechnicalDiagnosis { get; set; }

        [Display(Name = "Root Cause")]
        [StringLength(500, ErrorMessage = "Root cause cannot exceed 500 characters.")]
        public string? RootCause { get; set; }

        [Display(Name = "Resolution Details")]
        [StringLength(2000, ErrorMessage = "Resolution details cannot exceed 2000 characters.")]
        [DataType(DataType.MultilineText)]
        public string? ResolutionDetails { get; set; }

        [Display(Name = "Technician Notes")]
        [StringLength(1000, ErrorMessage = "Technician notes cannot exceed 1000 characters.")]
        public string? TechnicianNotes { get; set; }

        // Cost & Parts Management
        [Display(Name = "Labor Hours")]
        [Range(0, 500, ErrorMessage = "Labor hours must be reasonable.")]
        public decimal? LaborHours { get; set; }

        [Display(Name = "Labor Cost")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Labor cost must be a positive value.")]
        public decimal? LaborCost { get; set; }

        [Display(Name = "Parts Cost")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Parts cost must be a positive value.")]
        public decimal? PartsCost { get; set; }

        [Display(Name = "Total Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost => (LaborCost ?? 0) + (PartsCost ?? 0);

        [Display(Name = "Replaced Parts")]
        [StringLength(1000, ErrorMessage = "Replaced parts cannot exceed 1000 characters.")]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Warranty Claim")]
        public bool IsWarrantyClaim { get; set; }

        [Display(Name = "Warranty Approved")]
        public bool? WarrantyApproved { get; set; }

        [Display(Name = "Customer Billed")]
        public bool CustomerBilled { get; set; }

        [Display(Name = "Billing Amount")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Billing amount must be a positive value.")]
        public decimal? BillingAmount { get; set; }

        // Customer Communication
        [Display(Name = "Customer Informed")]
        public bool CustomerInformed { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Customer Notified Date")]
        public DateTime? CustomerNotifiedDate { get; set; }

        [Display(Name = "Customer Satisfaction (1-5)")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? CustomerSatisfactionRating { get; set; }

        [Display(Name = "Customer Feedback")]
        [StringLength(1000, ErrorMessage = "Customer feedback cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        public string? CustomerFeedback { get; set; }

        // Documentation & Media
        [Display(Name = "Fault Photos URL")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "Photo URL cannot exceed 500 characters.")]
        public string? FaultPhotosUrl { get; set; }

        [Display(Name = "Resolution Photos URL")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "Photo URL cannot exceed 500 characters.")]
        public string? ResolutionPhotosUrl { get; set; }

        [Display(Name = "Documentation URL")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "Documentation URL cannot exceed 500 characters.")]
        public string? DocumentationUrl { get; set; }

        // Metadata & Audit
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;

        // Navigation Collections
        [ValidateNever]
        [Display(Name = "Related Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        [ValidateNever]
        [Display(Name = "Related Replacement Requests")]
        public virtual ICollection<ReplacementRequest> ReplacementRequests { get; set; } = new List<ReplacementRequest>();

        // Computed Properties (Not Mapped)
        [NotMapped]
        [Display(Name = "Time to Resolution (Hours)")]
        public double? TimeToResolutionHours => ResolvedDate.HasValue
            ? (ResolvedDate.Value - ReportedDate).TotalHours
            : null;

        [NotMapped]
        [Display(Name = "Time to Acknowledgement (Hours)")]
        public double? TimeToAcknowledgementHours => AcknowledgedDate.HasValue
            ? (AcknowledgedDate.Value - ReportedDate).TotalHours
            : null;

        [NotMapped]
        [Display(Name = "Aging (Days)")]
        public double AgingDays => (DateTime.UtcNow - ReportedDate).TotalDays;

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => Status < FaultStatus.Resolved &&
                                EstimatedCompletionDate.HasValue &&
                                DateTime.UtcNow > EstimatedCompletionDate.Value;

        [NotMapped]
        [Display(Name = "Is High Priority")]
        public bool IsHighPriority => Priority == FaultPriority.High || Priority == FaultPriority.Critical;

        // Helper Methods
        private string GenerateFaultCode()
               => $"FLT-{DateTime.UtcNow:yyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";

        private FaultPriority DetermineInitialPriority()
               => FaultPriority.Medium; // 🔧 Can later be extended to base on Category, Customer type, etc.

        public void UpdateStatus(FaultStatus newStatus, string notes = null)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;

            switch (newStatus)
            {
                case FaultStatus.Acknowledged:
                    AcknowledgedDate ??= DateTime.UtcNow;
                    break;
                case FaultStatus.InProgress:
                    WorkStartedDate ??= DateTime.UtcNow;
                    break;
                case FaultStatus.Resolved:
                    ResolvedDate = DateTime.UtcNow;
                    break;
                case FaultStatus.Closed:
                    ClosedDate = DateTime.UtcNow;
                    break;
            }

            if (!string.IsNullOrEmpty(notes))
            {
                TechnicianNotes += $"\n[{DateTime.UtcNow:dd/MM/yyyy HH:mm}] {notes}";
            }
        }
    }
}

