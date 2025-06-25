namespace SchoolAPIs.Models.DBO
{
    public class GetAllEmployeeResponseDbo
    {
        public int employee_Id { get; set; } = 0;
        public string employee_Name { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty ;
        public int employee_role_Id { get; set;} = 0;
        public  string employee_Role{ get; set;} = string.Empty ;   
    }
}
