using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
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
         ISocialLinksRepository socialLinksRepository
         )
        {
            Appointment = appointmentRepository;
            Availability = availabilityRepository;
            Department = departmentRepository;
            Disease = diseaseRepository;
            SocialLinks = socialLinksRepository;
            Request = requestRepository;
            Drug = drugRepository;
            DiseasePrecaution = diseasePrecautionRepository;
            Doctor = doctorRepository;
            Precautions = precautionsRepository;

        }


    }
}
