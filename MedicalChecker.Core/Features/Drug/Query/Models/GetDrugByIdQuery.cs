using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Drug.Query.Response;

namespace MedicalChecker.Core.Features.Drug.Query.Models
{
    public class GetDrugByIdQuery : IRequest<Response<GetDrugByIdQueryResponse>>
    {
        public int DrugId { get; set; }
        public GetDrugByIdQuery(int id)
        {
            DrugId = id;
        }
    }
}
