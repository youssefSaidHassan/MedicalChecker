using MediatR;
using MedicalChecker.Core.Bases;
using Microsoft.AspNetCore.Http;

namespace MedicalChecker.Core.Features.Request.Command.Models
{
    public class CreateRequestCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
