using System;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces;
using Food2Desk.DataAccess.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Food2Desk.DataAccess
{
    public class OrderDataAccess(Food2deskContext context) : BaseRepository<OrderDTO>(context), IOrderDataAccess
    {
        private readonly Food2deskContext DBContext = context;
        private readonly IProductDataAccess ProductDA;


        public OrderDTO Get(Guid id)
        {
            var list = Query().ToList();
            return list.FirstOrDefault(x => x.Id == id);
        }

        public List<OrderDTO> List()
        {
            //var path = new Path<OrderDTO>(o => o.Office); // isso vai funcionar se Path<T> está implementado corretamente

            //return Query(path).Where(o => o.UserId == id).ToList();

            return DBContext.Set<OrderDTO>()
               .Include(o => o.Office)
               .Include(o => o.Cart)               
               .ToList();
        }

        //public List<OrderDTO> ListMocked()
        //{

        //    var orders = new List<OrderDTO>
        //    {
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0301,
        //            UserId = Guid.NewGuid(),
        //            UserName = "Igor Capelazo",
        //            Status = 1,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "12", Number = "331" },
        //            Cart = ListCart(1),
        //            TotalCharge = 0
        //        },
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0302,
        //            UserId = Guid.NewGuid(),
        //            UserName = "Juliana Ribeiro",
        //            Status = 1,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "12", Number = "321" },
        //            Cart = ListCart(2),
        //            TotalCharge = 0
        //        },
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0303,
        //            UserId = Guid.NewGuid(),
        //            UserName = "João Pereira",
        //            Status = 2,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "1", Number = "31" },
        //            Cart = ListCart(3),
        //            TotalCharge = 0
        //        },
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0304,
        //            UserId = Guid.NewGuid(),
        //            UserName = "Rafael Matos",
        //            Status = 2,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "12", Number = "331" },
        //            Cart = ListCart(4),
        //            TotalCharge = 0
        //        },
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0304,
        //            UserId = Guid.NewGuid(),
        //            UserName = "Juliana Gadotti",
        //            Status = 3,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "12", Number = "331" },
        //            Cart = ListCart(5),
        //            TotalCharge = 0
        //        },
        //        new OrderDTO
        //        {
        //            Id = Guid.NewGuid(),
        //            Code = 0304,
        //            UserId = Guid.NewGuid(),
        //            UserName = "Gabriel Carneiro",
        //            Status = 3,
        //            Office = new OfficeDTO { Id = Guid.NewGuid(), Floor = "12", Number = "331" },
        //            Cart = ListCart(6),
        //            TotalCharge = 0
        //        }
        //    };

        //    return orders;
        //}

        //public OrderDTO BuildOrder(Guid id)
        //{
        //    return ListMocked().FirstOrDefault(p => p.Id == id);
        //}

        //public List<ProductCartDTO> ListCart(int option)
        //{
        //    List<ProductDTO> productList = ProductDA.mockedList();

        //    var cartProducts = productList.Take(3).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 1
        //    }).ToList();

        //    var cartProducts2 = productList.Skip(3).Take(2).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 2
        //    }).ToList();

        //    var cartProducts3 = productList.Skip(5).Take(3).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 2
        //    }).ToList();

        //    var cartProducts4 = productList.Skip(8).Take(2).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 1
        //    }).ToList();

        //    var cartProducts5 = productList.Skip(10).Take(2).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 3
        //    }).ToList();

        //    var cartProducts6 = productList.Skip(7).Take(4).Select(product => new ProductCartDTO
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Quantity = 1
        //    }).ToList();

        //    var list = new List<ProductCartDTO>();

        //    switch (option)
        //    {
        //        case 1:
        //            list = cartProducts;
        //            break;
        //        case 2:
        //            list = cartProducts2;
        //            break;
        //        case 3:
        //            list = cartProducts3;
        //            break;
        //        case 4:
        //            list = cartProducts4;
        //            break;
        //        case 5:
        //            list = cartProducts5;
        //            break;
        //        case 6:
        //            list = cartProducts6;
        //            break;
        //    }

        //    return list;
        //}
    }
}
