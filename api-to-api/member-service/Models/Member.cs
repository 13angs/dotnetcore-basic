using member_service.DTOs;

namespace member_service.Models
{
    public class Member 
    {
        public Member()
        {
            Setting = new GetMemberSettingModel();
        }
        public long Id {get; set;}
        public string? Name {get; set;}
        public GetMemberSettingModel Setting { get; set; }
    }
}