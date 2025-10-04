using Project.Helpers;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationCartItemVM
    {
        public Guid TempId { get; set; } = Guid.NewGuid();

        // ===== FRIDGE MODEL SELECTION =====
        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid fridge model.")]
        public int FridgeModelId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Rental duration is required.")]
        [Range(1, 60, ErrorMessage = "Rental duration must be between 1 and 60 months.")]
        [Display(Name = "Rental Duration (Months)")]
        public int RentalDurationMonths { get; set; } = 24;

        // ===== REPLACEMENT-SPECIFIC =====
        [Display(Name = "Is Replacement Unit")]
        public bool IsReplacementUnit { get; set; }

        [StringLength(500, ErrorMessage = "Special requirements cannot exceed 500 characters.")]
        [Display(Name = "Special Requirements")]
        public string? SpecialRequirements { get; set; }

        // ===== DISPLAY PROPERTIES =====
        [Display(Name = "Fridge Model")]
        public FridgeModelVM? FridgeModel { get; set; }

        [Display(Name = "Model Name")]
        public string ModelName => FridgeModel?.DisplayName ?? "Unknown Model";

        [Display(Name = "Manufacturer")]
        public string Manufacturer => FridgeModel?.Manufacturer ?? "Unknown";

        [Display(Name = "Capacity")]
        public string Capacity => FridgeModel != null ? $"{FridgeModel.CapacityLiters}L" : "N/A";

        [Display(Name = "Monthly Rental Price")]
        [DataType(DataType.Currency)]
        public decimal MonthlyRentalPrice => FridgeModel?.MonthlyRentalPrice ?? 0;

        [Display(Name = "Available Stock")]
        public int AvailableStock { get; set; }

        // ===== DISCOUNT INFORMATION =====
        [Display(Name = "Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        public decimal DiscountPercentage { get; set; }

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Monthly Total")]
        [DataType(DataType.Currency)]
        public decimal MonthlyTotal => Quantity * MonthlyRentalPrice;

        [Display(Name = "Line Total")]
        [DataType(DataType.Currency)]
        public decimal LineTotal => MonthlyTotal * RentalDurationMonths;

        [Display(Name = "Discount Amount")]
        [DataType(DataType.Currency)]
        public decimal DiscountAmount => LineTotal * (DiscountPercentage / 100);

        [Display(Name = "Final Amount")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount => LineTotal - DiscountAmount;

        [Display(Name = "Has Sufficient Stock")]
        public bool HasSufficientStock => Quantity <= AvailableStock;

        [Display(Name = "Stock Status")]
        public string StockStatus => HasSufficientStock
            ? $"{AvailableStock} in stock"
            : $"Only {AvailableStock} available";

        [Display(Name = "Stock Status Class")]
        public string StockStatusClass => HasSufficientStock ? "text-success" : "text-danger";

        [Display(Name = "Is Valid")]
        public bool IsValid => FridgeModelId > 0 &&
                              Quantity > 0 &&
                              RentalDurationMonths > 0 &&
                              MonthlyRentalPrice > 0 &&
                              HasSufficientStock;

        [Display(Name = "Is Replacement")]
        public bool IsReplacement => IsReplacementUnit;

        [Display(Name = "Display Summary")]
        public string DisplaySummary => $"{Quantity} × {ModelName} ({RentalDurationMonths} months)";

        [Display(Name = "Price Summary")]
        public string PriceSummary => $"{MonthlyTotal:C}/month | {FinalAmount:C} total";

        [Display(Name = "Replacement Badge")]
        public string ReplacementBadge => IsReplacementUnit ? "🔄 Replacement" : "🆕 New";

        // ===== VALIDATION METHODS =====
        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (FridgeModelId <= 0)
                errors.Add("Fridge model selection is required");

            if (Quantity <= 0)
                errors.Add("Quantity must be greater than 0");

            if (Quantity > 20)
                errors.Add("Quantity cannot exceed 20 units per item");

            if (RentalDurationMonths <= 0)
                errors.Add("Rental duration must be greater than 0");

            if (RentalDurationMonths > 60)
                errors.Add("Rental duration cannot exceed 60 months");

            if (MonthlyRentalPrice <= 0)
                errors.Add("Monthly rental price must be greater than 0");

            if (!HasSufficientStock)
                errors.Add($"{ModelName}: Only {AvailableStock} units available (requested {Quantity})");

            // Replacement-specific validation
            if (IsReplacementUnit && Quantity != 1)
                errors.Add("Replacement items should typically have a quantity of 1");

            return errors;
        }

        // ===== BUSINESS LOGIC METHODS =====
        public void MarkAsReplacement()
        {
            IsReplacementUnit = true;
            Quantity = 1; // Replacements are typically 1:1
            RentalDurationMonths = 12; // Standard replacement duration
        }

        public void ApplyDiscount(decimal discountPercentage)
        {
            if (discountPercentage >= 0 && discountPercentage <= 100)
            {
                DiscountPercentage = discountPercentage;
            }
        }

        public void UpdateFromFridgeModel(FridgeModelVM model, int availableStock = 0)
        {
            if (model != null)
            {
                FridgeModel = model;
                AvailableStock = availableStock;
            }
        }

        public void IncreaseQuantity(int amount = 1)
        {
            if (IsReplacementUnit) return; // Don't allow quantity changes for replacements

            var newQuantity = Quantity + amount;
            if (newQuantity <= 20 && newQuantity <= AvailableStock)
            {
                Quantity = newQuantity;
            }
        }

        public void DecreaseQuantity(int amount = 1)
        {
            if (IsReplacementUnit) return; // Don't allow quantity changes for replacements

            var newQuantity = Quantity - amount;
            if (newQuantity >= 1)
            {
                Quantity = newQuantity;
            }
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (IsReplacementUnit) return; // Don't allow quantity changes for replacements

            if (newQuantity >= 1 && newQuantity <= 20 && newQuantity <= AvailableStock)
            {
                Quantity = newQuantity;
            }
        }

        public void UpdateRentalDuration(int newDuration)
        {
            if (newDuration >= 1 && newDuration <= 60)
            {
                RentalDurationMonths = newDuration;
            }
        }

        // ===== MAPPING METHODS =====
        public AllocationRequestDetailVM ToRequestDetailVM()
        {
            return new AllocationRequestDetailVM
            {
                FridgeModelId = FridgeModelId,
                Quantity = Quantity,
                RentalDurationMonths = RentalDurationMonths,
                SpecialRequirements = SpecialRequirements,
                AvailableStock = AvailableStock,
                IsReplacementUnit = IsReplacementUnit
            };
        }

        public AllocationRequestDetail ToEntity(int allocationRequestHeaderId)
        {
            return new AllocationRequestDetail
            {
                FridgeModelId = FridgeModelId,
                Quantity = Quantity,
                RentalDurationMonths = RentalDurationMonths,
                SpecialRequirements = SpecialRequirements,
                AllocationRequestHeaderId = allocationRequestHeaderId,
                UnitPrice = MonthlyRentalPrice
            };
        }
    }
}

