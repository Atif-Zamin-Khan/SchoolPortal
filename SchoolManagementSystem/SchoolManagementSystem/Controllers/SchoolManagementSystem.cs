using Mapster;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Dto;
using SchoolManagementSystem.Services.Services.Interfaces;


namespace SchoolManagementSystem.Controllers
{
    public class SchoolManagementSystem : Controller
    {
        private readonly IAccountServices _accountServices;

        public SchoolManagementSystem(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }


        //Loign View endpoint
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(viewLoginRequest requestView)
        {

            LoginRequestDto loginRequestDto = new LoginRequestDto();

            loginRequestDto = requestView.Adapt<LoginRequestDto>();

            /* var requestDto = new LoginRequestDto
             {
                 email = requestView.email,
                 password = requestView.password
             };
             */

            if (requestView == null || string.IsNullOrEmpty(requestView.email) || string.IsNullOrEmpty(requestView.password))
            {
                ViewBag.ErrorMessage = "Email and password are required.";
                return View();
            }

            var response = await _accountServices.Login(loginRequestDto);

            if (response.responseCode != "00")
            {
                TempData["msg"] = "Invalid Credentials, Please Enter Valid Email & Password";
                return RedirectToAction("Login");
            }

            // Store user data in session
            HttpContext.Session.SetString("Authorization", response.token);
            HttpContext.Session.SetString("UserRole", response.role);

            return response.role switch
            {
                "SuperAdmin" => RedirectToAction("Index", "Home"),
                "Administrator" => RedirectToAction("Index", "Home"),
                "Student" => RedirectToAction("Index", "Home"),
                "HOD" => RedirectToAction("Index", "Home"),
                _ => RedirectToAction("Privacy", "Home")
            };

        }


       

        [HttpGet]
        public async Task<IActionResult> AllStudent()
        {
            var response = await _accountServices.GetAllStudents();

            List<AllStudenResponsetView> responseView = response.Adapt<List<AllStudenResponsetView>>();

            /*  var studentview = response.Select(s => new AllStudenResponsetView
              {
                  studentid = s.studentid,
                  student_name = s.student_name,
                  age = s.age,
                  address = s.address,
                  phonenumber = s.phonenumber,
                  email = s.email,
                  classid = s.classid,
                  section = s.section,
                  title = s.title
              }).ToList();*/

            return View(responseView);

        }


        // Add Student 
        [HttpGet]
        public async Task<IActionResult> Create()
            {
            var response = await _accountServices.StudentClassList();
            var classlistViewResponse = response.Adapt<List<StudentClassListView>>();
            ViewBag.classList = classlistViewResponse;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddStudentViewRequest viewRequest)
        {

            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please fill all fields.";
                return View("Create");
            }

            AddStudentDto addstudentDto = new AddStudentDto();

            addstudentDto = viewRequest.Adapt<AddStudentDto>();

            /* AddStudentDto addStudentrequest = new AddStudentDto
             {
                 studentName = model.studentName,
                 classId = model.classId,
                 age = model.age,
                 address = model.address,
                 phoneNumber = model.phoneNumber,
                 email = model.email,
                 password = model.password
             };*/

            var response = await _accountServices.AddStudent(addstudentDto);


            if (response.responseCode != "00")
            {
                //  return RedirectToAction("Create");
                ViewBag.ErrorMessage = "No Student Added";
                return View("Create");
            }

            return RedirectToAction("AllStudent");


        }


        //Update Student 
        [HttpGet]
        public async Task<IActionResult> Edit(UpdateStudentDto updateStudentDto)
        {
            var response = await _accountServices.GetById(updateStudentDto);
            var responseclassList = await _accountServices.StudentClassList();
            var responseView = responseclassList.Adapt<List<StudentClassListView>>();
            ViewBag.classList = responseView;



            if (response == null)
            {
                return NotFound();
            }

            UpdateStudentViewModel viewResponse = new();

            viewResponse = response.Adapt<UpdateStudentViewModel>();
           // viewResponse.updateName = viewResponse.updateName + "_123";

            /*var viewModel = new UpdateStudentViewModel
            {
                Studentid = response.id,
                updateName = response.student_name,
                classId = response.classid,
                age = response.age,
                address = response.address,
                phoneNumber = response.phone_Number,
                updateEmail = response.email,
                password = response.password
            };*/

            return View(viewResponse);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostStudentDtoRequest updatestudent)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var response = await _accountServices.UpdateStudent(updatestudent);
                if (response.responseCode == "00")
                {

                    TempData["msg"] = "Successfully Student Record Updated";
                    return RedirectToAction("AllStudent");
                }

