using System.Collections.Generic;
using VatanBilgisayarMobil.Models;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BilgisayarMenu : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }//buradan emin değilim
        List<HomeMenuItem> PCmenuItems;
        public BilgisayarMenu()
        {
            InitializeComponent();

            
            PCmenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Notebook, Title="Notebook" },
                new HomeMenuItem {Id = MenuItemType.Diğer, Title="Masaüstü Bilgisayar" },
                new HomeMenuItem {Id = MenuItemType.Diğer, Title="Tablerler" },
                new HomeMenuItem {Id = MenuItemType.Diğer, Title="Bilgisayar Bileşenleri" },
                new HomeMenuItem {Id = MenuItemType.Diğer, Title="Oyun Bilgisayarları" },
                new HomeMenuItem {Id = MenuItemType.Diğer, Title="Ekran Kartları" },
            };

            ListViewMenu.ItemsSource = PCmenuItems;

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;

                ListViewMenu.SelectedItem = null;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}