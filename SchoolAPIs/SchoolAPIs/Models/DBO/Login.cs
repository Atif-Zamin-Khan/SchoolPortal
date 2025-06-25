using System.Data;

namespace SchoolAPIs.Models.DBO
{
    public class LoginRequestDbo
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDbo
    {
        public int Id { get; set ; } = 0;

        // for Super Admin
        public string Name { get; set; } = string.Empty;
        public string Passwrod { get; set; } = string.Empty;

        // for Emp and student
        public string employee_Name { get; set; } = string.Empty;
        public string student_Name { get; set; } = string.Empty;
       // public int cms_class_detail_Id { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Address {  get; set; } = string.Empty;
        public string phone_Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;    
        public string Class_Name {  get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Section { get; set;} = string.Empty;  

        public string Token { get; set; } = string.Empty;
        public int employee_role_Id { get; set; } = 0;

        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;

    }
}
