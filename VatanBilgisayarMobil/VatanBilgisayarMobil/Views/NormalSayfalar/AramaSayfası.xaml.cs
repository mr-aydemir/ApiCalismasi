using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static VatanBilgisayarMobil.Data.RestAPIForProducts;
using Settings = VatanBilgisayarMobil.Helpers.Settings;


namespace VatanBilgisayarMobil.Views.KullanıcıSayfaları
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AramaSayfası : ContentPage
    {
        ÜrünModel ürünler;
        public AramaSayfası()
        {
            InitializeComponent();
            ürünler = new ÜrünModel(this);
            ÜrünList.FlowItemsSource = ürünler.GetItems(20);
        }

        private void ürünAraması_TextChanged(object sender, TextChangedEventArgs e)
        {
            ÜrünList.BeginRefresh();
            string[] substrings = e.NewTextValue.Split(' ');
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ÜrünList.FlowItemsSource = null;
            else
            {
                var products = ürünler.GetAllItemsNonCallApi();       
                foreach (var item in substrings)
                {
                    products = products.Where(c => c.Info.ToLower().Contains(item.ToLower())).ToList();
                }
                ÜrünList.FlowItemsSource = products;
            }

            ÜrünList.EndRefresh();
        }

        private async void ÜrünList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
    }
}