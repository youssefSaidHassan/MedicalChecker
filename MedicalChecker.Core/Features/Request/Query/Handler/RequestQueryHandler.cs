using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Request.Query.Models;
using MedicalChecker.Core.Features.Request.Query.Responses;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Request.Query.Handler
{
    public class RequestQueryHandler : ResponseHandler,
        IRequestHandler<GetRequestByIdQuery, Response<GetRequestByIdResponse>>,
        IRequestHandler<GetAllRequestsQuery, PaginatedResponse<GetAllRequestsQueryResponse>>,
        IRequestHandler<GetRequestsCountQuery, Response<int>>,
        IRequestHandler<DownloadRequestFileQuery, byte[]>,
        IRequestHandler<GetFileNameQuery, string>
    {

        #region Fields
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public RequestQueryHandler(IMapper mapper, IRequestService requestService)
        {
            _mapper = mapper;
            _requestService = requestService;
        }
        #endregion
        #region Handel Functions
        public async Task<Response<GetRequestByIdResponse>> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestService.GetRequestByIdAsync(request.RequestId);
            var resultMapping = _mapper.Map<GetRequestByIdResponse>(result);
            return Success(resultMapping);
        }

        public Task<PaginatedResponse<GetAllRequestsQueryResponse>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            var filterQuery = _requestService.FilterRequestsQuerable(request.OrderBy, request.Search);
            var result = _mapper.ProjectTo<GetAllRequestsQueryResponse>(filterQuery).ToPaginatedAsync(request.pageNumber, request.pageSize);
            return result;
        }

        public async Task<Response<int>> Handle(GetRequestsCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestService.GetCountAsync(request.Status);
            return Success(result);
        }

        public async Task<byte[]> Handle(DownloadRequestFileQuery request, CancellationToken cancellationToken)
        {
            return await _requestService.DownloadRequestFile(request.requestId);
        }

        public async Task<string> Handle(GetFileNameQuery request, CancellationToken cancellationToken)
        {
            return await _requestService.GetFileName(request.RequestId);

        }
        #endregion
    }
}
