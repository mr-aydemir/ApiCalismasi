using System;
using System.Collections.Generic;
using System.Text;

namespace VatanBilgisayarMobil.Models
{
    public enum PCMenuItemType
    {
        Notebook,
        MasaustuPC,
        Tablet,
        PCBilesenler,
        OyunBilgisayarlari,
        EkranKartlari
    }
    public class PCMenuItem
    {
        public PCMenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
