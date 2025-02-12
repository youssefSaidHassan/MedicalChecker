using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Departments.Command.Models
{
    public class UpdateDepartmentCommand : IRequest<Response<string>>
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
    }
}
