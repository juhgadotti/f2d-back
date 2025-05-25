using Food2Desk.DataAccess.Context;
﻿using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
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
            return UserDA.Get();
            
        }

        public List<UserDTO> ListBanco()
        {
            return UserDA.ListBanco();
        }

        public UserAuthenticationModel GetUserInfo(string email)
        {
            return UserDA.GetUserInfo(email);
        }

    }
}
