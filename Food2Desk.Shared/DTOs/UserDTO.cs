using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class UserDTO : DTOBase
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String? Phone { get; set; }
        public String Doc {  get; set; }
        public List<OfficeDTO> Offices {  get; set; }      

    }
}
