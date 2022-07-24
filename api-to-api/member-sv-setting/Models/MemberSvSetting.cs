using System.ComponentModel.DataAnnotations;

namespace member_sv_setting.Models
{
    public class MemberSvSetting
    {
        [Key]
        public long Id { get; set; }
        public string? Name {get; set; }
        public long MemberId { get; set;}
    }
}