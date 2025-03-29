using System;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces.Product;

namespace Food2Desk.DataAccess.Order
{   
    public class OrderDataAccess : IOrderDataAccess
    {
        private readonly IProductDataAccess ProductDA;
        public OrderDataAccess(IProductDataAccess productDA)
        {
            ProductDA = productDA;
        }

        public OrderDTO Insert(OrderDTO dto)
        {
            dto.UserName = "deu certinho";

            return dto;
        }


        public OrderDTO Get(Guid id) {
            var list = List();
            return list.FirstOrDefault(x => x.Id == id);
        }

        public OrderDTO Update(OrderDTO dto)
        {
            return dto;
        }

        public List<OrderDTO> List()
        {
            List<ProductCartDTO> productCartList = ListCart();
            
            var orders = new List<OrderDTO>
            {
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    Code = 0301,
                    UserId = Guid.NewGuid(),
                    UserName = "Wanessa Ventura <3",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Status = 1,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "12", Number = "331" },
                    Cart = productCartList,
                    TotalCharge = 0 
                },
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    Code = 0302,
                    UserId = Guid.NewGuid(),
                    UserName = "Ana Souza",
                    DeliveryNow = false,
                    DeliveryTime = "14:30",
                    Status = 1,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "12", Number = "321" },
                    Cart = productCartList,
                    TotalCharge = 0
                },
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    Code = 0303,
                    UserId = Guid.NewGuid(),
                    UserName = "João Pereira",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Status = 2,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "1", Number = "31" },
                    Cart = productCartList,
                    TotalCharge = 0
                },
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    Code = 0304,
                    UserId = Guid.NewGuid(),
                    UserName = "Rafael Lendario",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Status = 3,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "12", Number = "331" },
                    Cart = productCartList,
                    TotalCharge = 0
                }
            };

            return orders;
        }

        public OrderDTO BuildOrder(Guid id)
        {
            return List().FirstOrDefault(p => p.Id == id);
        }

        public List<ProductCartDTO> ListCart()
        {
            List<ProductDTO> productList = ProductDA.List();

            var cartProducts = new List<ProductCartDTO>()
            {
                new ProductCartDTO { ProductId = productList[0].Id, Quantity = 1, Price = productList[0].Price, Name = productList[0].Name},
                new ProductCartDTO { ProductId = productList[1].Id, Quantity = 2, Price = productList[1].Price, Name = productList[1].Name},
                new ProductCartDTO { ProductId = productList[2].Id, Quantity = 3, Price = productList[2].Price, Name = productList[2].Name},
                new ProductCartDTO { ProductId = productList[3].Id, Quantity = 2, Price = productList[3].Price, Name = productList[3].Name},
            };

            return cartProducts;
        }
    }
}
