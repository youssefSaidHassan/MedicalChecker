using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Context;
using MedicalChecker.Infrastructure.Generic;
using MedicalChecker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalChecker.Infrastructure.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Request> GetAllWithUser()
        {
            return _context.Requests.Include(x => x.User).AsQueryable();
        }

        public async Task<Request> GetRequestByIdWithUser(int id)
        {
            return await _context.Requests.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
