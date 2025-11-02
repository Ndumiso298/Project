using System;

namespace Project.Models.ViewModel
{
    public class SupportNotificationVM
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int ReferenceId { get; set; }
        public string Priority { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }
    }
}