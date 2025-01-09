using FluentValidation;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Command.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public CreateUserCommandValidator(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion


        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name Is Required")
                .NotNull().WithMessage("First Name Can Not Be Null");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name Is Required")
                .NotNull().WithMessage("Last Name Can Not Be Null");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Is Required")
                .NotNull().WithMessage("Email Can Not Be Null")
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("Phone Number Is Required")
               .NotNull().WithMessage("Phone Number Can Not Be Null")
               .Matches("^01[0125][0-9]{8}$").WithMessage("Invalid Phone Number");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password Is Required")
               .NotNull().WithMessage("Password Can Not Be Null")
               .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$").WithMessage("Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, and one number.");

            RuleFor(x => x.ConfirmPassword)
              .NotEmpty().WithMessage("Confirm Password Is Required")
              .NotNull().WithMessage("Confirm Can Not Be Null")
              .Matches(x => x.Password).WithMessage("Confirm Password Not Match The Password");

        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => !await _applicationUserService.EmailIsExistAsync(key))
                .WithMessage("Email Already Exist");
        }
        #endregion
    }
}
