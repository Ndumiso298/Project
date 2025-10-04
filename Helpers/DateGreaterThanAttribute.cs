using System.ComponentModel.DataAnnotations;

namespace Project.Helpers
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var currentValue = (DateTime)value;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException($"Property {_comparisonProperty} not found");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue.HasValue && currentValue <= comparisonValue.Value)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be after {GetDisplayName(_comparisonProperty)}");
            }

            return ValidationResult.Success;
        }

        private string GetDisplayName(string propertyName)
        {
            // Simple conversion from property name to display name
            return propertyName switch
            {
                "AllocationDate" => "Allocation Date",
                "RequestDate" => "Request Date",
                "RentalStartDate" => "Rental Start Date",
                _ => propertyName
            };
        }
    }
}