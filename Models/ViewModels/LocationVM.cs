using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class LocationVM
    {
        public int Id { get; set; }

        // ===== LOCATION IDENTIFICATION =====
        [Required(ErrorMessage = "Location name is required.")]
        [StringLength(100, ErrorMessage = "Location name cannot exceed 100 characters.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location type is required.")]
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

        // ===== AUDIT INFORMATION =====
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

        // ===== STATISTICS PROPERTIES =====
        [Display(Name = "Total Employees")]
        public int TotalEmployees { get; set; }

        [Display(Name = "Total Customers")]
        public int TotalCustomers { get; set; }

        [Display(Name = "Total Fridges")]
        public int TotalFridges { get; set; }

        [Display(Name = "Available Fridges")]
        public int AvailableFridges { get; set; }

        [Display(Name = "Allocated Fridges")]
        public int AllocatedFridges { get; set; }

        [Display(Name = "Under Maintenance")]
        public int UnderMaintenance { get; set; }

        [Display(Name = "Faulty Fridges")]
        public int FaultyFridges { get; set; }

        [Display(Name = "Pending Maintenance")]
        public int PendingMaintenance { get; set; }

        [Display(Name = "Open Faults")]
        public int OpenFaults { get; set; }

        [Display(Name = "Active Suppliers")]
        public int ActiveSuppliers { get; set; }

        [Display(Name = "Pending Orders")]
        public int PendingOrders { get; set; }

        // ===== CALCULATED PROPERTIES =====
        [Display(Name = "Utilization Rate")]
        public string UtilizationRate
        {
            get
            {
                if (TotalFridges == 0) return "0%";
                var rate = (double)AvailableFridges / TotalFridges * 100;
                return $"{rate:F1}%";
            }
        }

        [Display(Name = "Allocation Rate")]
        public string AllocationRate
        {
            get
            {
                if (TotalFridges == 0) return "0%";
                var rate = (double)AllocatedFridges / TotalFridges * 100;
                return $"{rate:F1}%";
            }
        }

        [Display(Name = "Capacity Utilization")]
        public string CapacityUtilization
        {
            get
            {
                if (!Capacity.HasValue || Capacity.Value == 0) return "N/A";
                var rate = (double)TotalFridges / Capacity.Value * 100;
                return $"{rate:F1}%";
            }
        }

        [Display(Name = "Operational Status")]
        public string OperationalStatus => !IsDeleted ? "Operational" : "Inactive";

        [Display(Name = "Location Summary")]
        public string Summary => $"{LocationType} - {Suburb}, {City}. {TotalFridges} fridges, {TotalCustomers} customers";

        [Display(Name = "Contact Summary")]
        public string ContactSummary
        {
            get
            {
                var contactInfo = new List<string>();
                if (!string.IsNullOrEmpty(ContactPerson)) contactInfo.Add(ContactPerson);
                if (!string.IsNullOrEmpty(ContactPhone)) contactInfo.Add(ContactPhone);
                if (!string.IsNullOrEmpty(ContactEmail)) contactInfo.Add(ContactEmail);
                return string.Join(" • ", contactInfo);
            }
        }

        // ===== VALIDATION METHODS =====
        public bool HasContactInformation()
        {
            return !string.IsNullOrEmpty(ContactPerson) ||
                   !string.IsNullOrEmpty(ContactPhone) ||
                   !string.IsNullOrEmpty(ContactEmail);
        }

        public bool IsNearCapacity()
        {
            return Capacity.HasValue && TotalFridges >= Capacity.Value * 0.9;
        }

        public string GetCapacityStatus()
        {
            if (!Capacity.HasValue) return "No capacity limit set";

            var percentage = (double)TotalFridges / Capacity.Value * 100;
            return percentage switch
            {
                >= 90 => "Critical - Near Full Capacity",
                >= 75 => "Warning - High Utilization",
                >= 50 => "Good - Moderate Utilization",
                _ => "Low - Underutilized"
            };
        }
        public static LocationVM FromEntity(Location entity)
        {
            if (entity == null) return null;

            return new LocationVM
            {
                Id = entity.Id,
                Name = entity.Name,
                LocationType = entity.LocationType,
                LocationCode = entity.LocationCode,
                StreetAddress = entity.StreetAddress,
                Suburb = entity.Suburb,
                City = entity.City,
                Province = entity.Province,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                ContactPerson = entity.ContactPerson,
                ContactPhone = entity.ContactPhone,
                ContactEmail = entity.ContactEmail,
                OperatingHours = entity.OperatingHours,
                Capacity = entity.Capacity,
                IsDeleted = entity.IsDeleted,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy
            };
        }
    }
    // Extension method for populating statistics
    public static class LocationVMExtensions
    {
        public static async Task<LocationVM> PopulateStatisticsAsync(this LocationVM vm, ApplicationDbContext context, int locationId)
        {
            vm.TotalEmployees = await context.Employees
                .CountAsync(e => e.WorkLocationId == locationId && !e.UserAccount.IsDeleted);

            vm.TotalCustomers = await context.Customers
                .CountAsync(c => c.TradingLocationId == locationId && c.AccountStatus == AccountStatus.Approved);

            vm.TotalFridges = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status != FridgeStatus.Scrapped);

            vm.AvailableFridges = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status == FridgeStatus.Available);

            vm.AllocatedFridges = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status == FridgeStatus.Allocated);

            var scrappedFridges = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status == FridgeStatus.Scrapped);

            vm.UnderMaintenance = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status == FridgeStatus.UnderMaintenance);

            vm.FaultyFridges = await context.Fridges
                .CountAsync(f => f.LocationId == locationId && f.Status == FridgeStatus.Quarantined);

            vm.PendingMaintenance = await context.MaintenanceVisits
                .CountAsync(mv => mv.LocationId == locationId &&
                                (mv.Status == ServicingStatus.Scheduled || mv.Status == ServicingStatus.InProgress));

            vm.OpenFaults = await context.FaultRecords
                .CountAsync(fr => fr.FaultLocationId == locationId &&
                                (fr.Status == FaultStatus.Reported || fr.Status == FaultStatus.Assigned || fr.Status == FaultStatus.InProgress));

            //vm.ActiveSuppliers = await context.Suppliers
            //    .CountAsync(s => s.PrimaryLocationId == locationId && s.IsActive && !s.IsDeleted);

            return vm;
        }
    }
}
