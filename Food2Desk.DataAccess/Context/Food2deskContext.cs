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
                entity.Property(x => x.Status);
            });

            modelBuilder.Entity<OfficeDTO>(entity =>
            {
                entity.ToTable("Office");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Block);
                entity.Property(x => x.Floor);
                entity.Property(x => x.Number);

                entity.HasOne(x => x.User)
                    .WithMany(o => o.Offices)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
//is required pra not null