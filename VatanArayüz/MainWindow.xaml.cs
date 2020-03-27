using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ForControllers;
using ForControllers.VatanArayüz;
using VatanArayüz.Content;

namespace VatanArayüz
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SwiperItem> swiperItems=new List<SwiperItem>();

        public MainWindow()
        {
            InitializeComponent();
            swiperItems.Add(new SwiperItem("sb0", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/kapali-thumb-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/duyuru-web2-min.jpg"));
            swiperItems.Add(new SwiperItem("sb1", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/cep7-thumb-min.png", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/cep-kamp-23-mart-web-min.jpg"));
            swiperItems.Add(new SwiperItem("sb2", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/sepet-yuzde-5-thumb-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/note-kdv-23-mart-web-reviz-min.jpg"));
            swiperItems.Add(new SwiperItem("sb3", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/gece-tv-thumb.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/tv-kamp-24-mart-web-revv-min.jpg"));
            swiperItems.Add(new SwiperItem("sb4", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/pc-mon-kamp-thumb-17-ocak-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/9mart/kamp-pc-mon-24-mart-web-revz-min.jpg"));
            swiperItems.Add(new SwiperItem("sb5", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/kea-28-ocak-thumb-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/kea-kampanya-25-varan-web-min.jpg"));
            swiperItems.Add(new SwiperItem("sb6", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/yazici-thumb-24-mart-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/yazici-super-24-mart-webz-min.jpg"));
            swiperItems.Add(new SwiperItem("sb7", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/maraton-thumb.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/phlipps-web-min.jpg"));
            swiperItems.Add(new SwiperItem("sb8", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/iphone-super-thumb-23-mart-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/iphone-super-fiyat-23-mart-web-min.jpg"));
            swiperItems.Add(new SwiperItem("sb9", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/tum-thumb-24-mart.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/apple-tum-24-mart-wb-min.png"));
            swiperItems.Add(new SwiperItem("sb10", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/sg-ilanlar-3-thumb-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/super-fiyat-air-24-mart-web-min.jpg"));
            swiperItems.Add(new SwiperItem("sb11", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/thumb/spor-thumb-17-mart-min.jpg", "https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/2020_Mart/bisiklet-super-17-mart-web-revize-min.jpg"));
            foreach (SwiperItem item in swiperItems)
            {
                Button newBtn = new Button();
                newBtn.Name = item.Name;
                newBtn.Tag = item.IconLink;
                Style st = FindResource("frstbutton") as Style;
                newBtn.Style = st;
                newBtn.Content = new BitmapImage(new Uri(item.IconLink));
                newBtn.MouseEnter += frstbutton_MouseEnter;
                swiper.Children.Add(newBtn);
                
            }

            
            SwipperImage.Source = new BitmapImage(new Uri("https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/duyuru-web2-min.jpg"));

        }
        
       public void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tamam");
        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {
           
        }

        private void frstbutton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button buton = (sender as Button);
            string butonname = buton.Name;
            foreach (SwiperItem item in swiperItems)
            {
                bool a = item.Name == butonname;
                if (a)
                {
                    SwipperImage.Source = new BitmapImage(new Uri(item.PicLink));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductPenceresi productPenceresi = new ProductPenceresi();
            productPenceresi.Show();
            this.Close();
        }

        private async Task SliderControlAsync(int location)
        {
            double maxw = sc2.ScrollableWidth, b = maxw / 4;
            double loc = location * b;
            if (loc< sc2.HorizontalOffset)
            {
                while (loc < sc2.HorizontalOffset)
                {
                    sc2.ScrollToHorizontalOffset(sc2.HorizontalOffset - 50);
                    await Task.Delay(10);
                }

                if (sc2.HorizontalOffset != loc)
                {
                    sc2.ScrollToHorizontalOffset(loc);
                }
            }
            else if (loc > sc2.HorizontalOffset)
            {
                while (loc > sc2.HorizontalOffset)
                {
                    sc2.ScrollToHorizontalOffset(sc2.HorizontalOffset + 50);
                    await Task.Delay(10);
                }

                if (sc2.HorizontalOffset != loc)
                {
                    sc2.ScrollToHorizontalOffset(loc);
                }
            }
            
        }
        private async void SliderButton_Click(object sender, RoutedEventArgs e)
        {
            int location = Convert.ToInt32((sender as Button).Content);
            await SliderControlAsync(location);
        }
    }
}
