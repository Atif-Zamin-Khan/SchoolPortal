using System.Data;

namespace CollegeAPIs.Models.DBO
{
    public class AddEmployeeRequestDbo
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
       // public string Role { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }
    public class AddEmployeeResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty; 
    }
}