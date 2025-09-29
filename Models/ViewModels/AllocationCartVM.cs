using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels
{
    public class AllocationCartVM
    {
        public List<AllocationCartItemVM> Items { get; set; } = new();
        public AllocationCartItemVM NewItem { get; set; } = new();

        public int? CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; } = "No customer selected";

        [Display(Name = "Business Type")]
        public BusinessType CustomerBusinessType { get; set; }

        [Display(Name = "Customer Location")]
        public string CustomerLocation { get; set; } = "N/A";

        // Contact Information (Enhanced with validation)
        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Contact person cannot exceed 100 characters.")]
        [Display(Name = "Contact Person *")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [Display(Name = "Phone Number *")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        // Delivery Information (Enhanced with validation)
        [Required(ErrorMessage = "Delivery location is required.")]
        [Display(Name = "Delivery Location *")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid delivery location.")]
        public int? DeliveryLocationId { get; set; }

        [Display(Name = "Delivery Instructions")]
        [StringLength(500, ErrorMessage = "Delivery instructions cannot exceed 500 characters.")]
        public string? DeliveryInstructions { get; set; }

        [Display(Name = "Preferred Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PreferredDeliveryDate { get; set; }

        // Request Information
        [Required(ErrorMessage = "Request type is required.")]
        [Display(Name = "Request Type *")]
        public CustomerRequestType RequestType { get; set; } = CustomerRequestType.NewAllocation;

        [Required(ErrorMessage = "Priority is required.")]
        [Display(Name = "Priority *")]
        public CustomerRequestPriority Priority { get; set; } = CustomerRequestPriority.Medium;

        // Financial Information
        [Display(Name = "Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent.")]
        public decimal DiscountPercentage { get; set; }

        // Dropdown Lists (Added for form functionality)
        [ValidateNever]
        public IEnumerable<SelectListItem>? CustomerList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? LocationList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RequestTypeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? PriorityList { get; set; }

        // Summary Statistics
        [Display(Name = "Total Models Requested")]
        public int TotalModels => Items.Count;

        [Display(Name = "Total Fridges Requested")]
        public int TotalFridges => Items.Sum(i => i.Quantity);

        [Display(Name = "Total Monthly Rental")]
        [DataType(DataType.Currency)]
        public decimal TotalMonthlyRental => Items.Sum(i => i.MonthlyTotal);

        [Display(Name = "Total Contract Value")]
        [DataType(DataType.Currency)]
        public decimal TotalContractValue => Items.Sum(i => i.LineTotal);

        [Display(Name = "Discount Amount")]
        [DataType(DataType.Currency)]
        public decimal DiscountAmount => TotalContractValue * (DiscountPercentage / 100);

        [Display(Name = "Final Amount")]
        [DataType(DataType.Currency)]
        public decimal FinalAmount => TotalContractValue - DiscountAmount;

        [Display(Name = "Average Rental Duration")]
        public string AverageRentalDuration => Items.Any()
            ? $"{Items.Average(i => i.RentalDurationMonths):F1} months"
            : "N/A";

        // Stock Validation
        [Display(Name = "All Items Available")]
        public bool AllItemsAvailable => Items.All(i => i.HasSufficientStock);

        [Display(Name = "Out of Stock Items")]
        public int OutOfStockCount => Items.Count(i => !i.HasSufficientStock);

        [Display(Name = "Has Stock Issues")]
        public bool HasStockIssues => Items.Any(i => !i.HasSufficientStock);

        // Validation Properties
        [Display(Name = "Is Valid")]
        public bool IsValid => CustomerId.HasValue &&
                              CustomerId > 0 &&
                              Items.Any() &&
                              AllItemsAvailable &&
                              DeliveryLocationId.HasValue &&
                              !string.IsNullOrWhiteSpace(ContactPerson) &&
                              !string.IsNullOrWhiteSpace(PhoneNumber);

        [Display(Name = "Can Submit")]
        public bool CanSubmit => IsValid;

        [Display(Name = "Is Empty")]
        public bool IsEmpty => !Items.Any();

        // Business Logic Methods
        public IEnumerable<string> GetValidationErrors()
        {
            var errors = new List<string>();

            if (!CustomerId.HasValue || CustomerId <= 0)
                errors.Add("Customer selection is required");

            if (!DeliveryLocationId.HasValue)
                errors.Add("Delivery location is required");

            if (string.IsNullOrWhiteSpace(ContactPerson))
                errors.Add("Contact person is required");

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                errors.Add("Phone number is required");

            if (!Items.Any())
                errors.Add("At least one fridge model is required");

            var stockErrors = Items.Where(i => !i.HasSufficientStock)
                .Select(i => $"{i.ModelName}: Only {i.AvailableStock} available, requested {i.Quantity}");
            errors.AddRange(stockErrors);

            var invalidItems = Items.Where(i => !i.IsValid)
                .Select(i => $"{i.ModelName}: Invalid configuration (check quantity and duration)");
            errors.AddRange(invalidItems);

            return errors;
        }

        public void ApplyCustomerDiscount(decimal discountPercentage)
        {
            if (discountPercentage >= 0 && discountPercentage <= 100)
            {
                DiscountPercentage = discountPercentage;
                foreach (var item in Items)
                {
                    item.ApplyDiscount(discountPercentage);
                }
            }
        }

        public void UpdateCustomerInfo(Customer customer)
        {
            if (customer != null)
            {
                CustomerId = customer.Id;
                CustomerName = customer.TradingName;
                CustomerBusinessType = customer.BusinessType;
                CustomerLocation = customer.TradingLocation?.ToString() ?? "N/A";

                // Set default contact info from customer
                if (string.IsNullOrWhiteSpace(ContactPerson))
                    ContactPerson = customer.FullName;

                if (string.IsNullOrWhiteSpace(PhoneNumber))
                    PhoneNumber = customer.BusinessPhoneNumber;

                if (string.IsNullOrWhiteSpace(Email))
                    Email = customer.BusinessEmail;
            }
        }

        public void ClearCart()
        {
            Items.Clear();
            DiscountPercentage = 0;
        }

        public void RemoveItem(Guid tempId)
        {
            var item = Items.FirstOrDefault(i => i.TempId == tempId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public AllocationCartItemVM? GetItem(Guid tempId)
        {
            return Items.FirstOrDefault(i => i.TempId == tempId);
        }

        public bool ContainsFridgeModel(int fridgeModelId)
        {
            return Items.Any(i => i.FridgeModelId == fridgeModelId);
        }

        // Mapping to Request
        public AllocationRequestHeaderVM ToRequestHeaderVM()
        {
            return new AllocationRequestHeaderVM
            {
                CustomerId = CustomerId ?? 0,
                ContactPerson = ContactPerson,
                PhoneNumber = PhoneNumber,
                Email = Email,
                DeliveryLocationId = DeliveryLocationId ?? 0,
                DeliveryInstructions = DeliveryInstructions,
                PreferredDeliveryDate = PreferredDeliveryDate,
                RequestType = RequestType,
                Priority = Priority,
                DiscountPercentage = DiscountPercentage,
                RequestDetails = Items.Select(i => i.ToRequestDetailVM()).ToList()
            };
        }
    }
}
