using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string? CustomerNumber { get; set; }

        [NotMapped]
        [Display(Name = "Business Proof Document")]
        public IFormFile? BusinessDocument { get; set; }

        public string? BusinessDocumentPath { get; set; }
        public byte[]? BusinessDocumentData { get; set; }

        public string CustomerNote { get; set; }
      
        // Navigation properties
        public virtual ICollection<Fridge> Fridges { get; set; } 
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; }
        public ICollection<Fault> Faults { get; set; }
        public ICollection<FridgeRequest> Requests { get; set; }
    }
}
