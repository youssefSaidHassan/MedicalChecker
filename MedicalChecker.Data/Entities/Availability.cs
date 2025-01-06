using MedicalChecker.Utility.Enums;

namespace MedicalChecker.Data.Entities
{
    public class Availability
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DayOfWeekEnum Day { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int BreakAfterHours { get; set; }
        public TimeOnly BreakDuration { get; set; }
        public Doctor Doctor { get; set; }
    }
}
