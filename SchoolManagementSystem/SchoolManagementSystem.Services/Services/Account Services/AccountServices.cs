using SchoolManagementSystem.Infrastructure.Shared.HttpCall;
using SchoolManagementSystem.Services.Dto;
using SchoolManagementSystem.Services.Services.Interfaces;
using SchoolManagementSystem.Services.Shared;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Services.Account_Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IHttpService _httpService;
        private readonly string _baseUrl;

        public AccountServices(IHttpService httpService)
        {
            _httpService = httpService;
            _baseUrl = "https://localhost:7269"; 
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            string url = _baseUrl + URL.Login;
           // string url = _baseUrl + "/api/College/Login";

           
            var responseApi = await _httpService.SendAsync<LoginRequestDto, LoginResponseDto>(
                HttpMethod.Post,
                url,
                requestDto
            );

            return responseApi;
        }

        // Student List
        public async Task<List<StudentClassListDto>> StudentClassList()
        {
            string url = _baseUrl + URL.getAllStudentsClass;
            var responseApi = await _httpService.SendAsync<object, List<StudentClassListDto>>
            (
                HttpMethod.Get, 
                url
            );
            return responseApi;
        }



        public async Task<List<AllStudentResponseDto>> GetAllStudents()
        {
            string url = _baseUrl + URL.GetAllStudents;
           // string url = _baseUrl + "/api/College/getAllStudentsClass";
            var responseApi = await _httpService.SendAsync<object, List<AllStudentResponseDto>>(
                HttpMethod.Get,
                url
            );
            return responseApi;
        }




        // AddStudent
        public async Task<AddStudentResponseDto> AddStudent(AddStudentDto addStudentrequest)
        {
             string url = _baseUrl + URL.AddStudent;
            //string url = _baseUrl + "/api/College/AddStudent";
            var responseApi = await _httpService.SendAsync<AddStudentDto, AddStudentResponseDto>
                (
                    HttpMethod.Post,
                    url,
                    addStudentrequest
                );

            return responseApi;

        }



        // Update Student
        public async Task<UpdateStudentResponseDto> UpdateStudent(PostStudentDtoRequest requstDto)
        {

            string url = _baseUrl + URL.Update;
            var responseApi = await _httpService.SendAsync<PostStudentDtoRequest, UpdateStudentResponseDto>
                (
                    HttpMethod.Post,
                    url,
                    requstDto
                );

            return responseApi;
        }

        // Get By Id
        public async Task<UpdateStudentDtoResponse> GetById(UpdateStudentDto requestDto)
        {
            string url = _baseUrl + URL.GetById;

            var responseApi = await _httpService.SendAsync<UpdateStudentDto, UpdateStudentDtoResponse>
              (
                HttpMethod.Post,
                url,
                requestDto
            );


            return responseApi;
        }


        // Delete

        public async Task<DeleteStudentDtoResponse> Delete(DeleteStudentDtoRequest requestDto)
        {
            string url = _baseUrl + URL.Delete;
            var responseApi = await _httpService.SendAsync<DeleteStudentDtoRequest, DeleteStudentDtoResponse>
                (
                    HttpMethod.Post,
                    url,
                    requestDto
                );
            return responseApi;
        }


        // All Employees Methods

        public async Task<List<AllEmployeeResponseDto>> AllEmployees()
        {
            string url = _baseUrl + "/api/College/GetAllEmployees";
            var responseApi = await _httpService.SendAsync<object, List<AllEmployeeResponseDto>>
                (
                    HttpMethod.Get,
                    url
                );

            return responseApi;
        }

        // Employee Role
        public async Task<List<EmployeeRoleDto>> EmployeeRole()
        {
            string url = _baseUrl + URL.EmployeeRole;
            var responseApi = await _httpService.SendAsync<object, List<EmployeeRoleDto>>
                (
                    HttpMethod.Get,
                    url
                );
            return responseApi;

        }




        // Add Employee Method
        public async Task<AddEmployeeDtoResponse> AddEmployee(AddEmployeeDtoRequest requestDto)
        {
            string url = _baseUrl + URL.AddEmployee;
            var responseApi = await _httpService.SendAsync<AddEmployeeDtoRequest, AddEmployeeDtoResponse>
                (
                    HttpMethod.Post,
                    url,
                    requestDto
                );
            return responseApi;
        }


        

        // Get ById Employee Method
        public async Task<GetEmployeeByIdDtoResponse> GetEmployeeById(GetEmployeeByIdDtoRequest requestDto)
         {
            string url = _baseUrl + URL.GetEmployeeById;
            var responseApi = await _httpService.SendAsync<GetEmployeeByIdDtoRequest, GetEmployeeByIdDtoResponse>
                (
                    HttpMethod.Post,
                    url,
                    requestDto
                );
            return responseApi;

        }


        // Udpate Employee 
        public async Task<UpdateEmployeeDtoResponse> UpdateEmployee(UpdateEmployeeDtoRequest requestDto)
        {
            string url = _baseUrl + URL.UpdateEmployee;
            var responseApi = await _httpService.SendAsync<UpdateEmployeeDtoRequest, UpdateEmployeeDtoResponse>
                (
                    HttpMethod.Post,
                    url,
                    requestDto
                );
            return responseApi;
        }


       public async Task<DeleteStudentDtoResponse> EmployeeDelete(DeleteEmpDtoRequest requestDto)
        {
            string url = _baseUrl + URL.Delete;
            var responseApi = await _httpService.SendAsync<DeleteEmpDtoRequest, DeleteStudentDtoResponse>
                (
                    HttpMethod.Post,
                    url,
                    requestDto
                );
            return responseApi;

        }




    }
}