using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static VatanBilgisayarMobil.Data.RestAPIForProducts;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ÜrünSayfasi : ContentPage
    {
        Product ÜrünBilgileri;
        int adet;
        public ÜrünSayfasi(Product ürünItem)
        {
            InitializeComponent();
            ÜrünBilgileri = ürünItem;
            id.Text = ÜrünBilgileri.Id.ToString();
            Image.Source = ÜrünBilgileri.ImageSource;
            Name.Text = ÜrünBilgileri.Name;
            Detail.Text = ÜrünBilgileri.Info;
            Cost.Text = ÜrünBilgileri.Cost.ToString();
            Taksit.Text = (ÜrünBilgileri.Cost / 12).ToString()+"'den başlayan taksitlerle ";
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                adet = Convert.ToInt32((picker.ItemsSource[selectedIndex] as string)[0].ToString());        
            }
        }
    }
}