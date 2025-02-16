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
        public String? Phone { get; set; }
        public List<OfficeModel> Offices {get; set;}

        public static UserModel BuildModel(UserDTO dto)
        {
            return new UserModel
            {
                //Id = dto.Id,
                //Name = dto.Name,
                //Offices = dto.Offices?.Select(x => x.OfficeModel.BuildModel()).ToList()
            };
        }
        public static UserDTO BuildDTO(UserModel model)
        {
            return new UserDTO
            {
                //Id = model.Id,
                //Name = model.Name,
                //Phone = model.Phone,
                //Offices = model.Offices.ForEach(o =>  OfficeModel.BuildModel(o))

            };
        }
    }
}
