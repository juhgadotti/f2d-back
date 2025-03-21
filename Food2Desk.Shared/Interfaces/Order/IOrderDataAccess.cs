using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces.Order
{
    public interface IOrderDataAccess
    {
        public OrderModel Get();
        public List<OrderModel> List();
        public OrderModel Insert(OrderModel model);

        public OrderModel BuildOrder(Guid id);
    }
}
