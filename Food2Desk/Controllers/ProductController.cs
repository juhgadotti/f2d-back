using Food2Desk.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Food2Desk.Shared.Interfaces;
using Food2Desk.Shared.DTOs;
using Food2Desk.Core;
using static System.Net.Mime.MediaTypeNames;
using Food2Desk.Shared;

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
            List<ProductDTO> listDTO = ProductCore.ListWithoutLunch();

            return new JsonResult(listDTO.Select(ProductModel.BuildModel));
        }

        [HttpGet("{id:Guid}")]
        public JsonResult Get(Guid id)
        {
            ProductDTO dto = ProductCore.Get(id);
            return new JsonResult(ProductModel.BuildModel(dto));
        }

        [HttpPost("lunch")]
        public JsonResult InsertLunch([FromBody] ProductModel model)
        {
            var newLunch = ProductModel.BuildDTO(model);
            var lunch = ProductCore.Insert(newLunch);
            return new JsonResult(lunch);
        }

        [HttpGet("lunch")]
        public JsonResult LunchList()
        {
            var list = ProductCore.LunchList();
            return new JsonResult(list);
        }

        [HttpGet("lunch/{weekDay}")]
        public JsonResult LunchDayList(int weekDay)
        {
            var list = ProductCore.LunchList().Where(l => l.WeekDay == weekDay);
            return new JsonResult(list);
        }

        [HttpDelete("lunch/{id}")]
        public IActionResult DeleteLunch(Guid id)
        {
            ProductCore.Delete(id);
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Insert([FromBody] ProductModel model)
        {
            var alreadyExist = ProductCore.ListWithoutLunch().Find(prod => prod.Name == model.Name);
            if (alreadyExist != null)
            {
                return new JsonResult(alreadyExist.Id);
            }

            //if (image != null && image.Length > 0)
            //{                
            //    var imageUrl = await SupabaseService.UploadImage(image);
            //    model.ImageUrl = imageUrl;
            //}

            model.Id = Guid.NewGuid();
            ProductDTO dto = ProductModel.BuildDTO(model);
            var newDTO = ProductCore.Insert(dto);
            return new JsonResult(ProductModel.BuildModel(newDTO));
        }

        [HttpPut("")]
        public JsonResult Update(ProductModel model)
        {
            if (model.Id == Guid.Empty || model.Id == null)
            {
                model.Id = ProductCore.ListWithoutLunch().Find(prod => prod.Name == model.Name).Id;
            }
            ProductDTO dto = ProductModel.BuildDTO(model);            
            ProductCore.Update(dto);
            return new JsonResult(model);
        }

        [HttpDelete("")]
        public JsonResult Delete(ProductModel model) //TODO
        {
            return new JsonResult(model);
        }

        [HttpGet("categories")]
        public JsonResult GetCategories()
        {
            var categoriesList = ProductCore.ListCategories();
            return new JsonResult(categoriesList);
        }

        [HttpPut("aa")] //test from front
        public JsonResult UpdateThenList(ProductModel model)
        {
            ProductDTO dto = ProductModel.BuildDTO(model);
            List<ProductDTO> newListDTO = ProductCore.UpdateThenList(dto);
            return new JsonResult(model);
        }

        [HttpPut("status/{id}")]
        public JsonResult ChangeProductStatus(Guid id)
        {
            ProductCore.ChangeProductStatus(id);
            return new JsonResult(id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            ProductCore.Delete(id);
        }
    }
}
