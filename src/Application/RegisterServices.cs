
using Application.Common.Interfaces.Persistence;
using Application.Features.Products.Commands;
using Application.Services.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterServices).Assembly));
            return service;
        }
    }
}
