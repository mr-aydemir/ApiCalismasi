using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ÜyelikBilgileri : ContentPage
    {
        public ÜyelikBilgileri()
        {
            InitializeComponent();
            Ad.Text = Settings.Name;
            Soyad.Text = Settings.LastName;
            Email.Text = Settings.Email;
            CepTLF.Text = Settings.UserId;
            Cinsiyet.Text = Settings.UserName;
        }

        private void KAYDET_Clicked(object sender, EventArgs e)
        {

        }

        private async void İPTAL_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}