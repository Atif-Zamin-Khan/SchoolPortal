using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Profiles
{
    public class UpdateProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateStudentByIdRequestDto, UpdateStudentByIdRequestDbo>()
                  .Map(dest => dest.StudentId, src => src.Studentid)
                  .Map(dest => dest.StudentName, src => src.updateName)
                  .Map(dest => dest.Age, src => src.age)
                  .Map(dest => dest.ClassId, src => src.classId)
                  .Map(dest => dest.Address, src => src.address)
                  .Map(dest => dest.PhoneNumber, src => src.phoneNumber)
                  .Map(dest => dest.Email, src => src.updateEmail);
        }

    }
}

