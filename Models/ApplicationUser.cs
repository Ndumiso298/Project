using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class ApplicationUser : IdentityUser

    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? CellNumber { get; set; }

        public bool IsApproved { get; set; } = false;
        public string? RejectionReason { get; set; }
   
        //public string? BusinessDocumentPath { get; set; }
        //public byte[]? BusinessDocumentData { get; set; } 
                                                            
        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public string UserClaim { get; set; }
        public string Status { get; internal set; }
        public DateTime? DeclinedAt { get; set; }
     
    }
}
