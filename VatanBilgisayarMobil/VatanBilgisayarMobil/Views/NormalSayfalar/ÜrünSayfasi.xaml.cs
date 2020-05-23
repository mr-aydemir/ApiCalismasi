using Android.Provider;
using VatanBilgisayarMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VatanBilgisayarMobil.Helpers;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ÜrünSayfasi : ContentPage
    {
        Product ÜrünBilgileri;
        int adet=1;
        SepetIslemleri SepetIslemleri = new SepetIslemleri();
        public ÜrünSayfasi(Product ürünItem)
        {
            InitializeComponent();
            ÜrünBilgileri = ürünItem;
            id.Text = ÜrünBilgileri.Id.ToString();
            Image.Source = ÜrünBilgileri.ImageSource;
            Name.Text = ÜrünBilgileri.Name;
            Detail.Text = ÜrünBilgileri.Info;
            Cost.Text = string.Format("{0:#,0.####}", ÜrünBilgileri.Cost);
            Taksit.Text = string.Format("{0:#,0.####}", (ÜrünBilgileri.Cost / 12))+"'den başlayan taksitlerle ";
            picker.SelectedIndex = 0;
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                adet = Convert.ToInt32((picker.ItemsSource[selectedIndex] as string)[0].ToString());        
            }
        }


        private async void SepeteEkle_Clicked(object sender, EventArgs e)
        {
            bool Mevcut= SepetIslemleri.SepeteEkle(ÜrünBilgileri, adet); 
            if (Mevcut)
            {
                await DisplayAlert("Zaten Ekli", "Sepete bu üründen en fazla bir adet eklenebilir", "Tamam");
            }
            else
            {
                await Navigation.PushAsync(new Sepetim());
            }
        }
    }
}