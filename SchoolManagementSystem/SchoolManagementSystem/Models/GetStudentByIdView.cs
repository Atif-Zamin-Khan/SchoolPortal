namespace SchoolManagementSystem.Models
{
    public class GetStudentByIdRequestView
    {
        public int id { get; set; } = 0;

    }
    public class GetStudentByIdResponseView
    {
        public int id { get; set; } = 0;
        public string Student_name { get; set; } = string.Empty;
        public int classid { get; set; } = 0;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phone_Number { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }


}

