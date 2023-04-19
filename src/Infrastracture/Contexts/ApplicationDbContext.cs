using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Contexts
{
    public partial class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService currentUserService) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
