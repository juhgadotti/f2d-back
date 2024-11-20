using Microsoft.AspNetCore.Mvc;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Principal : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("gets")]
        public JsonResult Gets()
        {
            return new JsonResult(Summaries);
        }
    }
}
