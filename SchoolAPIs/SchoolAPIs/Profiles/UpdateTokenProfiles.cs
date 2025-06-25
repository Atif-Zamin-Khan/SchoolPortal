using CollegeAPIs.Models.DBO;
using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace CollegeAPIs.Profiles
{
    public class UpdateTokenProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginEmployeeResponseDto, UpdateTokenEmployeeRequestDbo>()
                 .Map(dest => dest.employeeId, src => src.id);
        }

       

    }

}
