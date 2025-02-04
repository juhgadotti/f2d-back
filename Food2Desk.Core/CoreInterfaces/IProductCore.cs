using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.Model;

namespace Food2Desk.Core.CoreInterfaces
{
    public interface IProductCore
    {
        public List<ProductModel> List();
    }
}
