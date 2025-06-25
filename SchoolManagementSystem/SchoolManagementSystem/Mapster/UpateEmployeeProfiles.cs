using Mapster;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Dto;

namespace SchoolManagementSystem.Mapster
{
    public class UpateEmployeeProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetEmployeeByIdDtoResponse, GetEmployeeByIdViewResponse>()
           .Map(dest => dest.emp_id, src => src.id)
           .Map(dest => dest.emp_name, src => src.employee_name)
           .Map(dest => dest.email, src => src.email)
           .Map(dest => dest.roleId, src => src.employee_role_id)
           .Map(dest => dest.password, src => src.password)
           .Map(dest => dest.responseCode, src => src.responseCode)
           .Map(dest => dest.responseDescription, src => src.responseDescription);
        }
    }
}
