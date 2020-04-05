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
        public MainWindow()
        {
            InitializeComponent();
            //Altaki kodlar sayfayı değiştirken kullanılması gereken kodlardır
            Anasayfa anasayfa = new Anasayfa()
            {
                currentFrame = Main
            };
            Main.Content = anasayfa;
        }
        public void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tamam");
        }       
        private void Next_Btn(object sender, RoutedEventArgs e)
        {
            if (this.Main.CanGoForward)
                Main.GoForward();
        }
        private void Back_Btn(object sender, RoutedEventArgs e)
        {
            if (this.Main.CanGoBack)
                Main.GoBack();
        }
        private void B0_Click(object sender, RoutedEventArgs e)
        {
            m0.IsSubmenuOpen = true;
        }
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            m1.IsSubmenuOpen = true;
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            m2.IsSubmenuOpen = true;
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            m3.IsSubmenuOpen = true;
        }
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            m4.IsSubmenuOpen = true;
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            m5.IsSubmenuOpen = true;
        }
        private void B6_Click(object sender, RoutedEventArgs e)
        {
            m6.IsSubmenuOpen = true;
        }
        private void B7_Click(object sender, RoutedEventArgs e)
        {
            m7.IsSubmenuOpen = true;
        }
        private void B8_Click(object sender, RoutedEventArgs e)
        {
            m8.IsSubmenuOpen = true;
        }
        private void B9_Click(object sender, RoutedEventArgs e)
        {
            m9.IsSubmenuOpen = true;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası() 
            {
                currentFrame = Main
            };
            Main.Content = notebook_Sayfası;
        }

        private void AnasayfayaDön_Click(object sender, RoutedEventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa()
            {
                currentFrame = Main
            };
            Main.Content = anasayfa;
        }
        private void Hakkımızda_Yönlendir(object sender, RoutedEventArgs e)
        {
            Hakkımızda anasayfa = new Hakkımızda()
            {
                currentFrame = Main
            };
            Main.Content = anasayfa;
        }
    } 
}
