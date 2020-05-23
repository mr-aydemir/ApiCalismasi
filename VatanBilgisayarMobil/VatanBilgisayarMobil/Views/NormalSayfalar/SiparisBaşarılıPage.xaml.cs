using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VatanBilgisayarMobil.Views.NormalSayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiparisBaşarılıPage : ContentPage
    {
        SepetIslemleri SepetIslemleri = new SepetIslemleri();
        public bool başarılıMı;
        public SiparisBaşarılıPage(bool başarı)
        {
            InitializeComponent();
            başarılıMı = başarı;
            BaşarıAction();


        }
        void BaşarıAction()
        {
            if (başarılıMı)
            {
                BaşarıDurumuLBL.Text = "Sipariş Başarıyla Gerçekleşti :)";
                BaşarıDurumuLBL.TextColor = Color.FromHex("#14C160");
                SepetIslemleri.SepetiBoşalt();
            }
            else
            {
                BaşarıDurumuLBL.Text = "Sipariş Başarısız :(";
                BaşarıDurumuLBL.TextColor = Color.Red;
            }
        }
    }
}