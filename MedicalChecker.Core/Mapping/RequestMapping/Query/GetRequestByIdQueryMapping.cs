using MedicalChecker.Core.Features.Request.Query.Responses;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.RequestMapping
{
    public partial class RequestProfile
    {
        public void GetRequestByIdQueryMapping()
        {
            CreateMap<Request, GetRequestByIdResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => string.Concat(src.User.FName, " ", src.User.LName)));

        }
    }
}
