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
            //builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "HP 15-DA1021NT",
                    Url = "",
                    CategoryId = 101
                },
                new Product
                {
                    Id = 101,
                    Name = "Monster Tulpar 10.71",
                    QuantityInPackage = 2,
                    Url = "",
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 102,
                    Name = "Monster Abra A5",
                    QuantityInPackage = 2,
                    Url = "",
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 103,
                    Name = "Monster Abra A7",
                    QuantityInPackage = 2,
                    Url = "",
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 104,
                    Name = "Acer Nitro 5 i5 9300HQ GTX1650 256GB SSD 1TB HDD",
                    QuantityInPackage = 2,
                    Url = "",
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 105,
                    Name = "Monster Tulpar 10.71",
                    QuantityInPackage = 2,
                    Url = "",
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
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
                    Url = "",
                    ProductId = 100
                },
                new Image
                {
                    Id = 101,
                    Name = "Monster Abra 14.53",
                    Url = "",
                    ProductId = 101
                },
                new Image
                {
                    Id = 102,
                    Name = "Monster Abra 14.53",
                    Url = "",
                    ProductId = 102
                },
                new Image
                {
                    Id = 103,
                    Name = "Monster Abra 14.53",
                    Url = "",
                    ProductId = 103
                },
                new Image
                {
                    Id = 104,
                    Name = "Monster Abra 14.53",
                    Url = "",
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
