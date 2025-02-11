using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;

namespace MedicalChecker.Core.Features.Drug.Command.Handler
{
    public class DrugCommandHandler : ResponseHandler,
        IRequestHandler<CreateDrugCommand, Response<string>>,
        IRequestHandler<UpdateDrugCommand, Response<string>>,
        IRequestHandler<DeleteDrugCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IDrugService _drugService;
        #endregion

        #region Constructor
        public DrugCommandHandler(IMapper mapper, IDrugService drugService)
        {
            _mapper = mapper;
            _drugService = drugService;
        }
        #endregion

        #region Handel Functions
        public async Task<Response<string>> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = _mapper.Map<Data.Entities.Drug>(request);
            var result = await _drugService.CreateAsync(drug);
            if (result == SD.Success)
                return Created("");
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = await _drugService.GetDrugByIdAsync(request.Id);
            drug = _mapper.Map(request, drug);
            var result = await _drugService.UpdateAsync(drug);
            if (result == SD.Success)
                return Updated<string>();
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = await _drugService.GetDrugByIdAsync(request.DrugId);
            var result = await _drugService.DeleteAsync(drug);
            if (result == SD.Success)
                return Deleted<string>();
            else
                return BadRequest<string>(result);
        }
        #endregion
    }
}
