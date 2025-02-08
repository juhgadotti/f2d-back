using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;

namespace Food2Desk.DataAccess.DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        public List<ProductDTO> List()
        {
            List<ProductDTO> list = new List<ProductDTO>()
            {
                new ProductDTO {Id = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Name = "Coca", Description = "350ml", Category = 1, Price = 5.99, ImageUrl = "cu"},
                new ProductDTO {Id = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Name = "Coxinha", Description = "Frango e catupiry", Category = 2, Price = 7.99, ImageUrl = "cuxinha"},
                new ProductDTO {Id = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Name = "Agua", Description = "Com/Sem gas", Category = 1, Price = 2.99, ImageUrl = "h2o"}
            };

            return list;
        }

        public ProductDTO Get(Guid id)
        {
            return new ProductDTO { Id = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Name = "Agua", Description = "Com/Sem gas", Category = 1, Price = 2.99, ImageUrl = "h2o" };
        }
    }
}
