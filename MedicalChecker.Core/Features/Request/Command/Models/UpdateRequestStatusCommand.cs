using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Utility.Requests;

namespace MedicalChecker.Core.Features.Request.Command.Models
{
    public class UpdateRequestStatusCommand : UpdateRequestStatusRequest, IRequest<Response<string>>
    {

    }
}
