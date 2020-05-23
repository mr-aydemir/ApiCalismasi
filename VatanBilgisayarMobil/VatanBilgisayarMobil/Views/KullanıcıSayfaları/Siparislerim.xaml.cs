using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VatanBilgisayarMobil.Helpers;
using VatanBilgisayarMobil.Data;
using VatanBilgisayarMobil.ViewModels;

namespace VatanBilgisayarMobil.Views.KullanıcıSayfaları
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Siparislerim : ContentPage
    {
        ÜrünModel ÜrünModel;
        public Siparislerim()
        {
            InitializeComponent();
            ÜrünModel = new ÜrünModel(this);
            RestAPIForAccounts restAPIForAccounts = new RestAPIForAccounts();
            SiparislerFLV.ItemsSource = restAPIForAccounts.GetSiparisler(Settings.Email);
        }

        private async void Detay_Tapped(object sender, EventArgs e)
        {
            var tappedItem = (Label)sender;
            string ProductId = ((tappedItem.Parent as StackLayout).Children[0] as Label).Text;
            await Navigation.PushAsync(new ÜrünSayfasi(ÜrünModel.FindÜrünItemWithId(ProductId)));
        }
    }
}