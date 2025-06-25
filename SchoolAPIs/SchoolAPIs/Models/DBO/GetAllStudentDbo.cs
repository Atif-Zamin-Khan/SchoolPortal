using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Xml.Linq;

namespace SchoolAPIs.Models.DBO
{
    public class GetAllStudentRequestDbo
    {

    }

    public class GetAllStudentResponseDbo
    {
        public int Id { get; set; } = 0;
        public  string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Clas { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } 
    }
}