using CollegeAPIs.Models.DBO;
using CollegeAPIs.Models.DTO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Services.Interfaces
{
    public interface IStudent
    {
        Task<Object> Login(LoginRequestDto requestDto);
        
        Task<List<GetAllEmployeeResponseDto>> GetAllEmployees();

        //Task<GetEmployeeByIdresponseDto> GetEmployeeById (GetEmployeeByIdrequestDto requestDto);

        Task<object> GetEmployeeById(GetEmployeeByIdrequestDto requestDto);


        Task<AddEmployeeResponseDto> AddEmployee(AddEmployeeRequestDto requestDto);

        Task<UpdateEmployeeByIdresponseDto> UpdateEmployee(UpdateEmployeeByIdrequestDto requestDto);

        Task<Object> DeleteRecord(DeleteEmployeeByIdrequestDto requestDto);

        Task<List<EmployeeRole>> EmployeeRole();


       // Student Methods
         //Task<List<GetAllStudentResponseDto>> GetAllStudents();

        Task<List<StudentClassList>> studentClassLists();

        Task<List<GetAllStudentsClassResponseDto>> GetAllStudentsClass();

        Task <GetStudentByIdResponseDto> GetStudentById(GetStudentByIdRequestDto requestDto);

        Task <AddStudentResponseDto> AddStudent(AddStudentRequestDto requestDto);

   
        Task<UpdateStudentByIdResponseDto> UpdateStudent(UpdateStudentByIdRequestDto requestDto);

        // Task<DeleteStudentByIdResponseDto> DeleteStudent(DeleteStudentByIdRequestDto requestDto);


    }
}
