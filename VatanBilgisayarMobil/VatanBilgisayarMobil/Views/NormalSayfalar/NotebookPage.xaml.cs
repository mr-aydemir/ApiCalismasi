using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Helpers;
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
        ProductFilter ProductFilter;
        ERadioButtonProperty RadioButtonProperty;
        public NotebookPage()
        {
            InitializeComponent();
            Ürünler = new ÜrünModel(this);
            ProductFilter = new ProductFilter(Ürünler, this);
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = Ürünler.GetAllItemsNonCallApi();
            AdetLabel.Text = ÖneÇıkanÜrünlerFLV.FlowItemsSource.Count.ToString();
            List<RadioButtonsModel> radioButtonsModels = new List<RadioButtonsModel>()
            {
                new RadioButtonsModel(){ Property=ERadioButtonProperty.Azalan, TextString="Azalan Fiyata Göre Sırala"},
                new RadioButtonsModel() { Property = ERadioButtonProperty.Artan, TextString = "Artan Fiyata Göre Sırala" }
            };
            Azalan.BindingContext = radioButtonsModels[0];
            Artan.BindingContext = radioButtonsModels[1];
        }

        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
        private void ürünAraması_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Filtrele();
        }
        private void Filtrele()
        {
            ÖneÇıkanÜrünlerFLV.BeginRefresh();
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = ProductFilter.Filtrele(ürünAraması.Text, Minimum.Text, Maksimum.Text, RadioButtonProperty);
            ÖneÇıkanÜrünlerFLV.EndRefresh();
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
            Filtrele();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value==true)
            {
                RadioButtonProperty = ((sender as RadioButton).BindingContext as RadioButtonsModel).Property;
            }
            Filtrele();
        }
    }
}