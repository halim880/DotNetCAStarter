using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Contexts
{
    public partial class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService) : base(options) 
        {

        }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Customer> Customers { get; set; }
    }
}
