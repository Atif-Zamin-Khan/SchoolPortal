using CollegeAPIs.Models.DBO;
using static Slapper.AutoMapper;

namespace CollegeAPIs.Models.DBO
{
    public class GetAllStudentsClassResponseDbo
    {
      
        public int studentId { get; set; } = 0;
        public string student_Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public string Token { get; set; } = string.Empty;
        public int classId { get; set; } = 0;
        public string Section { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        /*  public bool IsActive { get; set; }
          public bool IsDeleted { get; set; }*/
    }

}
