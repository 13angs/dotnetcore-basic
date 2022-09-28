using group_sv.Models;
using Microsoft.AspNetCore.Mvc;

namespace group_sv.Controllers
{
    [ApiController]
    [Route("api/group/groups")]
    public class GroupController : ControllerBase
    {
        private readonly GroupContext context;

        public GroupController(GroupContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return context.Groups;
        }
    }
}