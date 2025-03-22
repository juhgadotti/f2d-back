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
        public Guid OfficeId { get; set; }
        public String Floor { get; set; }
        public String Number { get; set; }
        public String? Block { get; set; }
        public String? Enterprise { get; set; }
        public Guid EnterpriseId { get; set; }
        public String? Obs { get; set; }

        public static OfficeModel BuildModel(OfficeDTO dto)
        {
            return new OfficeModel
            {
                OfficeId = dto.OfficeId,
                Floor = dto.Floor,
                Number = dto.Number,
                Block = dto.Block,
                Enterprise = dto.Enterprise,
                EnterpriseId = dto.EnterpriseId,
                Obs = dto.Obs
            };
        }

        public static OfficeDTO BuildDTO(OfficeModel model)
        {
            return new OfficeDTO
            {
                OfficeId = model.OfficeId,
                Floor = model.Floor,
                Number = model.Number,
                Block = model.Block,
                Enterprise = model.Enterprise,
                EnterpriseId = model.EnterpriseId,
                Obs = model.Obs
            };
        }
    }
}
