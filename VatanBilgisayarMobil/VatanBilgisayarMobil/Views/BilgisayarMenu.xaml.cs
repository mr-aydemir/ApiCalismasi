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
        List<PCMenuItem> PCmenuItems;
        public BilgisayarMenu()
        {
            InitializeComponent();

            PCmenuItems = new List<PCMenuItem>
            {
                new PCMenuItem {Id = PCMenuItemType.Notebook, Title="Notebook" },
                new PCMenuItem {Id = PCMenuItemType.MasaustuPC, Title="Masaüstü Bilgisayar" },
                new PCMenuItem {Id = PCMenuItemType.Tablet, Title="Tablerler" },
                new PCMenuItem {Id = PCMenuItemType.PCBilesenler, Title="Bilgisayar Bileşenleri" },
                new PCMenuItem {Id = PCMenuItemType.OyunBilgisayarlari, Title="Oyun Bilgisayarları" },
                new PCMenuItem {Id = PCMenuItemType.EkranKartlari, Title="Ekran Kartları" },
            };

            ListViewMenu.ItemsSource = PCmenuItems;

            ListViewMenu.SelectedItem = PCmenuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((PCMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}