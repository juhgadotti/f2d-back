using Food2Desk.Core.Order;
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

        [HttpGet("get")]
        public JsonResult Get(Guid id)            
        {
            var order = OrderCore.Get(id);
            return new JsonResult(order);
        }

        [HttpGet]
        public JsonResult List()
        {
            var list = OrderCore.List();

            return new JsonResult(list);
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

        [HttpPut("status/{id:Guid}")]

        public IActionResult UpdateOrderStatus(Int32 status)
        {
            return Ok();
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
