namespace ParkViewServices.Helpers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Property with name {_otherPropertyName} not found.");
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value is DateTime dateValue && otherPropertyValue is DateTime otherDateValue)
            {
                if (dateValue > otherDateValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"{validationContext.DisplayName} must be greater than {_otherPropertyName}.");
        }
    }

}
