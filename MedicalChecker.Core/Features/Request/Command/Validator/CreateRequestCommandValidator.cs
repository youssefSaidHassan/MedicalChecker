using FluentValidation;
using MedicalChecker.Core.Features.Request.Command.Models;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Command.Validator
{
    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {

        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        private readonly IFileService _fileService;
        #endregion

        #region Constructor
        public CreateRequestCommandValidator(IApplicationUserService applicationUserService, IFileService fileService)
        {
            _applicationUserService = applicationUserService;
            _fileService = fileService;
            AppleyValidationRules();
            AppleyCustomRules();
        }
        #endregion

        #region Handel Functions
        public void AppleyValidationRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User Id Is Required")
                .NotNull().WithMessage("User Id Can Not Be Empty");
            RuleFor(x => x.File)
                .NotEmpty().WithMessage("File Must Be Uploaded")
                .NotNull().WithMessage("File Must Be Uploaded");
        }

        public void AppleyCustomRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (key, CancellationToken) => await _applicationUserService.UserExistByIdAsync(key))
                .WithMessage("No Exist User");
            RuleFor(x => x.File)
                .MustAsync(async (key, CancellationToken) => await _fileService.IsPdf(key))
                .WithMessage("The File Must Be a PDF File");
        }

        #endregion
    }
}
