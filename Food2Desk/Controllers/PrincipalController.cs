using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrincipalController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public PrincipalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
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
