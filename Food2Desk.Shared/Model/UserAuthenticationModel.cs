using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class UserAuthenticationModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
