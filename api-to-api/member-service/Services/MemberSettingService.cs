using System.Text;
using System.Text.Json;
using member_service.DTOs;

namespace member_service.Services
{
    public interface IMemberSetting
    {
        public Task<object> Create(MemberSettingModel model);
        public Task<IEnumerable<GetMemberSettingModel>> Get();
        // public Task<IEnumerable<GetMemberSettingModel>> Update(long id, GetMemberSettingModel model);
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

        public async Task<IEnumerable<GetMemberSettingModel>> Get(){
            HttpResponseMessage response = new HttpResponseMessage();
            IEnumerable<GetMemberSettingModel>? models = new List<GetMemberSettingModel>();

            try{
                response = await client.GetAsync($"{endpoint}/{route}");
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Sync To MemberSetting Service is OK");
                    var strRes = await response.Content.ReadAsStringAsync();
                    models = JsonSerializer.Deserialize<IEnumerable<GetMemberSettingModel>>(strRes);
                }

                return models!;
            }catch (Exception ex)
            {
                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("--> Fail to Sync To MemberSetting");
                }
                return new List<GetMemberSettingModel>();
            }
        }
    
        // public async Task<GetMemberSettingModel> Update(long id, GetMemberSettingModel model)
        // {
        //     try{

        //     }catch (Exception ex)
        //     {
        //         Console.WriteLine(ex);
        //     }
        // }
    }
}