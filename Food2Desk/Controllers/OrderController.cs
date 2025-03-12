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
        public OrderModel Insert(OrderModel model)
        {
            return model;
        }

        [HttpPut("")]
        public OrderModel Update(OrderModel model)
        {
            return model;
        }

        [HttpDelete("")]
        public IActionResult Delete()
        {
            return Ok();
        }

        #region test
        [HttpPost("test")]
        public IActionResult Test(OrderModel model)
        {
            var a = model;
            return Ok();
        }
        #endregion
    }
}
