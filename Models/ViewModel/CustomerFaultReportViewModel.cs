using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class CustomerFaultReportViewModel
    {
        public int RequestHeaderId { get; set; }

        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        public string FridgeModel { get; set; } = string.Empty;

        public string? FridgeNo { get; set; }

        public DateTime ReportDate { get; set; }

        [Required(ErrorMessage = "Please select a fault type")]
        public string? FaultType { get; set; }

        [Required(ErrorMessage = "Please describe the fault")]
        public string? FaultDescription { get; set; }

        public string? AdditionalNotes { get; set; }
    }
}