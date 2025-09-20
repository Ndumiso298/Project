using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeAllocation
    {
        public FridgeAllocation()
        {
            Status = AllocationStatus.Pending; // Start as pending rather than approved
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; set; }

        [Required]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        public virtual Fridge Fridge { get; set; } = null!;

        // Foreign key to Customer
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer Customer { get; set; } = null!;

        // Foreign key to Customer Liaison (Employee)
        [Required]
        public int AllocatedById { get; set; }

        [ForeignKey(nameof(AllocatedById))]
        [InverseProperty(nameof(Employee.AllocatedFridges))]
        public virtual Employee AllocatedBy { get; set; } = null!;

        [Required]
        public int ProcessedById { get; set; }

        [ForeignKey(nameof(ProcessedById))]
        [InverseProperty(nameof(Employee.ProcessedAllocations))]
        public virtual Employee ProcessedBy { get; set; } = null!;

        [NotMapped]
        public decimal Price { get; set; }

        public AllocationStatus Status { get; set; }

        [Required(ErrorMessage = "The quantity of fridges is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Allocation date is required.")]
        [Display(Name = "Allocation Date*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime AllocationDate { get; set; }

        [Display(Name = "Expected Return Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpectedReturnDate { get; set; }

        [Display(Name = "Actual Return Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ActualReturnDate { get; set; }

        [Display(Name = "Service Interval (Months)")]
        [Range(1, 24, ErrorMessage = "Service Interval must be between 1 and 24 months.")]
        public int ServiceIntervalMonths { get; set; } = 6;

        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LastServiceDate { get; set; }

        [Display(Name = "Next Service Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NextServiceDue { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [Display(Name = "Allocation Notes")]
        public string? Notes { get; set; }

        // Audit fields
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }

        // Rental Period
        [ValidateNever]
        public ICollection<FridgeVisit> FridgeVisits { get; set; }
    }
}
