using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpPost("")]
        public IActionResult Insert(OrderModel model)
        {
            return Ok(model);
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
