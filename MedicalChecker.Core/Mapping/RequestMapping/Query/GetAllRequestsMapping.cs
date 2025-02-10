using MedicalChecker.Core.Features.Request.Query.Responses;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.RequestMapping
{
    public partial class RequestProfile
    {
        public void GetAllRequestsMapping()
        {
            CreateMap<Request, GetAllRequestsQueryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => string.Concat(src.User.FName, " ", src.User.LName)));
        }
    }
}
