using ForControllers.VatanArayüz;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace VatanArayüz
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> Products;
        public List<Category> Categories;
        public List<ImageModel> ImageModels;
        public MainWindow()
        {
            InitializeComponent();
            GetData();
            //Altaki kodlar sayfayı değiştirken kullanılması gereken kodlardır
            Anasayfa anasayfa = new Anasayfa();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = anasayfa;
        }
        private void GetData()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://sytronus.azurewebsites.net/")
            };
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/products").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                Products = items as List<Product>;
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

            response = client.GetAsync("api/categories").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                Categories = items as List<Category>;
            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            response = client.GetAsync("api/images").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<ImageModel>>().Result;
                ImageModels = items as List<ImageModel>;

            }
            else
            {
                MessageBox.Show("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            foreach (var item in Products)
            {
                foreach (var item2 in ImageModels)
                {
                    if (item2.ProductId == item.Id)
                    {
                        item.ImageUrl = item2.Url;
                        break;
                    }
                }
            }
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
            Notebook_Sayfası notebook_Sayfası = new Notebook_Sayfası();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = notebook_Sayfası;
        }

        private void AnasayfayaDön_Click(object sender, RoutedEventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = anasayfa;
        }
        private void Hakkımızda_Yönlendir(object sender, RoutedEventArgs e)
        {
            Hakkımızda anasayfa = new Hakkımızda();
            var window = (MainWindow)Application.Current.MainWindow;
            window.Main.Content = anasayfa;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
