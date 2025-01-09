namespace MedicalChecker.Core.Features.User.Query.Responses
{
    public class GetUserByIdQueryResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
