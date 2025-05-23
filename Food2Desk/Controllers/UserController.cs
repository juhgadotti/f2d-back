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
        public JsonResult Insert(UserModel user)
        {
            var a = user;

            return new JsonResult(user);
        }

        [HttpGet("authentication")]
        public IActionResult Authentication(UserAuthenticationModel user)
        {
            UserAuthenticationModel userRegistered = UserCore.GetUserInfo(user.Email);          

            if(userRegistered == null) return NotFound(user.Email);

            if (userRegistered.Password == user.Password) {
                return Ok(userRegistered);
            }
            
            return BadRequest();
        }


    }
}
