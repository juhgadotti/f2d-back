using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class UserAuthModel
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLogged { get; set; }
        public static UserAuthModel BuildModel(UserAuthDTO dto)
        {
            return new UserAuthModel
            {
                UserId = dto.UserId,
                Email = dto.Email,
                Password = dto.Password,
                IsLogged = dto.IsLogged
            };
        }
    }
}
