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
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
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

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_2(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_3(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_4(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_5(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_6(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseEnter_7(object sender, MouseEventArgs e)
        {

        }
    }
}
