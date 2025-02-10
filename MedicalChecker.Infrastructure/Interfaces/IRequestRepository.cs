using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.Generic;

namespace MedicalChecker.Infrastructure.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<Request> GetRequestByIdWithUser(int id);
        IQueryable<Request> GetAllWithUser();
    }
}
