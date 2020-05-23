using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace VatanBilgisayarMobil.Helpers
{
    
    public class UserSettings
    {
        public string GirisYapıldı
        {
            get 
            { 
                return VatanBilgisayarMobil.Helpers.Settings.GirişYapıldı;
            }
            set 
            {
                
                VatanBilgisayarMobil.Helpers.Settings.GirişYapıldı = value;
                OnPropertyChanged();
            }
        }
       
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
