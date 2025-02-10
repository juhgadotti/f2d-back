using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;
using Food2Desk.Shared.Interfaces;


namespace Food2Desk.Core
{

    public class Product : IProductCore 
    {
        private readonly IProductDataAccess ProductDA;

        public Product(IProductDataAccess productDA)
        {
            ProductDA = productDA;
        }

        public List<ProductDTO> List()
        {
            return ProductDA.List();
        }

        public ProductDTO Get(Guid id)
        {
            return ProductDA.Get(id);
        }

        public ProductDTO Insert(ProductDTO dto)
        {            
            return ProductDA.Insert(dto);
        }

        public ProductDTO Update(ProductDTO dto)
        {
            return ProductDA.Update(dto);
        }

        public void Delete(ProductModel model)
        {
            // :)
        }

    }
}
