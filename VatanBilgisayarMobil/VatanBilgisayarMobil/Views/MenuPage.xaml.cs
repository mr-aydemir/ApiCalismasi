using VatanBilgisayarMobil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                new HomeMenuItem {Id = MenuItemType.AnaSayfa, Title="Anasayfa" },
                new HomeMenuItem {Id = MenuItemType.Telefon, Title="Telefon" },
                new HomeMenuItem {Id = MenuItemType.Bilgisayar, Title="Bilgisayar" },
                new HomeMenuItem {Id = MenuItemType.Bilgisayar_Parcalari, Title="Bilgisayar Parçaları" },
                new HomeMenuItem {Id = MenuItemType.Kamera, Title="Kamera" },
                new HomeMenuItem {Id = MenuItemType.TV_ve_Elektronigi, Title="TV ve Elektroniği" },
                new HomeMenuItem {Id = MenuItemType.Ofis, Title="Ofis" },
                new HomeMenuItem {Id = MenuItemType.Aksesuar, Title="Aksesuar" },
                new HomeMenuItem {Id = MenuItemType.Oyun_ve_Hobi, Title="Oyun ve Hobi" },
                new HomeMenuItem {Id = MenuItemType.EvAletleri, Title="Ev Aletleri" },
                new HomeMenuItem {Id = MenuItemType.Spor_ve_Outdoor, Title="Spor ve Outdoor" },
                new HomeMenuItem {Id = MenuItemType.Hakkımızda, Title="Hakkımızda" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}