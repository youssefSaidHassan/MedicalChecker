using FluentValidation;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Drug.Command.Validators
{
    public class UpdateDrugCommandValidator : AbstractValidator<UpdateDrugCommand>
    {
        #region Fields
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor
        public UpdateDrugCommandValidator(IDrugService drugService)
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
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Cannot Be NULL");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Id)
               .MustAsync(async (Key, CancellationToken) => await _drugService.DrugExistByIdAsync(Key)
               ).WithMessage("No Exist Drug");
            RuleFor(x => x.Name)
               .MustAsync(async (Key, CancellationToken) => !await _drugService.IsNameExist(Key)
               ).WithMessage("Drug Is Exist");

        }
        #endregion


    }
}
