using Application.Interfaces.Services;
using RESTApi.Services;

namespace RESTApi
{
    public static class RegisterServices
    {
        public static IServiceCollection AddRESTApiServer(this IServiceCollection service)
        {
            service.AddHttpContextAccessor();
            service.AddScoped<ILoggedInUserService, LoggedInUserService>();
            return service;
        }
    }
}
