using Microsoft.AspNetCore.Mvc;
using NxFullstack.DTOs.group;

namespace user_sv.Controllers
{
    [ApiController]
    [Route("api/v1/user/groups")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult Create([FromBody] GroupModel model)
        {
            return Ok(model);
        }
    }
}