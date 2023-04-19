
using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            return service;
        }
    }
}
