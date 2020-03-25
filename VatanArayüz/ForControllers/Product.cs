using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForControllers.VatanArayüz
{
    public class Product
    {
        public string Name { get; set; }
        public string Url  { get; set; }
        public string Info { get; set; }
        public double Cost { get; set; }
        
        public Product(string name, string url, string info, double cost)
        {
            Name = name;
            Url  = url;
            Info = info;
            Cost = cost;
        }

    }
}
