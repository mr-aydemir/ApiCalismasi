using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Helpers;
using VatanBilgisayarMobil.Views.KullanıcıSayfaları;

namespace VatanBilgisayarMobil.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        KullaniciIslemleri KullaniciIslemleri = new KullaniciIslemleri();
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
                        PushPage(MenuItemType.AnaSayfa,new Anasayfa());
                        break;
                    case (int)MenuItemType.Bilgisayar:
                        PushPage(MenuItemType.Bilgisayar,(new BilgisayarMenu()));
                        break;
                    case (int)MenuItemType.Hakkımızda:
                        PushPage(MenuItemType.Hakkımızda,(new AboutPage()));
                        break;
                    case (int)MenuItemType.Notebook:
                        PushPage(MenuItemType.Notebook,(new NotebookPage()));
                        break;
                    case (int)MenuItemType.ÜyeGirisi:
                        PushPage(MenuItemType.ÜyeGirisi,new Giris());
                        break;
                    case (int)MenuItemType.Hesabım:
                        PushPage(MenuItemType.Hesabım, new Hesabım());
                        break;
                    case (int)MenuItemType.ÜyelikBilgileri:
                        PushPage(MenuItemType.ÜyelikBilgileri, new ÜyelikBilgileri());
                        break;
                    case (int)MenuItemType.Siparişler:
                        PushPage(MenuItemType.ÜyelikBilgileri, new Siparislerim());
                        break;
                    case (int)MenuItemType.ÇıkışYap:
                        KullaniciIslemleri.ÇıkışYap();
                        PushPage(MenuItemType.ÇıkışYap, new Anasayfa());
                        break;
                    default:
                        PushPage(MenuItemType.Diğer, (new Sayfa()));
                        break;

                }
            }
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);

            IsPresented = false;
        }
        public void NavigateTo(ContentPage TargetPage)
        {
            this.Master = TargetPage;
            //this.Title = TargetPage.Title;
            //this.IsPresented = false;
        }
        public async void PushPage(MenuItemType menuItemType,ContentPage page)
        {
            if (menuItemType== MenuItemType.ÇıkışYap)
            {
                await ((NavigationPage)((MasterDetailPage)Application.Current.MainPage).Detail).CurrentPage.Navigation.PopAsync();
            }
            else
            await ((NavigationPage)((MasterDetailPage)Application.Current.MainPage).Detail).CurrentPage.Navigation.PushAsync(page);

            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);

            IsPresented = false;
        }
    }
}