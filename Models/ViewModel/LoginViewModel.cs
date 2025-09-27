using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]//Defining password datatype
        public string Password { get; set; }

        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set;}
    }
}
