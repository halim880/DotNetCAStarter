using Application.Interfaces.Services;
using Infrastracture.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RESTApi.Services;
using System.Data;

namespace RESTApi
{
    public static class RegisterServices
    {
        public static IServiceCollection AddRESTApiServer(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpContextAccessor();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString),
                         ServiceLifetime.Transient);

            services.AddTransient<IDbConnection>(provider => new SqlConnection(connectionString));

            

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            return services;
        }
    }
}
