using Food2Desk.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LunchController : ControllerBase
    {
        public readonly IProductCore ProductCore; //aq vai ser lunch

        public LunchController(IProductCore productCore) //aq vai ser lunch
        {
            ProductCore = productCore; //aq vai ser lunch
        }

        [HttpGet]
        public JsonResult LunchList()
        {
            var lunchList = LunchCore.List(); 
            return new JsonResult();
        }
    }
}
