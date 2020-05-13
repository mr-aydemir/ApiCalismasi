using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VatanBilgisayarMobil.Services;
using VatanBilgisayarMobil.Views;

namespace VatanBilgisayarMobil
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
