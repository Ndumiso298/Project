using System.ComponentModel.DataAnnotations;

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
    }

}
