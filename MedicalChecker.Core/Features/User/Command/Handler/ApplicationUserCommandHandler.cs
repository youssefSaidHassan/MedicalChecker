using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Data.Entities.Identity;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;

namespace MedicalChecker.Core.Features.User.Command.Handler
{
    public class ApplicationUserCommandHandler : ResponseHandler,
        IRequestHandler<CreateUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        #endregion

        #region Constructor
        public ApplicationUserCommandHandler(IMapper mapper, IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _applicationUserService = applicationUserService;
        }
        #endregion

        #region Handel Functions
        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var result = await _applicationUserService.CreateUserAsync(user, request.Password);
            if (result != SD.Success)
            {
                return BadRequest<string>(result);
            }
            return Created<string>("User Created Successfully");
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserService.GetByIdAsync(request.UserId);
            var userMapping = _mapper.Map(request, user);
            var result = await _applicationUserService.UpdateUserAsync(userMapping);
            if (result != SD.Success)
            {
                return BadRequest<string>(result);
            }
            return Success<string>("User Updated Successfully");

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationUserService.DeleteUserAsync(request.UserId); ;
            if (result != SD.Success)
            {
                return BadRequest<string>(result);
            }
            return Success<string>("User Deleted Successfully");
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _applicationUserService.ChangePasswordAsync(request);
            if (result != SD.Success)
            {
                return BadRequest<string>(result);
            }
            return Success<string>("Password Changed Successfully");
        }
        #endregion
    }
}
