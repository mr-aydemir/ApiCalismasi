using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;

namespace VatanBilgisayarMobil.Helpers
{
    public class ProductFilter
    {
        ÜrünModel ÜrünModel;
        List<Product> Products = new List<Product>();
        public string searchkeywords { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public ProductFilter(ÜrünModel ürünModel, Page page)
        {
            ÜrünModel = new ÜrünModel(page);
            ResetList();
        }
        public List<Product> Filtrele(string word, string minPrice, string maxPrice, ERadioButtonProperty OrderType)
        {
            ResetList();
            Products=Arama(word);
            Products=FiyataGöreFiltrele(minPrice, maxPrice);
            Products=Order(OrderType);
            return Products;
        }
        public List<Product> ResetList()
        {
           return Products = ÜrünModel.GetAllItemsNonCallApi();
        }
        //
        public List<Product> Order(ERadioButtonProperty OrderType)
        {
            if (Products==null)
            {
                return Products;
            }
            switch ((int)OrderType)
            {
                case (int)ERadioButtonProperty.Artan:
                    Products=Products.OrderBy(o => o.Cost).ToList();
                    break;
                case (int)ERadioButtonProperty.Azalan:
                    Products = Products.OrderBy(o => o.Cost * (-1)).ToList();
                    break;
                default:
                    break;
            }
            return Products;
        }
        //Sıkıntısız
        public List<Product> FiyataGöreFiltrele(string minimum, string maksimum)
        {
            int min = 0;
            int max = 0;
            if (string.IsNullOrWhiteSpace(minimum))
            {
                min = 0;
            }
            else min = Convert.ToInt32(minimum);
            if (string.IsNullOrWhiteSpace(maksimum))
            {
                max = 100000;
            }
            else max = Convert.ToInt32(maksimum);

            if (Products==null)
            {
                return Products;
            }
            Products = Products.Where(c => c.Cost >= min).ToList();
            Products = Products.Where(c => c.Cost <= max).ToList();
            return Products;
        }
        //Sıkıntısız
        public List<Product> Arama(string word)
        {
           
            if (string.IsNullOrWhiteSpace(word))
                return Products;
            else
            {
                string[] substrings = word.Split(' ');
                foreach (var item in substrings)
                {
                    Products = Products.Where(c => c.Info.ToLower().Contains(item.ToLower())).ToList();
                }
                return Products;
            }

        }
    }
}
