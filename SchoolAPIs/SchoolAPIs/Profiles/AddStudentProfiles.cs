using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Profiles
{
    public class AddStudentProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddStudentRequestDto, AddStudentRequestDbo>()
                 .Map(dest => dest.StudentName, src => src.studentName)
                 .Map(dest => dest.Age, src => src.age)
                 .Map(dest => dest.ClassId, src => src.classId)
                 .Map(dest => dest.Address, src => src.address)
                 .Map(dest => dest.PhoneNumber, src => src.phoneNumber)
                 .Map(dest => dest.Email, src => src.email)
                 .Map(dest => dest.Password, src => src.password);
        }
    }
}