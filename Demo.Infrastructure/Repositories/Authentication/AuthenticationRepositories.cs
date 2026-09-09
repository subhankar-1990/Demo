using Demo.Infrastructure.Context;
using Demo.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Repositories.Authentication
{
    public interface IAuthenticationRepositories
    {
        Task<bool> SigninAsync(string empNo, string password, CancellationToken cancellationToken);
    }
    public class AuthenticationRepositories(DemoDbContext context) : IAuthenticationRepositories
    {
        public async Task<bool> SigninAsync(string empNo, string password, CancellationToken cancellationToken)
        {
            var user = await context.AuthMasters.FirstOrDefaultAsync(e => e.EmpNo.ToString() == empNo && e.Password == password, cancellationToken);
            return user != null;
        }
    }
}
