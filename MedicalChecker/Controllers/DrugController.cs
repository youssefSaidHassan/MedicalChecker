using MedicalChecker.Api.Bases;
using MedicalChecker.Core.Features.Drug.Command.Models;
using MedicalChecker.Core.Features.Drug.Query.Models;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace MedicalChecker.Api.Controllers
{
    [ApiController]
    public class DrugController : AppControllerBase
    {
        [HttpGet(Router.Drug.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDrugsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(Router.Drug.Count)]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await _mediator.Send(new GetDrugsCountQuery()));
        }
        [HttpGet(Router.Drug.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new GetDrugByIdQuery(id)));
        }
        [HttpPost(Router.Drug.Create)]
        public async Task<IActionResult> Create([FromForm] CreateDrugCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPut(Router.Drug.Update)]
        public async Task<IActionResult> UpdateStatus([FromForm] UpdateDrugCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpDelete(Router.Drug.Delete)]
        public async Task<IActionResult> UpdateStatus([FromRoute] int drugId)
        {
            return NewResult(await _mediator.Send(new DeleteDrugCommand(drugId)));
        }
    }
}
