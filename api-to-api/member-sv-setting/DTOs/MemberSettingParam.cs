using Microsoft.AspNetCore.Mvc;

namespace member_sv_setting.DTOs
{
    [BindProperties]
    public class MemberSettingParam
    {
        public string? Query { get; set; }
        public string? Action { get; set; }
        public int Mid { get; set; }
    }
}