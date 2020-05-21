using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Giris : ContentPage
    {
        public Giris()
        {
            InitializeComponent();
        }

        private async void KayıtOl_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UyeOl());
        }

        private async void GirisYap_Clicked(object sender, EventArgs e)
        {
            RestAPIForAccounts restAPIForAccounts = new RestAPIForAccounts();

            await restAPIForAccounts.LoginAsync(Email.Text, Sifre.Text);
        }
    }
}