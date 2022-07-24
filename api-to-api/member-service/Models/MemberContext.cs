

using Microsoft.EntityFrameworkCore;

namespace member_service.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedData();
        }

        public DbSet<Member> Members {get; set; } = null!;
    }
}