using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class SocialLinksRepository : GenericRepository<SocialLinks>, ISocialLinksRepository
    {
        public SocialLinksRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
