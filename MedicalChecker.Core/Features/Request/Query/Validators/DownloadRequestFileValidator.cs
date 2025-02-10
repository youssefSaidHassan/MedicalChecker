using FluentValidation;
using MedicalChecker.Core.Features.Request.Query.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Query.Validators
{
    public class DownloadRequestFileValidator : AbstractValidator<DownloadRequestFileQuery>
    {
        #region Fields
        private readonly IRequestService _requestService;
        #endregion

        #region Constructor
        public DownloadRequestFileValidator(IRequestService requestService)
        {
            _requestService = requestService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion

        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.requestId)
                .NotEmpty().WithMessage("Request Id Is Required")
                .NotNull().WithMessage("Request Id Can Not Be Null");


        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.requestId)
                .MustAsync(async (key, CancellationToken) => await _requestService.CheckForId(key))
                .WithMessage("No Exist Request");
        }
        #endregion
    }
}
