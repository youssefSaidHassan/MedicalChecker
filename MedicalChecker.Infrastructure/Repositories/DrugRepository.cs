using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class DrugRepository : GenericRepository<Drug>, IDrugRepository
    {
        public DrugRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
