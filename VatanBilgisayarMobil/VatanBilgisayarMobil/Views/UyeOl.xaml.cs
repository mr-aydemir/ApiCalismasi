using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UyeOl : ContentPage
    {
        RestAPIForAccounts restAPIForAccounts = new RestAPIForAccounts();
        public UyeOl()
        {
            InitializeComponent();
        }

        private async void KayitOl_Clicked(object sender, EventArgs e)
        {
            var isSuccess = await restAPIForAccounts.Register(EmailLBL.Text, 
            PasswordLBL.Text, NameLBL.Text, LastNameLBL.Text, UserNameLBL.Text);
            if (isSuccess)
            Mesaj.Text = "Kayıt başarılı!";
            else
            Mesaj.Text = "Kayıt başarısız, lütfen tekrar deneyin! ";
        }
    }
}