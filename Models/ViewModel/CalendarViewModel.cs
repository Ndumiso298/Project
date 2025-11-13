namespace Project.Models.ViewModel
{
    public class CalendarViewModel
    {
        public List<CalendarRepairItem> Repairs { get; set; } = new List<CalendarRepairItem>();
    }

    public class CalendarRepairItem
    {
        public int Id { get; set; }
        public int? VisitId { get; set; }
        public DateTime Date { get; set; }
        public string Technician { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string FridgeModel { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
