using MedicalChecker.Data.Entities;
using MedicalChecker.Utility.Helper.Enums;
using MedicalChecker.Utility.Requests;
using Microsoft.AspNetCore.Http;

namespace MedicalChecker.Services.Interfaces
{
    public interface IRequestService
    {
        Task<string> CreateAsync(string userId, IFormFile file);
        Task<string> UpdateStatusAsync(UpdateRequestStatusRequest request);
        Task<int> GetCountAsync(RequestStatusEnum? request);
        Task<Request> GetRequestByIdAsync(int id);
        Task<string> DeleteRequestAsync(int id);
        Task<bool> CheckForId(int id);
        Task<string> GetFileName(int id);
        Task<byte[]> DownloadRequestFile(int id);
        IQueryable<Request> GetStudentsQuerableByUserId(string userId);
        IQueryable<Request> FilterRequestsQuerable(RequestOrderingEnum ordering, string? search);

    }
}
