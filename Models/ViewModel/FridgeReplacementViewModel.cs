using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{


    public class FridgeReplacementViewModel
    {
        public int VisitId { get; set; }
        public int FridgeReplacementId { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Old Fridge Number")]
        public string OldFridgeNo { get; set; }

        [Display(Name = "Fridge Model")]
        public string FridgeModel { get; set; }

        [Required]
        [Display(Name = "Reason for Replacement")]
        public string ReasonForReplacement { get; set; }

        [Display(Name = "Additional Notes")]
        public string? AdditionalNotes { get; set; }

        [Required]
        [Display(Name = "Replacement Date")]
        public DateTime ReplacementDate { get; set; }

        // For customer support actions
        public string? DeclineReason { get; set; }
        public string? TechnicianNotes { get; set; }
        public int? NewFridgeInStockId { get; set; }

        public List<SelectListItem> AvailableFridges { get; set; } = new();
    }
}