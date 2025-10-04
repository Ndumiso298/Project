using Project.Utilities.Enums;

namespace Project.Helpers
{
    public static class ViewHelperExtensions
    {
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
