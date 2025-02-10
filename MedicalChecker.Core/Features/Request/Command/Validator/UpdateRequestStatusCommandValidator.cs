using FluentValidation;
using MedicalChecker.Core.Features.Request.Command.Models;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.Helper.Enums;


namespace MedicalChecker.Core.Features.Request.Command.Validator
{
    public class UpdateRequestStatusCommandValidator : AbstractValidator<UpdateRequestStatusCommand>
    {
        #region Fields
        private readonly IRequestService _requestService;
        #endregion

        #region Constructor
        public UpdateRequestStatusCommandValidator(IRequestService requestService)
        {
            _requestService = requestService;
            AppleyValidationRules();
            AppleyCustomRules();
        }
        #endregion

        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.RequestId)
                .NotEmpty().WithMessage("Request Id Is Required")
                .NotNull().WithMessage("Request Id Can Not Be Empty");
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status Is Required")
                .NotNull().WithMessage("Status Can Not Be Null");
        }

        public void AppleyCustomRules()
        {
            RuleFor(x => x.RequestId)
                .MustAsync(async (key, CancellationToken) => await _requestService.CheckForId(key))
                .WithMessage("No Exist Request");
            RuleFor(x => x.Status)
                .MustAsync(async (key, CancellationToken) =>
                {
                    bool result = Enum.IsDefined(typeof(RequestStatusEnum), key);
                    return result;
                })
                .WithMessage("Invalid Status");
        }

        #endregion
    }
}
