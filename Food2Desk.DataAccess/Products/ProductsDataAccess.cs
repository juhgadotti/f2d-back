using Food2Desk.Shared.DTOs;

namespace Food2Desk.DataAccess.DataAccess
{
    public class ProductsDataAccess
    {
        public List<ProductsDTO> List()
        {
            List<ProductsDTO> list = new List<ProductsDTO>()
            {
                new ProductsDTO {Id = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Name = "Coca", Description = "350ml", Category = 1, Price = 5.99, ImageUrl = "cu"},
                new ProductsDTO {Id = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Name = "Coxinha", Description = "Frango e catupiry", Category = 2, Price = 7.99, ImageUrl = "cuxinha"},
                new ProductsDTO {Id = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Name = "Agua", Description = "Com/Sem gas", Category = 1, Price = 2.99, ImageUrl = "h2o"}
            };

            return list;
        }
    }
}
