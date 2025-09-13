using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string CustomerNote { get; set; }
      
        // Navigation properties
        public virtual ICollection<Fridge> Fridges { get; set; } 
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; }
        public ICollection<Fault> Faults { get; set; }
        public ICollection<FridgeRequest> Requests { get; set; }
    }
}
