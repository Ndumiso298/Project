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

        [StringLength(10, ErrorMessage = "Location code cannot exceed 10 characters.")]
        [Display(Name = "Location Code")]
        public string? LocationCode { get; set; } // Short code for internal reference

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
        public string Country { get; set; } = "South Africa"; // Default value

        // Location characteristics
        [Required(ErrorMessage = "Location type is required.")]
        [Display(Name = "Location Type")]
        public LocationType Type { get; set; }

        // Type-specific properties
        [StringLength(20, ErrorMessage = "Warehouse code cannot exceed 20 characters.")]
        [Display(Name = "Warehouse Code")]
        public string? WarehouseCode { get; set; } // For warehouse locations

        [StringLength(50, ErrorMessage = "Supplier code cannot exceed 50 characters.")]
        [Display(Name = "Supplier Code")]
        public string? SupplierCode { get; set; } // For supplier locations

        // Contact information
        [Phone(ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Location Phone")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Location Email")]
        public string? Email { get; set; }

        // Manager/contact person at this location
        [Display(Name = "Location Manager")]
        public string? ManagerName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [Display(Name = "Manager Phone")]
        public string? ManagerPhone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Manager Email")]
        public string? ManagerEmail { get; set; }

        // Operational details
        [Display(Name = "Operating Hours")]
        public string? OperatingHours { get; set; }

        [Display(Name = "Service Area Radius (km)")]
        [Range(0, 1000, ErrorMessage = "Service area radius must be between 0 and 1000 km.")]
        public int? ServiceAreaRadius { get; set; } // For service centers

        // Capacity tracking (for warehouses)
        [Display(Name = "Storage Capacity (units)")]
        [Range(0, 10000, ErrorMessage = "Storage capacity must be a positive value.")]
        public int? StorageCapacity { get; set; }

        [Display(Name = "Current Occupancy (units)")]
        [Range(0, 10000, ErrorMessage = "Current occupancy must be a positive value.")]
        public int? CurrentOccupancy { get; set; }

        [NotMapped]
        [Display(Name = "Available Capacity")]
        public int? AvailableCapacity => StorageCapacity.HasValue && CurrentOccupancy.HasValue
            ? StorageCapacity.Value - CurrentOccupancy.Value
            : null;

        // Status
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        // Metadata
        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ValidateNever]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [ValidateNever]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [ValidateNever]
        public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();

        // Computed properties
        [NotMapped]
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

        [NotMapped]
        [Display(Name = "Is Warehouse")]
        public bool IsWarehouse => Type == LocationType.Warehouse || Type == LocationType.DistributionCenter;

        [NotMapped]
        [Display(Name = "Is Customer Facing")]
        public bool IsCustomerFacing => Type == LocationType.CustomerSite || Type == LocationType.RetailStore || Type == LocationType.ServiceCentre;
    }
}
