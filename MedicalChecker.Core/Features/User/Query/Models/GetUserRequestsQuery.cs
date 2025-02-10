using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.User.Query.Responses;

namespace MedicalChecker.Core.Features.User.Query.Models
{
    public class GetUserRequestsQuery : IRequest<Response<GetUserRequestsQueryResponse>>
    {
        public string UserId { get; set; }
        public int RequestPageNumber { get; set; }
        public int RequestPageSize { get; set; }
    }
}
