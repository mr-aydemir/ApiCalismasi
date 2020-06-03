using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VatanBilgisayarMobil.Models
{
    public class RadioButtonsModel
    {
        public ERadioButtonProperty Property { get; set; }
        public string TextString { get; set; }
    }
    public enum ERadioButtonProperty : byte
    {
        [Description("Azalan")]
        Azalan = 1,

        [Description("Artan")]
        Artan = 2
    }
}
