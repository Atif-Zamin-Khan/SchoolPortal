using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Dto
{
    public class UpdateStudentDto
    {
        public int id { get; set; } = 0;
    }
    public class UpdateStudentResponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }

    public class UpdateStudentDtoResponse
    {
        public int id { get; set; } = 0;
        public string student_name { get; set; } = string.Empty;
        public int classid { get; set; } = 0;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phone_Number { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string Success { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }




    public class PostStudentDtoRequest
    {
        public int Studentid { get; set; } = 0;
        public string updateName { get; set; } = string.Empty;
        public int classId { get; set; } = 0;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string updateEmail { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

}
