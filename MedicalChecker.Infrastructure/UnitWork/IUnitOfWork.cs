using MedicalChecker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

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
        IApplicationUserRepository ApplicationUser { get; }
        IDbContextTransaction BeginTransaction();
        Task Commit();
        Task RollBack();
    }
}
