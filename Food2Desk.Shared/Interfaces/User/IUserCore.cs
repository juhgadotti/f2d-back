using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces
{
    public interface IUserCore
    {
        public UserModel Get(Guid id);
        public UserModel Insert(UserRegisterModel user);
        public List<UserDTO> ListBanco();

        public UserAuthDTO Authentication(UserAuthModel user);
        public OfficeDTO InsertOffice(OfficeModel office);
        public OfficeModel InsertNewOffice(OfficeModel office);

    }
}
