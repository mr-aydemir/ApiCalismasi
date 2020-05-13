using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace VatanBilgisayarMobil.Models
{
    public class ÜrünItem
    {
        private string _image;
        public string ImageSource
        {
            get { return _image; }
            set { _image=value; }
        }
        private string _ürünİsmi;
        public string Ürünİsmi
        {
            get { return _ürünİsmi; }
            set { _ürünİsmi = value; }
        }
        private string _ürünDetayı;
        public string ÜrünDetayı
        {
            get { return _ürünDetayı; }
            set { _ürünDetayı = value; }
        }
        private string _ürünFiyatı;
        public string ÜrünFiyatı
        {
            get { return _ürünFiyatı; }
            set { _ürünFiyatı = value; }
        }
    }
}
