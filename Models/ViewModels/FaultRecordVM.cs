using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models.ViewModels
{
    public class FaultRecordVM
    {
        public int Id { get; set; }

        // ===== FAULT IDENTIFICATION =====
        [Display(Name = "Fault Code")]
        [StringLength(20)]
        public string FaultCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fault title is required.")]
        [StringLength(200, ErrorMessage = "Fault title cannot exceed 200 characters.")]
        [Display(Name = "Fault Title")]
        public string Title { get; set; } = string.Empty;

        // ===== CORE RELATIONSHIPS =====
        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }
        public IEnumerable<SelectListItem>? FridgeList { get; set; }

        [Required(ErrorMessage = "Reported by is required.")]
        [Display(Name = "Reported By")]
        public string ReportedById { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? UserList { get; set; }

        [Display(Name = "Assigned Technician")]
        public int? AssignedTechnicianId { get; set; }
        public IEnumerable<SelectListItem>? TechnicianList { get; set; }

        [Display(Name = "Fault Location")]
        public int? FaultLocationId { get; set; }
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        // ===== FAULT DETAILS =====
        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public FaultCategory Category { get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

        [Required(ErrorMessage = "Fault description is required.")]
        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        // ===== STATUS & PRIORITY =====
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public FaultStatus Status { get; set; }
        public IEnumerable<SelectListItem>? StatusList { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority")]
        public FaultPriority Priority { get; set; }
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        // ===== TIMELINE =====
        [Required(ErrorMessage = "Reported date is required.")]
        [Display(Name = "Reported Date")]
        public DateTime ReportedDate { get; set; } = DateTime.Now;

        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        // ===== ADDITIONAL PROPERTIES TO MATCH CONTROLLER =====
        public int? MaintenanceVisitId { get; set; }
        public IEnumerable<SelectListItem>? VisitList { get; set; }

        [Display(Name = "Resolution Notes")]
        [StringLength(1000)]
        public string? ResolutionNotes { get; set; }

        [Display(Name = "Parts Replaced")]
        [StringLength(500)]
        public string? PartsReplaced { get; set; }

        [Display(Name = "Repair Cost (R)")]
        [Range(0, 100000)]
        public decimal? RepairCost { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Is Open")]
        public bool IsOpen => Status == FaultStatus.Reported ||
                             Status == FaultStatus.Assigned ||
                             Status == FaultStatus.InProgress ||
                             Status == FaultStatus.Reopened;

        [Display(Name = "Is Resolved")]
        public bool IsResolved => Status == FaultStatus.Resolved || Status == FaultStatus.Closed;

        [Display(Name = "Is Critical")]
        public bool IsCritical => Priority == FaultPriority.Critical;

        [Display(Name = "Display Name")]
        public string DisplayName => $"Fault #{FaultCode}";

        // ===== FACTORY METHODS =====
        public static FaultRecordVM FromEntity(FaultRecord entity)
        {
            if (entity == null) return new FaultRecordVM();

            return new FaultRecordVM
            {
                Id = entity.Id,
                FaultCode = entity.FaultCode,
                Title = entity.Title,
                FridgeId = entity.FridgeId,
                ReportedById = entity.ReportedById,
                AssignedTechnicianId = entity.AssignedTechnicianId,
                FaultLocationId = entity.FaultLocationId,
                Category = entity.Category,
                Description = entity.Description,
                Status = entity.Status,
                Priority = entity.Priority,
                ReportedDate = entity.ReportedDate,
                ResolvedDate = entity.ResolvedDate, // Map to ResolutionDate in entity
                ResolutionNotes = entity.ResolutionNotes, // Map to TechnicianNotes in entity
                PartsReplaced = entity.PartsReplaced,
                RepairCost = entity.TotalCost
            };
        }

        public FaultRecord ToEntity()
        {
            return new FaultRecord
            {
                Id = Id,
                Title = Title,
                FridgeId = FridgeId,
                ReportedById = ReportedById,
                AssignedTechnicianId = AssignedTechnicianId,
                FaultLocationId = FaultLocationId,
                Category = Category,
                Description = Description,
                Status = Status,
                Priority = Priority,
                ReportedDate = ReportedDate,
                ResolutionNotes = ResolutionNotes, // Map back to TechnicianNotes
                PartsReplaced = PartsReplaced
                // Note: TotalCost is computed in entity, so we don't set it directly
            };
        }
    }
}
