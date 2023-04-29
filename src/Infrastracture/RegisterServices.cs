

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Interfaces;
using Infrastracture.Authentication;
using Infrastracture.Contexts;
using Infrastracture.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            service.AddScoped<IUserRepository, UserRepository>();
            //service.AddScoped<IProductRepository, ProductRepository>();
            service.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            return service;
        }
    }
}
