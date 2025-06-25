using SchoolManagementSystem.Services.Dto;

namespace SchoolManagementSystem.Models
{
    public class GetEmployeeByIdViewRequest
    {
        public int id { get; set; } = 0;
    }


    public class GetEmployeeByIdViewResponse
    {
        public int emp_id { get; set; } = 0;
        public string emp_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int roleId { get; set; } = 0;
        public string password { get; set; } = string.Empty;
        public string responseCode { get; set; } = string.Empty;
        public string responseDescription { get; set; } = string.Empty;

    }


}

