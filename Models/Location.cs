using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project.Utilities.Enums;

namespace Project.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        // Address information
        [Required(ErrorMessage = "Address line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Suburb is required.")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be 4 digits")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; } = "South Africa";

        // Status
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        // Metadata
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        [StringLength(450, ErrorMessage = "Created by cannot exceed 450 characters.")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Last Updated")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ModifiedAt { get; set; }

        [Display(Name = "Modified By")]
        [StringLength(450, ErrorMessage = "Updated by cannot exceed 450 characters.")]
        public string? ModifiedBy { get; set; }

        // Navigation properties
        [ValidateNever]
        [Display(Name = "Employees")]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [ValidateNever]
        [Display(Name = "Customers")]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [ValidateNever]
        [Display(Name = "Fridges")]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        // ADD THIS: Fridge Allocations related to this location
        [ValidateNever]
        [Display(Name = "Fridge Allocations")]
        public virtual ICollection<FridgeAllocation> FridgeAllocations { get; set; } = new List<FridgeAllocation>();

        // ADD THIS: Maintenance visits at this location
        [ValidateNever]
        [Display(Name = "Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        // ADD THIS: Fault reports at this location
        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

        // Computed properties
        [NotMapped]
        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                var address = AddressLine1;
                if (!string.IsNullOrWhiteSpace(AddressLine2))
                    address += $", {AddressLine2}";
                address += $", {Suburb}, {City}, {Province}, {PostalCode}, {Country}";
                return address;
            }
        }
    }
}
