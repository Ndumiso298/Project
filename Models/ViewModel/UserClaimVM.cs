namespace Project.Models.ViewModel
{
    public class UserClaimVM
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Claims { get; set; }
    }
}
