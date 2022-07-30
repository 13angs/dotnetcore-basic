using member_sv_setting.Models;
using member_sv_setting.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace member_sv_setting.Controllers
{
    [Route("api/members/settings")]
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly MemberSettingContext context;

        public SettingsController(ILogger<SettingsController> logger, MemberSettingContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MemberSvSetting setting)
        {
            await context.MemberSettings.AddAsync(setting);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, setting);
        }

        [HttpGet]
        public ActionResult Get([FromQuery] MemberSettingParam param)
        {
            IEnumerable<MemberSvSetting> settings = context.MemberSettings;
            if(!String.IsNullOrEmpty(param.Query) && param.Query == "mid")
            {
                settings = context.MemberSettings
                    .Where(s => s.MemberId == param.Mid);
            }else{
                settings = context.MemberSettings;
            }
            return StatusCode(StatusCodes.Status200OK, settings);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> Get([FromRoute] long id)
        {
            MemberSvSetting? setting = await context.MemberSettings.FindAsync(id);
            return StatusCode(StatusCodes.Status200OK, setting);
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] MemberSettingModel model)
        {
            MemberSvSetting? setting = new MemberSvSetting();
            if(!String.IsNullOrEmpty(model.Action) && model.Action == "by_mid")
            {
                setting = await context.MemberSettings
                    .SingleOrDefaultAsync(s => s.MemberId == id);
            }else{
                setting = await context.MemberSettings.FindAsync(id);
            }
            setting!.Name = model.Name; 
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, setting);
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> Remove([FromRoute] long id, [FromQuery] MemberSettingParam param)
        {
            MemberSvSetting? setting = new MemberSvSetting();
            if(!String.IsNullOrEmpty(param.Action) && param.Action == "by_mid")
            {
                setting = await context.MemberSettings.SingleOrDefaultAsync(s => s.MemberId == param.Mid);
            }else{
                setting = await context.MemberSettings.FindAsync(id);
            }

            context.MemberSettings.Remove(setting!);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, setting);
        }
    }
}