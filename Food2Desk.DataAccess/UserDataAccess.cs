using Food2Desk.Shared.Interfaces.User;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.DataAccess
{
    class UserDataAccess : IUserDataAccess
    {
        public UserModel Get()
        {
            OfficeModel office = new OfficeModel()
            {
                Floor = "11",
                Number = "102",
                Enterprise = "Numax",
                EnterpriseId = Guid.NewGuid() //"A24C13F0-E264-4396-BCEF-69AA8BD76465"
            };
            UserModel user = new UserModel()
            {
                Name = "Joao",
                Id = Guid.NewGuid(),
                Offices = new List<OfficeModel>() { office }
            };

            return user;
        }
    }
}
