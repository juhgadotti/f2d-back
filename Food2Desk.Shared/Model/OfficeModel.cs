using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class OfficeModel
    {
        public Guid Id { get; set; }
        public String Floor { get; set; }
        public String Number { get; set; }
        public String? Block { get; set; }

        public static OfficeModel BuildModel(OfficeDTO dto)
        {
            return new OfficeModel
            {
                Id = dto.Id,
                Floor = dto.Floor,
                Number = dto.Number,
                Block = dto.Block
            };
        }

        public static OfficeDTO BuildDTO(OfficeModel model)
        {
            return new OfficeDTO
            {
                Id = model.Id,
                Floor = model.Floor,
                Number = model.Number,
                Block = model.Block
            };
        }
    }
}
