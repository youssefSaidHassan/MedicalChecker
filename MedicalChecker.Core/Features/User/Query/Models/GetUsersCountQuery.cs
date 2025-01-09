using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.User.Query.Models
{
    public class GetUsersCountQuery : IRequest<Response<int>>
    {
    }
}
