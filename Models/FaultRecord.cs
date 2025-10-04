using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Project.Utilities.Enums;
using System;
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

        // ===== FAULT IDENTIFICATION =====
        [StringLength(20)]
        public string FaultCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fault title is required.")]
        [StringLength(200, ErrorMessage = "Fault title cannot exceed 200 characters.")]
        [Display(Name = "Fault Title")]
        public string Title { get; set; } = string.Empty;

        // ===== CORE RELATIONSHIPS =====
        [Required(ErrorMessage = "Fridge is required.")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        // ===== LOCATION INFORMATION =====
        public int? FaultLocationId { get; set; }

        [ForeignKey(nameof(FaultLocationId))]
        [ValidateNever]
        public virtual Location? FaultLocation { get; set; }

        // ===== PERSONNEL ASSIGNMENT =====
        public int? AssignedTechnicianId { get; set; }

        // navigation to Employee
        [ForeignKey(nameof(AssignedTechnicianId))]
        [InverseProperty(nameof(Employee.AssignedFaults))]
        public virtual Employee? AssignedTechnician { get; set; }

        [Required]
        // reported-by links to ApplicationUser
        public string ReportedById { get; set; } = string.Empty;

        [ForeignKey(nameof(ReportedById))]
        [InverseProperty(nameof(ApplicationUser.ReportedFaults))]
        public virtual ApplicationUser ReportedBy { get; set; } = null!;

        // ===== FAULT DETAILS =====
        [Required(ErrorMessage = "Fault category is required.")]
        [Display(Name = "Category")]
        public FaultCategory Category { get; set; }

        [Required(ErrorMessage = "Fault description is required.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        // ===== STATUS & PRIORITY =====
        [Required]
        [Display(Name = "Status")]
        public FaultStatus Status { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }

        // ===== ADD MISSING PROPERTIES =====
        [Display(Name = "Parts Replaced")]
        [StringLength(500, ErrorMessage = "Parts replaced description cannot exceed 500 characters.")]
        public string? PartsReplaced { get; set; }

        // ===== RESOLUTION INFORMATION =====
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

        [StringLength(2000, ErrorMessage = "Resolution details cannot exceed 2000 characters.")]
        [Display(Name = "Resolution Details")]
        public string? ResolutionDetails { get; set; }

        [StringLength(1000, ErrorMessage = "Resolution notes cannot exceed 1000 characters.")]
        [Display(Name = "Resolution Notes")]
        public string? ResolutionNotes { get; set; }

        // ===== REPLACEMENT TRACKING =====
        [Display(Name = "Requires Replacement")]
        public bool RequiresReplacement { get; set; }

        [Display(Name = "Replacement Recommended")]
        public bool ReplacementRecommended { get; set; }

        [Display(Name = "Replacement Request")]
        public int? ReplacementRequestId { get; set; }

        [ForeignKey(nameof(ReplacementRequestId))]
        [ValidateNever]
        public virtual AllocationRequestHeader? ReplacementRequest { get; set; }

        // ===== TIMELINE =====
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Assigned Date")]
        public DateTime? AssignedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Response Date")]
        public DateTime? ResponseDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Closed Date")]
        public DateTime? ClosedDate { get; set; }

        // ===== COST & PARTS MANAGEMENT =====
        [Range(0, 500, ErrorMessage = "Labor hours must be reasonable.")]
        [Display(Name = "Labor Hours")]
        public decimal? LaborHours { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Labor cost must be a positive value.")]
        [Display(Name = "Labor Cost")]
        public decimal? LaborCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Parts cost must be a positive value.")]
        [Display(Name = "Parts Cost")]
        public decimal? PartsCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Cost")]
        public decimal TotalCost => (LaborCost ?? 0) + (PartsCost ?? 0);

        [Display(Name = "Warranty Covered")]
        public bool WarrantyCovered { get; set; }

        [Display(Name = "Customer Billed")]
        public bool CustomerBilled { get; set; } = true;

        // ===== CUSTOMER COMMUNICATION =====
        [Display(Name = "Customer Informed")]
        public bool CustomerInformed { get; set; }

        [StringLength(1000, ErrorMessage = "Customer feedback cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Customer Feedback")]
        public string? CustomerFeedback { get; set; }

        // ===== NAVIGATION COLLECTIONS =====
        [ValidateNever]
        [Display(Name = "Related Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

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
        [Display(Name = "Is Open")]
        public bool IsOpen => Status == FaultStatus.Reported ||
                              Status == FaultStatus.Assigned ||
                              Status == FaultStatus.InProgress;

        [NotMapped]
        [Display(Name = "Is Resolved")]
        public bool IsResolved => Status == FaultStatus.Resolved || Status == FaultStatus.Closed;

        [NotMapped]
        [Display(Name = "Time to Response (Hours)")]
        public double? TimeToResponseHours => ResponseDate.HasValue ?
            (ResponseDate.Value - ReportedDate).TotalHours : null;

        [NotMapped]
        [Display(Name = "Time to Resolution (Hours)")]
        public double? TimeToResolutionHours => ResolvedDate.HasValue ?
            (ResolvedDate.Value - ReportedDate).TotalHours : null;

        [NotMapped]
        [Display(Name = "Aging (Days)")]
        public double AgingDays => (DateTime.UtcNow - ReportedDate).TotalDays;

        [NotMapped]
        [Display(Name = "Is High Priority")]
        public bool IsHighPriority => Priority == FaultPriority.High || Priority == FaultPriority.Critical;

        [NotMapped]
        [Display(Name = "Is Critical Severity")]
        public bool IsCriticalSeverity => Priority == FaultPriority.Critical;

        [NotMapped]
        [Display(Name = "Should Trigger Replacement")]
        public bool ShouldTriggerReplacement =>
            (RequiresReplacement || ReplacementRecommended) &&
            Priority == FaultPriority.Critical &&
            !ReplacementRequestId.HasValue;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"Fault #{FaultCode} - {Fridge?.DisplayName ?? "Unknown Fridge"}";

        [NotMapped]
        [Display(Name = "Fault Summary")]
        public string FaultSummary => $"{Fridge?.DisplayName} - {Category} - {Priority} - {Status}";

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue
        {
            get
            {
                if (IsResolved) return false;

                var severityHours = Priority switch
                {
                    FaultPriority.Critical => 24,
                    FaultPriority.High => 48,
                    FaultPriority.Medium => 72,
                    FaultPriority.Low => 168, // 7 days
                    _ => 168
                };

                return AgingDays * 24 > severityHours;
            }
        }

        // ===== HELPER METHODS =====
        private string GenerateFaultCode()
            => $"FLT-{DateTime.UtcNow:yyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";

        private FaultPriority DetermineInitialPriority()
        {
            // Base priority on severity and other factors
            return Priority switch
            {
                FaultPriority.Critical => FaultPriority.Critical,
                FaultPriority.High => FaultPriority.High,
                FaultPriority.Medium => FaultPriority.Medium,
                FaultPriority.Low => FaultPriority.Low,
                _ => FaultPriority.Medium
            };
        }

        // ===== BUSINESS LOGIC METHODS =====
        public bool CanTransitionTo(FaultStatus newStatus)
        {
            return Status switch
            {
                FaultStatus.Reported => newStatus == FaultStatus.Assigned,
                FaultStatus.Assigned => newStatus == FaultStatus.InProgress ||
                                       newStatus == FaultStatus.PartsRequired,
                FaultStatus.InProgress => newStatus == FaultStatus.Resolved ||
                                         newStatus == FaultStatus.PartsRequired,
                FaultStatus.PartsRequired => newStatus == FaultStatus.InProgress,
                FaultStatus.Resolved => newStatus == FaultStatus.Closed ||
                                       newStatus == FaultStatus.Reopened,
                FaultStatus.Reopened => newStatus == FaultStatus.Assigned ||
                                       newStatus == FaultStatus.InProgress,
                FaultStatus.Closed => newStatus == FaultStatus.Reopened,
                _ => false
            };
        }

        // Reopening logic
        public void ReopenFault(string reason, string reopenedBy)
        {
            if (CanBeReopened())
            {
                Status = FaultStatus.Reopened;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = reopenedBy;
                ResolutionNotes += $"\n[Reopened - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {reopenedBy}: {reason}";
            }
        }

        public bool CanBeReopened()
        {
            return Status == FaultStatus.Resolved || Status == FaultStatus.Closed;
        }

        public void AssignToTechnician(int technicianId, string assignedBy)
        {
            if (CanBeAssigned())
            {
                AssignedTechnicianId = technicianId;
                Status = FaultStatus.Assigned;
                AssignedDate = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = assignedBy;
            }
        }

        public void MarkInProgress(string updatedBy)
        {
            if (Status == FaultStatus.Assigned)
            {
                Status = FaultStatus.InProgress;
                ResponseDate ??= DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = updatedBy;
            }
        }

        public void ResolveFault(FaultPriority faultPriority, string resolutionDetails,
            string resolvedBy, decimal? repairCost = null, double? repairTime = null)
        {
            if (CanBeResolved())
            {
                Status = FaultStatus.Resolved;
                ResolutionDetails = resolutionDetails;
                ResolvedDate = DateTime.UtcNow;
                LaborCost = repairCost;
                LaborHours = (decimal?)repairTime;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = resolvedBy;

                // Auto-determine if replacement is needed
                if (faultPriority == FaultPriority.Critical)
                {
                    RequiresReplacement = true;
                    ReplacementRecommended = true;
                }
            }
        }

        public void CloseFault(string closedBy, string? notes = null)
        {
            if (CanBeClosed())
            {
                Status = FaultStatus.Closed;
                ClosedDate = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
                UpdatedBy = closedBy;

                if (!string.IsNullOrEmpty(notes))
                {
                    ResolutionNotes += $"\n[Closed - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {closedBy}: {notes}";
                }
            }
        }

        public void RecommendReplacement(string reason, string recommendedBy)
        {
            ReplacementRecommended = true;
            ResolutionNotes += $"\n[Replacement Recommended - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {recommendedBy}: {reason}";
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = recommendedBy;

            // Auto-escalate severity if recommending replacement
            if (Priority != FaultPriority.Critical)
            {
                Priority = FaultPriority.Critical;
            }
        }

        public void LinkReplacementRequest(int replacementRequestId, string linkedBy)
        {
            ReplacementRequestId = replacementRequestId;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = linkedBy;
            ResolutionNotes += $"\n[Replacement Request Linked - {DateTime.UtcNow:dd/MM/yyyy HH:mm}] {linkedBy}: Linked to replacement request #{replacementRequestId}";
        }

        public bool CanBeAssigned()
        {
            return Status == FaultStatus.Reported || Status == FaultStatus.Reopened;
        }

        public bool CanBeResolved()
        {
            return Status == FaultStatus.Assigned || Status == FaultStatus.InProgress;
        }

        public bool CanBeClosed()
        {
            return Status == FaultStatus.Resolved;
        }

        public (bool isValid, List<string> errors) ValidateForSubmission()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Title))
                errors.Add("Fault title is required");

            if (string.IsNullOrWhiteSpace(Description))
                errors.Add("Fault description is required");

            if (FridgeId <= 0)
                errors.Add("Valid fridge is required");

            if (Description.Length > 1000)
                errors.Add("Fault description cannot exceed 1000 characters");

            if (Title.Length > 200)
                errors.Add("Fault title cannot exceed 200 characters");

            return (!errors.Any(), errors);
        }
    }
}

