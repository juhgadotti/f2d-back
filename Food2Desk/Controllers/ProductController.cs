using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.DTOs;

namespace Food2Desk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductCore ProductCore;

        public ProductController(IProductCore productCore)
        {
            ProductCore = productCore;
        }

        [HttpGet("")]
        public JsonResult List()
        {
            List<ProductDTO> listDTO = ProductCore.List();

            return new JsonResult(listDTO.Select(ProductBuilds.BuildModel));
        }
    }
}
