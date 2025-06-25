namespace SchoolAPIs.Models.DTO
{
    public class UpdateStudentByIdRequestDto
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
    public class UpdateStudentByIdResponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }

}
