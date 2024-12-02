using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using WebApplication1.Validation.Interfaces;
using WebApplication1.Validation.Models;

namespace WebApplication1.Validation.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var result = new List<CustomValidationResult>();
            foreach (var argument in context.ActionArguments)
            {
                var properties = argument.Value?.GetType().GetProperties();
                if(properties != null)
                {
                    foreach (var property in properties)
                    {
                        var attributes = property.GetCustomAttributes()
                            .OfType<ICustomValidationAttribute>()
                            .ToList();
                        attributes.ForEach(attribute =>
                        {
                            var validationResult = attribute.Validate(argument.Value!, property);
                            if (validationResult != null)
                            {
                                validationResult.FieldName = argument.Key + "." + validationResult.FieldName;
                                result.Add(validationResult);
                            }
                        });
                    }
                }                
            }
            if (result.Count != 0)
            {
                context.Result = new ValidationResponse(result);
            }
        }
        public virtual void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
