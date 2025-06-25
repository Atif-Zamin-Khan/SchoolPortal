using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class AddStudentViewRequest
    {
        [Required]
        public string studentName { get; set; } = string.Empty;
        [Required]
        public int classId { get; set; } = 0;
        [Required]
        public int age { get; set; } = 0;
        [Required]
        public string address { get; set; } = string.Empty;
        [Required]
        public string phoneNumber { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }

    public class AddStudentResponseView
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }
}
