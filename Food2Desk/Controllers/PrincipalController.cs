using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Food2Desk.Core.CoreInterfaces;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrincipalController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly IProductCore ProductCore;

        public PrincipalController(IConfiguration configuration, IProductCore Product)
        {
            _configuration = configuration;
            ProductCore = Product;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("")]
        public string[] Gets()
        {
            var a = Summaries;
            return a;
        }

        [HttpGet("/Product-list")]
                
    }
}
