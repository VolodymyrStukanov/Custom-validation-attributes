using WebApplication1.Validation.Models;
using WebApplication1.Validation.Interfaces;
using System.Reflection;

namespace WebApplication1.Validation.PropertyAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomRangeAttribute : AbstractPropertyAttribute
    {
        readonly private int MaxValue;
        readonly private int MinValue;
        private readonly string MessagePattern;
        public CustomRangeAttribute(int minValue, int maxValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
        public CustomRangeAttribute(int minValue, int maxValue, string messagePattern)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            MessagePattern = messagePattern;
        }

        public override CustomValidationResult? Validate(object value, PropertyInfo propertyInfo)
        {
            int? intValue = (int?)propertyInfo.GetValue(value);

            if (intValue == null)
            {
                var errorMessage = ((ICustomValidationAttribute)this).FormatMessage(propertyInfo.Name, "Property {0} is null");
                return new CustomValidationResult(errorMessage, propertyInfo.Name, ValidationErrorStatuses.empty);
            }

            if (intValue > MaxValue || intValue < MinValue)
            {
                var errorMessage = MessagePattern != null
                            ? ((ICustomValidationAttribute)this).FormatMessage(propertyInfo.Name, MessagePattern)
                            : ((ICustomValidationAttribute)this).FormatMessage(propertyInfo.Name);
                return new CustomValidationResult(errorMessage, propertyInfo.Name, ValidationErrorStatuses.outOfRangeValue);
            }
            return null;
        }
    }
}
