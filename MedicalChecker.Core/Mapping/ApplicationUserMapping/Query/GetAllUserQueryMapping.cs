using MedicalChecker.Core.Features.User.Query.Responses;
using MedicalChecker.Data.Entities.Identity;

namespace MedicalChecker.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetAllUserQueryMapping()
        {
            CreateMap<ApplicationUser, GetAllUsersResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.Concat(src.FName, " ", src.LName)));
        }
    }
}
