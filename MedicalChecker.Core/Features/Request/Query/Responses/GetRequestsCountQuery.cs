using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Utility.Helper.Enums;

namespace MedicalChecker.Core.Features.Request.Query.Responses
{
    public class GetRequestsCountQuery : IRequest<Response<int>>
    {
        public RequestStatusEnum? Status { get; set; }
        public GetRequestsCountQuery(RequestStatusEnum? status = null)
        {
            Status = status;
        }
    }
}
