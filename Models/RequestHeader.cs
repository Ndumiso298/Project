using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Project.Utility;

namespace Project.Models
{
    public class RequestHeader
    {
        [Key]
        public int RequestHeaderId { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [ValidateNever]
        public Customer Customer { get; set; }

        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [ValidateNever]
        public Employee Employee { get; set; }

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
        public string? Status { get; set; } =SD.Pending;
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime? RejectionDate { get; set; }
        public string? AdditionalDocumentPath { get; set; }
        public string? AdditionalDescription { get; set; }
        public bool IsRelaunched { get; set; } = false;
        public bool IsReplacement { get; set; } = false;
        public int? OriginalRequestId { get; set; }


        public ICollection<RequestDetails> RequestFridges { get; set; }
        public ICollection<FridgeVisit> FridgeVisits { get; set; } = new List<FridgeVisit>();


    }
}
