using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Departments.Query.Models;
using MedicalChecker.Core.Features.Departments.Query.Response;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Departments.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllDepartmentsQuery, PaginatedResponse<GetAllDepartmentsQueryResponse>>,
        IRequestHandler<GetDepartmentsCountQuery, Response<int>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        #endregion

        #region Handel Functions
        public Task<PaginatedResponse<GetAllDepartmentsQueryResponse>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var filterQuery = _departmentService.FilterDepartmentsQuerable(request.Search);
            var result = _mapper.ProjectTo<GetAllDepartmentsQueryResponse>(filterQuery).ToPaginatedAsync(request.pageNumber, request.pageSize);
            return result;
        }

        public async Task<Response<int>> Handle(GetDepartmentsCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetCountAsync();
            return Success(result);
        }
        #endregion


    }
}
