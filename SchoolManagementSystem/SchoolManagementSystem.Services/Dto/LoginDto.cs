
namespace SchoolManagementSystem.Services.Dto
{
    public class LoginRequestDto
    {
        public string email {get; set;} = string.Empty;
        public string password {get; set;} = string.Empty ;
    }

    public class LoginResponseDto
    {
        /*public int id { get; set; } = 0;
        public string student_name { get; set; } = string.Empty;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string class_Name { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string section { get; set; } = string.Empty;*/
        public string role { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }

    public class LoginEmployeeResponseDto
    {
        public int id { get; set; } = 0;

        public string employee_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        // public string role { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        //public int employee_role_id { get; set; } = 0;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }

}
