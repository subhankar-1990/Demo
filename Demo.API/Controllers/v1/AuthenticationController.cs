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
        public async Task<ActionResult> Signin([FromBody] SigninCommand request)
        {
            var result = await mediator.Send(new SigninCommand { EmpNo = request.EmpNo, Password = request.Password });
            if (string.IsNullOrEmpty(result))
            {
                return NotFound("EmpNo or Password not match !!!!");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
