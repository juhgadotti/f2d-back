using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.DataAccess
{
    public class OfficeDataAccess(Food2deskContext context) : BaseRepository<OfficeDTO>(context), IOfficeDataAccess
    {
        private readonly Food2deskContext DBContext = context;        
    }
}
