namespace MedicalChecker.Data.Entities
{
    public class SocialLinks
    {
        public int Id;
        public string Name;
        public string Url;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
