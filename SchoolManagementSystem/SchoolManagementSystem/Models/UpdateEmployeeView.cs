namespace SchoolManagementSystem.Models
{
    public class UpdateEmployeeViewRequest
    {
        public int id { get; set; } = 0;
        public int roleId { get; set; } = 0;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
    public class UpdateEmployeeViewResponse
    {
        public int id { get; set; } = 0;
        public string employee_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int employee_role_id { get; set; } = 0;
        public string password { get; set; } = string.Empty;    
        /*  public string Success { get; set; } = string.Empty;
          public string Message { get; set; } = string.Empty;
          public string responseCode { get; set; } = string.Empty;
          public string responseDescription { get; set; } = string.Empty;*/
        /*   public int id { get; set; } = 0;
           public int roleId { get; set; } = 0;
           public string email { get; set; } = string.Empty;
           public string password { get; set; } = string.Empty;*/
    }
}
