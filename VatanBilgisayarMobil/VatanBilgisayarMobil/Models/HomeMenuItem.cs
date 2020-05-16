using System;
using System.Collections.Generic;
using System.Text;

namespace VatanBilgisayarMobil.Models
{
    public enum MenuItemType
    {
        AnaSayfa,
        Telefon,
        Bilgisayar,
        Bilgisayar_Parcalari,
        Kamera,
        TV_ve_Elektronigi,
        Ofis,
        Aksesuar,
        Oyun_ve_Hobi,
        EvAletleri,
        Spor_ve_Outdoor,
        Hakkımızda
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
