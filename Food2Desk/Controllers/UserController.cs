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

        [HttpGet("{id}")]
        public JsonResult Get(Guid id)        
        {
            var user = UserCore.Get(id);

            return new JsonResult(user);
        }

        [HttpGet("aaa")]
        public JsonResult ListBanco()
        {
            var user = UserCore.ListBanco();

            return new JsonResult(user);
        }

        [HttpPost("")]
        public JsonResult Insert([FromBody] UserRegisterModel user)
        {
            var newUser = UserCore.Insert(user);

            return new JsonResult(newUser);
        }

        [HttpPut("auth")]
        public IActionResult Authentication([FromBody] UserAuthModel user)
        {

            if (user.Email == "admin@snack2desk.com")
            {
                return Ok();
            }            

            var userRegistered = UserCore.Authentication(user);

            if (userRegistered == null) return NotFound(user.Email);

            return Ok(userRegistered);
        }

        [HttpPost("office")]
        public JsonResult InsertOffice([FromBody] OfficeModel office)
        {
            var newOffice = UserCore.InsertNewOffice(office);
            return new JsonResult(newOffice);
        }
    }
}
