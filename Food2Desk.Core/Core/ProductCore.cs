using Food2Desk.Shared.Model;
using Food2Desk.DataAccess.DAInterfaces;
using Food2Desk.DataAccess.DataAccess;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Core.Core
{

    public class ProductCore
    {
        private readonly IProductDA ProductDA;

        public ProductCore(IProductDA productDA)
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
