using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class AllocationRequestDetail
    {
        [Key]
        [Display(Name = "Detail ID")]
        public int Id { get; set; }

        // Parent Relationship
        [Required(ErrorMessage = "Request header is required.")]
        [Display(Name = "Request Header")]
        public int AllocationRequestHeaderId { get; set; }

        [ForeignKey("AllocationRequestHeaderId")]
        [ValidateNever]
        public virtual AllocationRequestHeader AllocationRequestHeader { get; set; } = null!;

        // Product Information
        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        public int FridgeModelId { get; set; }

        [ForeignKey("FridgeModelId")]
        [ValidateNever]
        public virtual FridgeModel FridgeModel { get; set; } = null!;

        // Quantity and Duration
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Rental duration is required.")]
        [Range(1, 60, ErrorMessage = "Rental duration must be between 1 and 60 months.")]
        [Display(Name = "Rental Duration (Months)")]
        public int RentalDurationMonths { get; set; } = 12;

        // Special Requirements
        [StringLength(500, ErrorMessage = "Special requirements cannot exceed 500 characters.")]
        [Display(Name = "Special Requirements")]
        public string? SpecialRequirements { get; set; }

        // Computed Properties
        [NotMapped]
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice => FridgeModel?.MonthlyRentalPrice ?? 0;

        [NotMapped]
        [Display(Name = "Monthly Total")]
        [DataType(DataType.Currency)]
        public decimal MonthlyTotal => Quantity * UnitPrice;

        [NotMapped]
        [Display(Name = "Line Total")]
        [DataType(DataType.Currency)]
        public decimal LineTotal => MonthlyTotal * RentalDurationMonths;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{Quantity} x {FridgeModel?.DisplayName ?? "Unknown Model"}";

        // Validation Methods
        public bool IsQuantityAvailable(int availableStock)
        {
            return Quantity <= availableStock;
        }

        public string GetValidationMessage(int availableStock)
        {
            if (Quantity > availableStock)
            {
                return $"Only {availableStock} units available for {FridgeModel?.DisplayName}";
            }
            return string.Empty;
        }
    }
}
