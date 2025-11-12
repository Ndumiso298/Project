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
            public FaultReport FaultReport { get; set; } = null!;
            public List<FaultComment> Comments { get; set; } = new List<FaultComment>();
            public List<FaultTimelineEvent> TimelineEvents { get; set; } = new List<FaultTimelineEvent>();
            public string NewComment { get; set; } = string.Empty;
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
