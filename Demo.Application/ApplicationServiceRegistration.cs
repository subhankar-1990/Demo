using Demo.Application.Services.Employee.Commands;
using Demo.Application.Services.Employee.Validations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Demo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Behaviors.ValidationBehavior<,>));

            services.AddTransient<IValidator<CreateEmployeeCommand>, CreateEmployeeCommandValidator>();

            return services;
        }
    }
}
