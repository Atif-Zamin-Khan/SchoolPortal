using SchoolManagementSystem.Services.Dto;

namespace SchoolManagementSystem.Services.Services.Interfaces
{
    public interface IAccountServices
    {
        Task<LoginResponseDto> Login(LoginRequestDto requestDto);
        Task<List<StudentClassListDto>> StudentClassList();
        Task<List<AllStudentResponseDto>> GetAllStudents();
        Task<AddStudentResponseDto> AddStudent(AddStudentDto addStudentrequest);

        Task<UpdateStudentResponseDto> UpdateStudent(PostStudentDtoRequest requstDto);

        Task<UpdateStudentDtoResponse> GetById(UpdateStudentDto requestDto);

        Task<DeleteStudentDtoResponse> Delete(DeleteStudentDtoRequest requestDto);


        // Employees Interfaces
        Task<List<AllEmployeeResponseDto>> AllEmployees();

        Task<AddEmployeeDtoResponse> AddEmployee(AddEmployeeDtoRequest requestDto);
        Task <List<EmployeeRoleDto>> EmployeeRole ();

        Task<GetEmployeeByIdDtoResponse> GetEmployeeById(GetEmployeeByIdDtoRequest requestDto);

        Task<UpdateEmployeeDtoResponse> UpdateEmployee(UpdateEmployeeDtoRequest requestDto);

        Task<DeleteStudentDtoResponse> EmployeeDelete(DeleteEmpDtoRequest requestDto);

    }
}
