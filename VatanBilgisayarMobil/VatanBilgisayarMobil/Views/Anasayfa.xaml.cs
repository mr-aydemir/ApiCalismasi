using System;
using System.Collections.Generic;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anasayfa : ContentPage
    {
        public double screensize;

        public Anasayfa()
        {
            InitializeComponent();
            ÜrünModel ÜrünModel;
            List<string> FırsatÜrünleriImages = new List<string>()
            {
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_nisan/ensuper-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/philips-tv-kamp-7-mayis-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/fiba-mob-3-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/super-fiyat-xr-acer-12-mayis-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/super-fiyat-airpods-11-mayis-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/super-fiyatlar-kea-12-mayis-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/uclu-ffirin-kea-mob-12-mayis-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/yazici-banner-12-mayis-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/lenovo-mob-12-mayis-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/ACER_nitro5_Vatan_700x380-mobbb.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_mayis/oppo-reno3-banner-mob-min.jpg",
                "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_nisan/sss-mob-min.jpg"
            };
            FırsatÜrünleriCarousel.ItemsSource = FırsatÜrünleriImages;
            ÜrünModel = new ÜrünModel(this);
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = new ÜrünModel(this).GetItems(10);
            BindableLayout.SetItemsSource(EnÇokSatanlarSB, new ÜrünModel(this).GetItems(15));
            FırsatÜrünleriCarousel.ItemsSource = FırsatÜrünleriImages;
            //ÖneÇıkanÜrünlerFLV.HeightRequest = Convert.ToDouble(ürünButonuModeli.Items.Count / ÖneÇıkanÜrünlerFLV.FlowColumnCount * 250); 
        }

        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as ÜrünItem;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }

        private async void ÜrünTapped2(object sender, EventArgs e)
        {
            var tappedItem = (StackLayout)sender;
            string ProductName = (tappedItem.Children[1] as Label).Text;
            await Navigation.PushAsync(new ÜrünSayfasi(new ÜrünModel(this).FindÜrünItemWithName(ProductName)));
        }
    }
}