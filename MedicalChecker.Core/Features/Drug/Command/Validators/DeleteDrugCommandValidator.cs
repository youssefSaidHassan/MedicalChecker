using FluentValidation;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Command.Validator
{
    public class DeleteDrugCommandValidator : AbstractValidator<DeleteDrugCommand>
    {

        #region Fields
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor
        public DeleteDrugCommandValidator(IDrugService drugService)
        {
            _drugService = drugService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion


        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.DrugId)
                .NotEmpty().WithMessage(" Is Required")
                .NotNull().WithMessage(" Can Not Be Null");

        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.DrugId)
                .MustAsync(async (key, CancellationToken) => await _drugService.DrugExistByIdAsync(key))
                .WithMessage("No Exist Drug");
        }
        #endregion
    }
}
