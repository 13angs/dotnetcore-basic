using member_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace member_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly MemberContext context;

        public MembersController(ILogger<MembersController> logger, MemberContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> Create([FromBody] Member model)
        {
            await context.Members.AddAsync(model);
            await context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Member> members = context.Members;
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