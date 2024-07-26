using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Health_Insurance_Application.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Identifier (Email, Phone Number, or Policy Number) is required.")]
        public string Username {  get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();


            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
           
            var phoneRegex = new Regex(@"^\+?[1-9]\d{1,14}$");

            if (!emailRegex.IsMatch(Username) && !phoneRegex.IsMatch(Username))
            {
                results.Add(new ValidationResult("Username must be a valid email, phone number"));
            }
            return results;
        }

    }
}
