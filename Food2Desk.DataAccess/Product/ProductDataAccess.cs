using Food2Desk.DataAccess.Context;
using Food2Desk.Shared.DTOs;
using Food2Desk.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Food2Desk.DataAccess.Product
{
    public class ProductDataAccess(Food2deskContext context) : BaseRepository<ProductDTO>(context), IProductDataAccess
    {
        private readonly Food2deskContext DBContext = context;

        public List<ProductDTO> List()
        {
            var list = DBContext.Set<ProductDTO>().ToList();

            return list;
        }

        public List<ProductDTO> mockedList()
        {
            List<ProductDTO> list = new List<ProductDTO>()
             {
                new() {Id = Guid.Parse("8CFB6326-8E5E-4BFE-B51E-95F5E2E79A6E"), Name = "Coxinha", Description = "Coxinha de frango com ou sem catupiry", Category = "Salgado", Price = 7.99, ImageUrl = "images/coxinha.jpg", Status = 1},
                new() {Id = Guid.Parse("e18cf5d3-d73b-4543-94de-74a642d7b355"), Name = "Pastel", Description = "Queijo, carne, pizza", Category = "Salgado", Price = 10.00, ImageUrl = "images/pastel.jpg", Status = 1},
                new() {Id = Guid.Parse("76B62969-25CE-4FBC-BE96-19B2447C69E7"), Name = "Coca cola", Description = "350ml", Category = "Bebida", Price = 5.99, ImageUrl = "images/coca.png", Status = 1},
                new() {Id = Guid.Parse("64794FA6-31A2-4E33-8E3C-3D8FE8A57827"), Name = "Agua", Description = "Com/Sem gas - 500ml", Category = "Bebida", Price = 2.99, ImageUrl = "images/agua.jp", Status = 1},
                new() { Id = Guid.Parse("B1A1E1B1-F1E1-4C1B-B1E1-11A1B1C1D1E1"), Name = "Esfirra", Description = "Carne", Category = "Salgado", Price = 6.50, ImageUrl = "images/esfirra.jpg", Status = 1 },
                new() { Id = Guid.Parse("D2B2C2D2-F2D2-4A2C-C2D2-22B2C2D2E2F2"), Name = "Refrigerante Guaraná", Description = "350ml", Category = "Bebida", Price = 5.50, ImageUrl = "images/guarana.png", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Pão de Queijo", Description = "Grande", Category = "Salgado", Price = 4.99, ImageUrl = "images/paodequeijo.jpg", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Suco de Laranja", Description = "Natural 300ml", Category = "Bebida", Price = 6.99, ImageUrl = "images/suco_laranja.jpg", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Empada", Description = "Frango", Category = "Salgado", Price = 7.00, ImageUrl = "images/empada.jpg", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Chá Gelado", Description = "Pêssego ou limão", Category = "Bebida", Price = 4.50, ImageUrl = "images/cha_gelado.jpg", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Kibe", Description = "Frito, com recheio de catupiry opcional", Category = "Salgado", Price = 6.99, ImageUrl = "images/kibe.jpg", Status = 1 },
                new() { Id = Guid.NewGuid(), Name = "Água de Coco", Description = "Natural 300ml", Category = "Bebida", Price = 5.00, ImageUrl = "images/agua_coco.jpg", Status = 1 }
            };


            return list;
        }

        public List<ProductDTO> UpdateThenList(ProductDTO dto)
        {
            List<ProductDTO> list = List();
            var toUpdate = list.FirstOrDefault(a => a.Id == dto.Id);
            return list;
        }
    }
}
