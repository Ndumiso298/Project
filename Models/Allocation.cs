using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allocation
    {
        [Key]
        public int AllocationId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Count must be at least 1")]
        public int Count { get; set; } = 1;

        [Required]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;

        [Required]
        public int FridgeId { get; set; }

        [ForeignKey("FridgeId")]
        public virtual Fridge Fridge { get; set; } = null!;

        // Add these properties based on your database schema
        public string RejectReason { get; set; } = "Not Rejected";

        public string Status { get; set; } = "InCart";

        public DateTime AllocationDate { get; set; } = DateTime.Now;

     
        public double? Price { get; set; }
    }
}