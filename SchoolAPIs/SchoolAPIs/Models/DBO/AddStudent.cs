using System.Net;

namespace SchoolAPIs.Models.DBO
{
    public class AddStudentRequestDbo
    {
        public string StudentName { get; set; } = string.Empty;
        public int ClassId { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AddStudentResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;

    }

}