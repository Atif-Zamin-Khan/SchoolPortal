namespace CollegeAPIs.Models.DTO
{
    public class GetEmployeeByIdrequestDto
    {
        public int id { get; set; } = 0;
    }
    public class GetEmployeeByIdresponseDto
    {
        public int id { get; set; } = 0;
        public string employee_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int employee_role_id { get; set; } = 0;
        public string password { get; set; } = string.Empty;

        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }
}
