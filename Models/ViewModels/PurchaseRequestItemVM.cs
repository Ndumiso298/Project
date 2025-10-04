using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class PurchaseRequestItemVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fridge Model")]
        public int FridgeModelId { get; set; }

        public IEnumerable<SelectListItem>? FridgeModelList { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Display(Name = "Estimated Unit Price (R)")]
        [DataType(DataType.Currency)]
        public decimal? EstimatedUnitPrice { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Computed
        public decimal LineTotal => (EstimatedUnitPrice ?? 0) * Quantity;
    }
}

