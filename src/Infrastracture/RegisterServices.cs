

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastracture.Authentication;
using Infrastracture.Persistence;
using Infrastracture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }
    }
}
