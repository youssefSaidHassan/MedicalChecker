using FluentValidation;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Departments.Command.Validators
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public UpdateDepartmentCommandValidator(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handel Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.DeptId)
               .NotEmpty().WithMessage("Is Required")
               .NotNull().WithMessage("Cannot Be NULL");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Is Required")
                .NotNull().WithMessage("Cannot Be NULL");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Key, CancellationToken) => !await _departmentService.IsNameExist(Key)
               ).WithMessage("Department Is Exist");
            RuleFor(x => x.DeptId)
               .MustAsync(async (Key, CancellationToken) => await _departmentService.DepartmentExistByIdAsync(Key)
               ).WithMessage("Department Is Not Exist");

        }
        #endregion
    }
}
