using AutoMapper;

namespace MedicalChecker.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetAllDepartmentsQueryMapping();
            CreateDepartmentCommandMapping();
            UpdateDepartmentCommandMapping();
        }
    }
}
