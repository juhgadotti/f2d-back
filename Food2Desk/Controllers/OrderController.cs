using Food2Desk.Core;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        #region funciona
        [HttpPost("")]
        public JsonResult Insert(OrderRequestModel model)
        {
            model.Id = Guid.NewGuid();
            if (model.IsLunch && !model.ToDelivery)
            {
                model.Office = new OfficeModel()
                {
                    Id = Guid.Parse("bbfce7be-8317-40d0-b00d-99785790ebf2"),
                    Block = "A",
                    Number = "1",
                    Floor = "1"
                };
            }
            var dto = OrderRequestModel.BuildOrderDTO(model);
            return new JsonResult(OrderCore.Insert(dto));
        }

        [HttpGet("{id}")]
        public JsonResult ListUserOrder(Guid id)
        {
            var list = OrderCore.ListUserOrder(id).OrderByDescending(c => c.Code);
            return new JsonResult(list);
        }

        [HttpPost("lunch")]
        public JsonResult OrderLunch()
        {

            return new JsonResult("socorro");
        }


        #endregion

        [HttpGet("get")]
        public JsonResult Get(Guid id)            
        {
            var orderDTO = OrderCore.Get(id);

            return new JsonResult(OrderModel.BuildModel(orderDTO));
        }

        [HttpGet]
        public JsonResult List()
        {
            var listDTO = OrderCore.List().OrderByDescending(c => c.Code);

            return new JsonResult(listDTO.Select(OrderModel.BuildModel).ToList());
        }

        [HttpPut("")]
        public OrderModel Update(OrderModel model)
        {
            return model;
        }

        
        [HttpPut("status")] // /{id:Guid}
        public IActionResult UpdateOrderStatus([FromBody] OrderModel order)
        {
            var dto = OrderModel.BuildDTO(order);
            dto.Cart = [];
            OrderCore.Update(dto);
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
