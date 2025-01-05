namespace MedicalChecker.Data.Entities
{
    public class Precautions
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DiseasePrecaution> DiseasePrecautions { get; set; }

    }
}
