using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class OfficeDTO : DTOBase
    {
        public String Floor { get; set; }
        public String Number { get; set; }
        public String? Block { get; set; }

        public Guid UserId { get; set; }
        public UserDTO User { get; set; } = null!;
    }
}
