using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Project.Utility;

namespace Project.Models
{
    public class FaultTechnician
    {
        [Key]
        public int FaultId { get; set; }

       
        [Required]
        [Display(Name = "Fault Description")]
        public string FaultDescription { get; set; }

        [Display(Name = "Repair Status")]
        public string RepairStatus { get; set; } = SD.Pending;

        [Display(Name = "Technician Assigned")]
        public string? TechnicianAssigned { get; set; }

        [Display(Name = "Resolution Notes")]
        public string? ResolutionNotes { get; set; }


        [Display(Name ="Booking Date")]
        public DateTime? Bookingate { get; set; }


        [Display(Name = "Completion Date")]
        public DateTime? Completion { get; set; }
        [Display(Name = "Customer Booking Status")]
        public string CustomerBookingStatus { get; set; } = SD.Pending; // New field


        public int VisitId { get; set; }
        [ForeignKey("VisitId")]
        [ValidateNever]
        public FridgeVisit FridgeVisit { get; set; }

    }
}
