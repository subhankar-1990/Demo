using MediatR;

namespace Demo.Application.Services.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public string Name { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string EmailID { get; set; } = null!;
    }
}
