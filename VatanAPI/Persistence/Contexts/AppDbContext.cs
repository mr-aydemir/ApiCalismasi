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
                    Name = "81ND009TTX",
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
                },
                new Product
                {
                    Id = 106,
                    Name = "A315-34-C7LB",
                    Url = "https://www.vatanbilgisayar.com/acer-aspire-3-celeron-n4000-1-1ghz-4gb-ram-128gb-ssd-15-6-int-w10-notebook.html",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 107,
                    Name = "AN515-54-74XH",
                    Url = "https://www.vatanbilgisayar.com/acer-nitro-5-core-i7-9750h-2-6ghz-16gb-1tb-128gb-ssd-15-6-gtx1660ti-6gb-w10.html",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 108,
                    Name = "AN515-54-56UW",
                    Url = "https://www.vatanbilgisayar.com/acer-nitro-5-core-i5-8300h-2-3ghz-8gb-1tb-128gb-ssd-15-6-gtx1050-3gb-w10.html",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 109,
                    Name = "AN515-54-78JD",
                    Url = "https://www.vatanbilgisayar.com/acer-nitro-5-core-i7-9750h-2-6ghz-16gb-1tb-256gb-ssd-15-6-gtx1650-4gb-w10.html",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 110,
                    Name = "5QS63EA",
                    Url = "https://www.vatanbilgisayar.com/hp-15-da1021nt-core-i5-8265u-1-6ghz-8gb-256gb-ssd-15-6-mx110-2gb-w10-notebook.html",
                    Marka = EMarka.HP,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 111,
                    Name = "G531GT-AL178T-Gaming",
                    Url = "https://www.vatanbilgisayar.com/asus-g531gt-core-i7-9750h-2-6ghz-16gb-512gb-ssd-15-6-gtx1650-4gb-w10.html",
                    Marka = EMarka.ASUS,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 112,
                    Name = "7WA87EA",
                    Url = "https://www.vatanbilgisayar.com/hp-spectre-x360-13-aw0001nt-core-i7-1065g7-1-3ghz-16gb-512gb-ssd-13-3-int-w10.html",
                    Marka = EMarka.HP,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 113,
                    Name = "9QH75EA",
                    Url = "https://www.vatanbilgisayar.com/hp-15-da1116nt-core-i5-8265u-1-6ghz-8gb-1tb-128gb-ssd-15-6-mx110-2gb-w10.html",
                    Marka = EMarka.HP,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 114,
                    Name = "6TC05EA",
                    Url = "https://www.vatanbilgisayar.com/hp-15-da1065nt-core-i5-8265u-1-6ghz-4gb-128gb-ssd-15-6-mx110-2gb-w10-notebook.html",
                    Marka = EMarka.HP,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 115,
                    Name = "SF314-41G-R1WG",
                    Url = "https://www.vatanbilgisayar.com/acer-swift-3-amd-ryzen-7-3700u-2-3ghz-8gb-256gb-ssd-14-rx540-2gb-w10.html",
                    Marka = EMarka.ACER,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 116,
                    Name = "G315-4B75D256W161C",
                    Url = "https://www.vatanbilgisayar.com/dell-g315-core-i7-9750h-2-6ghz-16gb-1tb-256-ssd-gtx1650-4gb-15-6-w10.html",
                    Marka = EMarka.DELL,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 117,
                    Name = "31.8029",
                    Url = "https://www.vatanbilgisayar.com/hometech-alfa-300i-intel-core-i3-5005u-2ghz-4gb-128gb-ssd-14-int-w10.html",
                    Marka = EMarka.HOMETECH,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 118,
                    Name = "G317-FB75D256W162C",
                    Url = "https://www.vatanbilgisayar.com/dell-g317-core-i7-8750h-2-2ghz-16gb-2tb-256-ssd-gtx1060-6gb-17-3-w10.html",
                    Marka = EMarka.DELL,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 119,
                    Name = "G315-4B75D256W161C",
                    Url = "https://www.vatanbilgisayar.com/dell-g315-core-i7-9750h-2-6ghz-16gb-1tb-256-ssd-gtx1650-4gb-15-6-w10.html",
                    Marka = EMarka.DELL,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 120,
                    Name = "53010TTJ",
                    Url = "https://www.vatanbilgisayar.com/huawei-matebook-d-15-amd-ryzen-5-3500u-2-1ghz-8gb-512gbssd-15-6-amd-w10.html",
                    Marka = EMarka.HUAWEİ,
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
                },
                new Image
                {
                    Id = 106,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105813_large.jpg",
                    ProductId = 106,
                    Name = "TeoriV2-105813_large.jpg"
                },
                new Image
                {
                    Id = 107,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105818-5_large.jpg",
                    ProductId = 107,
                    Name = "TeoriV2-105818-5_large.jpg"
                },
                new Image
                {
                    Id = 108,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105819-5_large.jpg",
                    ProductId = 108,
                    Name = "TeoriV2-105819-5_large.jpg"
                },
                new Image
                {
                    Id = 109,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-105816-5_large.jpg",
                    ProductId = 109,
                    Name = "TeoriV2-105816-5_large.jpg"
                },
                new Image
                {
                    Id = 110,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106687_large.jpg",
                    ProductId = 110,
                    Name = "TeoriV2-106687_large.jpg"
                },
                new Image
                {
                    Id = 111,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ASUS/thumb/TeoriV2-106598_large.jpg",
                    ProductId = 111,
                    Name = "TeoriV2-106598_large.jpg"
                },
                new Image
                {
                    Id = 112,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106595_large.jpg",
                    ProductId = 112,
                    Name = "TeoriV2-106595_large.jpg"
                },
                new Image
                {
                    Id = 113,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106571_large.jpg",
                    ProductId = 113,
                    Name = "TeoriV2-106571_large.jpg"
                },
                new Image
                {
                    Id = 114,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-106470_large.jpg",
                    ProductId = 114,
                    Name = "TeoriV2-106470_large.jpg"
                },
                new Image
                {
                    Id = 115,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-106421_large.jpg",
                    ProductId = 115,
                    Name = "TeoriV2-106421_large.jpg"
                },
                new Image
                {
                    Id = 116,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/TeoriV2-104849_large.jpg",
                    ProductId = 116,
                    Name = "TeoriV2-104849_large.jpg"
                },
                new Image
                {
                    Id = 117,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HOMETECH/thumb/TeoriV2-104680-3_large.jpg",
                    ProductId = 117,
                    Name = "TeoriV2-104680-3_large.jpg"
                },
                new Image
                {
                    Id = 118,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/v2-92892_large.jpg",
                    ProductId = 118,
                    Name = "v2-92892_large.jpg"
                },
                new Image
                {
                    Id = 119,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/DELL/thumb/TeoriV2-104849_large.jpg",
                    ProductId = 119,
                    Name = "TeoriV2-104849_large.jpg"
                },
                new Image
                {
                    Id = 120,
                    Url = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HUAWEI/thumb/TeoriV2-106613_large.jpg",
                    ProductId = 120,
                    Name = "TeoriV2-106613_large.jpg"
                }
            );


            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
