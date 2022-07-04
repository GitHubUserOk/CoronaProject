using Microsoft.EntityFrameworkCore;

namespace CoronaProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Visitor> Visitor => Set<Visitor>();
        public DbSet<Certificate> Certificate => Set<Certificate>();

    }
}
