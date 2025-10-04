using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class AllocationRequestDetail
    {
        public AllocationRequestDetail()
        {
            CreatedAt = DateTime.UtcNow;
        }

        // ===== PRIMARY IDENTIFIER =====
        [Key]
        public int Id { get; set; }

        // ===== PARENT RELATIONSHIP =====
        [Required(ErrorMessage = "Request header is required.")]
        public int AllocationRequestHeaderId { get; set; }

        [ForeignKey("AllocationRequestHeaderId")]
        [ValidateNever]
        public virtual AllocationRequestHeader AllocationRequestHeader { get; set; } = null!;

        // ===== FRIDGE MODEL INFORMATION =====
        [Required(ErrorMessage = "Fridge model is required.")]
        public int FridgeModelId { get; set; }

        [ForeignKey(nameof(FridgeModelId))]
        [ValidateNever]
        public virtual FridgeModel FridgeModel { get; set; } = null!;

        // ===== QUANTITY & DURATION =====
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Rental duration is required.")]
        [Range(1, 36, ErrorMessage = "Rental duration must be between 1 and 36 months.")]
        [Display(Name = "Rental Duration (Months)")]
        public int RentalDurationMonths { get; set; } = 12;

        // ===== PRICING INFORMATION =====
        [Required(ErrorMessage = "Monthly rental price is required.")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 10000, ErrorMessage = "Monthly rental must be between 0.01 and 10,000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        // ===== SPECIAL REQUIREMENTS =====
        [StringLength(500, ErrorMessage = "Special requirements cannot exceed 500 characters.")]
        [Display(Name = "Special Requirements")]
        public string? SpecialRequirements { get; set; }

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

        // ===== COMPUTED PROPERTIES =====
        [NotMapped]
        [Display(Name = "Current Unit Price")]
        [DataType(DataType.Currency)]
        public decimal CurrentUnitPrice => FridgeModel?.MonthlyRentalPrice ?? 0;

        [NotMapped]
        [Display(Name = "Monthly Total")]
        [DataType(DataType.Currency)]
        public decimal MonthlyTotal => Quantity * UnitPrice;

        [NotMapped]
        [Display(Name = "Line Total")]
        [DataType(DataType.Currency)]
        public decimal LineTotal => MonthlyTotal * RentalDurationMonths;

        [NotMapped]
        [Display(Name = "Price Difference")]
        [DataType(DataType.Currency)]
        public decimal PriceDifference => UnitPrice - CurrentUnitPrice;

        [NotMapped]
        [Display(Name = "Has Price Changed")]
        public bool HasPriceChanged => PriceDifference != 0;

        [NotMapped]
        [Display(Name = "Display Name")]
        public string DisplayName => $"{Quantity} x {FridgeModel?.DisplayName ?? "Unknown Model"} - {RentalDurationMonths} months";

        [NotMapped]
        [Display(Name = "Price Summary")]
        public string PriceSummary => $"{UnitPrice:C}/month × {Quantity} units × {RentalDurationMonths} months = {LineTotal:C}";

        [NotMapped]
        [Display(Name = "Item Summary")]
        public string ItemSummary => $"{FridgeModel?.Manufacturer} {FridgeModel?.ModelName} - {Quantity} units";

        // ===== BUSINESS LOGIC METHODS =====
        public bool IsQuantityAvailable(int availableStock)
        {
            return Quantity <= availableStock;
        }

        public void UpdatePricingFromModel()
        {
            if (FridgeModel != null && UnitPrice == 0)
            {
                UnitPrice = FridgeModel.MonthlyRentalPrice;
            }
        }

        public bool ValidatePricing()
        {
            return UnitPrice > 0 && UnitPrice <= 10000;
        }
    }
}
