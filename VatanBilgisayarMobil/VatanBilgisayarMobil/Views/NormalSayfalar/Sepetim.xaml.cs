using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Helpers;
using VatanBilgisayarMobil.Models;
using VatanBilgisayarMobil.Services;
using VatanBilgisayarMobil.Views.NormalSayfalar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Settings = VatanBilgisayarMobil.Helpers.Settings;

namespace VatanBilgisayarMobil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sepetim : ContentPage
    {
        
        SepetIslemleri SepetIslemleri = new SepetIslemleri();
        public Sepetim()
        {
            InitializeComponent();
            Refresh();
        }
        private void Sepet_Action()
        {

            
            if (SepetIslemleri.GetSepet().Count == 0)
                BosSepet_Action();
            else DoluSepet_Action();
        }
        private void DoluSepet_Action()
        {
            if (BosSepet.IsVisible == true)
            {
                BosSepet.IsVisible = false;
                DoluSepet.IsVisible = true;
            }
        }
        private void BosSepet_Action()
        {
            if (BosSepet.IsVisible == false)
            {
                BosSepet.IsVisible = true;
                DoluSepet.IsVisible = false;
            }
        }
        private void Refresh()
        {
            OnPropertyChanged();
            SepettekilerFLV.ItemsSource = SepetIslemleri.GetSepet();
            TutarLBL.Text ="₺" + string.Format("{0:#,0.####}", SepetIslemleri.ToplamTutar());
            double KDV = SepetIslemleri.ToplamTutar() / 6.555;
            double AraToplam = SepetIslemleri.ToplamTutar() - KDV;
            AraToplamLBL.Text = "₺" + string.Format("{0:#,0.####}", AraToplam);
            KDVLBL.Text = "₺" + string.Format("{0:#,0.####}", KDV);
            Sepet_Action();
        }
        private void SepettenSil_Clicked(object sender, EventArgs e)
        {

            var tappedItem = (ImageButton)sender;
            StackLayout stackLayout = tappedItem.Parent as StackLayout;
            int SepetId = Convert.ToInt32((stackLayout.Children[0] as Label).Text);
            SepetIslemleri.SepettenSil(SepetId); 
            Refresh();
        }

        private void SptiBslt_Clicked(object sender, EventArgs e)
        {
            SepetIslemleri.SepetiBoşalt();
            Refresh();
        }

        private async void Tamamla_Clicked(object sender, EventArgs e)
        {
            bool response = true;
            int a = 0;
            RestAPIForAccounts restAPIForAccounts = new RestAPIForAccounts();
            var Siparisler = new List<Siparis>();
            foreach (var item in SepetIslemleri.GetSepet())
            {
                Siparis siparis = new Siparis()
                {
                    Adet = item.Adet,
                    ProductID = item.Id,
                    UserId = Convert.ToInt32(Settings.UserId),
                    SiparisTarihi = DateTime.Now
                };
                response = await restAPIForAccounts.PostSiparis(siparis);
                if (response == true)
                {
                    a++;
                }
                Siparisler.Add(siparis);
            }
            await Navigation.PushAsync(new SiparisBaşarılıPage(response));
        }

        private async void AlisveriseBasla_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}