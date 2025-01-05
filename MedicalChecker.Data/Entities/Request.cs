using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Utility.Enums;

namespace MedicalChecker.Data.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public RequestStatusEnum Status { get; set; }
        public string FileName { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
