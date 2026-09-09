using Demo.Application.Services.Authentication.Commands;
using FluentValidation;

namespace Demo.Application.Services.Authentication.Validations
{
    public class SigninCommandValidator : AbstractValidator<SigninCommand>
    {
        public SigninCommandValidator()
        {
            RuleFor(p => p.EmpNo)
                .NotEmpty().WithMessage("Employee Number is required.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
