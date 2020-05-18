using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}