using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Drug.Query.Models;
using MedicalChecker.Core.Features.Drug.Query.Response;
using MedicalChecker.Core.Wrappers;
using MedicalChecker.Services.Interfaces;

namespace MedicalChecker.Core.Features.Drug.Query.Handler
{
    public class DrugQueryHandler : ResponseHandler,
        IRequestHandler<GetAllDrugsQuery, PaginatedResponse<GetAllDrugsQueryResponse>>,
        IRequestHandler<GetDrugsCountQuery, Response<int>>,
        IRequestHandler<GetDrugByIdQuery, Response<GetDrugByIdQueryResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor

        public DrugQueryHandler(IMapper mapper, IDrugService drugService)
        {
            _mapper = mapper;
            _drugService = drugService;
        }
        #endregion

        #region Handel Functions
        public Task<PaginatedResponse<GetAllDrugsQueryResponse>> Handle(GetAllDrugsQuery request, CancellationToken cancellationToken)
        {
            var filterQuery = _drugService.FilterDrugsQuerable(request.Search);
            var result = _mapper.ProjectTo<GetAllDrugsQueryResponse>(filterQuery).ToPaginatedAsync(request.pageNumber, request.pageSize);
            return result;
        }

        public async Task<Response<int>> Handle(GetDrugsCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _drugService.GetCountAsync();
            return Success(result);
        }

        public async Task<Response<GetDrugByIdQueryResponse>> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _drugService.GetDrugByIdAsync(request.DrugId);
            var resultMapping = _mapper.Map<GetDrugByIdQueryResponse>(result);
            return Success(resultMapping);
        }
        #endregion
    }
}
