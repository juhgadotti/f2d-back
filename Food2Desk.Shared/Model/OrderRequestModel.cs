using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class OrderRequestModel
    {
        public Guid Id { get; set; }
        public Int32 Code { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public decimal TotalCharge { get; set; } = 0;
        public bool ToDelivery { get; set; }
        public bool IsLunch { get; set; }
        public Int32 Status { get; set; }
        public OfficeModel Office { get; set; }
        public List<ProductCartModel> Cart { get; set; }

        public static OrderDTO BuildOrderDTO(OrderRequestModel model)
        {
            return new OrderDTO
            {
                Id = model.Id,
                Code = model.Code,
                UserId = model.UserId,
                UserName = model.UserName,
                TotalCharge = model.TotalCharge,
                ToDelivery = model.ToDelivery,
                IsLunch = model.IsLunch,
                Status = model.Status,
                OfficeId = (Guid)model.Office.Id,
                Cart = model.Cart.Select(ProductCartModel.BuildCartDTO).ToList()
            };
        }
    }
}
