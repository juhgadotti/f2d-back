using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class OfficeDTO
    {
        public Guid OfficeId { get; set; }
        public String Floor { get; set; }
        public String Number { get; set; }
        public String? Block { get; set; }
        public String? Enterprise { get; set; }
        public Guid EnterpriseId { get; set; }
        public String? Obs { get; set; }
    }
}
