using MedicalChecker.Api.Bases;
using Microsoft.AspNetCore.Mvc;

namespace MedicalChecker.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost("Api/V1/Authentication/ConfirmEmail")]
        public IActionResult ConfirmEmail(string userId, string code)
        {
            return Ok(new { user = userId, code = code });
        }
    }
}
