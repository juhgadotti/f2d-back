using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.Interfaces.Lunch;
using Microsoft.AspNetCore.Mvc;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LunchController : ControllerBase
    {
        public readonly ILunchCore LunchCore; //aq vai ser lunch

        public LunchController(ILunchCore lunchCore) //aq vai ser lunch
        {
            LunchCore = lunchCore; //aq vai ser lunch
        }

        [HttpGet]
        public JsonResult LunchList()
        {
            var lunchList = LunchCore.List(); 
            return new JsonResult(lunchList);
        }
    }
}
