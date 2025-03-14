using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Interfaces.Product
{
    public interface IProductDataAccess
    {
        public List<ProductDTO> List();
        public ProductDTO Get(Guid id);
        public ProductDTO Get(string id);
        public ProductDTO Insert(ProductDTO dto);
        public ProductDTO Update(ProductDTO dto);
        public List<ProductDTO> UpdateThenList(ProductDTO dto);
    }
}