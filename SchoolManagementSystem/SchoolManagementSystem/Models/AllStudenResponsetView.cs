namespace SchoolManagementSystem.Models
{
    public class AllStudenResponsetView
    {
        /*public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public int age { get; set; } = 0;
        public string clas { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        */
        public int studentid { get; set; } = 0;
          public string student_name { get; set; } = string.Empty;
          public int age { get; set; } = 0;
          public string address { get; set; } = string.Empty;
          public string phonenumber { get; set; } = string.Empty;
          public string email { get; set; } = string.Empty;
          public int classid { get; set; } = 0;
          public string section { get; set; } = string.Empty;
          public string title { get; set; } = string.Empty;
    }
}
