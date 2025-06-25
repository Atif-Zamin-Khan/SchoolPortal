namespace SchoolAPIs.Models.DBO
{
    public class DeleteStudentByIdRequestDbo
    {
        public int Id { get; set; } = 0;
        
    }

    public class DeleteStudentByIdResponseDbo
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;

    }
}
