using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class AddEmployeeViewRequest
    {
        public string employeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [CustomEmailValidation(ErrorMessage = "Email must contain '@' symbol.")]
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string roleId { get; set; } = string.Empty;

   /*     public int id { get; set; } = 0;
        public string role { get; set; } = string.Empty;*/

    }
    public class AddEmployeeViewResponse
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }

    public class CustomEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !value.ToString().Contains("@"))
            {
                return new ValidationResult("Email must contain '@' symbol.");
            }
            return ValidationResult.Success;
        }
    }

}

