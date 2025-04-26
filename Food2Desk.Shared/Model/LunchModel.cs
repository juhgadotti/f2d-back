using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class LunchModel
    {
        public Guid Id { get; set; }
        public string WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public List<ProductModel> Lunchs { get; set; }///aaaaabbbbbbb

    }
}
