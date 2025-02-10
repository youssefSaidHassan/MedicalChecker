using MedicalChecker.Api.Bases;
using MedicalChecker.Core.Features.User.Command.Models;
using MedicalChecker.Core.Features.User.Query.Models;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace MedicalChecker.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpGet(Router.ApplicationUser.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(Router.ApplicationUser.GetById)]
        public async Task<IActionResult> GetUser([FromRoute] string userId)
        {
            return NewResult(await _mediator.Send(new GetUserByIdQuery(userId)));
        }
        [HttpGet(Router.ApplicationUser.GetUserRequests)]
        public async Task<IActionResult> GetUserRequests([FromQuery] GetUserRequestsQuery query)
        {
            return NewResult(await _mediator.Send(query));
        }
        [HttpGet(Router.ApplicationUser.Count)]
        public async Task<IActionResult> GetUsersCount()
        {
            return NewResult(await _mediator.Send(new GetUsersCountQuery()));
        }
        [HttpPost(Router.ApplicationUser.Create)]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }


        [HttpPut(Router.ApplicationUser.Update)]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPut(Router.ApplicationUser.ChangePassword)]
        public async Task<IActionResult> ChangeUserPassword([FromForm] ChangePasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpDelete(Router.ApplicationUser.Delete)]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            return NewResult(await _mediator.Send(new DeleteUserCommand(userId)));
        }

    }
}
