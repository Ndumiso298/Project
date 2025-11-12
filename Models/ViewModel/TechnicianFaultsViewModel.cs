using System.Collections.Generic;

namespace Project.Models.ViewModel
{
    public class TechnicianFaultsViewModel
    {
        public List<FridgeVisit> MaintenanceFaults { get; set; } = new List<FridgeVisit>();
        public List<FaultReport> CustomerReportedFaults { get; set; } = new List<FaultReport>();
    }
}