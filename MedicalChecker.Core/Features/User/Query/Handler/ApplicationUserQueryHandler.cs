using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.User.Query.Models;
using MedicalChecker.Core.Features.User.Query.Responses;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.User.Query.Handler
{
    public class ApplicationUserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdQueryResponse>>,
        IRequestHandler<GetUsersCountQuery, Response<int>>,
        IRequestHandler<GetAllUsersQuery, PaginatedResponse<GetAllUsersResponse>>
    {
        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ApplicationUserQueryHandler(IApplicationUserService applicationUserService, IMapper mapper)
        {
            _applicationUserService = applicationUserService;
            _mapper = mapper;
        }
        #endregion

        #region Handel Functions
        public async Task<Response<GetUserByIdQueryResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserService.GetByIdAsync(request.UserId);
            var result = _mapper.Map<GetUserByIdQueryResponse>(user);
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            var result = _applicationUserService.GetUsersCount();
            return Success(result);
        }

        public async Task<PaginatedResponse<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var filterQuery = _applicationUserService.FilterUsersQuerable(request.OrderBy, request.Search);
            var result = await _mapper.ProjectTo<GetAllUsersResponse>(filterQuery).ToPaginatedAsync(request.pageNumber, request.pageSize);
            return result;
        }
        #endregion
    }
}
