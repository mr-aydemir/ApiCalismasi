using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VatanBilgisayarMobil.Services;
using VatanBilgisayarMobil.Views;
using DLToolkit.Forms.Controls;
using Xamarin.Essentials;
using System.Linq;
using VatanBilgisayarMobil.Helpers;

namespace VatanBilgisayarMobil
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent(); 
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var screenWidth = mainDisplayInfo.Width;
            var density = mainDisplayInfo.Density;
            var fullScreenWidth = screenWidth / density;
            var FırsatÜrünleriCarouselHeight = fullScreenWidth*0.54 ;
            Resources.Add("FullScreenWidth", fullScreenWidth);
            Resources.Add("FırsatÜrünleriCarouselHeight", FırsatÜrünleriCarouselHeight);
            FlowListView.Init();
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
