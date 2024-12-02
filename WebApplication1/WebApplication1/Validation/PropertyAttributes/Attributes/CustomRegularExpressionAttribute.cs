using System.Text.RegularExpressions;
using WebApplication1.Validation.Models;
using WebApplication1.Validation.Interfaces;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Validation.PropertyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomRegularExpressionAttribute : AbstractPropertyAttribute
    {
        private readonly string Pattern;
        private readonly string? MessagePattern;
        public CustomRegularExpressionAttribute([StringSyntax("Regex")] string pattern)
        {
            Pattern = pattern;
        }
        public CustomRegularExpressionAttribute([StringSyntax("Regex")] string pattern, string messagePattern)
        {
            Pattern = pattern;
            MessagePattern = messagePattern;
        }

        public override CustomValidationResult? Validate(object value, PropertyInfo property)
        {
            var stringValue = (string?)property.GetValue(value);
            if (string.IsNullOrEmpty(stringValue))
            {
                var errorMessage = ((ICustomValidationAttribute)this).FormatMessage(property.Name, "Property {0} is null");
                return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.empty);
            }

            if (!Regex.IsMatch(stringValue, Pattern))
            {
                var errorMessage = MessagePattern != null
                            ? ((ICustomValidationAttribute)this).FormatMessage(property.Name, MessagePattern)
                            : ((ICustomValidationAttribute)this).FormatMessage(property.Name);
                return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.wrongStringFormat);
            }
            return null;
        }
    }
}
