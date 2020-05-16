using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace VatanBilgisayarMobil.Data
{
    public class RestApi
    {
        public List<Product> Products;
        public List<Category> Categories;
        public List<ImageModel> ImageModels;
        public RestApi()
        {
            GetData();
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public List<Category> GetCategories()
        {
            return Categories;
        }
        public List<ImageModel> GetImageModels()
        {
            return ImageModels;
        }
        private void GetData()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/products").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                Products = items as List<Product>;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Hata!","Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase,"Tamam");
            }

            response = client.GetAsync("api/categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                Categories = items as List<Category>;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Hata!", "Error Code" +
               response.StatusCode + " : Message - " + response.ReasonPhrase, "Tamam");
            }
            response = client.GetAsync("api/images").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<ImageModel>>().Result;
                ImageModels = items as List<ImageModel>;

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Hata!", "Error Code" +
               response.StatusCode + " : Message - " + response.ReasonPhrase, "Tamam");
            }
            foreach (var item in Products)
            {
                foreach (var item2 in ImageModels)
                {
                    if (item2.ProductId == item.Id)
                    {
                        item.ImageUrl = item2.Url;
                        break;
                    }
                }
            }
        }

        public class ImageModel
        {
            public int Id { get; set; }
            public string Url { get; set; }
            public string Name { get; set; }
            public int ProductId { get; set; }
            public Product Product { get; set; }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IList<Product> Products { get; set; } = new List<Product>();
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public EMarka Marka { get; set; }
            public double Cost { get; set; }
            public double PreviousCost { get; set; }
            public int CategoryId { get; set; }
            public string Url { get; set; }
            public int NumberInStock { get; set; }
            public string Info { get; set; }
            public double KargoFiyatı { get; set; }
            public Category Category { get; set; }
            public IList<ImageModel> Images { get; set; } = new List<ImageModel>();
            public string ImageUrl;

            public enum EMarka : byte
            {
                [Description("LENOVO")]
                LENOVO = 1,

                [Description("ASUS")]
                ASUS = 2,

                [Description("SAMSUNG")]
                SAMSUNG = 3,

                [Description("ACER")]
                ACER = 4,

                [Description("APPLE")]
                APPLE = 5,

                [Description("DELL")]
                DELL = 6,

                [Description("HUAWEI")]
                HUAWEI = 7,

                [Description("HP")]
                HP = 8,

                [Description("HOMETECH")]
                HOMETECH = 9
            }
        }
    }

}
