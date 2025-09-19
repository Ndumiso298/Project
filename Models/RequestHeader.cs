using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Project.Models
{
    public class RequestHeader
    {
        [Key]
        public int RequestHeaderId { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime RequestDate { get; set; }
       
        public double RequestTotal { get; set; }
      
                                                                                                                         
       
       [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string CellNumber { get; set; }
        public string? Carrier { get; set; }
        public string? Status { get; set; } = "Waiting For Payment";
        public DateTime? ShippingDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public ICollection<Allocation> Allocations { get; set; }
        public ICollection<RequestDetails> RequestFridges { get; set; }
    }
}
