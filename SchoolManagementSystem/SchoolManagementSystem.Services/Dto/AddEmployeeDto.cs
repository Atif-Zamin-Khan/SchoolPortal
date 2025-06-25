using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Dto
{
    public class AddEmployeeDtoRequest
    {
        public string employeeName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        // public string role { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string roleId { get; set; } = string.Empty;

    }
    public class AddEmployeeDtoResponse
    {
        public string success { get; set; } = string.Empty;
        public string Message {  get; set; } = string.Empty;    
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }
}

