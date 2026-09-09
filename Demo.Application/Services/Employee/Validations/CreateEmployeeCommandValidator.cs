using Demo.Application.Services.Employee.Commands;
using FluentValidation;

namespace Demo.Application.Services.Employee.Validations
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);

            RuleFor(p => p.MobileNo)
                .NotEmpty().WithMessage("Mobile Number is required.")
                .Matches(@"^\d{10}$").WithMessage("Invalid Mobile Number format.");

            RuleFor(p => p.EmailID)
                .NotEmpty().WithMessage("Email ID is required.")
                .EmailAddress().WithMessage("Invalid Email ID format.");
        }
    }
}
