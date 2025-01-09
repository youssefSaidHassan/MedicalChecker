using AutoMapper;

namespace MedicalChecker.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateUserCommandMapping();
            GetUserByIdQueryMapping();
            UpdateUserCommandMapping();
            GetAllUserQueryMapping();
        }
    }
}
