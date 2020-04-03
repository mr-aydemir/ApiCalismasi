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
using VatanArayüz.Content;

namespace VatanArayüz
{
    /// <summary>
    /// ÜrünSayfası.xaml etkileşim mantığı
    /// </summary>
    public partial class ÜrünSayfası : Page
    {
        List<SwiperItem> swiperItems = new List<SwiperItem>();
        public Frame currentFrame;
        public ÜrünSayfası()
        {
            InitializeComponent();
            swiperItems.Add(new SwiperItem("sb0", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-5_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-5_large.jpg"));
            swiperItems.Add(new SwiperItem("sb1", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-6_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-6_large.jpg"));
            swiperItems.Add(new SwiperItem("sb2", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-7_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-7_large.jpg"));
            swiperItems.Add(new SwiperItem("sb3", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-8_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-8_large.jpg"));
            swiperItems.Add(new SwiperItem("sb4", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-9_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-9_large.jpg"));
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
            swiperImage.Source = new BitmapImage(new Uri("https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-5_large.jpg"));
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
                    swiperImage.Source = new BitmapImage(new Uri(item.PicLink));
                }
            }
        }

        private void Notebook_Yönlendir(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            notebook_Sayfası.currentFrame = currentFrame;
            currentFrame.Content = notebook_Sayfası;
        }
        private void Laptop_Yönlendir(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            notebook_Sayfası.başlık.Content = "Laptop";
            notebook_Sayfası.kategoribilgi.Content = "";
            notebook_Sayfası.currentFrame = currentFrame;
            currentFrame.Content = notebook_Sayfası;

        }
    }
   
}
