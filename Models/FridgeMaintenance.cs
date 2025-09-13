using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Models.FridgeManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FridgeMaintenance
    {
        [Key]
        public int Id { get; set; }

        // Foreign keys
        [Required(ErrorMessage = "Allocated Fridge is required.")]
        [Display(Name = "FridgeAllocationId")]
        public int FridgeAllocationId { get; set; }

        [Display(Name = "Assigned Technician")]
        public int? MaintenanceTechnicianId { get; set; }

        // Navigation properties
        [ForeignKey("FridgeAllocationId")]
        [ValidateNever]
        public virtual FridgeAllocation AllocatedFridge { get; set; } = null!;

        [ForeignKey("MaintenanceTechnicianId")]
        [ValidateNever]
        public virtual MaintenanceTechnician? MaintenanceTechnician { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Display(Name = "Description*")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Scheduled Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Scheduled Date*")]
        public DateTime ScheduledDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Customer Confirmation Date")]
        public DateTime? CustomerConfirmationDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Scheduled";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }

        [StringLength(1000, ErrorMessage = "Service Notes cannot exceed 1000 characters.")]
        [Display(Name = "Service Notes")]
        public string? ServiceNotes { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
