using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utility.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allocation
    {
        public int AllocationId { get; set; } 


        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [ValidateNever]
        public Customer Customer { get; set; }


        [ForeignKey("FridgeId")]
        public int FridgeId { get; set; }
        [ValidateNever]
        public Fridge Fridge { get; set; }
        public int Count { get; set; }
       

        [NotMapped]
        public double Price { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationStatus Status { get; set; }
    }
}
