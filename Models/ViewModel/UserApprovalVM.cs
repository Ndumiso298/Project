namespace Project.Models.ViewModel
{
    public class UserApprovalVM
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        public string Reason { get; set; } 
    }
}

