using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Shared.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String? Phone { get; set; }
        public String Doc { get; set; }
        public List<OfficeModel> Offices {get; set;}

        public static UserModel BuildModel(UserDTO dto)
        {
            return new UserModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Doc = dto.Doc,
                Offices = dto.Offices?.Select(x => OfficeModel.BuildModel(x)).ToList()
            };
        }
        public static UserDTO BuildDTO(UserModel model)
        {
            return new UserDTO
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Doc = model.Doc,
                Offices = model.Offices?.Select(o => OfficeModel.BuildDTO(o)).ToList()

            };
        }
    }
}
