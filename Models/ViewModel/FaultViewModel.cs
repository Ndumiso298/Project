namespace Project.Models.ViewModel
{
    public class FaultViewModel
    {
        public int Id { get; set; }
        public string Source { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string FridgeModel { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ReportedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string? FaultType { get; set; }
        public string? AdditionalNotes { get; set; }

        // Add this property
        public bool HasReportedFault { get; set; }
    }
}