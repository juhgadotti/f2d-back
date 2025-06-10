using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Food2Desk.Core
{
    public class Order(Food2deskContext context, IOrderDataAccess orderDA, IProductDataAccess productDA, IUserDataAccess userDA) : IOrderCore
    {
        private readonly IOrderDataAccess OrderDA = orderDA;
        private readonly IProductDataAccess ProductDA = productDA;
        private readonly IUserDataAccess UserDA = userDA;
        private readonly Food2deskContext _context = context;

        public OrderDTO Get(Guid id)
        {
            return OrderDA.Get(id);
        }

        public List<OrderDTO> ListUserOrder(Guid id)
        {
            var list = OrderDA.List().Where(p => p.UserId == id).ToList();
            

            return list;
        }


        public List<OrderDTO> List()
        {
            var list = OrderDA.List();
            list.ForEach(p => Math.Round(p.TotalCharge = p.Cart.Sum(u => u.Quantity * (decimal)u.Price), 2));

            return list;
        }

        public OrderDTO Update(OrderDTO dto)
        {
            var newDto = OrderDA.Update(dto);
            _context.SaveChanges();
            return newDto;
        }

        public OrderDTO Insert(OrderDTO dto)
        {
            var name = UserDA.GetById(dto.UserId).Name;
            dto.UserName = name;

            dto.Cart.ForEach(c => c.OrderId = dto.Id);

            dto.Code = OrderDA.List().Max(o => o.Code) + 1;

            var model = OrderDA.Insert(dto);
            _context.SaveChanges();
            return model;
        }

        public void UpdateStatus(OrderDTO dto)
        {
            var model = OrderDA.Update(dto);
            _context.SaveChanges();
        }

        //public OrderDTO BuildOrder(Guid id) //test
        //{
        //    var order = OrderDA.ListMocked().FirstOrDefault(i => i.Id == id);

        //    List<ProductDTO> products = ProductDA.List();

        //    //List<ProductModel> productModel = ProductModel.BuildModel();

        //    //order.Cart = products;

        //    return order;
        //}


    }
}
