using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Supplier name must be between 3 and 100 characters.")]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person name cannot exceed 100 characters.")]
        [Display(Name = "Contact Person")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [StringLength(20, ErrorMessage = "Fax number cannot exceed 20 characters.")]
        [Display(Name = "Fax Number")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "VAT number is required.")]
        [StringLength(20, ErrorMessage = "VAT number cannot exceed 20 characters.")]
        [Display(Name = "VAT Number")]
        public string VatNumber { get; set; }

        [StringLength(50, ErrorMessage = "Registration number cannot exceed 50 characters.")]
        [Display(Name = "Company Registration Number")]
        public string RegistrationNumber { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Updated")]
        public DateTime? UpdatedDate { get; set; }

        // Navigation properties for relationships
        public virtual ICollection<PurchaseRequest> PurchaseRequests { get; set; }
        //public virtual ICollection<RequestForQuotation> RequestsForQuotation { get; set; }
        //public virtual ICollection<Quotation> Quotations { get; set; }
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
