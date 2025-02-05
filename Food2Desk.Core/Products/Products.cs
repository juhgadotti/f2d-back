using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Products;


namespace Food2Desk.Core.Core
{

    public class Products
    {
        private readonly IProductsDataAccess ProductsDA;

        public Products(IProductsDataAccess productsDA)
        {
            ProductsDA = productsDA;
        }

        public List<ProductsModel> List()
        {
            List<ProductsDTO> dtoList = ProductsDA.List();
            return 
        }

    }
}
