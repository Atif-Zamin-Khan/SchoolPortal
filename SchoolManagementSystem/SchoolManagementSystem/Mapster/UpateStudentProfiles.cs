using Mapster;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Dto;

namespace SchoolManagementSystem.Mapster
{
    public class UpateStudentProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
               config.NewConfig<UpdateStudentDtoResponse, UpdateStudentViewModel>()
              .Map(dest => dest.Studentid, src => src.id)
              .Map(dest => dest.updateName, src => src.student_name)
              .Map(dest => dest.classId, src => src.classid)
              .Map(dest => dest.age, src => src.age)
              .Map(dest => dest.address, src => src.address)
              .Map(dest => dest.phoneNumber, src => src.phone_Number)
              .Map(dest => dest.updateEmail, src => src.email)
              .Map(dest => dest.password, src => src.password);

        }
    }
}
