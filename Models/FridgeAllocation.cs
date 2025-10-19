using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeAllocation
    {
        [Key]
        public int FridgeAllocationId { get; set; }

        [Required]
        [ForeignKey("RequestHeader")]
        public int RequestHeaderId { get; set; }
        public virtual RequestHeader RequestHeader { get; set; }

        [Required]
        [ForeignKey("FridgeInStock")]
        public int FridgeInStockId { get; set; }
        public virtual FridgeInStock FridgeInStock { get; set; }

        [Required]
        public string FridgeNo { get; set; }

        [Required]
        public DateTime AllocatedDate { get; set; }

        [ForeignKey("EmployeeID")]
        public int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public string Status { get; set; }

        public string? Notes { get; set; }
    }

}