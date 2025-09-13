using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ViewModels
{
    public class EmployeeManagementVM
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public string SelectedRole { get; set; }
        public string CurrentRole { get; set; }

        // Additional properties for comprehensive management
        public List<FridgeAllocation> RecentAllocations { get; set; }
        public List<FridgeFault> AssignedFaults { get; set; }
        public List<FridgeMaintenance> ScheduledMaintenance { get; set; }

        // For performance metrics
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public double AverageResolutionTime { get; set; }

        // For availability management
        public string AvailabilityStatus { get; set; }
        public IEnumerable<SelectListItem> AvailabilityOptions { get; set; }
    }
}
