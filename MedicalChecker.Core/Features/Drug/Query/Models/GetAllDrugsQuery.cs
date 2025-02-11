using MediatR;
using MedicalChecker.Core.Features.Drug.Query.Response;
using MedicalChecker.Core.Wrappers;

namespace MedicalChecker.Core.Features.Drug.Query.Models
{
    public class GetAllDrugsQuery : IRequest<PaginatedResponse<GetAllDrugsQueryResponse>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? Search { get; set; }
    }
}
