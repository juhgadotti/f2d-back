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
        public JsonResult Post(ProductDTO model) {
            return new JsonResult(model);
        }

        [HttpPut("")]
        public JsonResult Put(ProductDTO model)
        {
            return new JsonResult(model);
        }

        [HttpDelete("")]
        public JsonResult Delete(ProductDTO model)
        {
            return new JsonResult(model);
        }

    }
}
