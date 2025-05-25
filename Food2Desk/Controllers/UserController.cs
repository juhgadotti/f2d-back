using Microsoft.AspNetCore.Mvc;
using Food2Desk.Shared.Model;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;

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
            var user = UserCore.Get();

            return new JsonResult(user);
        }

        [HttpGet("aaa")]
        public JsonResult ListBanco()
        {
            var user = UserCore.ListBanco();

            return new JsonResult(user);
        }

        [HttpPost("")]
        public JsonResult Insert(UserRegisterModel user)
        {
            UserCore.Insert(user);

            return new JsonResult(user);
        }

        [HttpPut("auth")]
        public IActionResult Authentication([FromBody] UserAuthModel user)
        {
            var userRegistered = UserCore.Authentication(user);

            if (userRegistered == null) return NotFound(user.Email);

            return Ok(userRegistered);
        }
    }
}
