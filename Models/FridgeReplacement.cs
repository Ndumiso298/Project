using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeReplacement
    {
        public int FridgeReplacementId { get; set; }

        public int VisitId { get; set; }
        public FridgeVisit FridgeVisit { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int? NewFridgeInStockId { get; set; }
        public FridgeInStock NewFridgeInStock { get; set; }

        public string OldFridgeNo { get; set; }
        public string ReasonForReplacement { get; set; }
        public string AdditionalNotes { get; set; }

        public DateTime ReplacementDate { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string ReplacementStatus { get; set; } = "Pending";

        public string? ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}