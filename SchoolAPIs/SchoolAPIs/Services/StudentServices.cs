using Azure;
using CollegeAPIs.Models.DBO;
using CollegeAPIs.Models.DTO;
using Mapster;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;
using SchoolAPIs.Services.Interfaces;
using SchoolAPIs.Shared.Db_Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolAPIs.Services
{
    public class StudentServices : IStudent
    {
        private readonly DapperDbContext _DbContext;
        private readonly IConfiguration _configuration;
        private readonly string _JwtSecretKey;
        private readonly ResponseModel _responseModel1;

        public StudentServices(DapperDbContext dapperDbContext, IConfiguration configuration, ResponseModel responseModel)
        {
            _DbContext = dapperDbContext;
             _configuration = configuration;
             _JwtSecretKey = _configuration.GetSection("JwtSettings:SecretKey").Value;
            _responseModel1 = responseModel;
        }
         
         
        // Login Method
        public async Task<object> Login(LoginRequestDto requestDto)
        {
            ResponseModel responseMOdel = new ResponseModel(); 

            LoginEmployeeResponseDto responseDto = new LoginEmployeeResponseDto();

            LoginRequestDbo requestDbo = requestDto.Adapt<LoginRequestDbo>();

            LoginResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<LoginResponseDbo>
                (
                    "sp_login",
                    requestDbo
                );
            
            

            /*if (responseDbo == null)
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }*/

            if(responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                
                responseMOdel.success = false;
                responseMOdel.message = "Error occurred while processing the request.";
                responseMOdel.data = null;
                return responseMOdel;
            }

           /* if(responseDbo.ResponseCode != "00")
            {
                responseMOdel.success = false;
                responseMOdel.message = "invalid ceditional.";
                responseMOdel.data = null;
                return responseMOdel;
            }*/

          /*  if (responseDbo.ResponseCode == "00" && responseDbo.Role == "SuperAdmin")
            {
                responseMOdel.success = true;
                responseMOdel.message = "valid ceditional.";
                responseMOdel.data = responseDbo;
                return responseMOdel;
            }*/

            if (responseDbo.ResponseCode != "00")
            {
                responseDto = responseDbo.Adapt<LoginEmployeeResponseDto>();
                return responseDto;
            }


            // Student Login 
            if (responseDbo.Role == "Student")
            {
                LoginStudentResponseDto StudentresponseDto = new LoginStudentResponseDto();

                StudentresponseDto = responseDbo.Adapt<LoginStudentResponseDto>();
                
                
                string tken = GenerateToken(responseDbo);
                StudentresponseDto.token = tken;

                UpdateTokenStudenRequestDbo studenttokenRequestDbo = StudentresponseDto.Adapt<UpdateTokenStudenRequestDbo>();

                // StudentTokenUpdate(studenttokenRequestDbo);

                UpdateTokenStudenResponseDbo studenttokenResponseDbo = await StudentTokenUpdate(studenttokenRequestDbo);
                return StudentresponseDto;

            }

            responseDto = responseDbo.Adapt<LoginEmployeeResponseDto>();
            string token = GenerateToken(responseDbo);
            responseDto.token = token;

            UpdateTokenEmployeeRequestDbo tokenRequestDbo = responseDto.Adapt<UpdateTokenEmployeeRequestDbo>();
            UpdateTokenEmployeeResponseDbo updateTokenResponseDbo = await UpdateTokenEmployee(tokenRequestDbo);
            return responseDto;

        }

        // Genrate Token Method for Login User
        private string GenerateToken(LoginResponseDbo responseDbo)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

           // string encodedKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(_JwtSecretKey));
            // Decode the Base64 key to ensure it meets the required 128-bit size
            var key = Encoding.UTF8.GetBytes(_JwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim("Id", responseDbo.Id.ToString()),
                    new Claim("Email", responseDbo.Email),
                   new Claim(ClaimTypes.Role, responseDbo.Role),
                   //new Claim("employee_role_Id", responseDbo.employee_role_Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


        // ********************* Employees All Methods *********************

        // Update Token For Employee
        private async Task<UpdateTokenEmployeeResponseDbo> UpdateTokenEmployee(UpdateTokenEmployeeRequestDbo requestDbo)
        {
            UpdateTokenEmployeeResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<UpdateTokenEmployeeResponseDbo>
                (
                    "sp_token_update",
                    requestDbo
                );

            return responseDbo;

        }


        // Get All Employees Method
        public async Task<List<GetAllEmployeeResponseDto>> GetAllEmployees()
        {
            List<GetAllEmployeeResponseDbo> responseDbo = await _DbContext.QueryAsync<GetAllEmployeeResponseDbo>
                (
                    "sp_get_all_employee"
                );

            if (responseDbo == null)
            {
                return new List<GetAllEmployeeResponseDto>();
            }

            return responseDbo.Select(Dbo => new GetAllEmployeeResponseDto
            {
                employee_id = Dbo.employee_Id,
                employee_name = Dbo.employee_Name,
                email = Dbo.Email,
                employee_role_id = Dbo.employee_role_Id,
                employee_role = Dbo.employee_Role
            }).ToList();

            var res = responseDbo.Adapt<List<GetAllEmployeeResponseDto>>();
            return res;

        }

        // Get Employee By Id
        public async Task<object> GetEmployeeById(GetEmployeeByIdrequestDto requestDto)
        {
            GetEmployeeByIdresponseDto responseDto = new();

            ResponseModel responseModel = new();

            GetEmployeeByIdrequestDbo requestDbo = requestDto.Adapt<GetEmployeeByIdrequestDbo>();

            GetEmployeeByIdresponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<GetEmployeeByIdresponseDbo>
                (
                    "sp_get_employee_by_id",
                    requestDbo
                );

           /* if (responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }*/

            //______________________
            if (responseDbo == null)
            {
                responseModel.success = false;
                responseModel.message = "Error occurred while processing the request.";
                responseModel.data = null;
                return responseModel;
            }

            // If the stored procedure returns an error response code
            if (responseDbo.ResponseCode != "00")
            {
                responseModel.success = false;
                responseModel.message = "no record found";
                responseModel.data = null;
                return responseModel;
            }



           /* if (responseDbo.ResponseCode != "00")
            {
              
                responseDto = responseDbo.Adapt<GetEmployeeByIdresponseDto>();
                return responseDto;
            }*/

            responseDto = responseDbo.Adapt<GetEmployeeByIdresponseDto>();
            return responseDto;

        }

        // Employee Role

         public async Task <List<EmployeeRole>> EmployeeRole()
         {
            List<EmployeeRole> responseDbo = await _DbContext.QueryAsync<EmployeeRole>
                (
                   "sp_employee_role"
                );
          if(responseDbo == null)
          {
                return new List<EmployeeRole>();
          }

           responseDbo.Adapt<List<EmployeeRole>>();
           return responseDbo;
         }



        // Add Employee Method
        public async Task<AddEmployeeResponseDto> AddEmployee(AddEmployeeRequestDto requestDto)
        {
            AddEmployeeResponseDto responseDto = new AddEmployeeResponseDto();

            AddEmployeeRequestDbo requestDbo = requestDto.Adapt<AddEmployeeRequestDbo>();

            AddEmployeeResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<AddEmployeeResponseDbo>
                   (
                        "sp_employee_insertion",
                         requestDbo
                   );

            if (responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {

                responseDto = responseDbo.Adapt<AddEmployeeResponseDto>();
                return responseDto;
            }
            responseDto = responseDbo.Adapt<AddEmployeeResponseDto>();
            return responseDto;

        }


        // Employee Update Method

        public async Task<UpdateEmployeeByIdresponseDto> UpdateEmployee(UpdateEmployeeByIdrequestDto requestDto)
        {
            UpdateEmployeeByIdresponseDto responseDto = new();

            UpdateEmployeeByIdrequestDbo requestDbo = requestDto.Adapt<UpdateEmployeeByIdrequestDbo>();

            UpdateEmployeeByIdresponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<UpdateEmployeeByIdresponseDbo>
                (
                    "sp_update_employee",
                    requestDbo
                );


            if (responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {

                responseDto = responseDbo.Adapt<UpdateEmployeeByIdresponseDto>();
                return responseDto;
            }

            responseDto = responseDbo.Adapt<UpdateEmployeeByIdresponseDto>();
            return responseDto;

        }


        // Detete Employee Or Student ById Method
        public async Task<Object> DeleteRecord(DeleteEmployeeByIdrequestDto requestDto)
        {
            
                DeleteEmployeeByIdResponseDto responseDto = new ();

                /*DeleteStudentByIdRequestDbo requestDbo = new DeleteStudentByIdRequestDbo()
                {
                    Id = requestDto.id
                };*/
            DeleteEmployeeByIdrequestDbo requestDbo = requestDto.Adapt<DeleteEmployeeByIdrequestDbo>();

            DeleteEmployeeByIdResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<DeleteEmployeeByIdResponseDbo>
                (
                    "sp_delete_by_id",
                    requestDbo
                );

            if (responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {

                responseDto = responseDbo.Adapt<DeleteEmployeeByIdResponseDto>();
                return responseDto;
            }

            if (responseDbo.Role == "Student")
            {
                DeleteEmployeeByIdResponseDto SresponseDto = new DeleteEmployeeByIdResponseDto();

                SresponseDto = responseDbo.Adapt<DeleteEmployeeByIdResponseDto>();
                return SresponseDto;

            }

            responseDto = responseDbo.Adapt<DeleteEmployeeByIdResponseDto>();
            return responseDto;
            
                
            
        }



        //********************* Student All Methods *********************

        // Student Class List

        public async Task<List<StudentClassList>> studentClassLists()
        {
            var response = await _DbContext.QueryAsync<StudentClassList>
                (
                    "sp_student_class_list"
                );
            if (response == null)
            {
                return new List<StudentClassList>();
            }

         /*  response.Select(x => new <List<StudentClassList>>
           (
           x.id = x.id,
           x.title = x.title
           ).ToList());*/

            response.Adapt<List<StudentClassList>>();
            return response;
        }


        // For Student Token Update 
        private async Task<UpdateTokenStudenResponseDbo> StudentTokenUpdate(UpdateTokenStudenRequestDbo requestDbo)
        {
            UpdateTokenStudenResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<UpdateTokenStudenResponseDbo>
                (
                    "sp_update_student_token",
                    requestDbo
                );
            return responseDbo;
        }


        // Get All Student and their Class Method
        public async Task<List<GetAllStudentsClassResponseDto>> GetAllStudentsClass()
        {
            List<GetAllStudentsClassResponseDbo> responseDbo = await _DbContext.QueryAsync<GetAllStudentsClassResponseDbo>
                (
                    "sp_get_all_students_class"
                );

            if(responseDbo == null )
            {
                return new List<GetAllStudentsClassResponseDto> ();
            }
            

            return responseDbo.Select(Dbo => new GetAllStudentsClassResponseDto
            {
                studentid = Dbo.studentId,
                student_name = Dbo.student_Name,
                age = Dbo.Age,
                address = Dbo.Address,
                phonenumber = Dbo.phone_number,
                email = Dbo.Email,
                classid = Dbo.classId,
                section = Dbo.Section,
                title = Dbo.Title

            }).ToList();

        }


        /* // All Students Method
         public async Task<List<GetAllStudentResponseDto>> GetAllStudents()
         {
             List<GetAllStudentResponseDbo> responseDbo = await _DbContext.QueryAsync<GetAllStudentResponseDbo>
             (
                 "sp_get_all_students"
             );

             if (responseDbo == null)
             {
                 return new List<GetAllStudentResponseDto>();
             }


             *//*return responseDbo.Select(Dbo => new GetAllStudentResponseDto
             {
                 id = Dbo.Id,
                 name = Dbo.Name,
                 age = Dbo.Age,
                 clas = Dbo.Clas,
                 phoneNumber = Dbo.PhoneNumber,
                 email = Dbo.Email
             }).ToList();*//*

             List<GetAllStudentResponseDto> studentList = responseDbo.Adapt<List<GetAllStudentResponseDto>>();

             // List<GetAllStudentResponseDto> studentList = new List<GetAllStudentResponseDto>();
             // var studentList = new List<GetAllStudentResponseDto>();

             //foreach (GetAllStudentResponseDbo dbo in responseDbo)
             //{
             //    studentList.Add(new GetAllStudentResponseDto
             //    {
             //        id = dbo.Id,
             //        name = dbo.Name,
             //        age = dbo.Age,
             //        clas = dbo.Clas,
             //        phoneNumber = dbo.PhoneNumber,
             //        email = dbo.Email
             //    });
             //}

            return studentList;

         }*/

        /*  List<GetAllEmployeeResponseDto> newList = new List<GetAllEmployeeResponseDto>()
            {
                new GetAllEmployeeResponseDto
                {
                        responseCode = "00",
                },

                new GetAllEmployeeResponseDto
                {
                        responseCode = "01"

                }

            };

               
            newList.Add
                (
                    new GetAllEmployeeResponseDto
                    {
                        responseCode = "00"

                    }

                );*/



        // Student Get ById Method 
        public async Task<GetStudentByIdResponseDto> GetStudentById(GetStudentByIdRequestDto requestDto)
        {
            GetStudentByIdResponseDto responseDto = new GetStudentByIdResponseDto();

            /*GetStudentByIdRequestDbo requestDbo = new GetStudentByIdRequestDbo()
            {
                Id = requestDto.id
            };*/

            GetStudentByIdRequestDbo requestDbo = requestDto.Adapt<GetStudentByIdRequestDbo>();

            GetStudentByIdResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<GetStudentByIdResponseDbo>
                (
                    "sp_get_by_id",
                     requestDbo
                );

            if (responseDbo == null)
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {
                responseDto = responseDbo.Adapt<GetStudentByIdResponseDto>();
                return responseDto;
            }

            responseDto = responseDbo.Adapt<GetStudentByIdResponseDto>();
            //responseDto.Student_name = responseDto.Student_name + "_123";
            return responseDto;
        }


        // Student Add Method
        public async Task<AddStudentResponseDto> AddStudent(AddStudentRequestDto requestDto)
        {
            AddStudentResponseDto responseDto = new AddStudentResponseDto();

            AddStudentRequestDbo requestDbo = requestDto.Adapt<AddStudentRequestDbo>();

            AddStudentResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<AddStudentResponseDbo>
                  (
                      "sp_student_insertion",
                       requestDbo
                  );

            if (responseDbo == null || string.IsNullOrEmpty(responseDbo.ResponseCode))
            {
                responseDto.responseCode = "04";
                responseDto.responseDescription = "Error occurred while processing the request.";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {
             
                responseDto = responseDbo.Adapt<AddStudentResponseDto>();
                return responseDto;
            }

            responseDto = responseDbo.Adapt<AddStudentResponseDto>();
            return responseDto;
        }




        // Update Method
        public async Task<UpdateStudentByIdResponseDto> UpdateStudent(UpdateStudentByIdRequestDto requestDto)
        {
            UpdateStudentByIdResponseDto responseDto = new UpdateStudentByIdResponseDto();

            UpdateStudentByIdRequestDbo requestDbo = requestDto.Adapt<UpdateStudentByIdRequestDbo>();

            UpdateStudentByIdResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<UpdateStudentByIdResponseDbo>
                  (
                      "sp_student_update",
                      requestDbo
                  );


            if (responseDbo == null)
            {
                responseDto.responseCode = "03";
                responseDto.responseDescription = "Error Occured While processing the request";
                return responseDto;
            }

            if (responseDbo.ResponseCode != "00")
            {
                responseDto = responseDbo.Adapt<UpdateStudentByIdResponseDto>();
                return responseDto;
            }

            responseDto = responseDbo.Adapt<UpdateStudentByIdResponseDto>();
            return responseDto;

        }


      /*  //Delete Method
        public async Task<DeleteStudentByIdResponseDto> DeleteStudent(DeleteStudentByIdRequestDto requestDto)
        {
            DeleteStudentByIdResponseDto responseDto = new DeleteStudentByIdResponseDto();

            *//*DeleteStudentByIdRequestDbo requestDbo = new DeleteStudentByIdRequestDbo()
            {
                Id = requestDto.id
            };*//*

            DeleteStudentByIdRequestDbo requestDbo = requestDto.Adapt<DeleteStudentByIdRequestDbo>();

            DeleteStudentByIdResponseDbo responseDbo = await _DbContext.QueryFirstOrDefault<DeleteStudentByIdResponseDbo>
                (
                    "sp_student_delete",
                    requestDbo
                );

            responseDto = responseDbo.Adapt< DeleteStudentByIdResponseDto >(); 
            return responseDto;
        }*/



    }
}