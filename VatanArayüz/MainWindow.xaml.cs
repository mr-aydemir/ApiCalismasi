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
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.currentFrame = Main;
            Main.Content = anasayfa;
        }
        public void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tamam");
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            m1.IsSubmenuOpen = true;
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
    } 
}
