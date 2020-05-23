using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static VatanBilgisayarMobil.Data.RestAPIForProducts;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotebookPage : ContentPage
    {
        public NotebookPage()
        {
            InitializeComponent();
            ÖneÇıkanÜrünlerFLV.FlowItemsSource = new ÜrünModel(this).GetAllItems();
        }

        private async void ÜrünTapped(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Product;
            await Navigation.PushAsync(new ÜrünSayfasi(content));
        }
    }
}