namespace SchoolAPIs.Models.DBO
{
    public class GetStudentByIdRequestDbo
    {
        public int Id { get; set; } = 0;
    }

    public class GetStudentByIdResponseDbo
    {
        public int Id { get; set; } = 0;
        public string Student_Name { get; set; } = string.Empty;
        public int cms_class_detail_Id { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set;} = string.Empty;
        public string ResponseCode {  get; set; } = string.Empty;   
        public string ResponseDescription { get; set; } = string.Empty;

    }

}
