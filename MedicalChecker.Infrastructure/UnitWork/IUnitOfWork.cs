using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.UnitWork
{
    public interface IUnitOfWork
    {
        IAppointmentRepository Appointment { get; }
        IAvailabilityRepository Availability { get; }
        IDepartmentRepository Department { get; }
        IDiseasePrecautionRepository DiseasePrecaution { get; }
        IDiseaseRepository Disease { get; }
        IDoctorRepository Doctor { get; }
        IDrugRepository Drug { get; }
        IPrecautionsRepository Precautions { get; }
        IRequestRepository Request { get; }
        ISocialLinksRepository SocialLinks { get; }
    }
}
