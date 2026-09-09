using Demo.Application.Services.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RateLimiting;

namespace Demo.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache(PolicyName = "CachePolicy")]
    [EnableRateLimiting("ConcurrencyPolicy")]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Signin([FromBody] SigninCommand request)
        {
            var token = await mediator.Send(new SigninCommand { EmpNo = request.EmpNo, Password = request.Password });
            if (string.IsNullOrEmpty(token))
            {
                return NotFound(new { message = "EmpNo or Password not match !!!!" });
            }
            else
            {
                return Ok(new { token });
            }
        }
    }
}
