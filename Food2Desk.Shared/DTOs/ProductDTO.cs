using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.DTOs
{
    public class ProductDTO : DTOBase
    {
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price {  get; set; }
        public int? WeekDay { get; set; }
        public string? Category { get; set; }
        public int? Quantity { get; set; }
        public int Status { get; set; }
    }
}
