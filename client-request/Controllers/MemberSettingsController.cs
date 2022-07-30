using client_request.DTOs;
using member_service.SyncDataService;
using Microsoft.AspNetCore.Mvc;

namespace client_request.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class MemberSettingsController : ControllerBase
    {
        private readonly IMemberSetting setting;

        public MemberSettingsController(IMemberSetting setting)
        {
            this.setting = setting;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MemberSettingModel model)
        {
            object res = await setting.Create(model);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var res = await setting.Get();
            return Ok(res);
        }
    }
}