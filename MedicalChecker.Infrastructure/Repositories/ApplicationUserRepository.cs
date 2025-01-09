using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
