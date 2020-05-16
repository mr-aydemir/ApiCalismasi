using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Essentials;
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
            ImageButton ImageButton = new ImageButton();
            ÜrünButonuModeli ürünButonuModeli;
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
            ürünButonuModeli = new ÜrünButonuModeli(this);
            BindingContext = ürünButonuModeli;
            FırsatÜrünleriCarousel.ItemsSource = FırsatÜrünleriImages;
            //ÖneÇıkanÜrünlerFLV.HeightRequest = Convert.ToDouble(ürünButonuModeli.Items.Count / ÖneÇıkanÜrünlerFLV.FlowColumnCount * 250); 
            
        }

        private void FırsatResmi_Tapped(object sender, EventArgs e)
        {
            
        }

        
    }
}