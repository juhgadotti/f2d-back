using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
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
    public class User(Food2deskContext context, IUserDataAccess userDA, IUserAuthDataAccess userAuthDA) : IUserCore
    {        

        private readonly IUserDataAccess UserDA = userDA;
        private readonly IUserAuthDataAccess _userAuthDA = userAuthDA;
        private readonly Food2deskContext _context = context;


        public UserModel Get()
        {
            return UserDA.Get();
            
        }

        public void Insert(UserRegisterModel user)
        {
            var newUser = new UserDTO()
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Doc = user.Doc,
                Email = user.Email,
                Phone = user.Phone
            };

            UserDA.Insert(newUser);

            var userAuth = new UserAuthDTO()
            {
                UserId = newUser.Id,
                Email = user.Email,
                Password = user.Password,
                IsLogged = true
            };

            _userAuthDA.Insert(userAuth);

            _context.SaveChanges();
        }

        public List<UserDTO> ListBanco()
        {
            return UserDA.ListBanco();
        }

        public UserAuthDTO Authentication(UserAuthModel user)
        {
            var userRegistered = _userAuthDA.GetUserByEmail(user.Email);

            if(userRegistered.Password != user.Password)
            {
                throw new Exception("Senha errada >:(");

            }
            return userRegistered;
        }

    }
}
