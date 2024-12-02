using System.Reflection;
using WebApplication1.Validation.Interfaces;
using WebApplication1.Validation.Models;

namespace WebApplication1.Validation.PropertyAttributes
{
    public abstract class AbstractPropertyAttribute : Attribute, ICustomValidationAttribute
    {
        public abstract CustomValidationResult? Validate(object value, PropertyInfo property);
        public string FormatMessage(string variable, string pattern = "There is error in field {0}")
        {
            return string.Format(pattern, variable);
        }
    }
}