using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationRequestDetailVM
    {
        public Guid TempId { get; set; } = Guid.NewGuid(); // For client-side tracking

        public int Id { get; set; }

        [Required(ErrorMessage = "Fridge is required.")]
        [Display(Name = "Fridge *")]
        public int FridgeId { get; set; }

        // Fridge details for display
        [Display(Name = "Model")]
        public string FridgeModel { get; set; } = string.Empty;

        [Display(Name = "Serial Number")]
        public string FridgeSerialNumber { get; set; } = string.Empty;

        [Display(Name = "Manufacturer")]
        public string FridgeManufacturer { get; set; } = string.Empty;

        [Display(Name = "Capacity")]
        public string FridgeCapacity { get; set; } = string.Empty;

        [Display(Name = "Current Stock")]
        public int CurrentStock { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        [Display(Name = "Quantity *")]
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price (R)")]
        public decimal Price { get; set; }

        [Display(Name = "Total Price (R)")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice => Quantity * Price;

        // Navigation property for dropdown
        public IEnumerable<SelectListItem>? AvailableFridges { get; set; }

        // Validation methods
        public bool IsQuantityAvailable()
        {
            return Quantity <= CurrentStock;
        }

        public string GetStockStatus()
        {
            if (Quantity > CurrentStock)
                return $"Insufficient stock. Available: {CurrentStock}";
            return $"Available: {CurrentStock}";
        }
    }
}
