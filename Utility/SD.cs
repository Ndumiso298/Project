namespace Project.Utility
{


    
    public static class SD
    {
        // Existing roles
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";
        public const string CustomerSupport = "CustomerSupport";
        public const string StockController = "StockController";
        public const string FaultTechnician = "FaultTech";
        public const string MaintenanceTechnician = "MaintenanceTech";

        // Status constants
        public const string Allocated = "Allocated";
        public const string WaitingForPayment = "Waiting For Payment";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
        public const string NeedsFeedback = "Needs Feedback";
        public const string FaultResolved = "Fault Resolved";
        public const string FaultPending = "Fault Pending";
        public const string Pending = "Pending";
        public const string Declined = "Decline";
        public const string NotStarted = "Not Started";
        public const string Success = "Success";
        public const string Error = "Error";

        // New constants for fault management
        public const string InProgress = "In Progress";
        public const string Completed = "Completed";
        public const string HighPriority = "High";
        public const string MediumPriority = "Medium";
        public const string LowPriority = "Low";
    }
}