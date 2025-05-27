using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class UserAuthDTO : DTOBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLogged { get; set; }
        public Guid UserId { get; set; }
    }
}
