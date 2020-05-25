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
            ÜrünList.FlowItemsSource = ürünler.GetItems(50);
        }

        private void ürünAraması_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = ürünAraması.Text;
            if (keyword.Length >= 1)
            {
                var suggestion = ürünler.GetAllItemsNonCallApi().Where(c => c.Info.ToLower().Contains(keyword.ToLower()));
                ÜrünList.ItemsSource = suggestion;
                ÜrünList.IsVisible = true;
            }
            else
            {
                ÜrünList.IsVisible = true;
            }
        }

        private void ÜrünList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        private async void ÜrünList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            if (e.Item as string == null)
            {
                return ;
            }
            else
            {
                ÜrünList.ItemsSource = ürünler.GetAllItemsNonCallApi();
                ÜrünList.IsVisible = true;
                ürünAraması.Text = e.Item as string;
            }
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
    }
}