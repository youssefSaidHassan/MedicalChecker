using MedicalChecker.Api.Bases;
using MedicalChecker.Core.Features.Request.Command.Models;
using MedicalChecker.Core.Features.Request.Query.Models;
using MedicalChecker.Core.Features.Request.Query.Responses;
using MedicalChecker.Utility.AppMetaData;
using MedicalChecker.Utility.Helper.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MedicalChecker.Api.Controllers
{
    [ApiController]
    public class RequestController : AppControllerBase
    {
        [HttpGet(Router.Request.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new GetRequestByIdQuery(id)));
        }

        [HttpGet(Router.Request.Count)]
        public async Task<IActionResult> GetCount([FromQuery] RequestStatusEnum? request = null)
        {
            return NewResult(await _mediator.Send(new GetRequestsCountQuery(request)));
        }
        [HttpGet(Router.Request.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRequestsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(Router.Request.Create)]
        public async Task<IActionResult> Create([FromForm] CreateRequestCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPut(Router.Request.UpdateStatus)]
        public async Task<IActionResult> UpdateStatus([FromQuery] UpdateRequestStatusCommand command)
        {
            return NewResult(await _mediator.Send(command));

        }
        [HttpDelete(Router.Request.Delete)]
        public async Task<IActionResult> DeleteRequest(int requestId)
        {
            return NewResult(await _mediator.Send(new DeleteRequestCommand(requestId)));

        }

        [HttpGet(Router.Request.Download)]
        public async Task<IActionResult> DownloadFile([FromRoute] int id)
        {
            try
            {
                var fileData = await _mediator.Send(new DownloadRequestFileQuery(id));
                var fileName = await _mediator.Send(new GetFileNameQuery(id));
                return File(fileData, "application/pdf", fileName);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
