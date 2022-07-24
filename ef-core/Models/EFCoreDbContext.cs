
using Microsoft.EntityFrameworkCore;

namespace ef_core.Models
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.SeedData();
        }

        public virtual DbSet<User> Users { get; set; } = null!;

    }
}