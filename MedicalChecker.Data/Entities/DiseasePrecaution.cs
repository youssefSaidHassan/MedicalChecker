namespace MedicalChecker.Data.Entities
{
    public class DiseasePrecaution
    {
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        public int PrecautionId { get; set; }

        public Precautions Precaution { get; set; }
    }
}
