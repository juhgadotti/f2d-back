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
        public Int32 Code {  get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public decimal TotalCharge { get; set; } = 0;
        public bool ToDelivery { get; set; }
        public bool isLunch { get; set; }
        public Int32 Status { get; set; } 
        public OfficeModel Office { get; set; }
        public List<ProductCartModel> Cart { get; set; }


        public static OrderModel BuildModel(OrderDTO dto)
        {
            return new OrderModel
            {
                Id = dto.Id,
                Code = dto.Code,
                UserId = dto.UserId,
                UserName = dto.UserName,
                TotalCharge = dto.TotalCharge,
                ToDelivery = dto.ToDelivery,
                Status = dto.Status,
                Office = OfficeModel.BuildModel(dto.Office),
                Cart = dto.Cart.Select(ProductCartModel.BuildCartModel).ToList()
            };
        }

        public static OrderDTO BuildDTO(OrderModel model)
        {
            return new OrderDTO
            {
                Id = model.Id,
                Code = model.Code,
                UserId = model.UserId,
                UserName = model.UserName,
                TotalCharge = model.TotalCharge,
                ToDelivery = model.ToDelivery,
                Status = model.Status,
                Office = OfficeModel.BuildDTO(model.Office),
                Cart = model.Cart.Select(ProductCartModel.BuildCartDTO).ToList()
            };
        }
    }

    public class ProductCartModel
    {
        public Guid ProductId { get; set; }
        public Int32 Quantity { get; set; }
        public Double Price { get; set; }
        public String Name { get; set; }

        public static ProductCartDTO BuildCartDTO(ProductCartModel cartModel)
        {
            return new ProductCartDTO { ProductId = cartModel.ProductId, Quantity = cartModel.Quantity, Price = cartModel.Price, Name = cartModel.Name };
        }
        public static ProductCartModel BuildCartModel(ProductCartDTO cartDTO)
        {
            return new ProductCartModel { ProductId = cartDTO.ProductId, Quantity = cartDTO.Quantity, Price = cartDTO.Price, Name = cartDTO.Name };
        }
    }
}