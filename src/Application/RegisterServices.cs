
using Application.Common.Interfaces.Persistence;
using Application.Features.Products.Commands;
using Application.Services.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RegisterServices).Assembly));
            return services;
        }
    }
}
