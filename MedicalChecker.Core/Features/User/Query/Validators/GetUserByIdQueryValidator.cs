using FluentValidation;
using MedicalChecker.Core.Features.User.Query.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Query.Validators
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public GetUserByIdQueryValidator(IApplicationUserService applicationUserService)
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
