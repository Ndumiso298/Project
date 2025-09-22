using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FridgeVisit
    {
        [Key]
        public int VisitId { get; set; }
       
        public DateTime VisitDate { get; set; }
        public string TechnicianName { get; set; }
        public string Notes { get; set; }

        public int RequestHeaderId { get; set; }
        [ForeignKey("RequestHeaderId")]
        [ValidateNever]
        public RequestHeader RequestHeader { get; set; }
    }
}
