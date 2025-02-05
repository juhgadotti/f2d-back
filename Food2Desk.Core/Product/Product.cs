using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;


namespace Food2Desk.Core.Core
{

    public class Product
    {
        private readonly IProductDataAccess ProductDA;

        public Product(IProductDataAccess productDA)
        {
            ProductDA = productDA;
        }

        public List<ProductModel> List()
        {
            List<ProductDTO> dtoList = ProductDA.List();
            return 
        }

    }
}
