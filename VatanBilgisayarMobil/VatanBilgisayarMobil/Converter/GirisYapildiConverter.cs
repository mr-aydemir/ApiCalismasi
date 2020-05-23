using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using VatanBilgisayarMobil.Helpers;
using VatanBilgisayarMobil.Models;
using Xamarin.Forms;
using Settings = VatanBilgisayarMobil.Helpers.Settings;

namespace VatanBilgisayarMobil.Converter
{
    public class GirisYapildiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UserSettings userSettings = new UserSettings();
            if (userSettings.GirisYapıldı == "true")
            {
                
                return true;
            }
            return false;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return System.Convert.ToInt32(value);
        }
    }
}
