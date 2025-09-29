using Project.Utilities.Enums;

namespace Project.Helpers
{
    public static class ViewHelperExtensions
    {
        public static string GetServiceTypeBadge(this ServicingType serviceType)
        {
            return serviceType switch
            {
                ServicingType.Installation => "bg-primary",
                ServicingType.PreventiveMaintenance => "bg-warning",
                ServicingType.CorrectiveMaintenance => "bg-danger",
                _ => "bg-secondary"
            };
        }

        public static string GetStatusBadgeClass(this CustomerRequestStatus status)
        {
            return status switch
            {
                CustomerRequestStatus.Draft => "bg-warning",
                CustomerRequestStatus.InProgress => "bg-info",
                CustomerRequestStatus.Completed => "bg-success",
                CustomerRequestStatus.Cancelled => "bg-danger",
                _ => "bg-secondary"
            };
        }
    }
}
