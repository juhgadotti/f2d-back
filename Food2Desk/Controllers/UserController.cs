using Microsoft.AspNetCore.Mvc;
using Food2Desk.Shared.Model;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.User;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserCore UserCore;

        public UserController(IUserCore userCore)
        {
            UserCore = userCore;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            UserModel user = UserCore.Get();

            return new JsonResult(user);
        }
    }
}
