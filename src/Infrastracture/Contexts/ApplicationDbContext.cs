using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Contexts
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService currentUserService) : base(options) 
        {

        }
    }
}
