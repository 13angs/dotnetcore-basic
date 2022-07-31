namespace member_service.DTOs
{
    public class GetMemberSettingModel
    {
        public virtual long id { get; set; }        
        public virtual string? name { get; set; }
        public virtual long memberId { get; set; }
    }
}