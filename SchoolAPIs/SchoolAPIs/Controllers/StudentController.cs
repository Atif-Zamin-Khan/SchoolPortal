using CollegeAPIs.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPIs.Models.DTO;
using SchoolAPIs.Services.Interfaces;

namespace SchoolAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly IStudent _Istudentservices;

        public CollegeController(IStudent studentServices)
        {
            _Istudentservices = studentServices;
        }


        // Login endpoint
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto RequestDto)
         {
            if (string.IsNullOrWhiteSpace(RequestDto.email) || string.IsNullOrWhiteSpace(RequestDto.password))
            {
                return BadRequest(new
                {
                    responseCode = "01",
                    responseDescription = "Email or Password cannot be empty"
                });
            }
            var responseDto = await _Istudentservices.Login(RequestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }
        


        // for Authorization 
        [Authorize]
        [HttpGet("SecureEndpoint")]
        public IActionResult GetSecureData()
        {
            return Ok("This is a secure endpoint!");
        }

        // ********************** All Employees endpoint **********************

        // Get All Employee endpoint

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var responseDto = await _Istudentservices.GetAllEmployees();
            return responseDto != null ? Ok(responseDto) : BadRequest();

        }

            
        // Role endpoint
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EmployeeRoles()
        {
            var responseDto = await _Istudentservices.EmployeeRole();
            return responseDto != null ? Ok(responseDto) : BadRequest();

        }


        // Get Employee By Id endpoint
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetEmployeeById([FromBody] GetEmployeeByIdrequestDto requestDto)
        {
            var responseDto = await _Istudentservices.GetEmployeeById(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }


        // Add Employee endpoint
        // [SuperAuthorizationFilter]

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto requestDto)
        {
            AddEmployeeResponseDto responseDto = await _Istudentservices.AddEmployee(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }



        // Update Employee By Id endpoint
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeByIdrequestDto RequestDto)
        {
            var responseDto = await _Istudentservices.UpdateEmployee(RequestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }


        // Delete Employe or Student Record ById endpoint

        // Delete Student Record
        //[Authorize(Roles = "Administrator")]

        [Authorize (Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> DeleteRecord([FromBody] DeleteEmployeeByIdrequestDto requestDto)
        {
                var responseDto = await _Istudentservices.DeleteRecord(requestDto);
                return responseDto != null ? Ok(responseDto) : BadRequest();
        }


        // ********************** Student all endpoint **********************

        // Get All Student endpoint

        //Student List
        [Authorize]
        [HttpGet]
         public async Task<IActionResult> StudentClassList()
        {
            var response = await _Istudentservices.studentClassLists();
            return response != null ? Ok(response) : BadRequest();
        }




       // [Authorize(Roles = "SuperAdmin")]
        [CustomAuthorizationFilter]
        [HttpGet]
        public async Task <IActionResult> getAllStudentsClass()
        {
            var responseDto = await _Istudentservices.GetAllStudentsClass();
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }


        // All Student endpoint
        // Apply the custom authorization filter
        // [CustomAuthorizationFilter]
        //[Authorize(Roles = "Administrator")]

        /*[HttpGet]
          public async Task <IActionResult> GetAllStudents()
          {
            var responseDto = await _Istudentservices.GetAllStudents();
            return responseDto != null ? Ok(responseDto) : NotFound();
            // This action is only accessible to users in the "Admin" role
          }*/


        // Token Based Authorization 
        //[Authorize (Roles = "Admin")]
        /*[CustomAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> GetAllStudent()
        {

            var responseDto = await _Istudentservices.GetAllStudents();
            return responseDto != null ? Ok(responseDto) : NotFound();

        }               
        */

        // GetById endpoint
        [CustomAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> GetStudentById([FromBody] GetStudentByIdRequestDto requestDto)
        {
            var responseDto = await _Istudentservices.GetStudentById(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();

        }


        // Add Student endpoint

        //[Authorize(Roles = "Administrator")]
        [CustomAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequestDto requestDto)
        {
            var responseDto = await _Istudentservices.AddStudent(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }



        // Update Student Record 
        // [Authorize(Roles = "Administrator")]

        [CustomAuthorizationFilter]
        [HttpPost]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentByIdRequestDto requestDto)
        {
            var responseDto = await _Istudentservices.UpdateStudent(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
        }



      /*   // Delete Student Record
        [HttpPost]
        // [Authorize (Roles = "Admin")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentByIdRequestDto requestDto)
        {
            var responseDto = await _Istudentservices.DeleteStudent(requestDto);
            return responseDto != null ? Ok(responseDto) : BadRequest();
         }
        */




    }
}
