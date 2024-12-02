using System.Reflection;
using WebApplication1.Validation.Models;

namespace WebApplication1.Validation.Interfaces
{
    public interface ICustomValidationAttribute
    {
        public CustomValidationResult? Validate(object value, PropertyInfo property);
        public string FormatMessage(string variable, string pattern = "There is error in field {0}");
    }
}
