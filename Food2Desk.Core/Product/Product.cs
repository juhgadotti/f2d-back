using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces.Product;
using Food2Desk.Shared.Interfaces;
using System.Collections.Generic;


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
            var alreadyExist = ProductDA.List().Any(x => x.Name == dto.Name);

            if (alreadyExist) throw new Exception("Já existe um produto cadastrado com esse nome!");
            
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

        public List<ProductDTO> UpdateThenList(ProductDTO dto)
        {
            return ProductDA.UpdateThenList(dto);
        }

        public List<String> ListCategories()
        {
            var productList = List();
            return productList.DistinctBy(pr => pr.Category).Select(ct => ct.Category).ToList();
        }
    }
}
