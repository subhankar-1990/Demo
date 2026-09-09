using MediatR;

namespace Demo.Application.Services.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public string Name { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string EmailID { get; set; } = null!;
    }
}
