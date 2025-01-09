using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.User.Command.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }
    }
}
