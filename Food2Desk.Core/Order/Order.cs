using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Core.Order
{
    public class Order : IOrderCore
    {
        private readonly IOrderDataAccess OrderDA;
        public Order(IOrderDataAccess orderDA)
        {
            OrderDA = orderDA;
        }

        public OrderModel Insert(OrderModel model)
        {
            return OrderDA.Insert(model);
        }

        public OrderModel BuildOrder(Guid id)
        {
            var order = OrderDA.list().FirstOrDefault(i => i.id == id);
        }
    }
}
