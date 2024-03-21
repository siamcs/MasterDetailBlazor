using Blazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
