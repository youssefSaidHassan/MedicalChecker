using AutoMapper;
using MedicalChecker.Core.Features.Departments.Query.Response;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public void GetAllDepartmentsQueryMapping()
        {
            CreateMap<Department, GetAllDepartmentsQueryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()));
        }
    }
}
