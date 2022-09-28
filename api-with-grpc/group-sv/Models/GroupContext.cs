using Microsoft.EntityFrameworkCore;

namespace group_sv.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {
            
        }

        public DbSet<Group> Groups { get; set; } = null!;
    }
}