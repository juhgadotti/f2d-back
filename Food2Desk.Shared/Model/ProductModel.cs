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
        public Guid? Id { get; set; } 
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
        public int? Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public int Status { get; set; }

        public int? WeekDay { get; set; }

        public static ProductModel BuildModel(ProductDTO dto)
        {
            return new ProductModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                WeekDay = dto.WeekDay,
                Category = dto.Category,
                Quantity = dto.Quantity,
                ImageUrl = dto.ImageUrl,
                Status = dto.Status
            };
        }

        public static ProductDTO BuildDTO(ProductModel model)
        {
            return new ProductDTO()
            {
                Id = model.Id ?? Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                WeekDay = model.WeekDay,
                Category = model.Category,
                Quantity = model.Quantity,
                ImageUrl = model.ImageUrl,
                Status = model.Status
            };
        }
    }
}


