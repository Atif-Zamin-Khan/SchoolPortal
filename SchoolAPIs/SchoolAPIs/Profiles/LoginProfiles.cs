using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Profiles
{
    public class LoginProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
                config.NewConfig<LoginRequestDto, LoginRequestDbo>()
                 .Map(dest => dest.Email, src => src.email)
                 .Map(dest => dest.Password, src => src.password);
        }
    }
}
