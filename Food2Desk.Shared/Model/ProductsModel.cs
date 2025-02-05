using Food2Desk.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2Desk.Shared.Model
{
    public class ProductsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        public string? ImageUrl { get; set; }

        public ProductsModel BuildModel(ProductsDTO dto)
        {
            return new ProductsModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                ImageUrl = dto.ImageUrl
            };
        }

        public List<ProductsModel> BuildModelList(List<ProductsDTO> dto)
        {
            for (int i = 0; i <= dto.Count(); i++)
            {
                new ProductsModel()
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

        public ProductsDTO BuildDTO(ProductsModel model)
        {
            return new ProductsDTO()
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


