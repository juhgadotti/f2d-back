using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces.Order
{
    public interface IOrderCore
    {
        public OrderDTO Get(Guid id);
        public List<OrderDTO> List();
        public OrderDTO Update(OrderDTO dto);
        public OrderDTO Insert(OrderDTO dto);
    }
}
