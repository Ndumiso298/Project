namespace Project.Models.ViewModels
{
    public class FaultDashboardVM
    {
            public int TotalFaults { get; set; }
            public int OpenFaults { get; set; }
            public int ResolvedFaults { get; set; }
            public int HighPriorityFaults { get; set; }
            public List<FaultRecord> RecentFaults { get; set; } = new();
    }
}
