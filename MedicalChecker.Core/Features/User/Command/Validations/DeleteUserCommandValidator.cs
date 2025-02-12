﻿using FluentValidation;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Command.Validations
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {

        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public DeleteUserCommandValidator(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
            AppleyValidationRules();
            AppleyCustomValidationRules();
        }
        #endregion


        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Request Id Is Required")
                .NotNull().WithMessage("Request Id Can Not Be Empty");

        }
        public void AppleyCustomValidationRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (key, CancellationToken) => await _applicationUserService.UserExistByIdAsync(key))
                .WithMessage("No Exist User");
        }
        #endregion
    }
}
