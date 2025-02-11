using FluentValidation;
using MedicalChecker.Core.Features.Drug.Query.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Drug.Query.Validator
{
    public class GetDrugByIdQueryValidator : AbstractValidator<GetDrugByIdQuery>
    {
        #region Fields
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor
        public GetDrugByIdQueryValidator(IDrugService drugService)
        {
            _drugService = drugService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion
        #region Handel Functions

        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.DrugId)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Can Not Be Null");
        }

        private void AppleyValidationRules()
        {
            RuleFor(x => x.DrugId)
                .MustAsync(async (key, CancellationToken) => await _drugService.DrugExistByIdAsync(key))
                .WithMessage("No Exist Drug");
        }
        #endregion

    }
}
