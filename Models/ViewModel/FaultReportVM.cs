using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class FaultReportVM
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a fridge")]
        public int FridgeInStockId { get; set; }

        [Required(ErrorMessage = "Please select a fault type")]
        public string? FaultType { get; set; }

        [Required(ErrorMessage = "Please describe the fault")]
        public string? Description { get; set; }

        public string? Priority { get; set; } = "Medium";

        public bool RequestReplacement { get; set; }

        public List<IFormFile>? FaultImages { get; set; }

        public List<CustomerFridge>? AvailableFridges { get; set; }
    }
}