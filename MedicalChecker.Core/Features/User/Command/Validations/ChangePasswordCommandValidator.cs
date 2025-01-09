using FluentValidation;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Command.Validations
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public ChangePasswordCommandValidator(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion


        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("First Name Is Required")
                .NotNull().WithMessage("First Name Can Not Be Null");



            RuleFor(x => x.OldPassword)
               .NotEmpty().WithMessage("Password Is Required")
               .NotNull().WithMessage("Password Can Not Be Null")
               .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$").WithMessage("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, and one number.");

            RuleFor(x => x.NewPassword)
               .NotEmpty().WithMessage("Password Is Required")
               .NotNull().WithMessage("Password Can Not Be Null")
               .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$").WithMessage("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, and one number.");

            RuleFor(x => x.ConfirmNewPassword)
              .NotEmpty().WithMessage("Confirm Password Is Required")
              .NotNull().WithMessage("Confirm Can Not Be Null")
              .Matches(x => x.NewPassword).WithMessage("Confirm Password Not Match The Password");

        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (key, CancellationToken) => await _applicationUserService.UserExistByIdAsync(key))
                .WithMessage("No Exist User");
        }
        #endregion
    }
}
