using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Project.Models.ViewModel
{
    // For displaying maintenance faults in the list
    public class MaintenanceFaultVM
    {
        public int VisitId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string FridgeModel { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? VisitDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = "Medium";
        public bool HasReportedFault { get; set; }
        public string? Notes { get; set; }
    }

    // For displaying customer faults in the list
    public class CustomerFaultVM
    {
        public int FaultReportId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string FridgeModel { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ReportedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string? FaultType { get; set; }
    }

    // For reporting faults from maintenance visits
    public class MaintenanceFaultReportVM
    {
        [Required]
        public int VisitId { get; set; }

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
        public string Priority { get; set; } = "High";

        [Display(Name = "Request Replacement")]
        public bool RequestReplacement { get; set; }

        [Display(Name = "Upload Images")]
        public List<IFormFile>? FaultImages { get; set; }

        // Display properties
        public string CustomerName { get; set; } = string.Empty;
        public string TechnicianName { get; set; } = string.Empty;
        public List<CustomerFridge> AvailableFridges { get; set; } = new List<CustomerFridge>();
        public FridgeVisit? Visit { get; set; }
    }
}