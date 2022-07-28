using Microsoft.EntityFrameworkCore;

namespace member_sv_setting.Models
{
    public class MemberSettingContext : DbContext
    {
        public MemberSettingContext(DbContextOptions<MemberSettingContext> options): base(options)
        {
            
        }

        public DbSet<MemberSvSetting> MemberSettings { get; set; } = null!;
    }
}