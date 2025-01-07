using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class DiseasePrecautionRepository : GenericRepository<DiseasePrecaution>, IDiseasePrecautionRepository
    {
        public DiseasePrecautionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
