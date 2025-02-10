using MedicalChecker.Core.Wrappers;

namespace MedicalChecker.Core.Features.User.Query.Responses
{
    public class GetUserRequestsQueryResponse
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public PaginatedResponse<RequestResponse>? Requests { get; set; }
    }
    public class RequestResponse
    {
        public string Status { get; set; }
        public int RequestId { get; set; }
    }
}
