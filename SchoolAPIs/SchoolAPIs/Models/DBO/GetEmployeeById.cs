namespace CollegeAPIs.Models.DBO
{
    public class GetEmployeeByIdrequestDbo
    {
        public int Id { get; set; } = 0;
    }
    public class GetEmployeeByIdresponseDbo
    {
        public int Id { get; set; } = 0;
        public string employee_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int employee_role_Id { get; set; } = 0;
        public string Password { get; set; } = string.Empty;

        public string ResponseCode { get; set; } = string.Empty;
        public string ResponseDescription { get; set; } = string.Empty;
    }


}
