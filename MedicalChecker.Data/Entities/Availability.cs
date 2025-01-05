namespace MedicalChecker.Data.Entities
{
    public class Availability
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BreakAfterHours { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public Doctor Doctor { get; set; }
    }
}
