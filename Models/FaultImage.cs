using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FaultImage
    {
        [Key]
        public int ImageId { get; set; }
        public int FaultReportId { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual FaultReport FaultReport { get; set; }
    }
}