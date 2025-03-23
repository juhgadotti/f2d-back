using Food2Desk.Shared.DTOs;
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
        public OrderDTO Update(OrderDTO model);
        public List<OrderDTO> List();
        public OrderDTO Insert(OrderDTO model);

        public OrderDTO BuildOrder(Guid id);
    }
}
