using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class CustomerFaultReportViewModel
    {
        public int VisitId { get; set; }
        public int RequestHeaderId { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? FridgeNo { get; set; }
        public string? FridgeModel { get; set; }

        [Required]
        public string? FaultType { get; set; }

        [Required]
        public string? FaultDescription { get; set; }

        public string? AdditionalNotes { get; set; }
        public DateTime ReportDate { get; set; }
    }
}