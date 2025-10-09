using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utility.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allocation
    {
        public int AllocationId { get; set; } // Unique ID for each allocation


        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("FridgeId")]
        public int FridgeId { get; set; }
        [ValidateNever]
        public Fridge Fridge { get; set; }
        public int Count { get; set; }
        // Rental Period
        public ICollection<FridgeVisit> FridgeVisits { get; set; }

        [NotMapped]
        public double Price { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public AllocationStatus Status { get; set; }
    }
}
