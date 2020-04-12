using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using VatanAPI.Domain.Models;
using VatanAPI.Core.Models;

namespace VatanAPI.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
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
                    Name= "da1021nt",
                    Url = "https://www.vatanbilgisayar.com/hp-15-da1021nt-core-i5-8265u-1-6ghz-8gb-256gb-ssd-15-6-mx110-2gb-w10-notebook.html",
                    Cost = 4837,
                    Marka = EMarka.HP,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 101,
                    Name = "81ND003TTX",
                    Url = "https://www.vatanbilgisayar.com/lenovo-ideapad-s540-core-i5-10210u-1-6ghz-8gb-ram-256gb-ssd-15-6-mx250-2gb-w10.html",
                    Marka = EMarka.LENOVO,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 102,
                    Name = "53010TTJ",
                    Url = "https://www.vatanbilgisayar.com/huawei-matebook-d-15-amd-ryzen-5-3500u-2-1ghz-8gb-512gbssd-15-6-amd-w10.html",
                    Marka = EMarka.HUAWEİ,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 103,
                    Name = "X509FB-BR073T",
                    Url = "https://www.vatanbilgisayar.com/asus-x509fb-core-i5-8265u-1-6ghz-8gb-ram-256gb-ssd-15-6-mx110-2gb-w10.html",
                    Marka = EMarka.DELL,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 104,
                    Name = "A315-55G-57HC",
                    Url = "https://www.vatanbilgisayar.com/acer-aspire-3-core-i5-10210u-1-6ghz-8gb-256gb-ssd-15-6-mx230-2gb-w10-notebook.html",
                    Cost = 4.599,
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 105,
                    Name = "MVVM2TU/A",
                    Url = "https://www.vatanbilgisayar.com/macbook-pro-touch-bar-core-i9-2-3ghz-16gb-1tb-ssd-retina-16-4gb-silver.html",
                    Marka = EMarka.APPLE,
                    CategoryId = 101,
                }
            );;
            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Image>().Property(p => p.Url).IsRequired();
            builder.Entity<Image>().Property(p => p.Name).IsRequired();
            builder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = 100,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106687_large.jpg",
                    Name= "TeoriV2-106687_large.jpg",
                    ProductId = 100
                },
                new Image
                {
                    Id = 101,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/LENOVO/thumb/TeoriV2-97788_large.jpg",
                    Name= "TeoriV2-97788_large.jpg",
                    ProductId = 101
                },
                new Image
                {
                    Id = 102,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HUAWEI/thumb/TeoriV2-106613_large.jpg",
                    Name= "TeoriV2-106613_large.jpg",
                    ProductId = 102
                },
                new Image
                {
                    Id = 103,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ASUS/thumb/TeoriV2-105445-7_large.jpg",
                    Name = "TeoriV2-105445-7_large.jpg",
                    ProductId = 103
                },
                new Image
                {
                    Id = 104,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-106597_large.jpg",
                    Name= "TeoriV2-106597_large.jpg",
                    ProductId = 104
                },
                new Image
                {
                    Id = 105,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/APPLE/thumb/TeoriV2-105271-4_large.jpg",
                    ProductId = 105,
                    Name= "TeoriV2-105271-4_large.jpg"
                }
            );


            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
