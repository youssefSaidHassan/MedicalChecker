using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Infrastructure.UnitWork;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;
using MedicalChecker.Utility.Helper.Enums;
using MedicalChecker.Utility.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MedicalChecker.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper _urlHelper;
        private readonly LinkGenerator _linkGenerator;
        #endregion

        #region Constructor
        public ApplicationUserService(UserManager<ApplicationUser> userManager, LinkGenerator linkGenerator, IUnitOfWork unitOfWork, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor, IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
            _urlHelper = urlHelper;
            _linkGenerator = linkGenerator;
        }

        #endregion

        #region Handel Functions
        public async Task<string> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            if (!result.Succeeded)
                return string.Join("-", result.Errors.Select(x => x.Description));
            else
                return SD.Success;
        }
        public async Task<string> CreateUserAsync(ApplicationUser user, string password)
        {
            var trans = _unitOfWork.BeginTransaction();
            try
            {
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return string.Join("-", result.Errors.Select(x => x.Description));
                }
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var requestAccessor = _httpContextAccessor.HttpContext.Request;
                // var returnUrl = $"{requestAccessor.Scheme}://{requestAccessor.Host}{_urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code })}";
                //var returnUrl = _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code }, requestAccessor.Scheme);
                var returnUrl = _linkGenerator.GetUriByAction(
                _httpContextAccessor.HttpContext,
                "ConfirmEmail",
                "Authentication",
                new { userId = user.Id, code = code },
                requestAccessor.Scheme);
                var message = $"<p>To Confirm Your Email Please <a href = {returnUrl} > Click Here </a></p>";
                await _emailSender.SendEmailAsync(user.Email, "Confirm Your Email", message);
                await trans.CommitAsync();
                return SD.Success;
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<string> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return string.Join("-", result.Errors.Select(x => x.Description));

            return SD.Success;
        }

        public async Task<bool> EmailIsExistAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public IQueryable<ApplicationUser> FilterUsersQuerable(UserOrderingEnum ordering, string? search)
        {
            var querable = _userManager.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                querable = querable.Where(x => x.Email.Contains(search));
            switch (ordering)
            {
                case UserOrderingEnum.Email:
                    querable = querable.OrderBy(x => x.Email);
                    break;
                case UserOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.FName).ThenBy(x => x.LName);

                    break;
                case UserOrderingEnum.Id:
                default:
                    querable = querable.OrderBy(x => x.Id);
                    break;
            }
            return querable;
        }

        public async Task<ApplicationUser> GetByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public int GetUsersCount()
        {
            var count = _userManager.Users.Count();
            return count;
        }

        public async Task<string> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return string.Join("-", result.Errors.Select(x => x.Description));
            }
            return SD.Success;

        }

        public async Task<bool> UserExistByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null;
        }
        #endregion
    }
}
