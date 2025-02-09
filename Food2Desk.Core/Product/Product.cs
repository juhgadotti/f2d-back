using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;
using Food2Desk.Shared.Interfaces;


namespace Food2Desk.Core
{

    public class Product : IProductCore //TESTE
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

    }
}
