using FluentValidation;
using MedicalChecker.Core.Features.Request.Query.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Query.Validators
{
    public class GetRequestByIdValidator : AbstractValidator<GetRequestByIdQuery>
    {

        #region Fields
        private readonly IRequestService _requestService;
        #endregion

        #region Constructor
        public GetRequestByIdValidator(IRequestService requestService)
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
                .NotEmpty().WithMessage("Request Id Is Required")
                .NotNull().WithMessage("Request Id Can Not Be Null");


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
