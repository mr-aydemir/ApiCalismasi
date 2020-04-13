using ForControllers.VatanArayüz;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VatanArayüz.Content;
using VatanArayüz.Controls;

namespace VatanArayüz
{
    /// <summary>
    /// Anasayfa.xaml etkileşim mantığı
    /// </summary>
    public partial class Anasayfa : Page
    {
        public List<SwiperItem> swiperItems = new List<SwiperItem>();
        string currentsenderbuttonname="sb0";
        private readonly DispatcherTimer timer
          = new DispatcherTimer(DispatcherPriority.Render);
        public Anasayfa()
        {
            InitializeComponent(); 
            AddProductButtons();
            SwiperItemGüncelle(); 
            SwipperImage.Source = new BitmapImage(new Uri("https://cdn.vatanbilgisayar.com/Upload/BANNER//yeni-tasarim/anasayfa/duyuru-web2-min.jpg"));
            timer.Tick += new EventHandler(AnasayfaIdle);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 3000);
            timer.IsEnabled = true;
            timer.Start(); 
        }
        void AddProductButtons()
        {
            var window = (MainWindow)Application.Current.MainWindow;
            foreach (var item in window.Products)
            {
                ProductButtons pb = new ProductButtons();
                ProductsButton2 productButtons2 = new ProductsButton2();
                ProductButton3 productButtons3 = new ProductButton3();
                pb.productName.Text =item.Name;
                if (item.Cost < item.PreviousCost)
                {
                    pb.ProductPreviousCost.Text = Convert.ToDecimal(item.PreviousCost).ToString();
                }
                else pb.ProductPreviousCost.Text = "";
                if (item.KargoFiyatı != 0)
                {
                    pb.KargoDurumuBelirteci.Visibility = Visibility.Hidden;
                }
                pb.productInfo.Text = item.Info;
                if (item.NumberInStock <= 20)
                {
                    pb.productCount.Text = "Son " + item.NumberInStock.ToString() + " Ürün";
                }
                else pb.OzelUrunBelirteci.Visibility = Visibility.Hidden;
                pb.productCost.Text = Convert.ToDecimal(item.Cost).ToString();
                pb.productImage.Source = new BitmapImage(new Uri(item.ImageUrl));
                pb.ProductButton.Tag = item.Id;
                pb.ProductButton.Click += Product_Click;
                UGFırsatUrunleri.Children.Add(pb);
                if (ugrid.Children.Count<=8)
                {


                    productButtons2.productName.Text = item.Name;
                    if (item.Cost < item.PreviousCost)
                    {
                        productButtons2.ProductPreviousCost.Text = Convert.ToDecimal(item.PreviousCost).ToString();
                    }
                    else productButtons2.ProductPreviousCost.Text = "";
                    if (item.KargoFiyatı != 0)
                    {
                        productButtons2.KargoDurumuBelirteci.Visibility = Visibility.Hidden;
                    }
                    productButtons2.productInfo.Text = item.Info;
                    if (item.NumberInStock <= 60)
                    {
                        productButtons2.productCount.Text = "Son " + item.NumberInStock.ToString() + " Ürün";
                    }
                    else productButtons2.OzelUrunBelirteci.Visibility = Visibility.Hidden;
                    productButtons2.productCost.Text = Convert.ToDecimal(item.Cost).ToString();
                    productButtons2.productImage.Source = new BitmapImage(new Uri(item.ImageUrl));
                    productButtons2.ProductButton.Tag = item.Id;
                    productButtons2.ProductButton.Click += Product_Click;
                    ugrid.Children.Add(productButtons2);
                }
                if (ugrid2.Children.Count<=10)
                {
                    productButtons3.productName.Text = item.Name;
                    productButtons3.productInfo.Text = item.Info;
                    productButtons3.productCost.Text = Convert.ToDecimal(item.Cost).ToString();
                    productButtons3.productImage.Source = new BitmapImage(new Uri(item.ImageUrl));
                    productButtons3.ProductButton.Tag = item.Id;
                    productButtons3.ProductButton.Click += Product_Click;
                    ugrid2.Children.Add(productButtons3);
                }
            }
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            int PId = Convert.ToInt32((sender as Button).Tag); 
            var window = (MainWindow)Application.Current.MainWindow;
            ÜrünSayfası ürünSayfası = new ÜrünSayfası();
            foreach (var item in window.Products)
            {
                if (PId == item.Id)
                {
                    ürünSayfası.productInfo.Text = item.Info;
                    ürünSayfası.productName.Content = item.Name;
                    ürünSayfası.swiperImage.Source = new BitmapImage(new Uri(item.ImageUrl));
                    ürünSayfası.productCost.Content = item.Cost.ToString();
                    ürünSayfası.MinTaksitTutarı.Text = (item.Cost / 12).ToString("C") + "TL";
                    ürünSayfası.productSayfaIsim.Content = item.Name;
                    break;
                }
            }
            window.Main.Content = ürünSayfası;
        }
        void AnasayfaIdle(object sender, EventArgs e)
        {
          ChangeImage();   
        }
        void ChangeImage()
        {
            int number = (Convert.ToInt32(currentsenderbuttonname.Substring(2)) + 1)%(swiperItems.Count);
            foreach (SwiperItem item in swiperItems)
            {
                bool a = Convert.ToInt32(item.Name.Substring(2)) == number;
                if (a)
                {
                    currentsenderbuttonname = item.Name;
                    SwipperImage.Source = new BitmapImage(new Uri(item.PicLink));
                }
            }
        }
        void SwiperItemGüncelle() 
        {
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

                Style st = FindResource("frstbutton") as Style;
                Button newBtn = new Button()
                {
                    Name = item.Name,
                    Tag = item.IconLink,
                    Style = st,
                    Content = new BitmapImage(new Uri(item.IconLink))
                };
                newBtn.MouseEnter += Frstbutton_MouseEnter;
                swiper.Children.Add(newBtn);

            }
        }
        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Frstbutton_MouseEnter(object sender, MouseEventArgs e)
        {
            Button buton = (sender as Button);
            currentsenderbuttonname = buton.Name;
            ChangeImage(currentsenderbuttonname);
        }
        void ChangeImage(string name)
        {
            foreach (SwiperItem item in swiperItems)
            {
                bool a = item.Name == name;
                if (a)
                {
                    currentsenderbuttonname = item.Name;
                    SwipperImage.Source = new BitmapImage(new Uri(item.PicLink));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ÜrünSayfası ürünSayfası = new ÜrünSayfası();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = ürünSayfası;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();

            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content= notebook_Sayfası;
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
                (child as UserControl).Width = w / 2 - 50;
            }
            foreach (UIElement child in ugrid2.Children)
            {
                (child as UserControl).Width = w / 5 - 43;
            }
        }
    }
}
