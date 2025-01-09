using MedicalChecker.Core.Features.User.Query.Responses;
using MedicalChecker.Data.Entities.Identity;

namespace MedicalChecker.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdQueryMapping()
        {
            CreateMap<ApplicationUser, GetUserByIdQueryResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
