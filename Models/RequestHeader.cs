using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Project.Models
{
    public class RequestHeader
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public Customer Customer { get; set; }

        public DateTime RequestDate { get; set; }
       
        public decimal RequestTotal { get; set; }                                                                          
       
       [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string CellNumber { get; set; }
        public string? Carrier { get; set; }
        public string? Status { get; set; } = "Waiting For Payment";
        public DateTime? ShippingDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }

        [ValidateNever]
        public ICollection<FridgeAllocation> Allocations { get; set; }
        [ValidateNever] 
        public ICollection<RequestDetail> RequestFridges { get; set; }
    }
}
