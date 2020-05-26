using VatanBilgisayarMobil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Settings = VatanBilgisayarMobil.Helpers.Settings;
using VatanBilgisayarMobil.Helpers;

namespace VatanBilgisayarMobil.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;        
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {                  
                new HomeMenuItem {Id = MenuItemType.AnaSayfa, Title="Anasayfa", Icon="" },
                new HomeMenuItem {Id = MenuItemType.Telefon, Title="Telefon" , Icon="TellIcon" },
                new HomeMenuItem {Id = MenuItemType.Bilgisayar, Title="Bilgisayar", Icon="PCIcon" },
                new HomeMenuItem {Id = MenuItemType.Bilgisayar_Parcalari, Title="Bilgisayar Parçaları", Icon="PcPartIcon" },
                new HomeMenuItem {Id = MenuItemType.Kamera, Title="Kamera", Icon="RadioIcon"},
                new HomeMenuItem {Id = MenuItemType.TV_ve_Elektronigi, Title="TV ve Elektroniği", Icon="TVIcon" },
                new HomeMenuItem {Id = MenuItemType.Ofis, Title="Ofis", Icon="PrinterIcon"},
                new HomeMenuItem {Id = MenuItemType.Aksesuar, Title="Aksesuar", Icon="aksesuarlar" },
                new HomeMenuItem {Id = MenuItemType.Oyun_ve_Hobi, Title="Oyun ve Hobi", Icon="OyunHobiIcon" },
                new HomeMenuItem {Id = MenuItemType.EvAletleri, Title="Ev Aletleri", Icon="EvAletleri" },
                new HomeMenuItem {Id = MenuItemType.Spor_ve_Outdoor, Title="Spor ve Outdoor", Icon="" },
                new HomeMenuItem {Id = MenuItemType.Hakkımızda, Title="Hakkımızda", Icon="" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                ((ListView)sender).SelectedItem = null;
                await RootPage.NavigateFromMenu(id);
            };
        }
        private async void ÜyeOlButton_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(Convert.ToInt32(MenuItemType.ÜyeGirisi));
        }

        private async void Hesabım_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu(Convert.ToInt32(MenuItemType.Hesabım));
        }
    }
}