namespace CollegeAPIs.Models.DTO
{

    public class DeleteEmployeeByIdrequestDto
    {
        public int id { get; set; } = 0;
    }
    public class DeleteEmployeeByIdResponseDto
    {
        public int id { get; set; } = 0;
        public string role { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }
}
