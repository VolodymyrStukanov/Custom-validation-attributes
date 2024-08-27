using System.ComponentModel.DataAnnotations;
using WebApplication1.Validation.PropertyAttributes.Attributes;

namespace WebApplication1.Models
{
    public class MyModel
    {
        [ExcludeChar("<?>,./!@#")]
        [CustomMaxLength(15)]
        public string? Name { get; set; }

        [MaxLength(10)]
        [CustomMaxLength(100)]
        public string? Description { get; set; }

        [CustomRange(0, 5000)]
        public int? Salary { get; set; }

        [CustomRegularExpression(@"^(([a-z0-9]+(.[a-z0-9])+))@([a-z]+)((.([a-z]{2,3}))+)$", "Wrong email format")]
        public string Email { get; set; }

        [CustomRegularExpression(@"^([0-9]{10})$")]
        public string Phone { get; set; }
    }
}
