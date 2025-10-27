using System;



namespace Project.Models.ViewModel
{
    public class FaultDetailsVM
    {
        public string Source { get; set; } = string.Empty;
        public int? VisitId { get; set; }
        public int? FaultReportId { get; set; }

        // Customer Information
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Fridge Information
        public string FridgeModel { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        // Fault Information
        public string Description { get; set; } = string.Empty;
        public string FaultType { get; set; } = string.Empty;
        public DateTime? ReportedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string TechnicianNotes { get; set; } = string.Empty;

        // Images
        public List<FaultImage> FaultImages { get; set; } = new List<FaultImage>();
    }

    public class ScheduleRepairVM
    {
        public int FaultId { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime? ProposedDate { get; set; }
        public string TechnicianNotes { get; set; } = string.Empty;
        public int? ExistingBookingId { get; set; }
    }

    public class CalendarEventVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CustomerBookingStatus { get; set; } = string.Empty;
        public string TechnicianName { get; set; } = string.Empty;
        public bool IsOverdue { get; set; }
    }
}