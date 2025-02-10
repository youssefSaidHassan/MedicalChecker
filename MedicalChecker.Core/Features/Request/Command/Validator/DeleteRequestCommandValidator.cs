using FluentValidation;
using MedicalChecker.Core.Features.Request.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Command.Validator
{
    public class DeleteRequestCommandValidator : AbstractValidator<DeleteRequestCommand>
    {

        #region Fields
        private readonly IRequestService _requestService;
        #endregion

        #region Constructor
        public DeleteRequestCommandValidator(IRequestService requestService)
        {
            _requestService = requestService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion


        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.RequestId)
                .NotEmpty().WithMessage("First Name Is Required")
                .NotNull().WithMessage("First Name Can Not Be Null");

        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.RequestId)
                .MustAsync(async (key, CancellationToken) => await _requestService.CheckForId(key))
                .WithMessage("No Exist Request");
        }
        #endregion
    }
}
