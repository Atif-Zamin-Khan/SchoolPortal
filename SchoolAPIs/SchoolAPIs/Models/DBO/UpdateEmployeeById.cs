using static Slapper.AutoMapper;

namespace CollegeAPIs.Models.DBO
{
    public class UpdateEmployeeByIdrequestDbo
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int RoleId { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UpdateEmployeeByIdresponseDbo
    {
        public string ResponseCode { get; set; }   = string.Empty ;
        public string ResponseDescription { get; set; } = string.Empty ;

    }

}
