using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class FridgeInStock
    {
        [Key]
        public int FridgeInStockId { get; set; }

        [Required]
        public string FridgeNo { get; set; } = string.Empty; 

        [Required]
        public DateTime LastMaintenanceDate { get; set; } = DateTime.Now; 

        public string Condition { get; set; } = "Good"; 

        [Required]
        public bool IsAvailable { get; set; } = true; 

        public int Quantity { get; set; } = 0;

        public string? Location { get; set; }

        [ForeignKey("Fridge")]
        public int FridgeId { get; set; }

        [ValidateNever]
        public virtual Fridge Fridge { get; set; }
    }
}