using CollegeAPIs.Models.DBO;
using Mapster;
using SchoolAPIs.Models.DTO;

namespace CollegeAPIs.Profiles
{
    public class TokenStudentUpdate : IRegister
    {
        // Student Token
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginStudentResponseDto, UpdateTokenStudenRequestDbo>()
                 .Map(dest => dest.StudentId, src => src.id);

        }
      
    }
}
