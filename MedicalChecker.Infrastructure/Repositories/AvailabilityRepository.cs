using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class AvailabilityRepository : GenericRepository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
