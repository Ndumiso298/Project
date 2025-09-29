using System.ComponentModel.DataAnnotations;

namespace Project.Helpers
{
    public class ValidateEnumerableAttribute : ValidationAttribute
    {
        private readonly int _minCount;

        public ValidateEnumerableAttribute(int minCount = 1)
        {
            _minCount = minCount;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IEnumerable<object> collection)
            {
                if (collection.Count() < _minCount)
                {
                    return new ValidationResult(ErrorMessage ?? $"At least {_minCount} item(s) are required.");
                }

                // Validate each item in the collection
                var itemErrors = new List<ValidationResult>();
                foreach (var item in collection)
                {
                    var itemValidationContext = new ValidationContext(item);
                    var itemResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(item, itemValidationContext, itemResults, true))
                    {
                        itemErrors.AddRange(itemResults);
                    }
                }

                if (itemErrors.Any())
                {
                    return new ValidationResult($"Collection contains invalid items: {string.Join("; ", itemErrors.Select(e => e.ErrorMessage))}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
