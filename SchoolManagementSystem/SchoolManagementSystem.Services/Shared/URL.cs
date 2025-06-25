namespace SchoolManagementSystem.Services.Shared
{
    public static class URL
    {
        public static string Login { get; set; } = "/api/College/Login";
        public static string getAllStudentsClass { get; set; } = "/api/College/StudentClassList";
        public static string GetAllStudents { get; set; } = "/api/College/getAllStudentsClass";
        public static string AddStudent { get; set; } = "/api/College/AddStudent";
        public static string Update { get; set; } = "/api/College/UpdateStudent";
        public static string GetById { get; set; } = "/api/College/GetStudentById";
        public static string Delete { get; set; } = "/api/College/DeleteRecord";
        public static string AllEmployees { get; set; } = "/api/College/GetAllEmployees";
        public static string AddEmployee { get; set; } = "/api/College/AddEmployee";
        public static string GetEmployeeById { get; set; } = "/api/College/GetEmployeeById";
        public static string UpdateEmployee { get; set; } = "/api/College/UpdateEmployee";
        public static string EmployeeRole { get; set; } = "/api/College/EmployeeRoles";
    }
}
