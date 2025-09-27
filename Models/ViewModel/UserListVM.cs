namespace Project.Models.ViewModel
{
    public class UserListVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserClaim { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }
}
