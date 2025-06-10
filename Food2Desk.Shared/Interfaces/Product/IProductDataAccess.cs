using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Interfaces
{
    public interface IProductDataAccess : IBaseRepository<ProductDTO>
    {
        public List<ProductDTO> List();
        //public List<ProductDTO> mockedList();

        public List<ProductDTO> UpdateThenList(ProductDTO dto);
    }
}