using System;

namespace Project.Models.ViewModel
{
    public class SupportNotificationVM
    {
        public int SupportNotificationId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int ReferenceId { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; }

        // Additional properties for display
        public string TimeAgo { get; set; }
        public string PriorityClass { get; set; }
    }
}