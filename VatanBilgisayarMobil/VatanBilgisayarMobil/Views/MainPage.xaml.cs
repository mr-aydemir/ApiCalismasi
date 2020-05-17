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
                           MenuPages.Add(id, new NavigationPage(new Anasayfa()));
                        break;
                    case (int)MenuItemType.Telefon:
                        MenuPages.Add(id, new NavigationPage(new ÜrünSayfasi()));
                        break;
                    case (int)MenuItemType.Bilgisayar:
                        MenuPages.Add(id, new NavigationPage(new BilgisayarMenu()));
                        break;
                    case (int)MenuItemType.Bilgisayar_Parcalari:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Kamera:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.TV_ve_Elektronigi:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Ofis:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Aksesuar:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Oyun_ve_Hobi:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.EvAletleri:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Spor_ve_Outdoor:
                        MenuPages.Add(id, new NavigationPage(new Sayfa()));
                        break;
                    case (int)MenuItemType.Hakkımızda:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}