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
            Status = AllocationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            FridgeVisits = new List<MaintenanceVisit>();
        }

        [Key]
        [Display(Name = "Allocation ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge")]
        public int FridgeId { get; set; }

        [ForeignKey(nameof(FridgeId))]
        [ValidateNever]
        [Display(Name = "Fridge")]
        public virtual Fridge Fridge { get; set; } = null!;

        [Required(ErrorMessage = "Customer is required.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        [Display(Name = "Customer")]
        public virtual Customer Customer { get; set; } = null!;

        [Required(ErrorMessage = "Allocated by employee is required.")]
        [Display(Name = "Allocated By")]
        public int AllocatedById { get; set; }

        [ForeignKey(nameof(AllocatedById))]
        [InverseProperty(nameof(Employee.AllocatedFridges))]
        [ValidateNever]
        [Display(Name = "Allocated By")]
        public virtual Employee AllocatedBy { get; set; } = null!;

        [Required(ErrorMessage = "Processed by employee is required.")]
        [Display(Name = "Processed By")]
        public int ProcessedById { get; set; }

        [ForeignKey(nameof(ProcessedById))]
        [InverseProperty(nameof(Employee.ProcessedAllocations))]
        [ValidateNever]
        [Display(Name = "Processed By")]
        public virtual Employee ProcessedBy { get; set; } = null!;

        [Display(Name = "Allocation Location")]
        public int AllocationLocationId { get; set; }

        [ForeignKey("AllocationLocationId")]
        [ValidateNever]
        public virtual Location AllocationLocation { get; set; } = null!;

        // Navigation to related requests
        public int? AllocationRequestHeaderId { get; set; }

        [ForeignKey("AllocationRequestHeaderId")]
        [ValidateNever]
        public virtual AllocationRequestHeader? AllocationRequestHeader { get; set; }

        [NotMapped]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price => StoredPrice > 0 ? StoredPrice : (Fridge?.RentalPricePerMonth * Quantity ?? 0);

        // Property for storing the calculated price
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoredPrice { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationStatus Status { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Allocation date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Allocation Date")]
        public DateTime AllocationDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Expected Return Date")]
        public DateTime? ExpectedReturnDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Actual Return Date")]
        public DateTime? ActualReturnDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Allocation Notes")]
        public string? Notes { get; set; }

        // Audit fields
        [Display(Name = "Created At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        // Rental Period
        [ValidateNever]
        [Display(Name = "Fridge Visits")]
        public virtual ICollection<MaintenanceVisit> FridgeVisits { get; set; }

        // Computed properties
        [NotMapped]
        [Display(Name = "Duration (days)")]
        public int? DurationDays
        {
            get
            {
                if (ActualReturnDate.HasValue)
                    return (int)(ActualReturnDate.Value - AllocationDate).TotalDays;
                if (ExpectedReturnDate.HasValue)
                    return (int)(ExpectedReturnDate.Value - AllocationDate).TotalDays;
                return null;
            }
        }

        [NotMapped]
        [Display(Name = "Is Active")]
        public bool IsActive => Status == AllocationStatus.Active;

        [NotMapped]
        [Display(Name = "Is Overdue")]
        public bool IsOverdue => ExpectedReturnDate.HasValue && ExpectedReturnDate < DateTime.UtcNow && Status == AllocationStatus.Active;
    }
}
