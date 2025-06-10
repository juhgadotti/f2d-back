using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.Model;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Interfaces   
{
    public interface IProductCore
    {
        public List<ProductDTO> ListWithoutLunch();
        public ProductDTO Get(Guid id);

        public ProductDTO Insert(ProductDTO dto);
        public ProductDTO Update(ProductDTO dto);
        public void Delete(Guid id);
        public List<ProductDTO> UpdateThenList(ProductDTO dto);
        public List<String> ListCategories();
        public List<ProductDTO> LunchList();
        public void ChangeProductStatus(Guid id);
    }
}
