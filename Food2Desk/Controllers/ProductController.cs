﻿using Food2Desk.Shared.Model;
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

            return new JsonResult(listDTO.Select(ProductModel.BuildModel));
        }

        [HttpGet("{id:Guid}")]
        public JsonResult Get(Guid id) {
            ProductDTO dto = ProductCore.Get(id);
            return new JsonResult(ProductModel.BuildModel(dto));
        }

        [HttpPost("")]
        public JsonResult Insert(ProductModel model) {
            ProductDTO dto = ProductModel.BuildDTO(model);
            var newDTO = ProductCore.Insert(dto);
            return new JsonResult(ProductModel.BuildModel(newDTO));
        }

        [HttpPut("{id:Guid}")]
        public JsonResult Update(ProductModel model)
        {
            ProductDTO dto = ProductModel.BuildDTO(model);
            return new JsonResult(model);
        }

        [HttpDelete("")]
        public JsonResult Delete(ProductModel model) //TODO
        {
            return new JsonResult(model);
        }

        [HttpPut("")] //test from front
        public JsonResult UpdateThenList(ProductModel model)
        {
            ProductDTO dto = ProductModel.BuildDTO(model);
            List<ProductDTO> newListDTO = ProductCore.UpdateThenList(dto);            
            return new JsonResult(model);
        }

    }
}
