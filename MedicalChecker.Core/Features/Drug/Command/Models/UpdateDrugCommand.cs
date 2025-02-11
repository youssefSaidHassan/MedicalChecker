using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Drug.Command.Models
{
    public class UpdateDrugCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
