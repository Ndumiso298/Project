using Project.Utility;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FaultReport
    {
      
            public int FaultReportId { get; set; }

            public int? CustomerId { get; set; }

            public int FridgeInStockId { get; set; }
            public string Description { get; set; } = "";
            public string FaultType { get; set; } = "";
            public string Status { get; set; } = SD.Pending;
            public string Priority { get; set; } = "Medium";
            public DateTime ReportedDate { get; set; } = DateTime.Now;
            public DateTime? ResolvedDate { get; set; }

            public bool RequestReplacement { get; set; }
            public bool IsReplacementRequested { get; set; }
            public string? DeclineReason { get; set; }
            public bool IsRelaunched { get; set; }
            public int? OriginalFaultReportId { get; set; }

            public Customer? Customer { get; set; }


            public  FridgeInStock FridgeInStock { get; set; }

            public  ICollection<FaultTechnician> FaultTechnicians { get; set; } = new List<FaultTechnician>();
            public FaultReport? OriginalFaultReport { get; set; }
            public ICollection<FaultReport> RelaunchedFaultReports { get; set; } = new List<FaultReport>();
        
    }
}
