using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Request.Command.Models;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;

namespace MedicalChecker.Core.Features.Request.Command.Handler
{
    public class RequestCommandHandler : ResponseHandler,
        IRequestHandler<CreateRequestCommand, Response<string>>,
        IRequestHandler<UpdateRequestStatusCommand, Response<string>>,
        IRequestHandler<DeleteRequestCommand, Response<string>>
    {

        #region Fields
        private readonly IRequestService _requestService;
        #endregion

        #region Constructor
        public RequestCommandHandler(IRequestService requestService)
        {
            _requestService = requestService;
        }
        #endregion

        #region Handel Functions
        public async Task<Response<string>> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _requestService.CreateAsync(request.UserId, request.File);
            if (result != SD.Success)
                return BadRequest<string>(result);
            return Success("");
        }

        public async Task<Response<string>> Handle(UpdateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _requestService.UpdateStatusAsync(request);
            if (result != SD.Success)
                return BadRequest<string>(result);
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _requestService.DeleteRequestAsync(request.RequestId);
            if (result != SD.Success)
                return BadRequest<string>(result);
            return Success("");
        }
        #endregion
    }
}
