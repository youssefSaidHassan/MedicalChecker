using MedicalChecker.Api.Bases;
using MedicalChecker.Core.Features.Departments.Command.Models;
using MedicalChecker.Core.Features.Departments.Query.Models;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace MedicalChecker.Api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.Department.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(Router.Department.Count)]
        public async Task<IActionResult> GetCount()
        {
            return NewResult(await _mediator.Send(new GetDepartmentsCountQuery()));
        }
        //[HttpGet(Router.Drug.GetById)]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    return NewResult(await _mediator.Send(new GetDrugByIdQuery(id)));
        //}
        [HttpPost(Router.Department.Create)]
        public async Task<IActionResult> Create([FromForm] CreateDepartmentCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPut(Router.Department.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateDepartmentCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpDelete(Router.Department.Delete)]
        public async Task<IActionResult> UpdateStatus([FromRoute] int deptId)
        {
            return NewResult(await _mediator.Send(new DeleteDepartmentCommand(deptId)));
        }
    }
}
