using Mapster;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Dto;

namespace SchoolManagementSystem.Mapster
{
    public class DeleteEmployeeProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DeleteEmpViewRequest, DeleteEmpDtoRequest>()
           .Map(dest => dest.id, src => src.emp_id);
        }
    }
}
