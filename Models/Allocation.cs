using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allocation
    {
        public int AllocationId { get; set; } // Unique ID for each allocation


        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [ValidateNever]
        public Customer Customer { get; set; }


        [ForeignKey("FridgeId")]
        public int FridgeId { get; set; }
        [ValidateNever]
        public Fridge Fridge { get; set; }
        public int Count { get; set; }
        // Rental Period
        //public ICollection<FridgeVisit> FridgeVisits { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
