using AutoMapper;

namespace MedicalChecker.Core.Mapping.DrugMapping
{
    public partial class DrugProfile : Profile
    {
        public DrugProfile()
        {
            GetAllDrugsQueryMapping();
            GetDrugByIdQueryMapping();
            CreateDrugCommandMapping();
            UpdateDrugCommandMapping();
        }
    }
}
