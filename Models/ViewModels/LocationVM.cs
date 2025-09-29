using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class LocationVM
    {
        public int Id { get; set; }

        // Address Information
        [Required(ErrorMessage = "Address line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address line 1 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 1 *")]
        public string AddressLine1 { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Address line 2 cannot exceed 100 characters.")]
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Suburb is required.")]
        [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters.")]
        [Display(Name = "Suburb *")]
        public string Suburb { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        [Display(Name = "City *")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
        [Display(Name = "Province *")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postal code must be 4 digits")]
        [Display(Name = "Postal Code *")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; } = "South Africa";

        // Status Management
        [Display(Name = "Active Status")]
        public bool IsActive { get; set; } = true;

        // Audit Information
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

        // Computed Properties
        [Display(Name = "Full Address")]
        public string FullAddress
        {
            get
            {
                var parts = new List<string> { AddressLine1 };
                if (!string.IsNullOrEmpty(AddressLine2))
                    parts.Add(AddressLine2);
                parts.AddRange(new[] { Suburb, City, Province, PostalCode });
                return string.Join(", ", parts.Where(p => !string.IsNullOrEmpty(p)));
            }
        }

        [Display(Name = "Complete Address")]
        public string CompleteAddress => $"{FullAddress}, {Country}";

        // Statistics (for display purposes)
        [Display(Name = "Total Fridges")]
        public int TotalFridges { get; set; }

        [Display(Name = "Available Fridges")]
        public int AvailableFridges { get; set; }

        [Display(Name = "Total Customers")]
        public int TotalCustomers { get; set; }

        [Display(Name = "Total Employees")]
        public int TotalEmployees { get; set; }

        [Display(Name = "Pending Maintenance")]
        public int PendingMaintenance { get; set; }

        [Display(Name = "Open Faults")]
        public int OpenFaults { get; set; }

        [Display(Name = "Utilization Rate")]
        public string UtilizationRate => TotalFridges > 0
            ? $"{((double)AvailableFridges / TotalFridges) * 100:F1}%"
            : "N/A";

        // Validation Methods
        public string GetLocationSummary()
        {
            return $"{Suburb}, {City} - {TotalFridges} fridges, {TotalCustomers} customers";
        }
    }
}
