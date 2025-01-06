using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Utility.Helper.Enums;

namespace MedicalChecker.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int DoctorId { get; set; }
        public ApplicationUser User { get; set; }
        public Doctor Doctor { get; set; }
    }
}
