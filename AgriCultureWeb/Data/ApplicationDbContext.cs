using AgriCultureWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AgriCultureWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Farmer> Farmers { get; set; }
		public DbSet<WorkShop> WorkShops { get; set; }
		public DbSet<AgriCultureWeb.Models.Employee> Employee { get; set; } = default!;
    }
}
