using System.Reflection;
using WebApplication1.Validation.Interfaces;
using WebApplication1.Validation.Models;

namespace WebApplication1.Validation.PropertyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomMaxLengthAttribute : AbstractPropertyAttribute
    {
        private readonly int Length;
        private readonly string? MessagePattern;
        public CustomMaxLengthAttribute(int length)
        {
            Length = length;
        }
        public CustomMaxLengthAttribute(int length, string messagePattern)
        {
            Length = length;
            MessagePattern = messagePattern;
        }

        public override CustomValidationResult? Validate(object value, PropertyInfo property)
        {
            var valueString = (string?)property.GetValue(value);

            if (valueString == null)
            {
                var errorMessage = ((ICustomValidationAttribute)this).FormatMessage(property.Name, "Property {0} is null");
                return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.empty);
            }

            if (value != null && valueString.Length > Length)
            {
                var errorMessage = MessagePattern != null
                        ? ((ICustomValidationAttribute)this).FormatMessage(property.Name, MessagePattern)
                        : ((ICustomValidationAttribute)this).FormatMessage(property.Name);
                return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.outOfLength);
            }
            return null;
        }
    }
}
