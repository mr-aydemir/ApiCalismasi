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
using System.Windows.Shapes;
using VatanArayüz.Content;

namespace VatanArayüz
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        List<SwiperItem> swiperItems = new List<SwiperItem>();
        public Window1()
        {
            InitializeComponent();
        }
        public void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tamam");
        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            m1.IsSubmenuOpen = true;
        }
    }
}
