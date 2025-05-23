using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces;
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
        private readonly IProductDataAccess ProductDA;
        public Order(IOrderDataAccess orderDA, IProductDataAccess productDA)
        {
            OrderDA = orderDA;
            ProductDA = productDA;
        }

        public OrderDTO Get(Guid id)
        {
            return OrderDA.Get(id);
        }

        public List<OrderDTO> List()
        {
            var list = OrderDA.List();
            list.ForEach(p => Math.Round(p.TotalCharge = p.Cart.Sum(u => u.Quantity * (decimal)u.Price), 2));

            return list;
        }

        public OrderDTO Update(OrderDTO dto)
        {
            return OrderDA.Update(dto);
        }

        public OrderDTO Insert(OrderDTO dto)
        {
            return OrderDA.Insert(dto);
        }

        public void UpdateStatus(Guid id, Int32 status)
        {
            //orderDA
        }

        public OrderDTO BuildOrder(Guid id) //test
        {
            var order = OrderDA.List().FirstOrDefault(i => i.Id == id);

            List<ProductDTO> products = ProductDA.List();

            //List<ProductModel> productModel = ProductModel.BuildModel();

            //order.Cart = products;

            return order;
        }


    }
}
