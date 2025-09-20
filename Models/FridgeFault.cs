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
    public class FridgeFault
    {
        public FridgeFault()
        {
            CreatedAt = DateTime.UtcNow;
            Status = FaultStatus.Reported;
            Priority = FaultPriority.Medium;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fridge allocation is required.")]
        [Display(Name = "Fridge Allocation")]
        public int FridgeAllocationId { get; set; }

        [Required]
        public int FridgeId { get; set; }

        [Display(Name = "Assigned Technician")]
        public int? FaultTechnicianId { get; set; }

        [Display(Name = "Reported By")]
        public string? ReportedById { get; set; }

        public int MaintenanceVisitId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(FridgeAllocationId))]
        [ValidateNever]
        public virtual FridgeAllocation FridgeAllocation { get; set; } = null!;

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        [ForeignKey(nameof(FaultTechnicianId))]
        [InverseProperty(nameof(Employee.AssignedFaults))]
        public virtual Employee? AssignedTechnician { get; set; }

        [ForeignKey(nameof(ReportedById))]
        [ValidateNever]
        public virtual ApplicationUser? ReportedBy { get; set; }

        public virtual MaintenanceVisit MaintenanceVisit { get; set; }

        [Required]
        [Display(Name = "Status")]
        public FaultStatus Status { get; set; }

        [Required(ErrorMessage = "Fault category is required.")]
        [Display(Name = "Category")]
        public FaultCategory Category { get; set; }

        [Required(ErrorMessage = "Fault description is required.")]
        [StringLength(1000, ErrorMessage = "Fault description cannot exceed 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Detailed Diagnosis")]
        [StringLength(2000, ErrorMessage = "Diagnosis cannot exceed 2000 characters.")]
        public string? Diagnosis { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }

        // Timeline
        [Required(ErrorMessage = "Reported date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; } = DateTime.UtcNow;

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
        [Display(Name = "Started Date")]
        public DateTime? StartedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Closed Date")]
        public DateTime? ClosedDate { get; set; }

        // Resolution details
        [StringLength(2000, ErrorMessage = "Resolution notes cannot exceed 2000 characters.")]
        [Display(Name = "Resolution Notes")]
        public string? ResolutionNotes { get; set; }

        [Display(Name = "Repair Cost")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000, ErrorMessage = "Repair cost must be a positive value.")]
        public decimal? RepairCost { get; set; }

        [Display(Name = "Parts Used")]
        [StringLength(1000, ErrorMessage = "Parts used cannot exceed 1000 characters.")]
        public string? PartsUsed { get; set; }

        [Display(Name = "Warranty Covered")]
        public bool? WarrantyCovered { get; set; }

        [Display(Name = "Customer Charged")]
        public bool CustomerCharged { get; set; }

        // Customer feedback
        [Display(Name = "Customer Satisfaction Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? CustomerRating { get; set; }

        [StringLength(1000, ErrorMessage = "Customer feedback cannot exceed 1000 characters.")]
        [Display(Name = "Customer Feedback")]
        public string? CustomerFeedback { get; set; }

        // Photos/documentation
        [Display(Name = "Fault Photo URL")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "Photo URL cannot exceed 500 characters.")]
        public string? FaultPhotoUrl { get; set; }

        [Display(Name = "Resolution Photo URL")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [StringLength(500, ErrorMessage = "Photo URL cannot exceed 500 characters.")]
        public string? ResolutionPhotoUrl { get; set; }

        // Metadata
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;

        [ValidateNever]
        public virtual ICollection<FridgeRequest> RelatedRequests { get; set; } = new List<FridgeRequest>();

        // Navigation to related work orders
        [ValidateNever]
        public virtual ICollection<MaintenanceVisit> RelatedMaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        [NotMapped]
        [Display(Name = "Time to Resolution (Hours)")]
        public double? TimeToResolutionHours => (ResolvedDate.HasValue && ReportedDate != null)
          ? (ResolvedDate.Value - ReportedDate).TotalHours
          : null;

        [NotMapped]
        [Display(Name = "Time to Acknowledgement (Hours)")]
        public double? TimeToAcknowledgementHours => (AcknowledgedDate.HasValue && ReportedDate != null)
            ? (AcknowledgedDate.Value - ReportedDate).TotalHours
            : null;
        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => Status != FaultStatus.Resolved && Status != FaultStatus.Closed;
    }
}

