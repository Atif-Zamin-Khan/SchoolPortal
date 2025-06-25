using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Dto
{
    public class AllEmployeeResponseDto
    {
        public int employee_id { get; set; } = 0;
        public string employee_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int employee_role_id { get; set; } = 0;
        public string employee_role { get; set; } = string.Empty;
    }
}
