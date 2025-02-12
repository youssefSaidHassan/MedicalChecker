using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Departments.Query.Models
{
    public class GetDepartmentsCountQuery : IRequest<Response<int>>
    {
    }
}
