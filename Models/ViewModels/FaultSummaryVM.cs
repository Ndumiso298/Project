using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class FaultSummaryVM
    {
        public int Id { get; set; }

        [Display(Name = "Fault Code")]
        public string FaultCode { get; set; } = string.Empty;

        [Display(Name = "Title")]
        public string FaultTitle { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string FaultDescription { get; set; } = string.Empty;

        [Display(Name = "Fridge")]
        public string FridgeInfo { get; set; } = string.Empty;

        [Display(Name = "Customer")]
        public string CustomerInfo { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public FaultStatus Status { get; set; }

        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }

        [Display(Name = "Category")]
        public FaultCategory Category { get; set; }

        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; }

        [Display(Name = "Assigned Technician")]
        public string? AssignedTechnician { get; set; }

        // ===== REPLACEMENT INFO =====
        [Display(Name = "Requires Replacement")]
        public bool RequiresReplacement { get; set; }

        [Display(Name = "Replacement Request")]
        public int? ReplacementRequestId { get; set; }

        [Display(Name = "Replacement Status")]
        public string ReplacementStatus => ReplacementRequestId.HasValue ? "Request Created" :
                                         RequiresReplacement ? "Replacement Needed" : "Not Required";

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Is Open")]
        public bool IsOpen => Status == FaultStatus.Reported ||
                             Status == FaultStatus.Assigned ||
                             Status == FaultStatus.InProgress;

        [Display(Name = "Is Critical")]
        public bool IsCritical => Priority == FaultPriority.Critical;

        [Display(Name = "Aging (Days)")]
        public double AgingDays => (DateTime.UtcNow - ReportedDate).TotalDays;

        [Display(Name = "Status Badge Class")]
        public string StatusBadgeClass => Status switch
        {
            FaultStatus.Reported => "bg-secondary",
            FaultStatus.Assigned => "bg-info",
            FaultStatus.InProgress => "bg-warning",
            FaultStatus.PartsRequired => "bg-primary",
            FaultStatus.Resolved => "bg-success",
            FaultStatus.Reopened => "bg-danger",
            FaultStatus.Closed => "bg-dark",
            _ => "bg-secondary"
        };

        [Display(Name = "Severity Badge Class")]
        public string SeverityBadgeClass => Priority switch
        {
            FaultPriority.Critical => "bg-danger",
            FaultPriority.High => "bg-warning",
            FaultPriority.Medium => "bg-info",
            FaultPriority.Low => "bg-success",
            _ => "bg-secondary"
        };

        // ===== FACTORY METHODS =====
        public static FaultSummaryVM FromEntity(FaultRecord entity)
        {
            if (entity == null) return new FaultSummaryVM();

            return new FaultSummaryVM
            {
                Id = entity.Id,
                FaultCode = entity.FaultCode,
                FaultTitle = entity.Title,
                FaultDescription = entity.Description,
                FridgeInfo = entity.Fridge?.DisplayName ?? "Unknown Fridge",
                CustomerInfo = entity.Fridge?.CurrentAllocation?.Customer?.BusinessName ?? "No Customer",
                Status = entity.Status,
                Priority = entity.Priority,
                Category = entity.Category,
                ReportedDate = entity.ReportedDate,
                AssignedTechnician = entity.AssignedTechnician?.FullName,
                RequiresReplacement = entity.RequiresReplacement || entity.ReplacementRecommended,
                ReplacementRequestId = entity.ReplacementRequestId
            };
        }
    }
}
