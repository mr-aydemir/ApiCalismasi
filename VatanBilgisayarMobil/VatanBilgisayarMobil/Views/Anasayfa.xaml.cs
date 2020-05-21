using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Services;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static VatanBilgisayarMobil.Data.RestAPIForProducts;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Anasayfa : ContentPage
    {
        public double screensize;
        ÜrünModel Ürünler;

        
        public Anasayfa()
        {
            InitializeComponent();
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
            Ürünler = new ÜrünModel(this);
            FırsatÜrünleriCarousel.ItemsSource = FırsatÜrünleriImages;
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = Ürünler.GetItems(10);
            BindableLayout.SetItemsSource(EnÇokSatanlarSB, Ürünler.GetItems(15));
            FırsatÜrünleriCarousel.ItemsSource = FırsatÜrünleriImages;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{0}", Color.Red, Color.White)
                    );
                return true; // True = Repeat again, False = Stop the timer
            });
            //ÖneÇıkanÜrünlerFLV.HeightRequest = Convert.ToDouble(ürünButonuModeli.Items.Count / ÖneÇıkanÜrünlerFLV.FlowColumnCount * 250); 
        }


        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }

        private async void ÜrünTapped2(object sender, EventArgs e)
        {
            var tappedItem = (StackLayout)sender;
            string ProductId = (tappedItem.Children[0] as Label).Text;
            await Navigation.PushAsync(new ÜrünSayfasi(Ürünler.FindÜrünItemWithId(ProductId)));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sepetim());
        }

        private async void TümünnüGöster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotebookPage());
        }
        private async Task Stepper_ValueChangedAsync(object sender, ValueChangedEventArgs e)
        {
            if (ToolbarItems.Count > 0)
            {
                await Task.Delay(100);
                DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), $"{e.NewValue}", Color.Red, Color.White);
            }
        }
    }
}