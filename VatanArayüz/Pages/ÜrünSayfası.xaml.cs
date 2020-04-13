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
        public List<SwiperItem> swiperItems = new List<SwiperItem>();
        public int productId;
        public ÜrünSayfası()
        {
            InitializeComponent();         
        }
        public void Swipperaction() 
        {
            swiperItems.Add(new SwiperItem("sb0", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-5_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-5_large.jpg"));
            swiperItems.Add(new SwiperItem("sb1", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-6_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-6_large.jpg"));
            swiperItems.Add(new SwiperItem("sb2", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-7_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-7_large.jpg"));
            swiperItems.Add(new SwiperItem("sb3", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-8_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-8_large.jpg"));
            swiperItems.Add(new SwiperItem("sb4", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-9_small.jpg", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/HP/thumb/TeoriV2-103918-9_large.jpg"));
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
            swiperImage.Source = new BitmapImage(new Uri(swiperItems.First<SwiperItem>().PicLink));
            swiperImage.Tag = swiperItems.First<SwiperItem>().Name;
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
                    swiperImage.Tag = item.Name;
                }
            }
        }

        private void Notebook_Yönlendir(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = notebook_Sayfası;
        }
        private void Laptop_Yönlendir(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            notebook_Sayfası.başlık.Content = "Laptop";
            notebook_Sayfası.kategoribilgi.Text = "";
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = notebook_Sayfası;

        }
        private void PreviousPhoto(object sender, RoutedEventArgs e)
        {
            /*string currentPhotoName = swiperImage.Tag.ToString();
            int b = (Convert.ToInt32(currentPhotoName.Substring(2)) - 1)%swiperItems.Count;
            if (b==-1)
            {
                b = swiperItems.Count - 1;
            }
            currentPhotoName = "sb" + b.ToString();
            foreach (SwiperItem item in swiperItems)
            {
                if (currentPhotoName==item.Name)
                {
                    swiperImage.Source = new BitmapImage(new Uri(item.PicLink));
                    swiperImage.Tag = item.Name;
                }
            }*/

        }
        private void NextPhoto(object sender, RoutedEventArgs e)
        {
            /*string currentPhotoName = swiperImage.Tag.ToString();
            int b = (Convert.ToInt32(currentPhotoName.Substring(2)) + 1) % swiperItems.Count;
            currentPhotoName = "sb" + b.ToString();
            foreach (SwiperItem item in swiperItems)
            {
                if (currentPhotoName == item.Name)
                {
                    swiperImage.Source = new BitmapImage(new Uri(item.PicLink));
                    swiperImage.Tag = item.Name;
                }
            }*/
        }
    }
   
}
