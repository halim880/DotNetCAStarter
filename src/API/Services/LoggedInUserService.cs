using Application.Interfaces.Services;
using System.Security.Claims;

namespace RESTApi.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            Role = httpContextAccessor.HttpContext?.User?.FindFirstValue("role");
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
        }

        public string UserId { get; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
        public string Role { get; }
    }
}
