using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.DataAccess
{
    public class UserAuthDataAccess(Food2deskContext context) : BaseRepository<UserAuthDTO>(context), IUserAuthDataAccess
    {
        private readonly Food2deskContext DBContext = context;

        public UserAuthDTO GetUserByEmail(string email)
        {
            return Query().FirstOrDefault(e => e.Email == email);
        }
    }
}
