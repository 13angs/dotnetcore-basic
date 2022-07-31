using member_service.DTOs;
using member_service.Models;
using member_service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace member_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly MemberContext context;
        private readonly IMemberSetting stRepo;

        public MembersController(
            ILogger<MembersController> logger, 
            MemberContext context,
            IMemberSetting stRepo)
        {
            _logger = logger;
            this.context = context;
            this.stRepo = stRepo;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> Create([FromBody] Member model)
        {
            await context.Members.AddAsync(model);
            await context.SaveChangesAsync();

            if(model.Id != 0)
            {
                MemberSettingModel settingModel = new MemberSettingModel{
                    MemberId=model.Id,
                    Name=model.Name
                };

                await stRepo.Create(settingModel);
            }

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetMemberSettingModelParam param)
        {
            IList<Member> members = context.Members.ToList();
            if(param.Query == "setting")
            {

                IEnumerable<GetMemberSettingModel> settingModels = await stRepo.Get();

                foreach(GetMemberSettingModel model in settingModels)
                {
                    Member? member = members
                        .FirstOrDefault(m => m.Id == model.memberId);
                    if(member != null)
                    {
                        member.Setting = model;
                    }
                }
            }else{
                members = context.Members.ToList();
            }
            return Ok(members);
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult> Get([FromRoute] long id)
        {
            Member? member = await context.Members.FindAsync(id);
            return Ok(member);
        }

        [HttpPut, Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] long id, [FromBody] Member model)
        {
            Member? member = await context.Members.FindAsync(id);
            member!.Name = model!.Name;
            await context.SaveChangesAsync();
            return Ok(member);
        }

        [HttpDelete, Route("{id}")]
        public async Task<ActionResult> Remove([FromRoute] long id)
        {
            Member? member = await context.Members.FindAsync(id);
            context.Members.Remove(member!);
            await context.SaveChangesAsync();
            return Ok(member);
        }
    }
}