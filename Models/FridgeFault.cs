using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FridgeFault
    {
        public FridgeFault()
        {
            CreatedAt = DateTime.UtcNow;
            Status = "Reported";
            Priority = "Medium";
        }

        [Key]
        public int Id { get; set; }

        // Foreign keys
        // Link to the allocation (important for context)
        [Required(ErrorMessage = "FridgeAllocationId is required.")]
        [Display(Name = "FridgeAllocationId")]
        public int FridgeAllocationId { get; set; }

        [Display(Name = "Assigned Technician")]
        public int? FaultTechnicianId { get; set; }

        [Display(Name = "Reported By")]
        public string? ReportedById { get; set; }

        // Navigation properties

        [ForeignKey("FridgeAllocationId")]
        [ValidateNever]
        public virtual FridgeAllocation FaultyFridge { get; set; }

        [ForeignKey("FaultTechnicianId")]
        [ValidateNever]
        public virtual FaultTechnician? FaultTechnician { get; set; }

        [ForeignKey("ReportedById")]
        [ValidateNever]
        public virtual ApplicationUser? ReportedBy { get; set; }

        [Display(Name = "Fault Status")]
        public string Status { get; set; } = "Reported";

        [Required(ErrorMessage = "Fault Description is required.")]
        [StringLength(1000, ErrorMessage = "Fault Description cannot exceed 1000 characters.")]
        [Display(Name = "Fault Description*")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Detailed Diagnosis")]
        [StringLength(2000, ErrorMessage = "Diagnosis cannot exceed 2000 characters.")]
        public string? Diagnosis { get; set; }

        [Display(Name = "Priority")]
        public string Priority { get; set; } = "Low";

        [Required(ErrorMessage = "Reported Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Reported Date*")]
        public DateTime ReportedDate { get; set; }

        [Display(Name = "Assigned Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? AssignedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Resolved Date")]
        public DateTime? ResolvedDate { get; set; }

        [StringLength(1000)]
        [Display(Name = "Resolution Notes")]
        public string? ResolutionNotes { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
