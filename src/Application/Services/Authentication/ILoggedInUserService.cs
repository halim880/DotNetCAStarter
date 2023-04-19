
namespace Application.Interfaces.Services
{
    public interface ILoggedInUserService
    {
        string UserId { get; }
        public string Role { get; }
    }
}
