using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using VatanAPI.Domain.Models;

namespace VatanAPI.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Telefon" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Bilgisayar" },
                new Category { Id = 102, Name = "Bilgisayar Parçaları" },
                new Category { Id = 103, Name = "Kamera" },
                new Category { Id = 104, Name = "TV & Ev Elektroniği" },
                new Category { Id = 105, Name = "Ofis" },
                new Category { Id = 106, Name = "Aksesuar" },
                new Category { Id = 107, Name = "Oyun & Hobi" },
                new Category { Id = 108, Name = "Ev Aletleri" },
                new Category { Id = 109, Name = "Spor & Outdoor" }
            ); 
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Url).IsRequired();
            builder.Entity<Product>().Property(p => p.Cost).IsRequired();
            builder.Entity<Product>().Property(p => p.Marka).IsRequired();
            builder.Entity<Product>().HasMany(p => p.Images).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "HP 15-DA1021NT",
                    Url = "https://www.vatanbilgisayar.com/hp-15-da1021nt-core-i5-8265u-1-6ghz-8gb-256gb-ssd-15-6-mx110-2gb-w10-notebook.html",
                    Cost = 4837,
                    Marka = EMarka.HP,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 101,
                    Name = "LENOVO IDEAPAD S540",
                    Url = "https://www.vatanbilgisayar.com/lenovo-ideapad-s540-core-i5-10210u-1-6ghz-8gb-ram-256gb-ssd-15-6-mx250-2gb-w10.html",
                    Marka = EMarka.LENOVO,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 102,
                    Name = "Monster Abra A5",
                    Url = "",
                    Marka = EMarka.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 103,
                    Name = "Monster Abra A7",
                    Url = "",
                    Marka = EMarka.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 104,
                    Name = "Acer Nitro 5 i5 9300HQ GTX1650 256GB SSD 1TB HDD",
                    Url = "",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 105,
                    Name = "Monster Tulpar 10.71",
                    Url = "",
                    Marka = EMarka.Unity,
                    CategoryId = 101,
                }
            );
            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Image>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Image>().Property(p => p.Url).IsRequired();
            builder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = 100,
                    Name = "Monster Abra 14.53",
                    Url = "mr.org",
                    ProductId = 100
                },
                new Image
                {
                    Id = 101,
                    Name = "Monster Abra 14.53",
                    Url = "sada.com",
                    ProductId = 101
                },
                new Image
                {
                    Id = 102,
                    Name = "Monster Abra 14.53",
                    Url = "wwdwd.tr",
                    ProductId = 102
                },
                new Image
                {
                    Id = 103,
                    Name = "Monster Abra 14.53",
                    Url = "wdawd.sd",
                    ProductId = 103
                },
                new Image
                {
                    Id = 104,
                    Name = "Monster Abra 14.53",
                    Url = "adsad.com",
                    ProductId = 104
                },
                new Image
                {
                    Id = 105,
                    Name = "Monster Abra 14.53",
                    Url = "",
                    ProductId = 105
                }
            );
        }
    }
}
