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

        public List<ProductDTO> List()
        {
            return _productDA.List();
        }

        public ProductDTO Get(Guid id)
        {
            return _productDA.GetById(id);
        }

        public ProductDTO Insert(ProductDTO dto)
        {
            var alreadyExist = _productDA.List().Any(x => x.Name == dto.Name);

            if (alreadyExist) throw new Exception("Já existe um produto cadastrado com esse nome!");

            var newDTO = _productDA.Insert(dto);
            _context.SaveChanges();

            return newDTO;
        }

        public ProductDTO Update(ProductDTO dto)
        {
            if (dto.Id == Guid.Empty)
            {
                dto.Id = List().Find(prod => prod.Name == dto.Name).Id;
            }
            return _productDA.Update(dto);
        }

        public void Delete(ProductModel model)
        {
            // :)
        }

        public List<ProductDTO> UpdateThenList(ProductDTO dto)
        {
            return _productDA.UpdateThenList(dto);
        }

        public List<String> ListCategories()
        {
            var productList = List();
            return productList.DistinctBy(pr => pr.Category).Select(ct => ct.Category).ToList();
        }

        public List<ProductDTO> LunchList()
        {
            return List().Where(prod => prod.Category == EnumCategory.Almoço).ToList();
        }
    }
}
