using System.Text;
using System.Text.Json;
using member_service.Models;

namespace member_service.SyncDataService
{
    public interface IMemberSetting
    {
        public Task<object> Create(Member member);
    }

    public class MemberSettingModel 
    {
        public long MemberId {get; set;}
        public string? Name {get; set;}
    }
    public class MemberSettingService : IMemberSetting
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public MemberSettingService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;

        }
        public async Task<object> Create(Member member)
        {
            MemberSettingModel settingModel = new MemberSettingModel{MemberId=member.Id, Name=member.Name};
            StringContent content = new StringContent(
                JsonSerializer.Serialize(settingModel),
                Encoding.UTF8,
                "application/json"
            );

            string endpoint = configuration["MemberSettingService:endpoint"];
            string route = configuration["MemberSettingService:route"];

            HttpResponseMessage response = new HttpResponseMessage();
            try{
                response = await client.PostAsync($"{endpoint}/{route}", content);
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Sync To MemberSetting Service is OK");
                }
                else
                {
                    Console.WriteLine("--> Fail to Sync To MemberSetting");
                }
                return new {status=200};
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new {status=400};
            }

        }
    }
}