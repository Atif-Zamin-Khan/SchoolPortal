namespace SchoolAPIs.Models.DTO
{
    public class AddStudentRequestDto
    {
        public string studentName { get; set; } = string.Empty;
        public int classId { get; set; } = 0;
        public int age { get; set; } = 0;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class AddStudentResponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }

}
