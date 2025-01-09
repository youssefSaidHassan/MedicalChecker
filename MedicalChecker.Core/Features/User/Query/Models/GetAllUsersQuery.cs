using MediatR;
using MedicalChecker.Core.Features.User.Query.Responses;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Utility.Helper.Enums;

namespace MedicalChecker.Core.Features.User.Query.Models
{
    public class GetAllUsersQuery : IRequest<PaginatedResponse<GetAllUsersResponse>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public UserOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
