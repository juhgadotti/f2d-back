using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces.Order
{
    public interface IOrderDataAccess : IBaseRepository<OrderDTO>
    {
        public OrderDTO Get(Guid id);
        //public List<OrderDTO> ListMocked();
        //public OrderDTO BuildOrder(Guid id);
        public List<OrderDTO> List();
    }
}
