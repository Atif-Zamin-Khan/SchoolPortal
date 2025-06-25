using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Dto
{
    public class UpdateEmployeeDtoRequest
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int roleId { get; set; } = 0;
        public string password { get; set; } = string.Empty;
        /* public int id { get; set; } = 0;
         //public int roleId { get; set; } = 0;
         public int employee_role_id { get; set }
         public string email { get; set; } = string.Empty;
         public string password { get; set; } = string.Empty;*/
    }
    public class UpdateEmployeeDtoResponse
    {
/*        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int roleId { get; set; } = 0;
        public string password { get; set; } = string.Empty;*/
        public string Success { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
        /*   public int id { get; set; } = 0;
           public int roleId { get; set; } = 0;
           public string email { get; set; } = string.Empty;
           public string password { get; set; } = string.Empty;*/
    }
}
