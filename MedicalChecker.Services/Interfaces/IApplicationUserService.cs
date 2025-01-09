using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Utility.Helper.Enums;
using MedicalChecker.Utility.Requests;

namespace MedicalChecker.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<string> CreateUserAsync(ApplicationUser user, string password);
        Task<string> UpdateUserAsync(ApplicationUser user);
        Task<string> ChangePasswordAsync(ChangePasswordRequest request);
        Task<string> DeleteUserAsync(string userId);
        Task<bool> EmailIsExistAsync(string email);
        Task<bool> UserExistByIdAsync(string userId);
        int GetUsersCount();
        Task<ApplicationUser> GetByIdAsync(string userId);
        IQueryable<ApplicationUser> FilterUsersQuerable(UserOrderingEnum ordering, string? search);
    }
}
