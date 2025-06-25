namespace CollegeAPIs.Models.DTO
{
    public class UpdateEmployeeByIdrequestDto
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;

        public int roleId { get; set; } = 0;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class UpdateEmployeeByIdresponseDto
    {
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }
}
