using AutoMapper;
using MediatR;
using MedicalChecker.Core.Bases;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Data.Entities;
using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;

namespace MedicalChecker.Core.Features.Departments.Command.Handler
{
    public class DepartmentCommandHandler : ResponseHandler,
        IRequestHandler<CreateDepartmentCommand, Response<string>>,
        IRequestHandler<UpdateDepartmentCommand, Response<string>>,
        IRequestHandler<DeleteDepartmentCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DepartmentCommandHandler(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        #endregion

        #region Handel Functions
        public async Task<Response<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept = _mapper.Map<Department>(request);
            var result = await _departmentService.CreateAsync(dept);
            if (result == SD.Success)
                return Created("");
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept = _mapper.Map(request, await _departmentService.GetDepartmentByIdAsync(request.DeptId));
            var result = await _departmentService.UpdateAsync(dept);
            if (result == SD.Success)
                return Updated<string>();
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(request.DeptId);
            var result = await _departmentService.DeleteAsync(dept);
            if (result == SD.Success)
                return Deleted<string>();
            else
                return BadRequest<string>(result);
        }
        #endregion


    }
}
