namespace CollegeAPIs.Models.DBO
{
    public class DeleteEmployeeByIdrequestDbo
    {
        public int Id { get; set; } = 0;
    }
    public class DeleteEmployeeByIdResponseDbo
    {
        public int Id { get; set; } = 0;
        public string Role { get; set; } = string.Empty;
        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;
    }

}
