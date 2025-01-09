using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.User.Query.Responses;

namespace MedicalChecker.Core.Features.User.Query.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdQueryResponse>>
    {
        public string UserId { get; set; }
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
