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
            List<ProductDTO> productList = ProductDA.List();

            var orders = new List<OrderDTO>
            {
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "Wanessa Ventura <3",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "12", Number = "331" },
                    Cart = new List<ProductCartDTO>
                    {
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 2 },
                        new ProductCartDTO { ProductId = Guid.NewGuid(),  Quantity = 1 }
                    },
                    TotalCharge = (2 * 7.99M) + (1 * 5.99M)
                },
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "Ana Souza",
                    DeliveryNow = false,
                    DeliveryTime = "14:30",
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "12", Number = "321" },
                    Cart = new List<ProductCartDTO>
                    {
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 1 },
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 2 }
                    },
                    TotalCharge = (1 * 10.00M) + (2 * 2.99M)
                },
                new OrderDTO
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "João Pereira",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Office = new OfficeDTO { OfficeId = Guid.NewGuid(), Floor = "1", Number = "31" },
                    Cart = new List<ProductCartDTO>
                    {
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 3 },
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 2 },
                        new ProductCartDTO { ProductId = Guid.NewGuid(), Quantity = 1 }
                    },
                    TotalCharge = (3 * 7.99M) + (2 * 10.00M) + (1 * 5.99M)
                }
            };

            return orders;
        }

        public OrderDTO BuildOrder(Guid id)
        {
            return List().FirstOrDefault(p => p.Id == id);
        }
    }
}
