using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class AddToCartVM
    {
        [Required]
        public int FridgeId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Count { get; set; } = 1;

        // Display properties
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double? RentalPricePerMonth { get; set; } //nullable to match Fridge model
        public int CapacityLiters { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}