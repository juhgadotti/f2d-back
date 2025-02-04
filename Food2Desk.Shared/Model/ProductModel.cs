using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        public string? ImageUrl { get; set; }

        public ProductModel BuildModel(ProductDTO dto)
        {
            return new ProductModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                ImageUrl = dto.ImageUrl
            };
        }

        public List<ProductModel> BuildModelList(List<ProductDTO> dto)
        {
            for (int i = 0; i <= dto.Count(); i++)
            {
                new ProductModel()
                {
                    Id = dto[i].Id,
                    Name = dto[i].Name,
                    Description = dto[i].Description,
                    Price = dto[i].Price,
                    Category = dto[i].Category,
                    ImageUrl = dto[i].ImageUrl
                };
            }
        }

        public ProductDTO BuildDTO(ProductModel model)
        {
            return new ProductDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                ImageUrl = model.ImageUrl
            };
        }
    }
}


