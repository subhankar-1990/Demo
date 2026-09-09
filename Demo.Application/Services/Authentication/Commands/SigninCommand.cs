using MediatR;

namespace Demo.Application.Services.Authentication.Commands
{
    public class SigninCommand : IRequest<string>
    {
        public string EmpNo { get; set; }
        public string Password { get; set; }
    }
}
