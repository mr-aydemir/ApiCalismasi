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

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotebookPage : ContentPage
    {
        ÜrünModel Ürünler;
        public NotebookPage()
        {
            InitializeComponent();
            Ürünler = new ÜrünModel(this);
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = Ürünler.GetAllItemsNonCallApi();
            AdetLabel.Text = ÖneÇıkanÜrünlerFLV.FlowItemsSource.Count.ToString();
        }

        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
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
            ÖneÇıkanÜrünlerFLV.BeginRefresh();
            
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = FiyataGöreFiltrele();
            ÖneÇıkanÜrünlerFLV.EndRefresh();
        }
        List<Product> FiyataGöreFiltrele()
        {
            int min = 0;
            int max = 0;
            if (string.IsNullOrWhiteSpace(Minimum.Text))
            {
                min = 0;
            }
            else min = Convert.ToInt32(Minimum.Text);
            if (string.IsNullOrWhiteSpace(Maksimum.Text))
            {
                max = 100000;
            }
            else max = Convert.ToInt32(Maksimum.Text);

            var products = Ürünler.GetAllItemsNonCallApi();
            products = products.Where(c => c.Cost >= min).ToList();
            products = products.Where(c => c.Cost <= max).ToList();
            return products;
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            bool a = e.Value;
            if ((sender as RadioButton).Text == "Artan Fiyata Göre Sırala")
            {
                if (a==true)
                {
                    ÖneÇıkanÜrünlerFLV.BeginRefresh();
                    ÖneÇıkanÜrünlerFLV.FlowItemsSource = FiyataGöreFiltrele().OrderBy(o => o.Cost).ToList();
                    ÖneÇıkanÜrünlerFLV.EndRefresh();
                }
            }
            else
            {
                if (a==true)
                {
                    if (a == true)
                    {
                        ÖneÇıkanÜrünlerFLV.BeginRefresh();
                        ÖneÇıkanÜrünlerFLV.FlowItemsSource = FiyataGöreFiltrele().OrderBy(o => o.Cost*(-1)).ToList();
                        ÖneÇıkanÜrünlerFLV.EndRefresh();
                    }
                }
            }
        }
    }
}