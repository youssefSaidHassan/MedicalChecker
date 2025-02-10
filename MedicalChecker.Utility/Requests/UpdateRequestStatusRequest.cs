using MedicalChecker.Utility.Helper.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicalChecker.Utility.Requests
{
    public class UpdateRequestStatusRequest
    {
        [Required]
        public int RequestId { get; set; }
        public RequestStatusEnum Status { get; set; }
    }
}
