using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class OfficeModel
    {
        public String? Block { get; set; }
        public String Floor { get; set; }
        public String Number { get; set; }
        public String Enterprise { get; set; }
        public int EnterpriseId { get; set; }
        public String? Obs { get; set; }
    }
}
