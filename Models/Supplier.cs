using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        // Navigation to address/location
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        // Navigation to supplied fridges
        public virtual ICollection<SupplierFridge> SuppliedFridges { get; set; } = new List<SupplierFridge>();
        //// Navigation to purchase orders
        //public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        //public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }

        // Optional: Additional properties based on project needs
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string Notes { get; set; }

        [Display(Name = "Preferred Supplier")]
        public bool IsPreferred { get; set; } = false;

        [Range(0, double.MaxValue, ErrorMessage = "Credit limit must be a positive value.")]
        [Display(Name = "Credit Limit")]
        public decimal CreditLimit { get; set; } = 0;

        [StringLength(50, ErrorMessage = "Payment Terms cannot exceed 50 characters.")]
        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; } // e.g., "Net 30 days"
    }

}
