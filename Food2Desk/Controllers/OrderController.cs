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

        [HttpPost("")]
        public OrderModel Insert(OrderModel model)
        {
            return OrderCore.Insert(model);
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
