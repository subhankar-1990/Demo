using Demo.Application.Services.Authentication.Commands;
using Demo.Infrastructure.Repositories.Authentication;
using Demo.Infrastructure.Repositories.Employee;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.Application.Services.Authentication.Handlers
{
    public class SigninCommandHandler(IConfiguration configuration, IAuthenticationRepositories authenticationRepositories, IEmployeeRepositories employeeRepositories) : IRequestHandler<SigninCommand, string>
    {
        public async Task<string> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var isValidUser = await authenticationRepositories.SigninAsync(request.EmpNo, request.Password, cancellationToken);

            if (isValidUser)
            {
                var emp = await employeeRepositories.GetEmployeeByEmpNoAsync(request.EmpNo, cancellationToken);

                if (emp != null)
                {
                    var jwtSettings = configuration.GetSection("JwtSettings");
                    var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey is missing.");
                    var key = Encoding.UTF8.GetBytes(secretKey);

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, $"{emp.EmpName}"),
                        new Claim(ClaimTypes.Role, $"Admin"),
                    };

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(2),
                        Issuer = jwtSettings["Issuer"],
                        Audience = jwtSettings["Audience"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
