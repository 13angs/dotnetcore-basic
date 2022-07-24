using Microsoft.EntityFrameworkCore;

namespace member_service.Models
{
    public static class ModelBuilderExtension
    {
        public static void SeedData (this ModelBuilder builder)
        {
            builder.Entity<Member>()
                .HasIndex(m => m.Name)
                .IsUnique(true);

            // builder.Entity<Member>()
            //     .HasData(
            //         new Member{Id=1,Name="don"},
            //         new Member{Id=2,Name="romd"},
            //         new Member{Id=3,Name="romdon"}
            //     );
        }
    }
}