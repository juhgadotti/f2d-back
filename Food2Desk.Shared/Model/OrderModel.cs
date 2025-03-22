using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public decimal? TotalCharge { get; set; }
        public bool DeliveryNow { get; set; }
        public string? DeliveryTime { get; set; }
        public OfficeModel Office { get; set; }
        public List<ProductCartModel> Cart { get; set; }


        public static OrderModel BuildModel(OrderDTO dto)
        {
            return new OrderModel
            {
                Id = dto.Id,
                UserId = dto.UserId,
                UserName = dto.UserName,
                TotalCharge = dto.TotalCharge,
                DeliveryNow = dto.DeliveryNow,
                DeliveryTime = dto.DeliveryTime,
                Office = OfficeModel.BuildModel(dto.Office),
                Cart = dto.Cart.Select(ProductCartModel.BuildCartModel).ToList()
            };
        }

        public OrderDTO BuildDTO(OrderModel model)
        {
            return new OrderDTO
            {
                Id = model.Id,
                UserId = model.UserId,
                UserName = model.UserName,
                TotalCharge = model.TotalCharge,
                DeliveryNow = model.DeliveryNow,
                DeliveryTime = model.DeliveryTime,
                Office = OfficeModel.BuildDTO(model.Office),
                Cart = model.Cart.Select(ProductCartModel.BuildCartDTO).ToList()
            };
        }
    }

    public class ProductCartModel
    {
        public Guid ProductId { get; set; }
        public Int32 Quantity { get; set; }

        public static ProductCartDTO BuildCartDTO(ProductCartModel cartModel)
        {
            return new ProductCartDTO { ProductId = cartModel.ProductId, Quantity = cartModel.Quantity };
        }
        public static ProductCartModel BuildCartModel(ProductCartDTO cartDTO)
        {
            return new ProductCartModel { ProductId = cartDTO.ProductId, Quantity = cartDTO.Quantity };
        }
    }
}