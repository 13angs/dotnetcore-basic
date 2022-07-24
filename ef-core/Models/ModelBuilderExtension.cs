using Microsoft.EntityFrameworkCore;

namespace ef_core.Models
{
    public static class ModelBuilderExtension {
        public static void SeedData (this ModelBuilder builder )
        {

            // for setting the name field as a unique value
            // can not be duplicated
            builder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique(true);


            // builder.Entity<User>()
            //     .HasIndex(p => p.UserId);
            // builder.Entity<User>()
            //     .Property(p => p.UserId)
            //     .ValueGeneratedOnAdd();
            // builder.Entity<User>()
            //     .HasAlternateKey("UserId");
        }
    }
}