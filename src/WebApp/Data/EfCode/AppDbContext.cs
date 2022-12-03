using Microsoft.EntityFrameworkCore;
using WebApp.Data.EfClasses;

namespace WebApp.Data.EfCode
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidature> Candidatures { get; set; }
    }
}