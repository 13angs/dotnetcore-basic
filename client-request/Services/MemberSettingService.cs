using System.Text;
using System.Text.Json;
using client_request.DTOs;

namespace member_service.SyncDataService
{
    public interface IMemberSetting
    {
        public Task<object> Create(MemberSettingModel model);
        public Task<IEnumerable<object>> Get();
    }

    public class MemberSettingService : IMemberSetting
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public string endpoint {get; set; }
        public string route {get; set; }

        public MemberSettingService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
            endpoint = configuration["MemberSettingService:endpoint"];
            route = configuration["MemberSettingService:route"];

        }
        public async Task<object> Create(MemberSettingModel model)
        {
            StringContent content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json"
            );

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

        public async Task<IEnumerable<object>> Get(){
            HttpResponseMessage response = new HttpResponseMessage();
            try{
                response = await client.GetAsync($"{endpoint}/{route}");
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Sync To MemberSetting Service is OK");
                }
                else
                {
                    Console.WriteLine("--> Fail to Sync To MemberSetting");
                }

                var strRes = await response.Content.ReadAsStringAsync();
                Console.WriteLine(strRes);

                IEnumerable<GetMemberSettingModel>? models = JsonSerializer.Deserialize<IEnumerable<GetMemberSettingModel>>(strRes);

                return models!;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<GetMemberSettingModel>();
            }
        }
    }
}