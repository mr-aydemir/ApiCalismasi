using System;
using System.Collections.ObjectModel;
using VatanBilgisayarMobil.Data;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Views;
using Xamarin.Forms;

namespace VatanBilgisayarMobil.ViewModels
{
    public class ÜrünModel : BindableObject
    {
        private Page Page;

        RestAPI RestAPI;
        public ÜrünModel(Page mainPage)
        {
            this.Page = mainPage;
            RestAPI = new RestAPI();
            //AddItems();
        }

        /*private void AddItems()
        {
            foreach (var item in RestAPI.GetProducts())
            {
                ÜrünItem ürünItem = new ÜrünItem()
                {
                    ImageSource = item.ImageUrl,
                    Ürünİsmi = item.Name,
                    ÜrünDetayı = item.Info,
                    ÜrünFiyatı = item.Cost.ToString()

                };
                Items.Add(ürünItem);

            }
        }*/
        public ÜrünItem FindÜrünItemWithName(string Name)
        {
            ÜrünItem ürünItem = new ÜrünItem();
            foreach (var item in RestAPI.GetProducts())
            {
                if (Name == item.Name)
                {
                    ürünItem = new ÜrünItem()
                    {
                        ImageSource = item.ImageUrl,
                        Ürünİsmi = item.Name,
                        ÜrünDetayı = item.Info,
                        ÜrünFiyatı = item.Cost.ToString()

                    };
                    break;
                }
            }
            return ürünItem;
        }
        public ObservableCollection<ÜrünItem> GetItems(int numberOfItem)
        {
            ObservableCollection<ÜrünItem> Items = new ObservableCollection<ÜrünItem>();
            foreach (var item in RestAPI.GetProducts())
            {

                ÜrünItem ürünItem = new ÜrünItem()
                {
                    ImageSource = item.ImageUrl,
                    Ürünİsmi = item.Name,
                    ÜrünDetayı = item.Info,
                    ÜrünFiyatı = item.Cost.ToString()

                };
                Items.Add(ürünItem);
                if (Items.Count == numberOfItem)
                {
                    break;
                }

            }
            return Items;
        }
        public ObservableCollection<ÜrünItem> GetAllItems()
        {
            ObservableCollection<ÜrünItem> Items = new ObservableCollection<ÜrünItem>();
            
            foreach (var item in RestAPI.GetProducts())
            {

                ÜrünItem ürünItem = new ÜrünItem()
                {
                    ImageSource = item.ImageUrl,
                    Ürünİsmi = item.Name,
                    ÜrünDetayı = item.Info,
                    ÜrünFiyatı = item.Cost.ToString()

                };
                Items.Add(ürünItem);

            }
            return Items;
        }
    }
}
