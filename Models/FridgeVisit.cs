using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utility;
using Project.Controllers;

namespace Project.Models
{

    public class FridgeVisit

    {
        [Key]
        public int VisitId { get; set; }

        public DateTime VisitDate { get; set; }
        [Required]
        public string TechnicianName { get; set; }
       

        public string? Notes { get; set; }

        public string CustomerApproval { get; set; } = SD.Pending;
        public string? CheckupStatus { get; set; }=SD.NotStarted;

        public int RequestHeaderId { get; set; }
        [ForeignKey("RequestHeaderId")]
        [ValidateNever]
        public RequestHeader RequestHeader { get; set; }
       


        public ICollection<FaultTechnician> FaultTechnicians { get; set; } = new List<FaultTechnician>();
    }
}