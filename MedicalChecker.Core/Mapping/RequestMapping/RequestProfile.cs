using AutoMapper;

namespace MedicalChecker.Core.Mapping.RequestMapping
{
    public partial class RequestProfile : Profile
    {
        public RequestProfile()
        {
            GetRequestByIdQueryMapping();
            GetAllRequestsMapping();
        }
    }
}
