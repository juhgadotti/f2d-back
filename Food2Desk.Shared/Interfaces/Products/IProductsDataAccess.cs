using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Interfaces.Products
{
    public interface IProductsDataAccess
    {
        public List<ProductsDTO> List();
    }
}