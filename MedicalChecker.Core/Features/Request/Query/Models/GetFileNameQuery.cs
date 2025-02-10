using MediatR;

namespace MedicalChecker.Core.Features.Request.Query.Models
{
    public class GetFileNameQuery : IRequest<string>
    {
        public int RequestId { get; set; }
        public GetFileNameQuery(int id)
        {
            this.RequestId = id;
        }
    }
}
