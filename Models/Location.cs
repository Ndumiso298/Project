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

        // ===== LOCATION IDENTIFICATION =====
        [Required(ErrorMessage = "Location name is required.")]
        [StringLength(100, ErrorMessage = "Location name cannot exceed 100 characters.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Location Type")]
        public LocationType LocationType { get; set; } = LocationType.Warehouse;

        [Display(Name = "Location Code")]
        [StringLength(20, ErrorMessage = "Location code cannot exceed 20 characters.")]
        public string? LocationCode { get; set; }

        // ===== ADDRESS INFORMATION =====
        [Required(ErrorMessage = "Street Address is required.")]
        [StringLength(100, ErrorMessage = "Street Address cannot exceed 100 characters.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Suburb is required.")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        [Display(Name = "Suburb")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [Display(Name = "Province")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be 4 digits")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; } = "South Africa";

        // ===== CONTACT INFORMATION =====
        [Display(Name = "Contact Person")]
        [StringLength(100, ErrorMessage = "Contact person name cannot exceed 100 characters.")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Contact Phone")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(15, ErrorMessage = "Contact phone cannot exceed 15 characters.")]
        public string? ContactPhone { get; set; }

        [Display(Name = "Contact Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Contact email cannot exceed 100 characters.")]
        public string? ContactEmail { get; set; }

        // ===== OPERATIONAL INFORMATION =====
        [Display(Name = "Operating Hours")]
        [StringLength(100, ErrorMessage = "Operating hours cannot exceed 100 characters.")]
        public string? OperatingHours { get; set; }

        [Display(Name = "Capacity")]
        [Range(0, 10000, ErrorMessage = "Capacity must be between 0 and 10,000.")]
        public int? Capacity { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; } = false;

        // ===== AUDIT FIELDS =====
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated By")]
        public string? UpdatedBy { get; set; }

        // ===== NAVIGATION PROPERTIES =====
        [ValidateNever]
        [Display(Name = "Employees")]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [ValidateNever]
        [Display(Name = "Customers")]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [ValidateNever]
        [Display(Name = "Fridges")]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        [ValidateNever]
        [Display(Name = "Fridge Allocations")]
        public virtual ICollection<FridgeAllocation> FridgeAllocations { get; set; } = new List<FridgeAllocation>();

        [ValidateNever]
        [Display(Name = "Maintenance Visits")]
        public virtual ICollection<MaintenanceVisit> MaintenanceVisits { get; set; } = new List<MaintenanceVisit>();

        [ValidateNever]
        [Display(Name = "Fault Reports")]
        public virtual ICollection<FaultRecord> FaultReports { get; set; } = new List<FaultRecord>();

        //[ValidateNever]
        //[Display(Name = "Suppliers")]
        //public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

        // ===== COMPUTED PROPERTIES =====
        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                var parts = new List<string> { StreetAddress, Suburb, City, Province, PostalCode };
                return string.Join(", ", parts.Where(p => !string.IsNullOrEmpty(p)));
            }
        }

        [Display(Name = "Complete Address")]
        public string CompleteAddress => $"{FullAddress}, {Country}";

        [Display(Name = "Location Identifier")]
        public string LocationIdentifier => !string.IsNullOrEmpty(LocationCode)
            ? $"{LocationCode} - {Name}"
            : Name;

        [Display(Name = "Current Utilization")]
        public double UtilizationRate => Capacity.HasValue && Capacity.Value > 0
            ? (double)Fridges.Count(f => f.Status != FridgeStatus.Scrapped) / Capacity.Value * 100
            : 0;

        [Display(Name = "Is Operational")]
        public bool IsOperational => !IsDeleted;
    }
}
