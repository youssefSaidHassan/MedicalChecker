using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Drug.Command.Models
{
    public class DeleteDrugCommand : IRequest<Response<string>>
    {
        public int DrugId { get; set; }
        public DeleteDrugCommand(int id)
        {
            this.DrugId = id;
        }
    }
}
