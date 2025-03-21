using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces.Product;
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

        public OrderModel Get()
        {
            return OrderDA.Get();
        }

        public OrderModel Insert(OrderModel model)
        {
            return OrderDA.Insert(model);
        }

        public OrderModel BuildOrder(Guid id)
        {
            var order = OrderDA.List().FirstOrDefault(i => i.Id == id);

            List<ProductDTO> products = ProductDA.List();

            //List<ProductModel> productModel = ProductModel.BuildModel();

            //order.Cart = products;

            return order;
        }
    }
}
