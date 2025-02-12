using MediatR;
using MedicalChecker.Core.Features.Departments.Query.Response;
using MedicalChecker.Core.Wrappers;

namespace MedicalChecker.Core.Features.Departments.Query.Models
{
    public class GetAllDepartmentsQuery : IRequest<PaginatedResponse<GetAllDepartmentsQueryResponse>>
    {
        public string? Search { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
