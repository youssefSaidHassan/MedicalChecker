using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Drug.Query.Models
{
    public class GetDrugsCountQuery : IRequest<Response<int>>
    {
    }
}
