using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public decimal? TotalCharge { get; set; }
        public bool DeliveryNow { get; set; }
        public string? DeliveryTime { get; set; }
        public Int32 Status { get; set; }
        public OfficeDTO Office { get; set; }
        public required List<ProductCartDTO> Cart { get; set; }
    }

    public class ProductCartDTO
    {
        public Guid ProductId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
