using AutoMapper;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Data.Entities;

namespace MedicalChecker.Core.Mapping.DrugMapping
{
    public partial class DrugProfile : Profile
    {
        public void UpdateDrugCommandMapping()
        {
            CreateMap<UpdateDrugCommand, Drug>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
