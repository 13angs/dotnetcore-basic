using Microsoft.AspNetCore.Mvc;
using NxFullstack.DTOs.group;

namespace group_sv.Controllers
{
    [ApiController]
    [Route("api/v1/group/groups")]
    public class GroupController : ControllerBase
    {
        public GroupController()
        {
            
        }

        [HttpPost]
        public ActionResult Create([FromBody] GroupModel model)
        {
            return Ok(model);
        }
    }
}