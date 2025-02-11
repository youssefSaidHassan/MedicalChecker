using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Drug.Command.Models
{
    public class CreateDrugCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
