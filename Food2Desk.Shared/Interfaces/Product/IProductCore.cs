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
        public List<ProductDTO> List();
        public ProductDTO Get(Guid id);
    }
}
