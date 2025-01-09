using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.User.Command.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
