namespace CollegeAPIs.Models.DTO
{
    public class GetAllStudentsClassResponseDto
    {
        public int studentid { get; set; } = 0;
        public string student_name { get; set; } = string.Empty;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phonenumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
       // public string token { get; set; } = string.Empty;
        public int classid { get; set; } = 0;
        public string section { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
    }

}