                if (response.responseCode != "00")
                {
                    TempData["msg"] = "Could Not Updated Student Record";
                    return RedirectToAction("AllStudent");

                }

            }
            catch (Exception ex)
            {

                TempData["msg"] = "Could Not Updated";
                return RedirectToAction("AllStudent");

            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(DeleteStudentDtoRequest request)
        {
            var response = await _accountServices.Delete(request);
            if (response == null)
            {
                TempData["msg"] = "No Student Found Against Given Id";
                return View(new DeleteStudentDtoResponse());
            }
            else
            {
                TempData["msg"] = "Successfully Student Record Deleted";
                return RedirectToAction("AllStudent");
            }
            return View();
        }

        // All Employees Ation Verbs

        [HttpGet]
        public async Task<IActionResult> AllEmployee()
        {
            var response = await _accountServices.AllEmployees();

            List<AllEmployeeResponseView> responseView = new();

            responseView = response.Adapt<List<AllEmployeeResponseView>>();

            /* var Viewresponse = response.Select(e => new AllEmployeeResponseView
             {
                 employee_id = e.employee_id,
                 employee_name = e.employee_name,
                 email = e.email,
                 employee_role_id = e.employee_role_id,
                 employee_role = e.employee_role,
             }).ToList();*/

            return View(responseView);
        }


        // Add Employee
        /*    [HttpGet]
           public IActionResult AddEmployee()
           {
               ViewBag.Roles = _accountServices.EmployeeRole(); 
               return View();
           }*/


        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {

            var response = await _accountServices.EmployeeRole();

            var responseView = response.Adapt <List<EmployeeRoleView>>();

           /* List<EmployeeRoleView> responseModal = response.Select(x => new EmployeeRoleView
            {
                id = x.id,
                role = x.role
            }).ToList();*/
            ViewBag.Roles = responseView;
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewRequest viewRequest)
        {
            
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Validation failed. Please check your inputs." });
            }

            AddEmployeeDtoRequest requestDto = new AddEmployeeDtoRequest();

            requestDto = viewRequest.Adapt<AddEmployeeDtoRequest>();

            /*  var requestDto = new AddEmployeeDtoRequest
              {
                  employeeName = viewRequest.employeeName,
                  email = viewRequest.email,
                  password = viewRequest.password,
                  roleId = viewRequest.roleId,
              };*/

            var responseApi = await _accountServices.AddEmployee(requestDto);

            if (responseApi.responseCode == "00")
            {
                return Json(new { success = true, message = "Employee added successfully!" });
            }

            else
                return Json(new { success = false, message = responseApi?.Message ?? "An error occurred while adding the employee." });
        }



        // Get Employee By Id
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(GetEmployeeByIdViewRequest viewRequest)
        {
            GetEmployeeByIdDtoRequest requestDto = new();

            var responseList = await _accountServices.EmployeeRole();

            var responseListView = responseList.Adapt<List<EmployeeRoleView>>();

           /* List<EmployeeRoleView> responseViewList = responseList.Select(x => new EmployeeRoleView
            {
                id = x.id,
                role = x.role
            }).ToList();
*/
            ViewBag.Roles = responseListView;

            requestDto = viewRequest.Adapt<GetEmployeeByIdDtoRequest>();

            /* var requestDto = new GetEmployeeByIdDtoRequest
             {
                 id = viewRequest.id
             };*/

            var responseApi = await _accountServices.GetEmployeeById(requestDto);

            if (responseApi == null)
            {
                return NotFound();
            }

            GetEmployeeByIdViewResponse responseView = new();
            responseView = responseApi.Adapt<GetEmployeeByIdViewResponse>();

            /* var responseView = new GetEmployeeByIdViewResponse
             {
                 emp_id = responseApi.id,
                 emp_name = responseApi.employee_name,
                 email = responseApi.email,
                 roleId = responseApi.employee_role_id,
                 password = responseApi.password,
                 responseCode = responseApi.responseCode,
                 responseDescription = responseApi.responseDescription,
             };*/

            return View(responseView);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDtoRequest requestDto)
        {

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Validation failed. Please check your inputs." });
            }
            var responseApi = await _accountServices.UpdateEmployee(requestDto);


            if (responseApi.responseCode == "00")
            {
                return Json(new { success = true, message = "Successfully! Employee Update Record" });
            }
            else

                return Json(new { success = false, message = responseApi?.Message ?? "An error occurred while Updating the employee." });
        }



        // Delete Employee
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(DeleteEmpViewRequest viewRequest)
        {
            DeleteEmpDtoRequest requestDto = new DeleteEmpDtoRequest();

            requestDto = viewRequest.Adapt<DeleteEmpDtoRequest>();

            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Validation failed. Please check your inputs.";
                return RedirectToAction("AllEmployee");
            }

            var responseApi = await _accountServices.EmployeeDelete(requestDto);

            if (responseApi.responseCode == "00")
            {
                TempData["Message"] = "Employee Record Deleted Successfully!";
                return RedirectToAction("AllEmployee");
            }

            TempData["Message"] = "Employee Record Not Deleted. Please try again.";
            return RedirectToAction("AllEmployee");

            /*  DeleteEmpDtoRequest requestDto = new DeleteEmpDtoRequest();

              requestDto = viewRequest.Adapt<DeleteEmpDtoRequest>();

              *//*var requestdto = new DeleteEmpDtoRequest
              {
                  id = requestDto.emp_id,
              };
                 */
            /*
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Validation failed. Please check your inputs." });
            }

            var responseApi = await _accountServices.EmployeeDelete(requestDto);
            if (responseApi.responseCode == "00")
            {
                return Json(new { success = true, message = "Successfully! Employee Delete Record" });

            }

            if (responseApi.responseCode != "00")
            {
                return Json(new { success = true, message = "Employee Record Not Deleted" });
            }

            return Json(new { success = false, message = responseApi?.Message ?? "An error occurred while Deleted the employee." });*/


        }



        // Departments View
        public IActionResult Departments()
        {
            var departments = new List<DepartmentView>
        {
            new DepartmentView { Id = 1, Name = "Computer Science" },
            new DepartmentView { Id = 2, Name = "Mathematics" },
            new DepartmentView { Id = 3, Name = "Physics" },
            new DepartmentView { Id = 4, Name = "Chemistry" },
            new DepartmentView { Id = 5, Name = "English" }
        };

            return View(departments);
        }


        // Courses View

        public IActionResult Courses()
        {
            var courses = new List<CourseView>
        {
            new CourseView { Id = 1, Name = "Introduction to Programming" },
            new CourseView { Id = 2, Name = "Calculus I" },
            new CourseView { Id = 3, Name = "Physics for Engineers" },
            new CourseView { Id = 4, Name = "Organic Chemistry" },
            new CourseView { Id = 5, Name = "Literary Studies" }
        };

            return View(courses);
        }


        // ExamSchedule View
        public IActionResult ExamSchedule()
        {
            var exams = new List<ExamScheduleView>
        {
            new ExamScheduleView { Id = 1, CourseName = "Introduction to Programming", ExamDate = "March 10, 2025", ExamTime = "10:00 AM" },
            new ExamScheduleView { Id = 2, CourseName = "Calculus I", ExamDate = "March 12, 2025", ExamTime = "2:00 PM" },
            new ExamScheduleView { Id = 3, CourseName = "Physics for Engineering", ExamDate = "March 15, 2025", ExamTime = "9:00 AM" },
            new ExamScheduleView { Id = 4, CourseName = "Organic Chemistry", ExamDate = "March 17, 2025", ExamTime = "1:00 PM" },
            new ExamScheduleView { Id = 5, CourseName = "Literary Studies", ExamDate = "March 20, 2025", ExamTime = "11:00 AM" }
        };

            return View(exams);
        }

    }

}
