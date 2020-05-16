using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VatanBilgisayarMobil.Data;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Views;
using Xamarin.Forms;
using static VatanBilgisayarMobil.Data.RestApi;

namespace VatanBilgisayarMobil.ViewModels
{
    public class ÜrünButonuModeli : BindableObject
    {
        private Page mainPage;
        RestApi RestApi;

        public ÜrünButonuModeli(Page mainPage)
        {
            this.mainPage = mainPage;
            RestApi = new RestApi();
            AddItems();
        }

        private void AddItems()
        {
            ÜrünItem ürünItem = new ÜrünItem();
            foreach (var item in RestApi.GetProducts())
            {
                ürünItem = new ÜrünItem()
                {
                    ImageSource = item.ImageUrl,
                    Ürünİsmi = item.Name,
                    ÜrünDetayı = item.Info,
                    ÜrünFiyatı = item.Cost.ToString()
                };
                Items.Add(ürünItem);
            }

            /*for (int i = 0; i < 20; i++)
            {
                ürünItem = new ÜrünItem()
                {
                    ImageSource = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/ACER/thumb/TeoriV2-104064-6_small.jpg",
                    Ürünİsmi = string.Format("Ürün İsmi {0}", i),
                    ÜrünDetayı = string.Format("Ürün Detayı {0}", i),
                    ÜrünFiyatı = string.Format("Ürün Fiyatı {0}", i)
                   
                }; 
                Items.Add(ürünItem);
            }*/

        }

        private ObservableCollection<ÜrünItem> _items = new ObservableCollection<ÜrünItem>();
        public ObservableCollection<ÜrünItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public Command ItemTappedCommand
        {
                get
                {
                    return new Command((data) =>
                    {
                        mainPage.DisplayAlert("FlowListView", data + "", "Ok"); 
                    });
                }
        }
        private void ItemTapped(object sender, EventArgs e)
        {
            mainPage = new NavigationPage(new AboutPage());
        }
    }
}
