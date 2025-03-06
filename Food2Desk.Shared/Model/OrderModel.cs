using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food2Desk.Shared.Model
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalCharge { get; set; }
        public bool DeliveryNow { get; set; }
        public string? DeliveryTime { get; set; }
        public DateTime? DateMade { get; set; }
        public OfficeModel Office { get; set; }
        public List<ProductModel> Cart { get; set; }
    }
}