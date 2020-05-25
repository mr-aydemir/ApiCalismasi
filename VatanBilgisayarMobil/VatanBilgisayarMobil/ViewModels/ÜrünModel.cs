using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VatanBilgisayarMobil.Data;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Views;
using Xamarin.Forms;
using static VatanBilgisayarMobil.Data.RestAPIForProducts;

namespace VatanBilgisayarMobil.ViewModels
{
    public class ÜrünModel : BindableObject
    {
        private Page Page;
        List<Product> Products = new List<Product>();
        RestAPIForProducts RestAPI;
        public ÜrünModel(Page mainPage)
        {
            this.Page = mainPage;
            RestAPI = new RestAPIForProducts();
            Products = GetAllItems();
        }
        public Product FindÜrünItemWithName(string Name)
        {
            Product Ürün = new Product();
            foreach (var item in Products)
            {
                if (Name == item.Name)
                {
                    Ürün = item;
                    break;
                }
            }
            return Ürün;
        }
        public Product FindÜrünItemWithId(string Id)
        {
            Product Ürün =new Product();
            foreach (Product item in Products)
            {
                if (Id == item.Id.ToString())
                {
                    Ürün = item;
                    break;
                }
            }
            return Ürün;
        }
        public List<Product> GetItems(int numberOfItem)
        {
            List<Product> Items = new List<Product>();
            foreach (Product item in Products)
            {
                Items.Add(item);
                if (Items.Count == numberOfItem)
                {
                    break;
                }

            }
            
            return Items;
        }
        public List<Product> GetAllItems()
        {
            
            return RestAPI.GetProducts();
        }
        public List<Product> GetAllItemsNonCallApi()
        {

            return Products;
        }
    }
}
