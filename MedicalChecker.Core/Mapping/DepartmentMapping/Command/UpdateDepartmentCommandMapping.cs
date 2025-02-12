using AutoMapper;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public void UpdateDepartmentCommandMapping()
        {
            CreateMap<UpdateDepartmentCommand, Department>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
