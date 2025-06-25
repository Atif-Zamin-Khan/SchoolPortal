namespace CollegeAPIs.Models.DTO
{
    public class AddEmployeeRequestDto
    {
        public string employeeName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
       // public string role { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string roleId { get; set; } = string.Empty;
    }
    public class AddEmployeeResponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;
    }
}
