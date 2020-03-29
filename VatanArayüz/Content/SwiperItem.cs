using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForControllers;
using ForControllers.VatanArayüz;

namespace VatanArayüz.Content
{
    public class SwiperItem
    {
        public string Name;
        public string IconLink;
        public string PicLink;
        //public Category Category;
        
        public SwiperItem(string name, string  iconLink, string picLink)
        {
            Name = name;
            IconLink = iconLink;
            PicLink = picLink;
            //Category = category;
        }
    }
}
