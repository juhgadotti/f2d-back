using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces
{
    public interface IUserAuthDataAccess : IBaseRepository<UserAuthDTO>
    {
        public UserAuthDTO GetUserByEmail(string email);
    }
}
