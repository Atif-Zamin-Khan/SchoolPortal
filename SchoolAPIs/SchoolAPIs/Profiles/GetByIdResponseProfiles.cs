using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace CollegeAPIs.Profiles
{
    public class GetByIdResponseProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetStudentByIdResponseDbo, GetStudentByIdResponseDto>()
                  .Map(dest => dest.classid, src => src.cms_class_detail_Id);


        }

    }
}
