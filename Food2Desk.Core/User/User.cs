using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Core
{
    public class User(Food2deskContext context, IUserDataAccess userDA, IUserAuthDataAccess userAuthDA, IOfficeDataAccess officeDA) : IUserCore
    {

        private readonly IUserDataAccess UserDA = userDA;
        private readonly IUserAuthDataAccess _userAuthDA = userAuthDA;
        private readonly IOfficeDataAccess _officeDA = officeDA;
        private readonly Food2deskContext _context = context;


        public UserModel Get(Guid id)
        {
            var path = new Path<OfficeDTO>();
            var user = UserDA.GetPath(id, u => u.Offices);
            return UserModel.BuildModel(user);

        }

        public UserModel Insert(UserRegisterModel user)
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

            _context.SaveChanges();

            var userAuth = new UserAuthDTO()
            {
                UserId = newUser.Id,
                Email = user.Email,
                Password = user.Password,
                IsLogged = true
            };

            _userAuthDA.Insert(userAuth);

            _context.SaveChanges();

            return UserModel.BuildModel(newUser);
        }

        public List<UserDTO> ListBanco()
        {
            return UserDA.ListBanco();
        }

        public UserAuthDTO Authentication(UserAuthModel user)
        {
            var userRegistered = _userAuthDA.GetUserByEmail(user.Email);

            if (userRegistered.Password != user.Password)
            {
                throw new Exception("Senha errada >:(");

            }
            return userRegistered;
        }

        public OfficeDTO InsertOffice(OfficeModel office)
        {
            office.UserId = office.Id;
            office.Id = Guid.NewGuid();

            var newOffice = OfficeModel.BuildDTO(office);
            newOffice.UserId = (Guid)office.UserId;
            _officeDA.Insert(newOffice);

            _context.SaveChanges();

            return newOffice;
        }

        public OfficeModel InsertNewOffice(OfficeModel office)
        {
            var officeDTO = OfficeModel.BuildDTO(office);
            var newOffice = _officeDA.Insert(officeDTO);
            _context.SaveChanges();
            return OfficeModel.BuildModel(newOffice);
        }

    }
}
