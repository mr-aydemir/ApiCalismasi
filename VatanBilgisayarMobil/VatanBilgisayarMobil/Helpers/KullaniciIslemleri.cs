using System;
using System.Collections.Generic;
using System.Text;

using Settings = VatanBilgisayarMobil.Helpers.Settings;
namespace VatanBilgisayarMobil.Helpers
{
    public class KullaniciIslemleri
    {
        public void ÇıkışYap()
        {
            Settings.GirişYapıldı = "false";
            Settings.Email = "";
            Settings.AccessToken = "";
            Settings.Password = "";
        }
    }
}
