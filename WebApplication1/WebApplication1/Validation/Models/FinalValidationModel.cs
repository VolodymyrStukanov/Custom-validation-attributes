

namespace WebApplication1.Validation.Models
{
    public class FinalValidationModel
    {
        public string Message { get; }
        public List<CustomValidationResult> ValidationErrors { get; }

        public FinalValidationModel(List<CustomValidationResult> errors)
        {
            Message = "Validation Failed";
            ValidationErrors = errors;
        }
    }
}
