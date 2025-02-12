using FluentValidation;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Departments.Command.Validators
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DeleteDepartmentCommandValidator(IDepartmentService departmentService)
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
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DeptId)
               .MustAsync(async (Key, CancellationToken) => await _departmentService.DepartmentExistByIdAsync(Key)
               ).WithMessage("Department Is Not Exist");

        }
        #endregion
    }
}
