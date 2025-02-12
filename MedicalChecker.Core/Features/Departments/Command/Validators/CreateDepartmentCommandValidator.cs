using FluentValidation;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Departments.Command.Validators
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public CreateDepartmentCommandValidator(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handel Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Cannot Be NULL");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Key, CancellationToken) => !await _departmentService.IsNameExist(Key)
               ).WithMessage("Department Is Exist");

        }
        #endregion

    }
}
