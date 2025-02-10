using MedicalChecker.Core.Features.User.Query.Responses;
using MedicalChecker.Data.Entities;
using MedicalChecker.Data.Entities.Identity;


namespace MedicalChecker.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserRequestsQueryMapping()
        {
            CreateMap<ApplicationUser, GetUserRequestsQueryResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.Concat(src.FName, " ", src.LName)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Requests, opt => opt.Ignore());

            CreateMap<Request, RequestResponse>()
                .ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
