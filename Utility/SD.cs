namespace Project.Utility
{
    public static class SD
    {
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";
        public const string CustomerSupport = "CustomerSupport";
        public const string StockController = "StockController";
        public const string FaultTechnician = "FaultTech";
        public const string MaintenanceTechnician = "MaintenanceTech";


        // Visit Status Constants
        public const string VisitFailed = "Failed";
        public const string VisitRepairScheduled = "Repair Scheduled";

        // Priority Constants
        public const string PriorityMedium = "Medium";

        // Fault Type Constants
        public const string FaultTypeRepair = "Maintenance Repair";
       
        // Technician Status
        public const string TechnicianScheduled = "Scheduled";
        public const string TechnicianPending = "Pending Schedule";
        public const string Scheduled = "Scheduled";

        // Time Slots
        public static readonly string[] TimeSlots = new[]
        {
        "09:00-11:00",
        "11:00-13:00",
        "13:00-15:00",
        "15:00-17:00"
    };


        public const string Allocated = "Allocated";
        public const string WaitingForPayment = "Waiting For Payment";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
        public const string Shipped = "Shipped";
        public const string Cancelled = "Cancelled";
        public const string Closed = "Closed";
        public const string Relaunched = "Relaunched";
        public const string FaultResolved = "Fault Resolved";
        public const string FaultPending = "Fault Pending";
        public const string FaultClosed = "Closed";
        public const string FaultScrapped = "Scrapped";
        public const string Pending = "Pending";
        public const string Replaced = "Replaced";
        public const string Declined = "Decline";
        public const string Reported = "Reported";
        public const string InProgress = "In Progress";
        public const string NotStarted = "Not Started";
        public const string Success = "Success";
        public const string Error = "Error";

    }
}
