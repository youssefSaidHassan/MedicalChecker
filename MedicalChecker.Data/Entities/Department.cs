namespace MedicalChecker.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
