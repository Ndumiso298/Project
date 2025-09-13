using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class FridgeRequest
    {
        [Key]
        public int FridgeRequestId { get; set; }

        // Customer making the request
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // Faulty fridge being replaced
        public int FaultyFridgeId { get; set; }
        public virtual Fridge FaultyFridge { get; set; }

        // Reason for replacement
        public string IssueDescription { get; set; } // e.g., "Compressor failure", "Not cooling"

        // Desired specifications for the new fridge
        public string PreferredModel { get; set; } // Optional
        public string CapacityRequirement { get; set; } // e.g., "300L", "Double-door"
      
        // Request metadata
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Approved", "Rejected", "Completed"
        public string TechnicianNotes { get; set; } // Optional notes from technician or admin

        // Optional: Link to resolution or replacement fridge
        public int? ReplacementFridgeId { get; set; }
        public virtual Fridge ReplacementFridge { get; set; }
    }
}