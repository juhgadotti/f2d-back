using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public readonly IOrderCore OrderCore;
        public OrderController(IOrderCore order)
        {
            OrderCore = order;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("")]
        public IActionResult Insert(OrderModel model)
        {
            return Ok();
        }

        [HttpPut("")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
