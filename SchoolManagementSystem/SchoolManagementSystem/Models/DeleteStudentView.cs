namespace SchoolManagementSystem.Models
{
    public class DeleteStudentViewRequest
    {
        public int id { get; set; } = 0;
    }

    public class DeleteEmpViewRequest
    {
        public int emp_id { get; set; } = 0;
    }

    public class DeleteStudentViewResponse
    {
            public int id { get; set; } = 0;
            public string role { get; set; } = string.Empty;
            public string responseCode { get; set; } = string.Empty;
            public string responseDescription { get; set; } = string.Empty;
    }
}
