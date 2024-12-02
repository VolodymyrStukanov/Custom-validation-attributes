using WebApplication1.Validation.Models;
using WebApplication1.Validation.Interfaces;
using System.Reflection;

namespace WebApplication1.Validation.PropertyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeCharAttribute : AbstractPropertyAttribute
    {
        private readonly string Chars;
        private readonly string? MessagePattern;
        public ExcludeCharAttribute(string chars)
        {
            Chars = chars;
        }
        public ExcludeCharAttribute(string chars, string messagePattern)
        {
            Chars = chars;
            MessagePattern = messagePattern;
        }

        public override CustomValidationResult? Validate(object value, PropertyInfo property)
        {
            var valueString = (string)property.GetValue(value);

            if (valueString == null)
            {
                var errorMessage = ((ICustomValidationAttribute)this).FormatMessage(property.Name, "Property {0} is null");
                return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.empty);
            }
            for (int i = 0; i < Chars.Length; i++)
            {
                if (valueString.Contains(Chars[i]))
                {
                    var errorMessage = MessagePattern != null
                        ? ((ICustomValidationAttribute)this).FormatMessage(property.Name, MessagePattern)
                        : ((ICustomValidationAttribute)this).FormatMessage(property.Name);
                    return new CustomValidationResult(errorMessage, property.Name, ValidationErrorStatuses.unnecessarySymbols);
                }
            }
            return null;
        }
    }

}
