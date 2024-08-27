using WebApplication1.Validation.PropertyAttributes;

namespace WebApplication1.Validation.Models
{
    public class CustomValidationResult
    {
        public int StatusCode { get; }
        public string FieldName { get; set; }
        public string Message { get; }
        public CustomValidationResult(string errorMessage, string fieldName, ValidationErrorStatuses statusCode)
        {
            Message = errorMessage;
            StatusCode = (int)statusCode;
            FieldName = fieldName;
        }
    }
}
