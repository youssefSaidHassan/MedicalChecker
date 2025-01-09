using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Utility.Requests;

namespace MedicalChecker.Core.Features.User.Command.Models
{
    public class ChangePasswordCommand : ChangePasswordRequest, IRequest<Response<string>>
    {

    }
}
