using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Dto
{
    public class DeleteStudentDtoRequest
    {
        public int id { get; set; } = 0;
    }


    public class DeleteEmpDtoRequest
    {
        public int id { get; set; } = 0;

    }


    public class DeleteStudentDtoResponse
    {
        public int id { get; set; } = 0;
        public string role { get; set; } = string.Empty;
        public string Success { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }
}
