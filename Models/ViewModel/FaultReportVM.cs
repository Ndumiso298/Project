using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class FaultReportVM
    {
        [Required(ErrorMessage = "Please select a fridge")]
        [Display(Name = "Select Fridge")]
        public int FridgeInStockId { get; set; }

        [Required(ErrorMessage = "Fault type is required")]
        [Display(Name = "Fault Type")]
        public string FaultType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Fault Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Priority Level")]
        public string Priority { get; set; } = "Medium";

        [Display(Name = "Request Replacement")]
        public bool RequestReplacement { get; set; }

        [Display(Name = "Upload Images")]
        public List<IFormFile>? FaultImages { get; set; }

        // Display properties (read-only)
        public string CustomerName { get; set; } = string.Empty;
        public List<CustomerFridge> AvailableFridges { get; set; } = new List<CustomerFridge>();
    }
}