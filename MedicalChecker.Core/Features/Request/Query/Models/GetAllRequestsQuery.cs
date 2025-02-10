using MediatR;
using MedicalChecker.Core.Features.Request.Query.Responses;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Utility.Helper.Enums;

namespace MedicalChecker.Core.Features.Request.Query.Models
{
    public class GetAllRequestsQuery : IRequest<PaginatedResponse<GetAllRequestsQueryResponse>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public RequestOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
