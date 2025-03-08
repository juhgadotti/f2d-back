using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Model;

namespace Food2Desk.DataAccess.Order
{
    public class OrderDataAccess : IOrderDataAccess
    {
        public OrderModel Insert(OrderModel model)
        {
            model.UserName = "deu certinho";

            return model;
        }
    }
}
