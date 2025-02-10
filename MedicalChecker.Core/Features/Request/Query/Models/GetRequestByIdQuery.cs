using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Request.Query.Responses;

namespace MedicalChecker.Core.Features.Request.Query.Models
{
    public class GetRequestByIdQuery : IRequest<Response<GetRequestByIdResponse>>
    {
        public int RequestId { get; set; }
        public GetRequestByIdQuery(int id)
        {
            RequestId = id;
        }
    }
}
