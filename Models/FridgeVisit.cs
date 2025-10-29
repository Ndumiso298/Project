using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utility;

namespace Project.Models
{
    public class FridgeVisit
    {
        [Key]
        public int VisitId { get; set; }

        public DateTime VisitDate { get; set; }

        [Required]
        public string TechnicianName { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public string CustomerApproval { get; set; } = SD.Pending;
        public string? CheckupStatus { get; set; } = SD.NotStarted;

        public int RequestHeaderId { get; set; }

        [ForeignKey("RequestHeaderId")]
        [ValidateNever]
        public virtual RequestHeader RequestHeader { get; set; } = null!;

     
        public virtual ICollection<FaultReport> FaultReports { get; set; } = new List<FaultReport>();
        public virtual ICollection<FaultTechnician> FaultTechnicians { get; set; } = new List<FaultTechnician>();
    }
}