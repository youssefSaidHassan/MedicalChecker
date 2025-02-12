using AutoMapper;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public void CreateDepartmentCommandMapping()
        {
            CreateMap<CreateDepartmentCommand, Department>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
