using Food2Desk.Shared.Interfaces.User;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Core.User
{
    public class User : IUserCore
    {
        public UserModel Get()
        {
            OfficeModel office = new OfficeModel()
            {
                Floor = "11",
                Number = "102",
                Enterprise = "Numax",
                EnterpriseId = 3
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
