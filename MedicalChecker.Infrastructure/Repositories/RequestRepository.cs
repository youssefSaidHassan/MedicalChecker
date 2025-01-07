using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
