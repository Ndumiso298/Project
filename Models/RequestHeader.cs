using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public string? Status { get; set; } = SD.Pending;
        public DateTime? ShippingDate { get; set; }
        public DateTime? PaymentDueDate { get; set; }

        public bool IsRelaunched { get; set; } = false;
        public int? OriginalRequestHeaderId { get; set; }
        [ForeignKey("OriginalRequestHeaderId")]
        [ValidateNever]
        public RequestHeader? OriginalRequest { get; set; }

        // NEW PROPERTIES FOR REPLACEMENT REQUESTS
        public bool IsReplacement { get; set; } = false;
        public int? OriginalFaultReportId { get; set; }
        [ForeignKey("OriginalFaultReportId")]
        [ValidateNever]
        public FaultReport? OriginalFaultReport { get; set; }

        // Navigation property for relaunched requests 
        [ValidateNever]
        public ICollection<RequestHeader> RelaunchedRequests { get; set; } = new List<RequestHeader>();

        public ICollection<RequestDetails> RequestFridges { get; set; }
        public ICollection<FridgeVisit> FridgeVisits { get; set; } = new List<FridgeVisit>();
    }
}