using member_sv_setting.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Get()
        {
            IEnumerable<MemberSvSetting> settings = context.MemberSettings;
            return StatusCode(StatusCodes.Status200OK, settings);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> Get([FromRoute] long id)
        {
            MemberSvSetting? setting = await context.MemberSettings.FindAsync(id);
            return StatusCode(StatusCodes.Status200OK, setting);
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] MemberSvSetting model)
        {
            MemberSvSetting? setting = await context.MemberSettings.FindAsync(id);
            setting!.Name = model.Name; 
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, setting);
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> Remove([FromRoute] long id)
        {
            MemberSvSetting? setting = await context.MemberSettings.FindAsync(id);
            context.MemberSettings.Remove(setting!);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, setting);
        }
    }
}