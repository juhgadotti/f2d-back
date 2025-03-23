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

        [HttpGet]
        public JsonResult Get(Guid id)            
        {
            var order = OrderCore.Get(id);
            return new JsonResult(order);
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok(); 
        }

        [HttpPost("")]
        public JsonResult Insert(OrderModel model)
        {
            model.Id = Guid.NewGuid();
            var dto = OrderModel.BuildDTO(model);
            return new JsonResult(OrderCore.Insert(dto));
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
