using Microsoft.AspNetCore.Identity;

namespace MedicalChecker.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Code { get; set; }
        public ICollection<Request>? Requests { get; set; }
        public Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
