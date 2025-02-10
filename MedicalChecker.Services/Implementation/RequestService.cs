using MedicalChecker.Data.Entities;
using MedicalChecker.Infrastructure.UnitWork;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;
using MedicalChecker.Utility.Helper.Enums;
using MedicalChecker.Utility.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MedicalChecker.Services.Implementation
{
    public class RequestService : IRequestService
    {

        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        #endregion

        #region Constructor
        public RequestService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        #endregion

        #region Handel Functions
        public async Task<bool> CheckForId(int id)
        {
            var result = await _unitOfWork.Request.GetByIdAsync(id);
            return result != null;
        }
        public async Task<string> CreateAsync(string userId, IFormFile file)
        {
            var trans = _unitOfWork.BeginTransaction();
            try
            {
                var request = new Request();
                request.UserId = userId;
                request.Status = RequestStatusEnum.Pending;

                var uploadResult = await _fileService.UploadFile("Requests/Cv", file);
                if (uploadResult == SD.FailedToUploadFile || uploadResult == SD.NoFile)
                {
                    return uploadResult;
                }
                request.FileName = uploadResult;
                await _unitOfWork.Request.AddAsync(request);
                await trans.CommitAsync();
                return SD.Success;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return SD.FailedToAdd;
            }
        }

        public async Task<string> DeleteRequestAsync(int id)
        {
            try
            {
                var request = await _unitOfWork.Request.GetByIdAsync(id);
                _fileService.DeleteFile(request.FileName);
                await _unitOfWork.Request.DeleteAsync(request);
                return SD.Success;
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }

        public async Task<byte[]> DownloadRequestFile(int id)
        {
            var request = await _unitOfWork.Request.GetByIdAsync(id);
            return _fileService.DownloadFile(request.FileName);
        }

        public IQueryable<Request> FilterRequestsQuerable(RequestOrderingEnum ordering, string? search)
        {
            var querable = _unitOfWork.Request.GetTableNoTracking().Include(x => x.User).AsQueryable();


            if (!string.IsNullOrEmpty(search))
                querable = querable.Where(x => (x.User.FName + " " + x.User.LName).Contains(search));
            switch (ordering)
            {
                case RequestOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.User.FName).ThenBy(x => x.User.LName);
                    break;
                case RequestOrderingEnum.Status:
                    querable = querable.OrderBy(x => x.Status);
                    break;
                case RequestOrderingEnum.Id:
                default:
                    querable = querable.OrderBy(x => x.Id);
                    break;
            }
            return querable;

        }

        public async Task<int> GetCountAsync(RequestStatusEnum? request)
        {
            var querable = _unitOfWork.Request.GetTableNoTracking();
            var count = await querable.CountAsync();
            if (request == null)
            {
                return count;
            }
            switch (request)
            {
                case RequestStatusEnum.Pending:
                    count = await querable.Where(x => x.Status == RequestStatusEnum.Pending).CountAsync();
                    break;
                case RequestStatusEnum.Approved:
                    count = await querable.Where(x => x.Status == RequestStatusEnum.Approved).CountAsync();
                    break;
                case RequestStatusEnum.Cancelled:
                    count = await querable.Where(x => x.Status == RequestStatusEnum.Cancelled).CountAsync();
                    break;
            }
            return count;
        }

        public async Task<string> GetFileName(int id)
        {
            var request = await _unitOfWork.Request.GetByIdAsync(id);
            return Path.GetFileName(request.FileName);
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            var result = await _unitOfWork.Request.GetRequestByIdWithUser(id);
            return result;
        }

        public IQueryable<Request> GetStudentsQuerableByUserId(string userId)
        {
            return _unitOfWork.Request.GetTableNoTracking().Where(x => x.UserId == userId).AsQueryable();
        }

        public async Task<string> UpdateStatusAsync(UpdateRequestStatusRequest command)
        {
            try
            {
                var request = await _unitOfWork.Request.GetByIdAsync(command.RequestId);
                request.Status = command.Status;
                await _unitOfWork.Request.UpdateAsync(request);
                return SD.Success;
            }
            catch (Exception)
            {

                return SD.FailedToUpdate;
            }
        }
        #endregion
    }
}
