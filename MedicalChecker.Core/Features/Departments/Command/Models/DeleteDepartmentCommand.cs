using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Departments.Command.Models
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public int DeptId { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            DeptId = id;
        }
    }
}
