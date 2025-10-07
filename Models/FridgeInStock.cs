using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FridgeInStock
    {
        [Key]
        public int FridgeInStockId { get; set; }

        [Required]
        public string FridgeNo { get; set; }

        [Required]
        public DateTime LastMaintenanceDate { get; set; }

        [Required]
        public string Condition { get; set; } 

        [Required]
        public bool IsAvailable { get; set; } 
        public string? Location { get; set; }

        [ForeignKey("Fridge")]
        public int FridgeId { get; set; }

        public virtual Fridge Fridge { get; set; }
    }
}