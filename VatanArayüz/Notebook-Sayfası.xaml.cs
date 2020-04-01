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

namespace VatanArayüz
{
    /// <summary>
    /// Notebook_Sayfası.xaml etkileşim mantığı
    /// </summary>
    public partial class Notebook_Sayfası : Page
    {
        public Frame currentFrame;
        public Notebook_Sayfası()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ÜrünSayfası ürünSayfası = new ÜrünSayfası();
            ürünSayfası.currentFrame = currentFrame;
            currentFrame.Content = ürünSayfası;
        }
    }
}
