using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class RequestFridge
    {
        [Key]
        public int RequestFridgeId { get; set; }

        [Required]
        public int RequestHeaderId { get; set; }

        [ForeignKey("RequestHeaderId")]
        public virtual RequestHeader RequestHeader { get; set; }

        [Required]
        public int FridgeId { get; set; }

        [ForeignKey("FridgeId")]
        public virtual Fridge Fridge { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; } = 1;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}