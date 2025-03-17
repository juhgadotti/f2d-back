using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;

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

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(); //commit de doming
        }

        [HttpPost("")]
        public JsonResult Insert(OrderModel model)
        {
            return new JsonResult(model);
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
