using Project.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeReplacement
    {
        [Key]
        public int FridgeReplacementId { get; set; }

        [Required]
        public int VisitId { get; set; }
        [ForeignKey("VisitId")]
        public FridgeVisit? FridgeVisit { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [Required]
        public string OldFridgeNo { get; set; } = string.Empty;

        [Required]
        public string ReasonForReplacement { get; set; } = string.Empty;
        public string? AdditionalNotes { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime ReplacementDate { get; set; }

        [Required]
        public string ReplacementStatus { get; set; } = SD.Pending;

        public string? DeclineReason { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        // New fridge allocation
        public int? NewFridgeInStockId { get; set; }
        [ForeignKey("NewFridgeInStockId")]
        public FridgeInStock? NewFridgeInStock { get; set; }

        public string? TechnicianNotes { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionBy { get; set; }
        public string? ApprovedBy { get; set; }
    }
}