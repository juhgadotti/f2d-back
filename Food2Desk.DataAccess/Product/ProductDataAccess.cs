using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;
using System.Collections.Generic;
using System.Linq;

namespace Food2Desk.DataAccess.Product
{
    public class ProductDataAccess : IProductDataAccess
    {
        public List<ProductDTO> List()
        {
            List<ProductDTO> list = new List<ProductDTO>()
            {
                new ProductDTO {Id = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Name = "Coxinha", Description = "Coxinha de frango com ou sem catupiry", Category = 2, Price = 7.99, ImageUrl = "images/coxinha.jpg"},
                new ProductDTO {Id = Guid.Parse("e18cf5d3-d73b-4543-94de-74a642d7b355"), Name = "Pastel", Description = "Queijo, carne, pizza", Category = 2, Price = 10.00, ImageUrl = "images/pastel.jpg"},
                new ProductDTO {Id = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Name = "Coca cola", Description = "350ml", Category = 1, Price = 5.99, ImageUrl = "images/coca.png"},
                new ProductDTO {Id = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Name = "Agua", Description = "Com/Sem gas - 500ml", Category = 1, Price = 2.99, ImageUrl = "images/agua.jp"}
            };

            return list;
        }

        public ProductDTO Get(Guid id)
        {
            List<ProductDTO> list = List();
     
            return list.FirstOrDefault(i => i?.Id == id);
        }

        public ProductDTO Get(string id)
        {
            List<ProductDTO> list = List();
            return list[0];
            //return list.FirstOrDefault(i => i?.Id == id);
        }

        public ProductDTO Insert(ProductDTO dto)
        {
            return dto;
        }

        public ProductDTO Update(ProductDTO dto)
        {
            return dto;
        }

        public List<ProductDTO> UpdateThenList(ProductDTO dto)
        {
            List<ProductDTO> list = List();
            var toUpdate = list.FirstOrDefault(a => a.Id == dto.Id);
            return list;
        }
    }
}
