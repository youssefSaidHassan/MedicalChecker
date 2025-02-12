using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Departments.Command.Models
{
    public class CreateDepartmentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
