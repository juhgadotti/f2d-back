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
        public OrderDTO Get(Guid id);
        public OrderModel Update(OrderModel model);
        public List<OrderModel> List();
        public OrderDTO Insert(OrderDTO model);

        public OrderModel BuildOrder(Guid id);
    }
}
