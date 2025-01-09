using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalChecker.Infrastructure.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAppointmentRepository Appointment { get; }
        public IAvailabilityRepository Availability { get; }
        public IDepartmentRepository Department { get; }
        public IDiseasePrecautionRepository DiseasePrecaution { get; }
        public IDiseaseRepository Disease { get; }
        public IDoctorRepository Doctor { get; }
        public IDrugRepository Drug { get; }
        public IPrecautionsRepository Precautions { get; }
        public IRequestRepository Request { get; }
        public ISocialLinksRepository SocialLinks { get; }

        public IApplicationUserRepository ApplicationUser { get; }

        public UnitOfWork(
         IAppointmentRepository appointmentRepository,
         IAvailabilityRepository availabilityRepository,
         IDepartmentRepository departmentRepository,
         IDiseasePrecautionRepository diseasePrecautionRepository,
         IDiseaseRepository diseaseRepository,
         IDoctorRepository doctorRepository,
         IDrugRepository drugRepository,
         IPrecautionsRepository precautionsRepository,
         IRequestRepository requestRepository,
         ISocialLinksRepository socialLinksRepository,
         IApplicationUserRepository applicationUser,
         ApplicationDbContext context
         )
        {
            Appointment = appointmentRepository;
            Availability = availabilityRepository;
            Department = departmentRepository;
            Disease = diseaseRepository;
            SocialLinks = socialLinksRepository;
            _context = context;
            Request = requestRepository;
            Drug = drugRepository;
            DiseasePrecaution = diseasePrecautionRepository;
            Doctor = doctorRepository;
            Precautions = precautionsRepository;
            ApplicationUser = applicationUser;

        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollBack()
        {
            await _context.Database.RollbackTransactionAsync();
        }


    }
}
