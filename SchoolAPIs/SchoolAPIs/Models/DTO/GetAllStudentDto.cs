namespace SchoolAPIs.Models.DTO
{
    public class GetAllStudentRequestDto
    {
    }

    public class GetAllStudentResponseDto
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public int age { get; set; } = 0;
        public string clas { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
  /*      public bool isActive { get; set; }
        public bool isDeleted { get; set; }*/
    }
}
