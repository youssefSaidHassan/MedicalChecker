using MediatR;

namespace MedicalChecker.Core.Features.Request.Query.Models
{
    public class DownloadRequestFileQuery : IRequest<byte[]>
    {
        public int requestId { get; set; }
        public DownloadRequestFileQuery(int id)
        {
            this.requestId = id;
        }
    }
}
