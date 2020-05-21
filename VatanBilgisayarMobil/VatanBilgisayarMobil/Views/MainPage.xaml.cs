using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VatanBilgisayarMobil.Models;

namespace VatanBilgisayarMobil.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.AnaSayfa, (NavigationPage)Detail);
            
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {                  
                    case (int)MenuItemType.AnaSayfa:
                        PushPage(new Anasayfa());
                        break;
                    case (int)MenuItemType.Bilgisayar:
                        PushPage((new BilgisayarMenu()));
                        break;
                    case (int)MenuItemType.Hakkımızda:
                        PushPage((new AboutPage()));
                        break;
                    case (int)MenuItemType.Notebook:
                        PushPage((new NotebookPage()));
                        break;
                    case (int)MenuItemType.ÜyeGirisi:
                        PushPage(new Giris());
                        break;
                    default:
                        PushPage((new Sayfa()));
                        break;

                }
            }
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);

            IsPresented = false;
        }

        public async void PushPage(ContentPage page)
        {
            await ((NavigationPage)((MasterDetailPage)Application.Current.MainPage).Detail).CurrentPage.Navigation.PushAsync(page);

            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);

            IsPresented = false;
        }
    }
}