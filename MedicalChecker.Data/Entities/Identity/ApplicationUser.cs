using Microsoft.AspNetCore.Identity;

namespace MedicalChecker.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Code { get; set; }
    }
}
