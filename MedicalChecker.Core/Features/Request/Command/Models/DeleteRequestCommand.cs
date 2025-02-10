using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.Request.Command.Models
{
    public class DeleteRequestCommand : IRequest<Response<string>>
    {
        public int RequestId { get; set; }
        public DeleteRequestCommand(int id)
        {
            RequestId = id;
        }
    }
}
