using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Profiles
{
    public class GetAllProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllStudentResponseDto,GetAllStudentResponseDbo>()
                  .Map(dest => dest.Id, src => src.id)
                  .Map(dest => dest.Name, src => src.name)
                  .Map(dest => dest.Age, src => src.age)
                  .Map(dest => dest.Clas, src => src.clas)
                  .Map(dest => dest.Address, src => src.address)
                  .Map(dest => dest.PhoneNumber, src => src.phoneNumber)
                  .Map(dest => dest.Email, src => src.email);
        }


    }
}