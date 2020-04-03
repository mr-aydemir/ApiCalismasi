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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VatanArayüz.Content;

namespace VatanArayüz
{
    /// <summary>
    /// Anasayfa.xaml etkileşim mantığı
    /// </summary>
    public partial class Anasayfa : Page
    {
        public List<SwiperItem> swiperItems = new List<SwiperItem>();
        public Frame currentFrame;
        public Anasayfa()
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
                newBtn.MouseEnter += Frstbutton_MouseEnter;
                swiper.Children.Add(newBtn);

            }
            SwipperImage.Source = new BitmapImage(new Uri("https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/duyuru-web2-min.jpg"));
            butonA.Width = this.Width/2-20;
        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Frstbutton_MouseEnter(object sender, MouseEventArgs e)
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
            ÜrünSayfası ürünSayfası = new ÜrünSayfası();
            ürünSayfası.currentFrame = currentFrame;
            currentFrame.Content = ürünSayfası;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            notebook_Sayfası.currentFrame = currentFrame;
            currentFrame.Content = notebook_Sayfası;
        }


        private async void SliderButton_Click(object sender, RoutedEventArgs e)
        {
            int location = Convert.ToInt32((sender as Button).Content);
            await SliderControlAsync(location,4,sc2);
        }
        private async void SliderButton_Click2(object sender, RoutedEventArgs e)
        {
            int location = Convert.ToInt32((sender as Button).Content);
            await SliderControlAsync(location,2,sc3);
        }
        private async void SliderButton_Click3(object sender, RoutedEventArgs e)
        {
            double back_next_scrollable_windth = sc3.ScrollableWidth /10;
            double location= sc3.HorizontalOffset / back_next_scrollable_windth;
            int butonnumber = Convert.ToInt32((sender as Button).Content);
            if (location>=0)
            {
                if (butonnumber == 0)
                {
                    location--;
                }
                else if (butonnumber == 1)
                {
                    location++;
                }
                await SliderControlAsync(location, 10, sc3);
            }
        }
        private async Task SliderControlAsync(double location, int numberOfButton, ScrollViewer scrollViewer)
        {
            double maxw = scrollViewer.ScrollableWidth, b = maxw / (numberOfButton-1);
            double loc = location * b;
            if (loc < scrollViewer.HorizontalOffset)
            {
                while (loc < scrollViewer.HorizontalOffset)
                {
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 50);
                    await Task.Delay(10);
                }

                if (scrollViewer.HorizontalOffset != loc)
                {
                    scrollViewer.ScrollToHorizontalOffset(loc);
                }
            }
            else if (loc > scrollViewer.HorizontalOffset)
            {
                while (loc > scrollViewer.HorizontalOffset)
                {
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 50);
                    await Task.Delay(10);
                }

                if (scrollViewer.HorizontalOffset != loc)
                {
                    scrollViewer.ScrollToHorizontalOffset(loc);
                }
            }

        }

        private void Button_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var w = ((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth;
            foreach (UIElement child in ugrid.Children)
            {
                (child as Button).Width = w / 2 - 50;
            }
            foreach (UIElement child in ugrid2.Children)
            {
                (child as Button).Width = w / 5 - 43;
            }
        }
    }
}
