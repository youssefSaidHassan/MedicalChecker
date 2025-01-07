using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class PrecautionsRepository : GenericRepository<Precautions>, IPrecautionsRepository
    {
        public PrecautionsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
