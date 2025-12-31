namespace Project.Utility
{
    public static class SD
    {
        // Role Constants
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";
        public const string CustomerSupport = "CustomerSupport";
        public const string StockController = "StockController";
        public const string FaultTechnician = "FaultTech";
        public const string MaintenanceTechnician = "MaintenanceTech";

        // Scrapping Status Constants
        public const string ScrappingPending = "Pending";
        public const string ScrappingApproved = "Approved";
        public const string ScrappingRejected = "Rejected";

        // Fridge Status Constants
        public const string FridgeAvailable = "Available";
        public const string FridgeAllocated = "Allocated";
        public const string FridgeScrapped = "Scrapped";
        public const string FridgePendingScrapping = "Pending Scrapping";
        public const string FaultScrapped = "Scrapped";


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

        // General Status Constants
        public const string Available = "Available";
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
        public const string Pending = "Pending";
        public const string Replaced = "Replaced";
        public const string Declined = "Decline";
        public const string Reported = "Reported";
        public const string InProgress = "In Progress";
        public const string Completed = "Completed";
        public const string NotStarted = "Not Started";

        // Notification Types
        public const string Success = "Success";
        public const string Error = "Error";
        public const string Warning = "Warning";
        public const string Info = "Info";
    }
}