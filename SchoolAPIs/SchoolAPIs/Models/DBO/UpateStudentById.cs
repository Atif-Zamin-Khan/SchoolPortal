namespace SchoolAPIs.Models.DBO
{
    public class UpdateStudentByIdRequestDbo
    {
        public int StudentId { get; set; } = 0;
        public string StudentName { get; set; } = string.Empty;
        public int ClassId { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }

    public class UpdateStudentByIdResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;
    }
}
