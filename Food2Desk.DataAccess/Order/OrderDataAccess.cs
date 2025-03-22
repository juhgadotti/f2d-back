using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Order;
using Food2Desk.Shared.Interfaces.Product;
using Food2Desk.Shared.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food2Desk.DataAccess.Order
{   
    public class OrderDataAccess : IOrderDataAccess
    {
        private readonly IProductDataAccess ProductDA;
        public OrderDataAccess(IProductDataAccess productDA)
        {
            ProductDA = productDA;
        }

        public OrderModel Insert(OrderModel model)
        {
            model.UserName = "deu certinho";

            return model;
        }


        public OrderModel Get() {
            return new OrderModel() {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserName = "Carlos Silva",
                DeliveryNow = true,
                DeliveryTime = null,
                Office = new OfficeModel { OfficeId = Guid.NewGuid(), Floor = "12", Number = "331" },
                Cart = new List<ProductCart>
                    {
                        new ProductCart { ProductId = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Quantity = 2 },
                        new ProductCart { ProductId = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Quantity = 1 }
                    },
                TotalCharge = (2 * 7.99M) + (1 * 5.99M)
            };
        }

        public OrderModel Update(OrderModel model)
        {
            return model;
        }

        public List<OrderModel> List()
        {
            List<ProductDTO> productList = ProductDA.List();

            var orders = new List<OrderModel>
            {
                new OrderModel
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "Carlos Silva",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Office = new OfficeModel { OfficeId = Guid.NewGuid(), Floor = "12", Number = "331" },
                    Cart = new List<ProductCart>
                    {
                        new ProductCart { Id = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Quantity = 2 },
                        new ProductCart { Id = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"),  Quantity = 1 }
                    },
                    TotalCharge = (2 * 7.99M) + (1 * 5.99M)
                },
                new OrderModel
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "Ana Souza",
                    DeliveryNow = false,
                    DeliveryTime = "14:30",
                    Office = new OfficeModel { OfficeId = Guid.NewGuid(), Floor = "12", Number = "321" },
                    Cart = new List<ProductCart>
                    {
                        new ProductCart { ProductId = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-93G1E2E79A6E"), Quantity = 1 },
                        new ProductCart { ProductId = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Quantity = 2 }
                    },
                    TotalCharge = (1 * 10.00M) + (2 * 2.99M)
                },
                new OrderModel
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    UserName = "João Pereira",
                    DeliveryNow = true,
                    DeliveryTime = null,
                    Office = new OfficeModel { OfficeId = Guid.NewGuid(), Floor = "1", Number = "31" },
                    Cart = new List<ProductCart>
                    {
                        new ProductCart { ProductId = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Quantity = 3 },
                        new ProductCart { ProductId = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-93G1E2E79A6E"), Quantity = 2 },
                        new ProductCart { ProductId = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Quantity = 1 }
                    },
                    TotalCharge = (3 * 7.99M) + (2 * 10.00M) + (1 * 5.99M)
                }
            };

            return orders;
        }
    }
}
