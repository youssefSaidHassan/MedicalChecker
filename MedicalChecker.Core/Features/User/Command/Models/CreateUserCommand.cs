using MediatR;
using MedicalChecker.Core.Bases;

namespace MedicalChecker.Core.Features.User.Command.Models
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
