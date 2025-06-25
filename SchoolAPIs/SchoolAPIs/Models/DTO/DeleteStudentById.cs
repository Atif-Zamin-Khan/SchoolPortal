namespace SchoolAPIs.Models.DTO
{
    public class DeleteStudentByIdRequestDto
    {
        public int id { get; set; } = 0;

    }

    public class DeleteStudentByIdResponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }

}
