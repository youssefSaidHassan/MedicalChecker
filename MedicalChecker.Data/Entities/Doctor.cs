using MedicalChecker.Data.Entities.Identity;

namespace MedicalChecker.Data.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string UserId { get; set; }
        public int DId { get; set; }
        public Department Department { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<SocialLinks> SocialLinks { get; set; }
    }
}
