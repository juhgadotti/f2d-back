using Food2Desk.Shared.Interfaces.User;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Core
{
    public class User : IUserCore
    {
        private readonly IUserDataAccess UserDA;

        public User(IUserDataAccess userDA)
        {
            UserDA = userDA;
        }
        public UserModel Get()
        {
            UserModel user = UserDA.Get();

            return user;
        }
    }
}
