using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
