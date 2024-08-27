using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Validation.Models
{
    public class ValidationResponse : ObjectResult
    {
        public ValidationResponse(List<CustomValidationResult> errors) : base(new FinalValidationModel(errors))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
