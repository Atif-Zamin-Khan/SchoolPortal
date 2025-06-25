
using Mapster;
using SchoolAPIs.Models.DBO;
using SchoolAPIs.Models.DTO;

namespace SchoolAPIs.Profiles
{
    public class GetByIdProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetStudentByIdRequestDto, GetStudentByIdRequestDbo>()
                 .Map(dest => dest.Id, src => src.id);

        }

        // Response..
      /*  public void Registers(TypeAdapterConfig config)
        {
            config.NewConfig<GetStudentByIdResponseDbo, GetStudentByIdResponseDto>()
                 .Map(dest => dest.classid, src => src.cms_class_detail_Id);
        }*/

    }
}