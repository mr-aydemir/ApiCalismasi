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
            ÜrünList.FlowItemsSource = ürünler.Arama(e.NewTextValue);
            ÜrünList.EndRefresh();
        }

        private async void ÜrünList_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }

        private void Filtre_Clicked(object sender, EventArgs e)
        {
            if (FiltreMenusu.IsVisible)
            {
                Filtre.Text = "FİLTRELE";
                FiltreMenusu.IsVisible = false;
            }
            else
            {
                Filtre.Text = "GİZLE";
                FiltreMenusu.IsVisible = true;
            }
        }

        private void Onayla_Clicked(object sender, EventArgs e)
        {
            ÜrünList.BeginRefresh();

            ÜrünList.FlowItemsSource = ürünler.FiyataGöreFiltrele(Minimum.Text, Maksimum.Text);
            ÜrünList.EndRefresh();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            bool a = e.Value;
            if ((sender as RadioButton).Text == "Artan Fiyata Göre Sırala")
            {
                if (a == true)
                {
                    ÜrünList.BeginRefresh();
                    ÜrünList.FlowItemsSource = ürünler.FiyataGöreFiltrele(Minimum.Text, Maksimum.Text).OrderBy(o => o.Cost).ToList();
                    ÜrünList.EndRefresh();
                }
            }
            else
            {
                if (a == true)
                {
                    if (a == true)
                    {
                        ÜrünList.BeginRefresh();
                        ÜrünList.FlowItemsSource = ürünler.FiyataGöreFiltrele(Minimum.Text, Maksimum.Text).OrderBy(o => o.Cost * (-1)).ToList();
                        ÜrünList.EndRefresh();
                    }
                }
            }
        }
    }
}