using Food2Desk.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = Food2Desk.Shared.Utils.ConfigurationManager;

namespace Food2Desk.DataAccess.Context
{
    public class Food2deskContext(DbContextOptions<Food2deskContext> options) : DbContext(options)
    {
        public virtual DbSet<UserDTO> User { get; set; } //faze pra todas as tabelaaaa
        public virtual DbSet<ProductDTO> Product { get; set; }
        public virtual DbSet<OfficeDTO> Office { get; set; }
        public virtual DbSet<UserAuthDTO> UserAuth { get; set; }
        public virtual DbSet<OrderDTO> Order { get; set; }
        public virtual DbSet <ProductCartDTO> ProductCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(Console.WriteLine)
                    .UseNpgsql(ConfigurationManager.AppSetting.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>(entity =>
            {
                //propriedades das tabela
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name);
                entity.Property(x => x.Email);
                entity.Property(x => x.Doc);
            });

            modelBuilder.Entity<ProductDTO>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.ImageUrl);
                entity.Property(x => x.Name);
                entity.Property(x => x.Description);
                entity.Property(x => x.Price);
                entity.Property(x => x.WeekDay);
                entity.Property(x => x.Category);
                entity.Property(x => x.Quantity);
                entity.Property(x => x.Status);
            });

            modelBuilder.Entity<OfficeDTO>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Block);
                entity.Property(x => x.Floor);
                entity.Property(x => x.Number);

                entity.HasOne(x => x.User)
                    .WithMany(o => o.Offices)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<UserAuthDTO>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Email);
                entity.Property(x => x.Password);
                entity.Property(x => x.IsLogged);
                entity.Property(x => x.UserId);
            });

            modelBuilder.Entity<OrderDTO>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Code);
                entity.Property(e => e.UserId);
                entity.Property(e => e.UserName);
                entity.Property(e => e.TotalCharge).HasColumnType("decimal(10,2)");
                entity.Property(e => e.ToDelivery);
                entity.Property(e => e.IsLunch);
                entity.Property(e => e.Status);
                entity.Property(e => e.OfficeId);

                // 🔗 Relacionamento com Office
                entity.HasOne(e => e.Office)
                      .WithMany()
                      .HasForeignKey(e => e.OfficeId)
                      .OnDelete(DeleteBehavior.Restrict);  // impede dele excluir o office se deletar o order

                // 🔗 Relacionamento com Cart
                entity.HasMany(e => e.Cart)
                      .WithOne()
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductCartDTO>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.Property(e => e.Quantity);
                entity.Property(e => e.Price);
                entity.Property(e => e.Name);
                entity.Property(e => e.OrderId);

                entity.HasOne<OrderDTO>()
                      .WithMany(o => o.Cart)
                      .HasForeignKey(e => e.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<OfficeDTO>(entity =>
            //{
            //    entity.HasKey(x => x.Id);
            //    entity.Property(x => x.Floor);
            //    entity.Property(x => x.Block);
            //    entity.Property(x => x.Number);

            //    entity.HasFor
            //});
        }
    }
}
//is required pra not null