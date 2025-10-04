using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestDetailVM
    {
        public int Id { get; set; }
        public Guid TempId { get; set; } = Guid.NewGuid();

        // Parent Reference
        [Display(Name = "Request Header ID")]
        public int AllocationRequestHeaderId { get; set; }

        // Fridge Selection
        [Required(ErrorMessage = "Fridge model is required.")]
        [Display(Name = "Fridge Model")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid fridge model.")]
        public int FridgeModelId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Rental duration is required.")]
        [Range(1, 60, ErrorMessage = "Rental duration must be between 1 and 60 months.")]
        [Display(Name = "Rental Duration (Months)")]
        public int RentalDurationMonths { get; set; } = 12;

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

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Monthly Total")]
        [DataType(DataType.Currency)]
        public decimal MonthlyTotal => Quantity * MonthlyRentalPrice;

        [Display(Name = "Line Total")]
        [DataType(DataType.Currency)]
        public decimal LineTotal => MonthlyTotal * RentalDurationMonths;

        [Display(Name = "Has Sufficient Stock")]
        public bool HasSufficientStock => Quantity <= AvailableStock;

        [Display(Name = "Stock Status")]
        public string StockStatus => HasSufficientStock
            ? $"{AvailableStock} available"
            : $"Only {AvailableStock} available";

        [Display(Name = "Stock Status Class")]
        public string StockStatusClass => HasSufficientStock ? "text-success" : "text-danger";

        [Display(Name = "Is Valid")]
        public bool IsValid => FridgeModelId > 0 &&
                              Quantity > 0 &&
                              RentalDurationMonths > 0 &&
                              MonthlyRentalPrice > 0;

        [Display(Name = "Can Edit")]
        public bool CanEdit { get; set; } = true;

        [Display(Name = "Is Replacement")]
        public bool IsReplacement => IsReplacementUnit;

        // ===== VALIDATION METHODS =====
        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (FridgeModelId <= 0)
                errors.Add("Fridge model selection is required");

            if (Quantity <= 0)
                errors.Add("Quantity must be greater than 0");

            if (Quantity > 50)
                errors.Add("Quantity cannot exceed 50 units per line");

            if (RentalDurationMonths <= 0)
                errors.Add("Rental duration must be greater than 0");

            if (RentalDurationMonths > 60)
                errors.Add("Rental duration cannot exceed 60 months");

            if (!HasSufficientStock)
                errors.Add($"{ModelName}: Only {AvailableStock} units available (requested {Quantity})");

            if (MonthlyRentalPrice <= 0)
                errors.Add($"Invalid pricing for {ModelName}");

            return errors;
        }

        // ===== MAPPING METHODS =====
        public AllocationRequestDetail ToEntity()
        {
            return new AllocationRequestDetail
            {
                Id = Id,
                AllocationRequestHeaderId = AllocationRequestHeaderId,
                FridgeModelId = FridgeModelId,
                Quantity = Quantity,
                RentalDurationMonths = RentalDurationMonths,
                SpecialRequirements = SpecialRequirements?.Trim(),
                UnitPrice = MonthlyRentalPrice // Use the displayed price
            };
        }

        public static AllocationRequestDetailVM FromEntity(AllocationRequestDetail entity, int availableStock = 0)
        {
            if (entity == null) return new AllocationRequestDetailVM();

            return new AllocationRequestDetailVM
            {
                Id = entity.Id,
                AllocationRequestHeaderId = entity.AllocationRequestHeaderId,
                FridgeModelId = entity.FridgeModelId,
                Quantity = entity.Quantity,
                RentalDurationMonths = entity.RentalDurationMonths,
                SpecialRequirements = entity.SpecialRequirements,
                AvailableStock = availableStock
            };
        }

        // ===== HELPER METHODS =====
        public Dictionary<string, string> GetValidationAttributes()
        {
            return new Dictionary<string, string>
        {
            { "data-available-stock", AvailableStock.ToString() },
            { "data-unit-price", MonthlyRentalPrice.ToString("F2") },
            { "data-is-valid", IsValid.ToString().ToLower() },
            { "data-temp-id", TempId.ToString() },
            { "data-model-name", ModelName },
            { "data-min-quantity", "1" },
            { "data-max-quantity", "50" },
            { "data-is-replacement", IsReplacementUnit.ToString().ToLower() }
        };
        }

        public void MarkAsReplacement()
        {
            IsReplacementUnit = true;
            Quantity = 1; // Replacements are typically 1:1
        }
    }
}
