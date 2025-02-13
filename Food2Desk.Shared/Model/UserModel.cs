using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public List<OfficeModel> Offices {get; set;}
    }
}
