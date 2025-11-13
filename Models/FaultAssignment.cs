using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class FaultAssignment
    {
        [Key]
        public int FaultAssignmentId { get; set; }

        [Required]
        public int FaultReportId { get; set; }
        [ForeignKey(nameof(FaultReportId))]
        public FaultReport FaultReport { get; set; } = null!;

        [Required]
        public string EmployeeId { get; set; } // This is ApplicationUserId from Employee table
        [ForeignKey(nameof(EmployeeId))]
        public ApplicationUser Employee { get; set; } = null!;

        public int? VisitId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public DateTime? ScheduledDate { get; set; }
        public string? TimeSlot { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}