using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using System.Collections.Generic;
using Food2Desk.Shared.Enum;
using Food2Desk.DataAccess.Context;


namespace Food2Desk.Core
{

    public class Product(Food2deskContext context, IProductDataAccess product) : IProductCore
    {
        private readonly IProductDataAccess _productDA = product;
        private readonly Food2deskContext _context = context;

        public List<ProductDTO> ListWithoutLunch()
        {
            return _productDA.List().Where(x => x.Category != "Almoço").ToList();
        }

        public ProductDTO Get(Guid id)
        {
            return _productDA.GetById(id);
        }

        public ProductDTO Insert(ProductDTO dto)
        {
            var alreadyExist = _productDA.List().Any(x => x.Name == dto.Name);

            if (alreadyExist && dto.Category != "Almoço") throw new Exception("Já existe um produto cadastrado com esse nome!");

            var newDTO = _productDA.Insert(dto);
            _context.SaveChanges();

            return newDTO;
        }

        public ProductDTO Update(ProductDTO dto)
        {            
            var newDto = _productDA.Update(dto);
            _context.SaveChanges();
            return newDto;
        }

        public void Delete(Guid id)
        {

            _productDA.Delete(id);
            _context.SaveChanges();
        }

        public List<ProductDTO> UpdateThenList(ProductDTO dto)
        {
            return _productDA.UpdateThenList(dto);
        }

        public List<String> ListCategories()
        {
            var productList = ListWithoutLunch();
            return productList.DistinctBy(pr => pr.Category).Select(ct => ct.Category).ToList();
        }

        public List<ProductDTO> LunchList()
        {
            return _productDA.List().Where(prod => prod.Category == EnumCategory.Almoço).ToList();
        }

        public void ChangeProductStatus(Guid id)
        {           
            var product = _productDA.GetById(id);
            product.Status = product.Status == 1 ? 0 : 1;
            _productDA.Update(product);
            _context.SaveChanges();
        }
    }
}
