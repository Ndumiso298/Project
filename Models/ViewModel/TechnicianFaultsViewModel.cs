using Project.Utility;
using System.Collections.Generic;

namespace Project.Models.ViewModel
{
    public class TechnicianFaultsViewModel
    {
        public List<FridgeVisit> MaintenanceFaults { get; set; } = new List<FridgeVisit>();
        public List<FaultReport> CustomerReportedFaults { get; set; } = new List<FaultReport>();
    }


    public class FaultDetailsViewModel
    {
        public required FaultReport FaultReport { get; set; }
        public List<FaultComment> Comments { get; set; } = new List<FaultComment>();
        public List<FaultTimelineEvent> TimelineEvents { get; set; } = new List<FaultTimelineEvent>(); // Changed from TimelineEvent

        // Non-hardcoded status properties with null checks
        public bool IsClosed => FaultReport?.Status?.Equals(SD.FaultClosed, StringComparison.OrdinalIgnoreCase) == true;
        public bool IsResolved => FaultReport?.Status?.Equals(SD.FaultResolved, StringComparison.OrdinalIgnoreCase) == true;
        public bool IsScrapped => FaultReport?.Status?.Equals(SD.FaultScrapped, StringComparison.OrdinalIgnoreCase) == true;
        public bool CanBeClosed => IsResolved && !IsClosed;

        // Role-based access properties
        public bool IsCustomerView { get; set; }
        public bool IsTechnicianView { get; set; }
    }

    public class FaultTimelineEvent
        {
            public string EventType { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public DateTime EventDate { get; set; }
            public string Icon { get; set; } = string.Empty;
            public string Color { get; set; } = string.Empty;
        }
    }
