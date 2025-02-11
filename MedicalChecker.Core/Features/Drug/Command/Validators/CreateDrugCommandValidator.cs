using FluentValidation;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Drug.Command.Validators
{
    public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
    {
        #region Fields
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor
        public CreateDrugCommandValidator(IDrugService drugService)
        {
            _drugService = drugService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handel Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Cannot Be NULL");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Cannot Be NULL");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Key, CancellationToken) => !await _drugService.IsNameExist(Key)
               ).WithMessage("Drug Is Exist");

        }
        #endregion


    }
}
