using ef_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ef_core.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly EFCoreDbContext dbContext;

        public UsersController(EFCoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel model)
        {
            User user = new User{
                Name=model.Name
            };
            
            try
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }catch
            {
                return StatusCode(StatusCodes.Status409Conflict, new {field="Name", msg=string.Format("User with name {0} exist!", user.Name)});
            }
            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<User> users = dbContext.Users;
                return Ok(users);
            }catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}