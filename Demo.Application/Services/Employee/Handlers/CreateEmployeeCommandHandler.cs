using Demo.Application.Services.Employee.Commands;
using Demo.Infrastructure.Repositories.Employee;
using MediatR;

namespace Demo.Application.Services.Employee.Handlers
{
    public class CreateEmployeeCommandHandler(IEmployeeRepositories repositories) : IRequestHandler<CreateEmployeeCommand, bool>
    {
        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await repositories.CreateEmployeeAsync(request.Name, request.MobileNo, request.EmailID, cancellationToken);
        }
    }
}
