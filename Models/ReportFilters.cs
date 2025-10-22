namespace Project.Models
{
    public class ReportFilters
    {
        public string ReportType { get; set; }
        public string DateRange { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Technician { get; set; }
    }
}
