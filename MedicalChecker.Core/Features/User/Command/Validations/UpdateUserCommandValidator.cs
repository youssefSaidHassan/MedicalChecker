using FluentValidation;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Command.Validations
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {

        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public UpdateUserCommandValidator(IApplicationUserService applicationUserService)
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
            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("Phone Number Is Required")
               .NotNull().WithMessage("Phone Number Can Not Be Null")
               .Matches("^01[0125][0-9]{8}$").WithMessage("Invalid Phone Number");

            RuleFor(x => x.UserId)
           .NotEmpty().WithMessage("UserId Is Required")
           .NotNull().WithMessage("User Id Can Not Be Null");


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
