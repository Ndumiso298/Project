using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class CustomerFridge
    {
        [Key]
        public int CustomerFridgeId { get; set; }

        [ForeignKey("FridgeId")]
        
        public int FridgeId { get; set; }
        [ValidateNever]
        public Fridge Fridge { get; set; }


        [ForeignKey("FridgeInStockId")]
        
        public int FridgeInStockId { get; set; }
        [ValidateNever]
        public virtual FridgeInStock FridgeInStock { get; set; }


        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        [ValidateNever]
        public Customer Customer { get; set; }
        [Required]
        public DateTime ReservedDate { get; set; }
     
        public DateTime? AllocatedDate { get; set; }

    }


}
