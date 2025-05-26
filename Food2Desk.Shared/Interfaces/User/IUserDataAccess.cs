using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Interfaces
{
    public interface IUserDataAccess : IBaseRepository<UserDTO>
    {
        // public UserModel Get();
        public UserModel Get();
        public List<UserDTO> ListBanco();
        //public UserAuthModel GetUserInfo(string email);
        public List<UserAuthModel> List();
    }
}
